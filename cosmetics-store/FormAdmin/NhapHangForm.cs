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
            LoadNhaCungCap();
            LoadSanPham();
            LoadPhieuNhapHistory();
            SetupGridChiTietMoi();
            dateNgayNhap.EditValue = DateTime.Now;
            dateHanSD.EditValue = DateTime.Now.AddYears(2);
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
                lookupNCC.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNCC", "Nhà cung c?p"));
                lookupNCC.Properties.NullText = "-- Ch?n NCC --";
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
                lookupSPMoi.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaSP", "M? SP", 60));
                lookupSPMoi.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenSP", "Tên s?n ph?m", 200));
                lookupSPMoi.Properties.NullText = "-- Ch?n s?n ph?m --";

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
            gridViewChiTietMoi.Columns.AddVisible("TenSP", "Tên s?n ph?m");
            gridViewChiTietMoi.Columns.AddVisible("SoLuong", "S? lý?ng");
            gridViewChiTietMoi.Columns.AddVisible("DonGiaNhap", "Ðõn giá");
            gridViewChiTietMoi.Columns.AddVisible("ThanhTien", "Thành ti?n");

            gridViewChiTietMoi.Columns["DonGiaNhap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewChiTietMoi.Columns["DonGiaNhap"].DisplayFormat.FormatString = "#,##0 ð";
            gridViewChiTietMoi.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewChiTietMoi.Columns["ThanhTien"].DisplayFormat.FormatString = "#,##0 ð";
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
                gridViewMaster.Columns.AddVisible("MaPN", "M? PN");
                gridViewMaster.Columns.AddVisible("NgayNhap", "Ngày nh?p");
                gridViewMaster.Columns.AddVisible("TenNCC", "Nhà cung c?p");

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
                gridViewDetail.Columns.AddVisible("TenSP", "Tên s?n ph?m");
                gridViewDetail.Columns.AddVisible("SoLuong", "S? lý?ng");
                gridViewDetail.Columns.AddVisible("DonGiaNhap", "Ðõn giá");
                gridViewDetail.Columns.AddVisible("ThanhTien", "Thành ti?n");
                gridViewDetail.Columns.AddVisible("HanSuDung", "H?n SD");

                gridViewDetail.Columns["DonGiaNhap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewDetail.Columns["DonGiaNhap"].DisplayFormat.FormatString = "#,##0 ð";
                gridViewDetail.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewDetail.Columns["ThanhTien"].DisplayFormat.FormatString = "#,##0 ð";
            }
            catch { }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (lookupSPMoi.EditValue == null)
            {
                XtraMessageBox.Show("Vui l?ng ch?n s?n ph?m!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (spinSoLuong.Value <= 0)
            {
                XtraMessageBox.Show("S? lý?ng ph?i > 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (spinDonGia.Value <= 0)
            {
                XtraMessageBox.Show("Ðõn giá ph?i > 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maSP = Convert.ToInt32(lookupSPMoi.EditValue);
            var row = lookupSPMoi.GetSelectedDataRow();
            string tenSP = ((dynamic)row).TenSP;

            // Ki?m tra ð? t?n t?i chýa
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
                XtraMessageBox.Show("Vui l?ng ch?n s?n ph?m c?n xóa!", "Thông báo",
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
                XtraMessageBox.Show("Vui l?ng ch?n nhà cung c?p!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_chiTietMoi.Count == 0)
            {
                XtraMessageBox.Show("Vui l?ng thêm ít nh?t 1 s?n ph?m!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tính t?ng ti?n
                decimal tongTien = _chiTietMoi.Sum(ct => ct.ThanhTien);

                // T?o phi?u nh?p
                var phieuNhap = new PhieuNhap
                {
                    MaNCC = Convert.ToInt32(lookupNCC.EditValue),
                    NgayNhap = Convert.ToDateTime(dateNgayNhap.EditValue)
                };

                _context.PhieuNhaps.Add(phieuNhap);
                _context.SaveChanges();

                // T?o chi ti?t và c?p nh?t t?n kho
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

                    // C?p nh?t t?n kho
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
                    DuLieuMoi = $"Phi?u nh?p #{phieuNhap.MaPN}, T?ng: {tongTien:N0}ð",
                    MaNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : (int?)null
                };
                _context.AuditLogs.Add(log);
                _context.SaveChanges();

                XtraMessageBox.Show($"T?o phi?u nh?p #{phieuNhap.MaPN} thành công!\nT?ng ti?n: {tongTien:N0} ð",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset
                _chiTietMoi.Clear();
                RefreshGridChiTietMoi();
                lookupNCC.EditValue = null;
                LoadPhieuNhapHistory();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"L?i t?o phi?u nh?p: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Class t?m ð? lýu chi ti?t phi?u nh?p m?i
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
