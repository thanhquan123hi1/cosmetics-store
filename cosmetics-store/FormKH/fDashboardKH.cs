using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormKH
{
    public partial class fDashboardKH : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;
        private List<CartItem> _cart = new List<CartItem>();
        private Timer _bannerTimer;
        private int _currentBannerIndex = 0;
        private string[] _bannerTexts = new[]
        {
            "YEU HANG XIN - SAN SALE DAM",
            "MUA 2 GIAM 40% - MUA 3 GIAM 50%",
            "FREESHIP MOI DON HANG TU 99K"
        };

        public fDashboardKH()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += fDashboardKH_Load;
        }

        private void fDashboardKH_Load(object sender, EventArgs e)
        {
            SetupUI();
            LoadTopProducts();
            StartBannerSlider();
        }

        private void SetupUI()
        {
            if (CurrentUser.IsLoggedIn)
            {
                lblDangNhap.Text = CurrentUser.User.HoTen;
            }
            UpdateCartCount();
        }

        private void StartBannerSlider()
        {
            _bannerTimer = new Timer();
            _bannerTimer.Interval = 4000;
            _bannerTimer.Tick += (s, e) =>
            {
                _currentBannerIndex = (_currentBannerIndex + 1) % _bannerTexts.Length;
                lblBannerMain.Text = _bannerTexts[_currentBannerIndex];
                UpdateBannerDots();
            };
            _bannerTimer.Start();
        }

        private void UpdateBannerDots()
        {
            string dots = "";
            for (int i = 0; i < _bannerTexts.Length; i++)
            {
                dots += (i == _currentBannerIndex) ? " ? " : " ? ";
            }
            lblBannerDots.Text = dots;
        }

        private void LoadTopProducts()
        {
            try
            {
                var products = _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .Where(sp => sp.SoLuongTon > 0)
                    .OrderByDescending(sp => sp.MaSP)
                    .Take(10)
                    .ToList();

                flowProducts.Controls.Clear();
                foreach (var sp in products)
                {
                    var card = CreateProductCard(sp);
                    flowProducts.Controls.Add(card);
                }
            }
            catch { }
        }

        private Panel CreateProductCard(SanPham sp)
        {
            var card = new Panel
            {
                Size = new Size(180, 280),
                BackColor = Color.White,
                Margin = new Padding(8),
                Cursor = Cursors.Hand
            };
            card.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(230, 230, 230)), 0, 0, card.Width - 1, card.Height - 1);
            };

            // Tag khuyen mai
            var lblTag = new Label
            {
                Text = "FREESHIP",
                Font = new Font("Segoe UI", 7F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(46, 204, 113),
                Size = new Size(60, 16),
                Location = new Point(5, 5),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblTag);

            // Gia tag
            var lblPrice = new Label
            {
                Text = $"{sp.DonGia / 1000:N0}K",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(231, 76, 60),
                Size = new Size(50, 18),
                Location = new Point(120, 5),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblPrice);

            // Anh san pham (placeholder)
            var picProduct = new PictureBox
            {
                Size = new Size(160, 120),
                Location = new Point(10, 30),
                BackColor = Color.FromArgb(245, 245, 245),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            // Load hinh anh neu co
            try
            {
                if (!string.IsNullOrEmpty(sp.HinhAnh))
                {
                    string path = System.IO.Path.Combine(Application.StartupPath, sp.HinhAnh);
                    if (System.IO.File.Exists(path))
                    {
                        picProduct.Image = Image.FromFile(path);
                    }
                }
            }
            catch { }
            card.Controls.Add(picProduct);

            // Thuong hieu
            var lblBrand = new Label
            {
                Text = sp.ThuongHieu?.TenThuongHieu ?? "N/A",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.Gray,
                Location = new Point(10, 155),
                Size = new Size(160, 16),
                AutoEllipsis = true
            };
            card.Controls.Add(lblBrand);

            // Ten san pham
            var lblName = new Label
            {
                Text = sp.TenSP,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Black,
                Location = new Point(10, 172),
                Size = new Size(160, 36),
                AutoEllipsis = true
            };
            card.Controls.Add(lblName);

            // Rating
            var lblRating = new Label
            {
                Text = "***** (0)",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(255, 193, 7),
                Location = new Point(10, 210),
                Size = new Size(160, 16)
            };
            card.Controls.Add(lblRating);

            // Gia
            var lblPriceFull = new Label
            {
                Text = $"{sp.DonGia:N0} d",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(231, 76, 60),
                Location = new Point(10, 230),
                Size = new Size(160, 20)
            };
            card.Controls.Add(lblPriceFull);

            // Nut them vao gio
            var btnAdd = new SimpleButton
            {
                Text = "+ Gio",
                Size = new Size(70, 25),
                Location = new Point(100, 250),
                Appearance = { Font = new Font("Segoe UI", 8F) }
            };
            btnAdd.Click += (s, e) => AddToCart(sp);
            card.Controls.Add(btnAdd);

            // Click vao card de xem chi tiet
            card.Click += (s, e) => ShowProductDetail(sp);
            picProduct.Click += (s, e) => ShowProductDetail(sp);
            lblName.Click += (s, e) => ShowProductDetail(sp);

            return card;
        }

        private void AddToCart(SanPham sp)
        {
            var existing = _cart.FirstOrDefault(c => c.MaSP == sp.MaSP);
            if (existing != null)
            {
                existing.SoLuong++;
            }
            else
            {
                _cart.Add(new CartItem
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    DonGia = sp.DonGia,
                    SoLuong = 1
                });
            }
            UpdateCartCount();
            XtraMessageBox.Show($"Da them '{sp.TenSP}' vao gio hang!", "Thong bao",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateCartCount()
        {
            int count = _cart.Sum(c => c.SoLuong);
            lblGioHang.Text = $"Gio ({count})";
        }

        private void ShowProductDetail(SanPham sp)
        {
            using (var form = new fSanPhamDetail(sp, _context))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    AddToCart(sp);
                }
            }
        }

        private void btnGioHang_Click(object sender, EventArgs e)
        {
            using (var form = new fGioHang(_cart, _context))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _cart.Clear();
                    UpdateCartCount();
                    LoadTopProducts();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadTopProducts();
                return;
            }

            try
            {
                var products = _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .Where(sp => sp.SoLuongTon > 0 &&
                                 (sp.TenSP.ToLower().Contains(keyword) ||
                                  sp.ThuongHieu.TenThuongHieu.ToLower().Contains(keyword)))
                    .Take(20)
                    .ToList();

                flowProducts.Controls.Clear();
                foreach (var sp in products)
                {
                    var card = CreateProductCard(sp);
                    flowProducts.Controls.Add(card);
                }
            }
            catch { }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show("Ban co chac muon dang xuat?", "Xac nhan",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CurrentUser.Logout();
                this.Hide();
                var loginForm = new Forms.fLogin();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

        private void btnMuaNgay_Click(object sender, EventArgs e)
        {
            // Scroll xuong danh sach san pham
            flowProducts.Focus();
        }

        private void lblDangNhap_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsLoggedIn)
            {
                var result = XtraMessageBox.Show("Ban chua dang nhap. Dang nhap ngay?", "Thong bao",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    var loginForm = new Forms.fLogin();
                    loginForm.FormClosed += (s, args) => this.Close();
                    loginForm.Show();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bannerTimer?.Stop();
                _bannerTimer?.Dispose();
                _context?.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class CartItem
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien => DonGia * SoLuong;
    }
}
