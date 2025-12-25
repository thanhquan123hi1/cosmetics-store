using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormStaff
{
    public partial class fTraCuuSanPham : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;

        public fTraCuuSanPham()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += fTraCuuSanPham_Load;
        }

        private void fTraCuuSanPham_Load(object sender, EventArgs e)
        {
            LoadThuongHieu();
            LoadLoaiSP();
            LoadSanPham();
        }

        private void LoadThuongHieu()
        {
            try
            {
                var list = _context.ThuongHieus
                    .Select(th => new { th.MaThuongHieu, th.TenThuongHieu })
                    .ToList();

                list.Insert(0, new { MaThuongHieu = 0, TenThuongHieu = "-- Tất cả --" });

                cboThuongHieu.Properties.DataSource = list;
                cboThuongHieu.Properties.ValueMember = "MaThuongHieu";
                cboThuongHieu.Properties.DisplayMember = "TenThuongHieu";
                cboThuongHieu.EditValue = 0;
            }
            catch { }
        }

        private void LoadLoaiSP()
        {
            try
            {
                var list = _context.LoaiSPs
                    .Select(l => new { l.MaLoai, l.TenLoai })
                    .ToList();

                list.Insert(0, new { MaLoai = 0, TenLoai = "-- Tất cả --" });

                cboLoaiSP.Properties.DataSource = list;
                cboLoaiSP.Properties.ValueMember = "MaLoai";
                cboLoaiSP.Properties.DisplayMember = "TenLoai";
                cboLoaiSP.EditValue = 0;
            }
            catch { }
        }

        private void LoadSanPham(string keyword = "", int? maTH = null, int? maLoai = null)
        {
            try
            {
                var query = _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .Include(sp => sp.LoaiSP)
                    .AsQueryable();

                // Lọc theo từ khóa
                if (!string.IsNullOrEmpty(keyword))
                {
                    keyword = keyword.ToLower();
                    query = query.Where(sp => sp.TenSP.ToLower().Contains(keyword) ||
                                               sp.MoTa.ToLower().Contains(keyword));
                }

                // Lọc theo thương hiệu
                if (maTH.HasValue && maTH.Value > 0)
                {
                    query = query.Where(sp => sp.MaThuongHieu == maTH.Value);
                }

                // Lọc theo loại
                if (maLoai.HasValue && maLoai.Value > 0)
                {
                    query = query.Where(sp => sp.MaLoai == maLoai.Value);
                }

                var data = query.Select(sp => new
                {
                    sp.MaSP,
                    sp.TenSP,
                    ThuongHieu = sp.ThuongHieu.TenThuongHieu,
                    LoaiSP = sp.LoaiSP.TenLoai,
                    sp.DonGia,
                    TonKho = sp.SoLuongTon,
                    TrangThai = sp.SoLuongTon > 0 ? "Còn hàng" : "Hết hàng"
                }).OrderByDescending(sp => sp.MaSP).Take(200).ToList();

                gridSanPham.DataSource = data;

                if (gridViewSP.Columns.Count > 0)
                {
                    gridViewSP.Columns["MaSP"].Caption = "Mã SP";
                    gridViewSP.Columns["TenSP"].Caption = "Tên sản phẩm";
                    gridViewSP.Columns["ThuongHieu"].Caption = "Thương hiệu";
                    gridViewSP.Columns["LoaiSP"].Caption = "Loại";
                    gridViewSP.Columns["DonGia"].Caption = "Đơn giá";
                    gridViewSP.Columns["TonKho"].Caption = "Tồn kho";
                    gridViewSP.Columns["TrangThai"].Caption = "Trạng thái";

                    gridViewSP.Columns["MaSP"].Width = 60;
                    gridViewSP.Columns["TenSP"].Width = 220;
                    gridViewSP.Columns["ThuongHieu"].Width = 120;
                    gridViewSP.Columns["LoaiSP"].Width = 120;
                    gridViewSP.Columns["DonGia"].Width = 100;
                    gridViewSP.Columns["TonKho"].Width = 80;
                    gridViewSP.Columns["TrangThai"].Width = 90;

                    gridViewSP.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridViewSP.Columns["DonGia"].DisplayFormat.FormatString = "#,##0";
                }

                lblKetQua.Text = "Tìm thấy " + data.Count + " sản phẩm";
            }
            catch (Exception ex)
            {
                lblKetQua.Text = "Lỗi: " + ex.Message;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            int? maTH = cboThuongHieu.EditValue != null && Convert.ToInt32(cboThuongHieu.EditValue) > 0
                ? Convert.ToInt32(cboThuongHieu.EditValue) : (int?)null;
            int? maLoai = cboLoaiSP.EditValue != null && Convert.ToInt32(cboLoaiSP.EditValue) > 0
                ? Convert.ToInt32(cboLoaiSP.EditValue) : (int?)null;

            LoadSanPham(keyword, maTH, maLoai);
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            cboThuongHieu.EditValue = 0;
            cboLoaiSP.EditValue = 0;
            LoadSanPham();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
