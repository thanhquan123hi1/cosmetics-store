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
                    query = query.Where(k => k.HoTen.ToLower().Contains(keyword) ||
                                               k.SDT.Contains(keyword));
                }

                var data = query.Select(k => new
                {
                    k.MaKH,
                    k.HoTen,
                    k.SDT,
                    GhiChu = k.DiaChi ?? ""
                }).OrderByDescending(k => k.MaKH).Take(100).ToList();

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
                        // Kiểm tra khách hàng đã tồn tại theo SĐT
                        var sdt = form.SDT.Trim();
                        var existingKH = _context.KhachHangs.FirstOrDefault(x => x.SDT == sdt);

                        if (existingKH != null)
                        {
                            // Khách hàng đã tồn tại -> sử dụng khách hàng hiện có
                            var result = XtraMessageBox.Show(
                                $"Khách hàng với SĐT {sdt} đã tồn tại:\n" +
                                $"Họ tên: {existingKH.HoTen}\n" +
                                $"Địa chỉ: {existingKH.DiaChi ?? "N/A"}\n\n" +
                                $"Bạn có muốn chọn khách hàng này không?",
                                "Khách hàng đã tồn tại",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                SelectedKhachHang = existingKH;
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            return;
                        }

                        // Tạo khách hàng mới
                        var newKH = new KhachHang
                        {
                            HoTen = form.HoTen,
                            SDT = sdt,
                            DiaChi = form.DiaChi,
                            GioiTinh = "Khác"
                        };
                        _context.KhachHangs.Add(newKH);
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
