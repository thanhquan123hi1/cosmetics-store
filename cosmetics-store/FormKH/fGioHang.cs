using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormKH
{
    public partial class fGioHang : DevExpress.XtraEditors.XtraForm
    {
        private List<CartItem> _cart;
        private CosmeticsContext _context;

        public fGioHang(List<CartItem> cart, CosmeticsContext context)
        {
            InitializeComponent();
            _cart = cart;
            _context = context;
            this.Load += fGioHang_Load;
        }

        private void fGioHang_Load(object sender, EventArgs e)
        {
            LoadCart();
        }

        private void LoadCart()
        {
            gridGioHang.DataSource = null;
            gridGioHang.DataSource = _cart.Select(c => new
            {
                c.MaSP,
                c.TenSP,
                c.SoLuong,
                c.DonGia,
                c.ThanhTien
            }).ToList();

            if (gridViewGH.Columns.Count > 0)
            {
                gridViewGH.Columns["MaSP"].Visible = false;
                gridViewGH.Columns["TenSP"].Caption = "San pham";
                gridViewGH.Columns["SoLuong"].Caption = "SL";
                gridViewGH.Columns["DonGia"].Caption = "Don gia";
                gridViewGH.Columns["ThanhTien"].Caption = "Thanh tien";

                gridViewGH.Columns["TenSP"].Width = 250;
                gridViewGH.Columns["SoLuong"].Width = 60;
                gridViewGH.Columns["DonGia"].Width = 100;
                gridViewGH.Columns["ThanhTien"].Width = 120;

                gridViewGH.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewGH.Columns["DonGia"].DisplayFormat.FormatString = "#,##0";
                gridViewGH.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewGH.Columns["ThanhTien"].DisplayFormat.FormatString = "#,##0";
            }

            UpdateTongTien();
        }

        private void UpdateTongTien()
        {
            decimal tongTien = _cart.Sum(c => c.ThanhTien);
            lblTongTien.Text = $"Tong tien: {tongTien:N0} VND";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridViewGH.FocusedRowHandle < 0) return;

            int maSP = Convert.ToInt32(gridViewGH.GetFocusedRowCellValue("MaSP"));
            var item = _cart.FirstOrDefault(c => c.MaSP == maSP);
            if (item != null)
            {
                _cart.Remove(item);
                LoadCart();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                XtraMessageBox.Show("Gio hang trong!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CurrentUser.IsLoggedIn)
            {
                XtraMessageBox.Show("Vui long dang nhap de thanh toan!", "Thong bao",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal tongTien = _cart.Sum(c => c.ThanhTien);

                // Tao hoa don
                var hoaDon = new HoaDon
                {
                    MaKH = GetOrCreateKhachHang(),
                    MaNV = 1, // Mac dinh NV he thong
                    NgayLap = DateTime.Now,
                    TongTien = tongTien,
                    TrangThai = "Hoan thanh",
                    PhuongThucTT = "Online"
                };

                _context.HoaDons.Add(hoaDon);
                _context.SaveChanges();

                // Chi tiet
                int stt = 1;
                foreach (var item in _cart)
                {
                    var ct = new CT_HoaDon
                    {
                        MaHD = hoaDon.MaHD,
                        MaSP = item.MaSP,
                        STT = stt++,
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia
                    };
                    _context.CT_HoaDons.Add(ct);

                    // Tru ton kho
                    var sp = _context.SanPhams.Find(item.MaSP);
                    if (sp != null) sp.SoLuongTon -= item.SoLuong;
                }

                _context.SaveChanges();

                XtraMessageBox.Show($"Dat hang thanh cong!\nMa don: #{hoaDon.MaHD}\nTong tien: {tongTien:N0} VND",
                    "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Loi: {ex.Message}", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetOrCreateKhachHang()
        {
            // Tim khach hang tu tai khoan dang nhap
            if (CurrentUser.IsLoggedIn)
            {
                var kh = _context.KhachHangs.FirstOrDefault(k => k.SDT == CurrentUser.User.Email);
                if (kh != null) return kh.MaKH;

                // Tao moi khach hang
                var newKH = new KhachHang
                {
                    HoTen = CurrentUser.User.HoTen,
                    SDT = CurrentUser.User.Email ?? "0000000000",
                    DiaChi = ""
                };
                _context.KhachHangs.Add(newKH);
                _context.SaveChanges();
                return newKH.MaKH;
            }

            return 1; // Khach le
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
