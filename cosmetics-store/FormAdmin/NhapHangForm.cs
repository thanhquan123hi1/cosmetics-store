using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace cosmetics_store.Forms
{
    public partial class NhapHangForm : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;
        private List<CT_PhieuNhapTemp> _chiTietMoi = new List<CT_PhieuNhapTemp>();

        public NhapHangForm()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += NhapHangForm_Load;
        }

        private void NhapHangForm_Load(object sender, EventArgs e)
        {
            EnsureDefaultSuppliers();
            LoadNhaCungCap();
            LoadSanPham();
            LoadPhieuNhapHistory();
            SetupGridChiTietMoi();
            dateNgayNhap.EditValue = DateTime.Now;
            dateHanSD.EditValue = DateTime.Now.AddYears(2);
        }

        private readonly (string Name, string Address, string Phone)[] _defaultSuppliers = new[]
        {
            ("Amorepacific Việt Nam", "TP. Hồ Chí Minh", ""),
            ("Công ty TNHH Mediheal Việt Nam", "TP. Hồ Chí Minh", ""),
            ("Chanel Việt Nam", "TP. Hồ Chí Minh", ""),
            ("Christian Dior Vietnam", "Hà Nội", ""),
            ("Shopee Mall Ofelia", "TP. Hồ Chí Minh", "")
        };

        private void EnsureDefaultSuppliers()
        {
            bool hasChanges = false;

            foreach (var supplier in _defaultSuppliers)
            {
                if (!_context.NhaCungCaps.Any(n => n.TenNCC == supplier.Name))
                {
                    _context.NhaCungCaps.Add(new NhaCungCap
                    {
                        TenNCC = supplier.Name,
                        DiaChi = supplier.Address,
                        SDT = supplier.Phone
                    });
                    hasChanges = true;
                }
            }

            if (hasChanges)
            {
                _context.SaveChanges();
            }
        }

        private void LoadNhaCungCap()
        {
            try
            {
                var nccList = _context.NhaCungCaps
                    .Select(n => new { n.MaNCC, n.TenNCC })
                    .ToList();

                lookupNCC.Properties.DataSource = nccList;
                lookupNCC.Properties.DisplayMember = "TenNCC";
                lookupNCC.Properties.ValueMember = "MaNCC";
                lookupNCC.Properties.Columns.Clear();
                lookupNCC.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNCC", "Nhà cung cấp"));
                lookupNCC.Properties.NullText = "-- Chọn NCC --";
            }
            catch { }
        }

        private void LoadSanPham()
        {
            try
            {
                var spList = _context.SanPhams
                    .Select(sp => new { sp.MaSP, sp.TenSP, sp.DonGia })
                    .ToList();

                lookupSPMoi.Properties.DataSource = spList;
                lookupSPMoi.Properties.DisplayMember = "TenSP";
                lookupSPMoi.Properties.ValueMember = "MaSP";
                lookupSPMoi.Properties.Columns.Clear();
                lookupSPMoi.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaSP", "Mã SP", 60));
                lookupSPMoi.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenSP", "Tên sản phẩm", 200));
                lookupSPMoi.Properties.NullText = "-- Chọn sản phẩm --";

                lookupSPMoi.EditValueChanged += (s, ev) =>
                {
                    var row = lookupSPMoi.GetSelectedDataRow();
                    if (row != null)
                    {
                        spinDonGia.Value = Convert.ToDecimal(((dynamic)row).DonGia);
                    }
                };
            }
            catch { }
        }

        private void SetupGridChiTietMoi()
        {
            gridViewChiTietMoi.Columns.Clear();
            gridViewChiTietMoi.Columns.AddVisible("TenSP", "Tên sản phẩm");
            gridViewChiTietMoi.Columns.AddVisible("SoLuong", "Số lượng");
            gridViewChiTietMoi.Columns.AddVisible("DonGiaNhap", "Đơn giá");
            gridViewChiTietMoi.Columns.AddVisible("ThanhTien", "Thành tiền");

            gridViewChiTietMoi.Columns["DonGiaNhap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewChiTietMoi.Columns["DonGiaNhap"].DisplayFormat.FormatString = "#,##0 đ";
            gridViewChiTietMoi.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewChiTietMoi.Columns["ThanhTien"].DisplayFormat.FormatString = "#,##0 đ";
        }

        private void LoadPhieuNhapHistory()
        {
            try
            {
                var phieuNhaps = _context.PhieuNhaps
                    .Include(p => p.NhaCungCap)
                    .OrderByDescending(p => p.NgayNhap)
                    .Select(p => new
                    {
                        p.MaPN,
                        p.NgayNhap,
                        TenNCC = p.NhaCungCap.TenNCC
                    })
                    .Take(50)
                    .ToList();

                gridMaster.DataSource = phieuNhaps;

                gridViewMaster.Columns.Clear();
                gridViewMaster.Columns.AddVisible("MaPN", "Mã PN");
                gridViewMaster.Columns.AddVisible("NgayNhap", "Ngày nhập");
                gridViewMaster.Columns.AddVisible("TenNCC", "Nhà cung cấp");

                gridViewMaster.Columns["NgayNhap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewMaster.Columns["NgayNhap"].DisplayFormat.FormatString = "dd/MM/yyyy";
            }
            catch { }
        }

        private void gridViewMaster_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                var maPN = gridViewMaster.GetFocusedRowCellValue("MaPN");
                if (maPN != null)
                {
                    LoadChiTietPhieuNhap(Convert.ToInt32(maPN));
                }
            }
        }

        private void LoadChiTietPhieuNhap(int maPN)
        {
            try
            {
                var chiTiet = _context.CT_PhieuNhaps
                    .Include(ct => ct.SanPham)
                    .Where(ct => ct.MaPN == maPN)
                    .Select(ct => new
                    {
                        TenSP = ct.SanPham.TenSP,
                        ct.SoLuong,
                        ct.DonGiaNhap,
                        ThanhTien = ct.SoLuong * ct.DonGiaNhap,
                        ct.HanSuDung
                    })
                    .ToList();

                gridDetail.DataSource = chiTiet;

                gridViewDetail.Columns.Clear();
                gridViewDetail.Columns.AddVisible("TenSP", "Tên sản phẩm");
                gridViewDetail.Columns.AddVisible("SoLuong", "Số lượng");
                gridViewDetail.Columns.AddVisible("DonGiaNhap", "Đơn giá");
                gridViewDetail.Columns.AddVisible("ThanhTien", "Thành tiền");
                gridViewDetail.Columns.AddVisible("HanSuDung", "Hạn SD");

                gridViewDetail.Columns["DonGiaNhap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewDetail.Columns["DonGiaNhap"].DisplayFormat.FormatString = "#,##0 đ";
                gridViewDetail.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewDetail.Columns["ThanhTien"].DisplayFormat.FormatString = "#,##0 đ";
            }
            catch { }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (lookupSPMoi.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (spinSoLuong.Value <= 0)
            {
                XtraMessageBox.Show("Số lượng phải > 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (spinDonGia.Value <= 0)
            {
                XtraMessageBox.Show("Đơn giá phải > 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maSP = Convert.ToInt32(lookupSPMoi.EditValue);
            var row = lookupSPMoi.GetSelectedDataRow();
            string tenSP = ((dynamic)row).TenSP;

            // Kiểm tra đã tồn tại chưa
            var existing = _chiTietMoi.FirstOrDefault(ct => ct.MaSP == maSP);
            if (existing != null)
            {
                existing.SoLuong += Convert.ToInt32(spinSoLuong.Value);
                existing.ThanhTien = existing.SoLuong * existing.DonGiaNhap;
            }
            else
            {
                _chiTietMoi.Add(new CT_PhieuNhapTemp
                {
                    MaSP = maSP,
                    TenSP = tenSP,
                    SoLuong = Convert.ToInt32(spinSoLuong.Value),
                    DonGiaNhap = spinDonGia.Value,
                    ThanhTien = spinSoLuong.Value * spinDonGia.Value,
                    HanSuDung = Convert.ToDateTime(dateHanSD.EditValue)
                });
            }

            RefreshGridChiTietMoi();

            // Reset
            lookupSPMoi.EditValue = null;
            spinSoLuong.Value = 1;
            spinDonGia.Value = 0;
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (gridViewChiTietMoi.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maSP = gridViewChiTietMoi.GetFocusedRowCellValue("MaSP");
            if (maSP != null)
            {
                _chiTietMoi.RemoveAll(ct => ct.MaSP == Convert.ToInt32(maSP));
                RefreshGridChiTietMoi();
            }
        }

        private void RefreshGridChiTietMoi()
        {
            gridChiTietMoi.DataSource = null;
            gridChiTietMoi.DataSource = _chiTietMoi;
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            if (lookupNCC.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn nhà cung cấp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_chiTietMoi.Count == 0)
            {
                XtraMessageBox.Show("Vui lòng thêm ít nhất 1 sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tính tổng tiền
                decimal tongTien = _chiTietMoi.Sum(ct => ct.ThanhTien);

                // Tạo phiếu nhập
                var phieuNhap = new PhieuNhap
                {
                    MaNCC = Convert.ToInt32(lookupNCC.EditValue),
                    NgayNhap = Convert.ToDateTime(dateNgayNhap.EditValue)
                };

                _context.PhieuNhaps.Add(phieuNhap);
                _context.SaveChanges();

                // Tạo chi tiết và cập nhật tồn kho
                int stt = 1;
                foreach (var ct in _chiTietMoi)
                {
                    var chiTiet = new CT_PhieuNhap
                    {
                        MaPN = phieuNhap.MaPN,
                        MaSP = ct.MaSP,
                        STT = stt++,
                        SoLuong = ct.SoLuong,
                        DonGiaNhap = ct.DonGiaNhap,
                        HanSuDung = ct.HanSuDung
                    };
                    _context.CT_PhieuNhaps.Add(chiTiet);

                    // Cập nhật tồn kho
                    var sanPham = _context.SanPhams.Find(ct.MaSP);
                    if (sanPham != null)
                    {
                        sanPham.SoLuongTon += ct.SoLuong;
                    }
                }

                _context.SaveChanges();

                // Log
                var log = new AuditLog
                {
                    ThoiGian = DateTime.Now,
                    HanhDong = "CREATE_PhieuNhap",
                    MaBanGhi = phieuNhap.MaPN.ToString(),
                    DuLieuMoi = $"Phiếu nhập #{phieuNhap.MaPN}, Tổng: {tongTien:N0}đ",
                    MaNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : (int?)null
                };
                _context.AuditLogs.Add(log);
                _context.SaveChanges();

                XtraMessageBox.Show($"Tạo phiếu nhập #{phieuNhap.MaPN} thành công!\nTổng tiền: {tongTien:N0} đ",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset
                _chiTietMoi.Clear();
                RefreshGridChiTietMoi();
                lookupNCC.EditValue = null;
                LoadPhieuNhapHistory();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tạo phiếu nhập: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblDonGia_Click(object sender, EventArgs e)
        {

        }
    }

    // Class tạm để lưu chi tiết phiếu nhập mới
    public class CT_PhieuNhapTemp
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal ThanhTien { get; set; }
        public DateTime HanSuDung { get; set; }
    }
}
