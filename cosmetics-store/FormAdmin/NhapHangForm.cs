using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
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

        // UI Colors
        private readonly Color _primaryColor = Color.FromArgb(52, 73, 94);
        private readonly Color _successColor = Color.FromArgb(39, 174, 96);
        private readonly Color _warningColor = Color.FromArgb(243, 156, 18);
        private readonly Color _dangerColor = Color.FromArgb(231, 76, 60);
        private readonly Color _infoColor = Color.FromArgb(52, 152, 219);

        public NhapHangForm()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += NhapHangForm_Load;
        }

        private void NhapHangForm_Load(object sender, EventArgs e)
        {
            SetupUI();
            LoadNhaCungCap();
            LoadSanPham();
            LoadPhieuNhapHistory();
            SetupGridChiTietMoi();
            dateNgayNhap.EditValue = DateTime.Now;
            dateHanSD.EditValue = DateTime.Now.AddYears(2);
            UpdateTongTien();
        }

        private void SetupUI()
        {
            this.Text = "📦 NHẬP HÀNG TỪ NHÀ CUNG CẤP";
            this.BackColor = Color.FromArgb(245, 246, 250);
        }

        private void LoadNhaCungCap()
        {
            try
            {
                var nccList = _context.NhaCungCaps
                    .Select(n => new { n.MaNCC, n.TenNCC, n.SDT })
                    .OrderBy(n => n.TenNCC)
                    .ToList();

                lookupNCC.Properties.DataSource = nccList;
                lookupNCC.Properties.DisplayMember = "TenNCC";
                lookupNCC.Properties.ValueMember = "MaNCC";
                lookupNCC.Properties.Columns.Clear();
                lookupNCC.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNCC", "Nhà cung cấp", 200));
                lookupNCC.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SDT", "SĐT", 100));
                lookupNCC.Properties.NullText = "-- Chọn nhà cung cấp --";
                lookupNCC.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tải NCC: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSanPham()
        {
            try
            {
                var spList = _context.SanPhams
                    .Include(sp => sp.LoaiSP)
                    .Include(sp => sp.ThuongHieu)
                    .Select(sp => new { 
                        sp.MaSP, 
                        sp.TenSP, 
                        sp.DonGia,
                        sp.SoLuongTon,
                        TenLoai = sp.LoaiSP.TenLoai,
                        ThuongHieu = sp.ThuongHieu.TenThuongHieu
                    })
                    .OrderBy(sp => sp.TenSP)
                    .ToList();

                lookupSPMoi.Properties.DataSource = spList;
                lookupSPMoi.Properties.DisplayMember = "TenSP";
                lookupSPMoi.Properties.ValueMember = "MaSP";
                lookupSPMoi.Properties.Columns.Clear();
                lookupSPMoi.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaSP", "Mã", 50));
                lookupSPMoi.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenSP", "Tên sản phẩm", 180));
                lookupSPMoi.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ThuongHieu", "Thương hiệu", 100));
                lookupSPMoi.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SoLuongTon", "Tồn", 50));
                lookupSPMoi.Properties.NullText = "-- Chọn sản phẩm --";
                lookupSPMoi.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;

                lookupSPMoi.EditValueChanged += (s, ev) =>
                {
                    var row = lookupSPMoi.GetSelectedDataRow();
                    if (row != null)
                    {
                        // Đề xuất giá nhập = 70% giá bán
                        decimal giaBan = Convert.ToDecimal(((dynamic)row).DonGia);
                        spinDonGia.Value = Math.Round(giaBan * 0.7m, 0);
                    }
                };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tải SP: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupGridChiTietMoi()
        {
            gridViewChiTietMoi.Columns.Clear();
            gridViewChiTietMoi.Columns.AddVisible("MaSP", "Mã");
            gridViewChiTietMoi.Columns.AddVisible("TenSP", "Tên sản phẩm");
            gridViewChiTietMoi.Columns.AddVisible("SoLuong", "SL");
            gridViewChiTietMoi.Columns.AddVisible("DonGiaNhap", "Đơn giá nhập");
            gridViewChiTietMoi.Columns.AddVisible("ThanhTien", "Thành tiền");
            gridViewChiTietMoi.Columns.AddVisible("HanSuDung", "Hạn SD");

            gridViewChiTietMoi.Columns["MaSP"].Width = 50;
            gridViewChiTietMoi.Columns["TenSP"].Width = 180;
            gridViewChiTietMoi.Columns["SoLuong"].Width = 50;
            gridViewChiTietMoi.Columns["DonGiaNhap"].Width = 100;
            gridViewChiTietMoi.Columns["ThanhTien"].Width = 110;
            gridViewChiTietMoi.Columns["HanSuDung"].Width = 90;

            gridViewChiTietMoi.Columns["DonGiaNhap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewChiTietMoi.Columns["DonGiaNhap"].DisplayFormat.FormatString = "#,##0 đ";
            gridViewChiTietMoi.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewChiTietMoi.Columns["ThanhTien"].DisplayFormat.FormatString = "#,##0 đ";
            gridViewChiTietMoi.Columns["HanSuDung"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridViewChiTietMoi.Columns["HanSuDung"].DisplayFormat.FormatString = "dd/MM/yyyy";

            gridViewChiTietMoi.OptionsView.ShowGroupPanel = false;
        }

        private void LoadPhieuNhapHistory()
        {
            try
            {
                var phieuNhaps = _context.PhieuNhaps
                    .Include(p => p.NhaCungCap)
                    .Include(p => p.CT_PhieuNhaps)
                    .OrderByDescending(p => p.NgayNhap)
                    .Select(p => new
                    {
                        p.MaPN,
                        p.NgayNhap,
                        TenNCC = p.NhaCungCap.TenNCC,
                        SoSP = p.CT_PhieuNhaps.Count,
                        TongTien = p.CT_PhieuNhaps.Sum(ct => (decimal?)(ct.SoLuong * ct.DonGiaNhap)) ?? 0
                    })
                    .Take(100)
                    .ToList();

                gridMaster.DataSource = phieuNhaps;

                gridViewMaster.Columns.Clear();
                gridViewMaster.Columns.AddVisible("MaPN", "Mã PN");
                gridViewMaster.Columns.AddVisible("NgayNhap", "Ngày nhập");
                gridViewMaster.Columns.AddVisible("TenNCC", "Nhà cung cấp");
                gridViewMaster.Columns.AddVisible("SoSP", "Số SP");
                gridViewMaster.Columns.AddVisible("TongTien", "Tổng tiền");

                gridViewMaster.Columns["MaPN"].Width = 60;
                gridViewMaster.Columns["NgayNhap"].Width = 100;
                gridViewMaster.Columns["TenNCC"].Width = 180;
                gridViewMaster.Columns["SoSP"].Width = 60;
                gridViewMaster.Columns["TongTien"].Width = 120;

                gridViewMaster.Columns["NgayNhap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewMaster.Columns["NgayNhap"].DisplayFormat.FormatString = "dd/MM/yyyy";
                gridViewMaster.Columns["TongTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewMaster.Columns["TongTien"].DisplayFormat.FormatString = "#,##0 đ";

                gridViewMaster.OptionsView.ShowGroupPanel = false;
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
                        ct.MaSP,
                        TenSP = ct.SanPham.TenSP,
                        ct.SoLuong,
                        ct.DonGiaNhap,
                        ThanhTien = ct.SoLuong * ct.DonGiaNhap,
                        ct.HanSuDung
                    })
                    .ToList();

                gridDetail.DataSource = chiTiet;

                gridViewDetail.Columns.Clear();
                gridViewDetail.Columns.AddVisible("MaSP", "Mã");
                gridViewDetail.Columns.AddVisible("TenSP", "Tên sản phẩm");
                gridViewDetail.Columns.AddVisible("SoLuong", "SL");
                gridViewDetail.Columns.AddVisible("DonGiaNhap", "Đơn giá");
                gridViewDetail.Columns.AddVisible("ThanhTien", "Thành tiền");
                gridViewDetail.Columns.AddVisible("HanSuDung", "Hạn SD");

                gridViewDetail.Columns["MaSP"].Width = 50;
                gridViewDetail.Columns["TenSP"].Width = 180;
                gridViewDetail.Columns["SoLuong"].Width = 50;
                gridViewDetail.Columns["DonGiaNhap"].Width = 90;
                gridViewDetail.Columns["ThanhTien"].Width = 100;
                gridViewDetail.Columns["HanSuDung"].Width = 90;

                gridViewDetail.Columns["DonGiaNhap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewDetail.Columns["DonGiaNhap"].DisplayFormat.FormatString = "#,##0 đ";
                gridViewDetail.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewDetail.Columns["ThanhTien"].DisplayFormat.FormatString = "#,##0 đ";
                gridViewDetail.Columns["HanSuDung"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewDetail.Columns["HanSuDung"].DisplayFormat.FormatString = "dd/MM/yyyy";

                gridViewDetail.OptionsView.ShowGroupPanel = false;
            }
            catch { }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (lookupSPMoi.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookupSPMoi.Focus();
                return;
            }

            if (spinSoLuong.Value <= 0)
            {
                XtraMessageBox.Show("Số lượng phải > 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spinSoLuong.Focus();
                return;
            }

            if (spinDonGia.Value <= 0)
            {
                XtraMessageBox.Show("Đơn giá nhập phải > 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spinDonGia.Focus();
                return;
            }

            var hanSD = Convert.ToDateTime(dateHanSD.EditValue);
            if (hanSD <= DateTime.Today)
            {
                XtraMessageBox.Show("Hạn sử dụng phải > ngày hôm nay!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateHanSD.Focus();
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
                    HanSuDung = hanSD
                });
            }

            RefreshGridChiTietMoi();
            UpdateTongTien();

            // Reset
            lookupSPMoi.EditValue = null;
            spinSoLuong.Value = 1;
            spinDonGia.Value = 0;
            lookupSPMoi.Focus();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (gridViewChiTietMoi.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tenSP = gridViewChiTietMoi.GetFocusedRowCellValue("TenSP")?.ToString();
            var confirm = XtraMessageBox.Show($"Xóa '{tenSP}' khỏi phiếu nhập?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var maSP = gridViewChiTietMoi.GetFocusedRowCellValue("MaSP");
                if (maSP != null)
                {
                    _chiTietMoi.RemoveAll(ct => ct.MaSP == Convert.ToInt32(maSP));
                    RefreshGridChiTietMoi();
                    UpdateTongTien();
                }
            }
        }

        private void RefreshGridChiTietMoi()
        {
            gridChiTietMoi.DataSource = null;
            gridChiTietMoi.DataSource = _chiTietMoi;
        }

        private void UpdateTongTien()
        {
            decimal tongTien = _chiTietMoi.Sum(ct => ct.ThanhTien);
            int soSP = _chiTietMoi.Count;
            int tongSL = _chiTietMoi.Sum(ct => ct.SoLuong);

            // Cập nhật title nếu có thể (không bắt buộc có lblTongTien)
            this.Text = $"📦 NHẬP HÀNG | Tổng: {tongTien:N0} đ | {soSP} SP | {tongSL} đơn vị";
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            if (lookupNCC.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn nhà cung cấp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookupNCC.Focus();
                return;
            }

            if (_chiTietMoi.Count == 0)
            {
                XtraMessageBox.Show("Vui lòng thêm ít nhất 1 sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tongTien = _chiTietMoi.Sum(ct => ct.ThanhTien);
            var nccRow = lookupNCC.GetSelectedDataRow();
            string tenNCC = ((dynamic)nccRow).TenNCC;

            var confirm = XtraMessageBox.Show(
                $"📦 XÁC NHẬN TẠO PHIẾU NHẬP\n\n" +
                $"🏭 Nhà cung cấp: {tenNCC}\n" +
                $"📅 Ngày nhập: {Convert.ToDateTime(dateNgayNhap.EditValue):dd/MM/yyyy}\n" +
                $"📋 Số sản phẩm: {_chiTietMoi.Count}\n" +
                $"💰 Tổng tiền: {tongTien:N0} đ\n\n" +
                "Xác nhận tạo phiếu nhập?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
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
                    DuLieuMoi = $"PN #{phieuNhap.MaPN} | NCC: {tenNCC} | Tổng: {tongTien:N0}đ",
                    MaNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : (int?)null
                };
                _context.AuditLogs.Add(log);
                _context.SaveChanges();

                XtraMessageBox.Show(
                    $"✅ TẠO PHIẾU NHẬP THÀNH CÔNG!\n\n" +
                    $"📋 Mã phiếu: PN{phieuNhap.MaPN:D4}\n" +
                    $"🏭 NCC: {tenNCC}\n" +
                    $"💰 Tổng tiền: {tongTien:N0} đ\n\n" +
                    "Tồn kho đã được cập nhật.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset
                _chiTietMoi.Clear();
                RefreshGridChiTietMoi();
                UpdateTongTien();
                lookupNCC.EditValue = null;
                LoadPhieuNhapHistory();
                LoadSanPham(); // Refresh để cập nhật tồn kho
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tạo phiếu nhập: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            if (_chiTietMoi.Count == 0) return;

            var confirm = XtraMessageBox.Show("Hủy phiếu nhập hiện tại?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _chiTietMoi.Clear();
                RefreshGridChiTietMoi();
                UpdateTongTien();
                lookupNCC.EditValue = null;
            }
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
