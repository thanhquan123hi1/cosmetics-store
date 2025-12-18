using System;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormStaff
{
    public partial class fChonKhachHang : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;
        public KhachHang SelectedKhachHang { get; private set; }

        public fChonKhachHang(CosmeticsContext context)
        {
            InitializeComponent();
            _context = context;
            this.Load += fChonKhachHang_Load;
        }

        private void fChonKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void LoadKhachHang(string keyword = "")
        {
            try
            {
                var query = _context.KhachHangs.AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    keyword = keyword.ToLower();
                    query = query.Where(kh => kh.HoTen.ToLower().Contains(keyword) ||
                                               kh.SDT.Contains(keyword));
                }

                var data = query.Select(kh => new
                {
                    kh.MaKH,
                    kh.HoTen,
                    kh.SDT,
                    GhiChu = kh.DiaChi ?? ""
                }).ToList();

                gridKhachHang.DataSource = data;

                gridViewKH.Columns["MaKH"].Caption = "M? KH";
                gridViewKH.Columns["HoTen"].Caption = "H? tên";
                gridViewKH.Columns["SDT"].Caption = "SÐT";
                gridViewKH.Columns["GhiChu"].Caption = "Ghi chú";

                gridViewKH.Columns["MaKH"].Width = 60;
                gridViewKH.Columns["HoTen"].Width = 150;
                gridViewKH.Columns["SDT"].Width = 100;
                gridViewKH.Columns["GhiChu"].Width = 150;
            }
            catch { }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadKhachHang(txtTimKiem.Text);
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadKhachHang(txtTimKiem.Text);
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (gridViewKH.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui l?ng ch?n khách hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maKH = Convert.ToInt32(gridViewKH.GetFocusedRowCellValue("MaKH"));
            SelectedKhachHang = _context.KhachHangs.Find(maKH);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThemNhanh_Click(object sender, EventArgs e)
        {
            using (var form = new fThemKhachHangNhanh())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var kh = new KhachHang
                        {
                            HoTen = form.HoTen,
                            SDT = form.SDT,
                            DiaChi = form.DiaChi
                        };
                        _context.KhachHangs.Add(kh);
                        _context.SaveChanges();

                        LoadKhachHang();

                        XtraMessageBox.Show("Ð? thêm khách hàng m?i!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"L?i: {ex.Message}", "L?i",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
