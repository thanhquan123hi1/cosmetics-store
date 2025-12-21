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
            LoadSanPham();
        }

        private void LoadSanPham(string keyword = "")
        {
            try
            {
                var query = _context.SanPhams
                    .Include(sp => sp.LoaiSP)
                    .Include(sp => sp.ThuongHieu)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    keyword = keyword.ToLower();
                    query = query.Where(sp => sp.TenSP.ToLower().Contains(keyword) ||
                                               sp.LoaiSP.TenLoai.ToLower().Contains(keyword) ||
                                               sp.ThuongHieu.TenThuongHieu.ToLower().Contains(keyword) ||
                                               sp.MaSP.ToString().Contains(keyword));
                }

                var data = query.Select(sp => new
                {
                    sp.MaSP,
                    sp.TenSP,
                    sp.DonGia,
                    TonKho = sp.SoLuongTon,
                    ThuongHieu = sp.ThuongHieu.TenThuongHieu,
                    LoaiSP = sp.LoaiSP.TenLoai
                }).ToList();

                gridSanPham.DataSource = data;

                gridViewSP.Columns["MaSP"].Caption = "Mã SP";
                gridViewSP.Columns["TenSP"].Caption = "Tên SP";
                gridViewSP.Columns["DonGia"].Caption = "Giá";
                gridViewSP.Columns["TonKho"].Caption = "Tồn kho";
                gridViewSP.Columns["ThuongHieu"].Caption = "Thương hiệu";
                gridViewSP.Columns["LoaiSP"].Caption = "Loại";

                gridViewSP.Columns["MaSP"].Width = 60;
                gridViewSP.Columns["TenSP"].Width = 200;
                gridViewSP.Columns["DonGia"].Width = 100;
                gridViewSP.Columns["TonKho"].Width = 70;
                gridViewSP.Columns["ThuongHieu"].Width = 120;
                gridViewSP.Columns["LoaiSP"].Width = 100;

                gridViewSP.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewSP.Columns["DonGia"].DisplayFormat.FormatString = "#,##0";

                // Highlight sản phẩm hết hàng
                gridViewSP.RowStyle += (s, e) =>
                {
                    if (e.RowHandle >= 0)
                    {
                        var tonKho = Convert.ToInt32(gridViewSP.GetRowCellValue(e.RowHandle, "TonKho"));
                        if (tonKho == 0)
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 200, 200);
                        }
                        else if (tonKho <= 10)
                        {
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 255, 200);
                        }
                    }
                };
            }
            catch { }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadSanPham(txtTimKiem.Text);
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadSanPham(txtTimKiem.Text);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
