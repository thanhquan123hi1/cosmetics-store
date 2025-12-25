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
                }).OrderByDescending(kh => kh.MaKH).Take(100).ToList();

                gridKhachHang.DataSource = data;

                if (gridViewKH.Columns.Count > 0)
                {
                    gridViewKH.Columns["MaKH"].Caption = "Mã KH";
                    gridViewKH.Columns["HoTen"].Caption = "Họ tên";
                    gridViewKH.Columns["SDT"].Caption = "SĐT";
                    gridViewKH.Columns["GhiChu"].Caption = "Địa chỉ";

                    gridViewKH.Columns["MaKH"].Width = 60;
                    gridViewKH.Columns["HoTen"].Width = 180;
                    gridViewKH.Columns["SDT"].Width = 100;
                    gridViewKH.Columns["GhiChu"].Width = 180;
                }
            }
            catch { }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadKhachHang(txtTimKiem.Text.Trim());
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadKhachHang(txtTimKiem.Text.Trim());
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (gridViewKH.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo",
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
                            DiaChi = form.DiaChi,
                            GioiTinh = "Khác"
                        };
                        _context.KhachHangs.Add(kh);
                        _context.SaveChanges();

                        LoadKhachHang();

                        XtraMessageBox.Show("Đã thêm khách hàng mới!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
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

        private void gridViewKH_DoubleClick(object sender, EventArgs e)
        {
            btnChon_Click(sender, e);
        }
    }
}
