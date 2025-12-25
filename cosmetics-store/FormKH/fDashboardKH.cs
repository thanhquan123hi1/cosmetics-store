using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BusinessAccessLayer.Services;
using BusinessAccessLayer.DTOs;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormKH
{
    public partial class fDashboardKH : DevExpress.XtraEditors.XtraForm
    {
        private readonly KHService _khService;
        private Timer _bannerTimer;
        private int _currentBannerIndex = 0;
        private string[] _bannerTexts = new[]
        {
            "🌸 YÊU HÀNG XIN - SĂN SALE ĐẬM 🌸",
            "💄 MUA 2 GIẢM 40% - MUA 3 GIẢM 50% 💄",
            "🚚 FREESHIP MỌI ĐƠN HÀNG TỪ 99K 🚚",
            "🎁 QUÀ TẶNG CHO ĐƠN TỪ 499K 🎁"
        };

        // Màu theme BeautyBox
        private readonly Color _primaryPurple = Color.FromArgb(128, 0, 128);
        private readonly Color _lightPurple = Color.FromArgb(147, 112, 219);
        private readonly Color _lightBg = Color.FromArgb(250, 248, 255);
        private readonly Color _accentGreen = Color.FromArgb(46, 204, 113);
        private readonly Color _accentRed = Color.FromArgb(231, 76, 60);

        // Menu hiện tại
        private string _currentMenu = "Trang chủ";
        private Panel _activeMenuPanel = null;
        
        // Cache cho products
        private List<SanPhamDTO> _cachedTopProducts = null;
        private List<SanPhamDTO> _cachedAllProducts = null;
        private DateTime _lastProductLoad = DateTime.MinValue;

        public fDashboardKH()
        {
            InitializeComponent();
            _khService = new KHService();
            
            // Enable double buffering
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                     ControlStyles.AllPaintingInWmPaint | 
                     ControlStyles.UserPaint, true);
            
            this.Load += fDashboardKH_Load;
        }
        
        private void fDashboardKH_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            
            try
            {
                DatabaseSeeder.SeedSampleProducts();
                InitializeCustomer();
                SetupSidebarMenu();
                SetupCategoryNav();
                SetupHeader();
                StartBannerSlider();
                
                // Hiển thị trang chủ
                ShowHomePage();
            }
            finally
            {
                this.ResumeLayout(true);
            }
        }
        
        private void InitializeCustomer()
        {
            try
            {
                if (CurrentUser.IsLoggedIn)
                {
                    // Gọi GetOrCreateKhachHang để đảm bảo có KhachHang và MaKH được set
                    var kh = _khService.GetOrCreateKhachHang();
                    if (kh != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"Customer initialized: MaKH={kh.MaKH}");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Customer initialization failed - no KhachHang created");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"InitializeCustomer Error: {ex.Message}");
            }
        }

        #region UI Setup

        private void SetupHeader()
        {
            if (CurrentUser.IsLoggedIn)
            {
                lblDangNhap.Text = $"👤 {CurrentUser.User.HoTen}";
                lblDangNhap.Cursor = Cursors.Hand;
            }
            else
            {
                lblDangNhap.Text = "👤 Đăng nhập";
            }
            UpdateCartCount();
        }

        private void SetupCategoryNav()
        {
            flowNav.SuspendLayout();
            flowNav.Controls.Clear();

            var categories = new[] { "Thương hiệu", "Khuyến mãi hot", "Trang điểm", 
                "Chăm sóc da mặt", "Chăm sóc cơ thể", "Sản phẩm mới" };

            foreach (var cat in categories)
            {
                var btn = new LinkLabel
                {
                    Text = cat,
                    Font = new Font("Segoe UI", 9.5F),
                    LinkColor = Color.FromArgb(60, 60, 60),
                    ActiveLinkColor = _primaryPurple,
                    LinkBehavior = LinkBehavior.HoverUnderline,
                    AutoSize = true,
                    Margin = new Padding(15, 5, 15, 5),
                    Padding = new Padding(5)
                };
                string category = cat;
                btn.Click += (s, e) => { ShowProductsPage(); lblSectionTitle.Text = $"📦 {category.ToUpper()}"; };
                flowNav.Controls.Add(btn);
            }
            flowNav.ResumeLayout(true);
        }

        private void SetupSidebarMenu()
        {
            flowSidebar.SuspendLayout();
            flowSidebar.Controls.Clear();

            var menuItems = new[]
            {
                ("🏠", "Trang chủ", new Action(ShowHomePage)),
                ("🛍️", "Sản phẩm", new Action(ShowProductsPage)),
                ("📋", "Hóa đơn mua hàng", new Action(ShowInvoicesPage)),
                ("💳", "Thanh toán", new Action(ShowPaymentPage)),
                ("👤", "Thông tin tài khoản", new Action(ShowAccountInfoPage))
            };

            foreach (var (icon, text, action) in menuItems)
            {
                flowSidebar.Controls.Add(CreateSidebarMenuItem(icon, text, action));
            }

            var logoutItem = CreateSidebarMenuItem("🚪", "Đăng xuất", new Action(() => btnDangXuat_Click(this, EventArgs.Empty)));
            logoutItem.Margin = new Padding(5, 30, 5, 5);
            flowSidebar.Controls.Add(logoutItem);
            flowSidebar.ResumeLayout(true);
        }

        private Panel CreateSidebarMenuItem(string icon, string text, Action clickAction)
        {
            var panel = new Panel
            {
                Size = new Size(flowSidebar.Width - 10, 50),
                Margin = new Padding(3),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Tag = text
            };

            var lblIcon = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI Emoji", 16F),
                Size = new Size(48, 50),
                Location = new Point(5, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };

            var lblText = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.FromArgb(60, 60, 60),
                Size = new Size(150, 50),
                Location = new Point(55, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
                AutoEllipsis = true
            };

            panel.Controls.Add(lblIcon);
            panel.Controls.Add(lblText);

            EventHandler clickHandler = (s, e) => { SetActiveMenu(text); clickAction(); };
            panel.Click += clickHandler;
            lblIcon.Click += clickHandler;
            lblText.Click += clickHandler;

            return panel;
        }

        private void SetActiveMenu(string menuName)
        {
            _currentMenu = menuName;
            
            foreach (Control ctrl in flowSidebar.Controls)
            {
                if (ctrl is Panel panel)
                {
                    bool isActive = panel.Tag?.ToString() == menuName;
                    panel.BackColor = isActive ? Color.FromArgb(220, 200, 240) : Color.Transparent;
                    if (isActive) _activeMenuPanel = panel;
                    
                    foreach (Control child in panel.Controls)
                    {
                        if (child is Label lbl && lbl.Location.X > 40)
                        {
                            lbl.Font = new Font("Segoe UI", 10.5F, isActive ? FontStyle.Bold : FontStyle.Regular);
                            lbl.ForeColor = isActive ? _primaryPurple : Color.FromArgb(60, 60, 60);
                        }
                    }
                }
            }
        }

        #endregion

        #region Banner

        private void StartBannerSlider()
        {
            _bannerTimer = new Timer { Interval = 4000 };
            _bannerTimer.Tick += (s, e) =>
            {
                _currentBannerIndex = (_currentBannerIndex + 1) % _bannerTexts.Length;
                lblBannerMain.Text = _bannerTexts[_currentBannerIndex];
                UpdateBannerDots();
            };
            _bannerTimer.Start();
            lblBannerMain.Text = _bannerTexts[0];
            UpdateBannerDots();
        }

        private void UpdateBannerDots()
        {
            string dots = "";
            for (int i = 0; i < _bannerTexts.Length; i++)
                dots += (i == _currentBannerIndex) ? " ● " : " ○ ";
            lblBannerDots.Text = dots;
        }

        private void btnBannerPrev_Click(object sender, EventArgs e)
        {
            _currentBannerIndex = (_currentBannerIndex - 1 + _bannerTexts.Length) % _bannerTexts.Length;
            lblBannerMain.Text = _bannerTexts[_currentBannerIndex];
            UpdateBannerDots();
        }

        private void btnBannerNext_Click(object sender, EventArgs e)
        {
            _currentBannerIndex = (_currentBannerIndex + 1) % _bannerTexts.Length;
            lblBannerMain.Text = _bannerTexts[_currentBannerIndex];
            UpdateBannerDots();
        }

        #endregion

        #region Page Navigation - QUAN TRỌNG: Quản lý hiển thị panels

        /// <summary>
        /// Ẩn tất cả panels con trong pnlMainArea (trừ pnlHero và pnlProducts)
        /// </summary>
        private void HideAllDynamicPanels()
        {
            var toRemove = pnlMainArea.Controls.Cast<Control>()
                .Where(c => c != pnlHero && c != pnlProducts)
                .ToList();
            
            foreach (var ctrl in toRemove)
            {
                pnlMainArea.Controls.Remove(ctrl);
                ctrl.Dispose();
            }
        }

        /// <summary>
        /// Cập nhật vị trí pnlProducts dựa trên pnlHero
        /// </summary>
        private void UpdateProductsPosition()
        {
            if (pnlHero.Visible)
            {
                pnlProducts.Location = new Point(0, pnlHero.Bottom + 5);
            }
            else
            {
                pnlProducts.Location = new Point(0, 0);
            }
            pnlProducts.Height = pnlMainArea.Height - pnlProducts.Top - 10;
        }

        private void ShowHomePage()
        {
            SetActiveMenu("Trang chủ");
            HideAllDynamicPanels();
            
            pnlHero.Visible = true;
            pnlProducts.Visible = true;
            UpdateProductsPosition();
            
            lblSectionTitle.Text = "🔥 TOP SẢN PHẨM BÁN CHẠY";
            LoadTopProducts();
        }

        private void ShowProductsPage()
        {
            SetActiveMenu("Sản phẩm");
            HideAllDynamicPanels();
            
            pnlHero.Visible = false;
            pnlProducts.Visible = true;
            UpdateProductsPosition();
            
            lblSectionTitle.Text = "🛍️ TẤT CẢ SẢN PHẨM";
            LoadAllProducts();
        }

        private void ShowInvoicesPage()
        {
            SetActiveMenu("Hóa đơn mua hàng");
            HideAllDynamicPanels();
            
            pnlHero.Visible = false;
            pnlProducts.Visible = false;
            
            ShowInvoicesList();
        }

        private void ShowPaymentPage()
        {
            SetActiveMenu("Thanh toán");
            HideAllDynamicPanels();
            
            pnlHero.Visible = false;
            pnlProducts.Visible = false;
            
            ShowPaymentPanel();
        }

        private void ShowAccountInfoPage()
        {
            SetActiveMenu("Thông tin tài khoản");
            HideAllDynamicPanels();
            
            pnlHero.Visible = false;
            pnlProducts.Visible = false;
            
            ShowAccountInfo();
        }

        #endregion

        #region Products

        private void LoadTopProducts()
        {
            if (_cachedTopProducts != null && (DateTime.Now - _lastProductLoad).TotalMinutes < 5)
            {
                DisplayProducts(_cachedTopProducts);
                return;
            }
            
            var products = _khService.GetTopProducts(6);
            _cachedTopProducts = products;
            _lastProductLoad = DateTime.Now;
            DisplayProducts(products);
        }

        private void LoadAllProducts()
        {
            if (_cachedAllProducts != null && (DateTime.Now - _lastProductLoad).TotalMinutes < 5)
            {
                DisplayProducts(_cachedAllProducts);
                return;
            }
            
            var products = _khService.GetAllProducts(1, 20);
            _cachedAllProducts = products;
            _lastProductLoad = DateTime.Now;
            DisplayProducts(products);
        }

        private void DisplayProducts(List<SanPhamDTO> products)
        {
            flowProducts.SuspendLayout();
            
            foreach (Control ctrl in flowProducts.Controls)
                ctrl.Dispose();
            flowProducts.Controls.Clear();

            if (products == null || products.Count == 0)
            {
                flowProducts.Controls.Add(new Label
                {
                    Text = "📭 Không có sản phẩm nào",
                    Font = new Font("Segoe UI", 14F),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(20)
                });
            }
            else
            {
                foreach (var sp in products)
                    flowProducts.Controls.Add(CreateProductCard(sp));
            }

            flowProducts.ResumeLayout(true);
        }

        private Panel CreateProductCard(SanPhamDTO sp)
        {
            var card = new Panel
            {
                Size = new Size(200, 280),
                BackColor = Color.White,
                Margin = new Padding(8),
                Cursor = Cursors.Hand,
                BorderStyle = BorderStyle.FixedSingle
            };

            // FREESHIP Badge
            card.Controls.Add(new Label
            {
                Text = "FREESHIP",
                Font = new Font("Segoe UI", 7F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = _accentGreen,
                Size = new Size(55, 16),
                Location = new Point(5, 5),
                TextAlign = ContentAlignment.MiddleCenter
            });

            // Price Badge
            card.Controls.Add(new Label
            {
                Text = sp.GiaShort,
                Font = new Font("Segoe UI", 7F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = _accentRed,
                Size = new Size(50, 16),
                Location = new Point(card.Width - 57, 5),
                TextAlign = ContentAlignment.MiddleCenter
            });

            // Product Image placeholder
            var picProduct = new Panel
            {
                Size = new Size(180, 100),
                Location = new Point(10, 28),
                BackColor = Color.FromArgb(248, 248, 252)
            };
            picProduct.Controls.Add(new Label
            {
                Text = "🧴",
                Font = new Font("Segoe UI Emoji", 32F),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(200, 180, 220)
            });
            card.Controls.Add(picProduct);

            // Brand
            card.Controls.Add(new Label
            {
                Text = sp.TenThuongHieu?.ToUpper() ?? "N/A",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.Gray,
                Location = new Point(10, 135),
                Size = new Size(180, 16),
                AutoEllipsis = true
            });

            // Product Name
            card.Controls.Add(new Label
            {
                Text = sp.TenSP,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(45, 45, 48),
                Location = new Point(10, 153),
                Size = new Size(180, 35),
                AutoEllipsis = true
            });

            // Rating
            card.Controls.Add(new Label
            {
                Text = "★★★★★",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(255, 193, 7),
                Location = new Point(10, 192),
                Size = new Size(80, 16)
            });

            // Price
            card.Controls.Add(new Label
            {
                Text = sp.GiaFormatted,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = _accentRed,
                Location = new Point(10, 212),
                Size = new Size(120, 22)
            });

            // Add to cart button
            var btnAddCart = new Button
            {
                Text = "🛒",
                Font = new Font("Segoe UI Emoji", 12F),
                Size = new Size(40, 35),
                Location = new Point(card.Width - 50, 210),
                FlatStyle = FlatStyle.Flat,
                BackColor = _lightPurple,
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnAddCart.FlatAppearance.BorderSize = 0;
            
            int maSP = sp.MaSP;
            btnAddCart.Click += (s, e) => AddToCart(maSP);
            card.Controls.Add(btnAddCart);

            card.Click += (s, e) => ShowProductDetail(maSP);
            picProduct.Click += (s, e) => ShowProductDetail(maSP);

            return card;
        }

        #endregion

        #region Invoices

        private void ShowInvoicesList()
        {
            var panel = CreateContentPanel("📋 HÓA ĐƠN MUA HÀNG");

            if (!CurrentUser.IsLoggedIn || CurrentUser.User == null)
            {
                AddNotLoggedInMessage(panel, 80);
                pnlMainArea.Controls.Add(panel);
                return;
            }

            int yPos = 80;
            
            // Lấy hóa đơn từ service
            var hoaDons = _khService.GetMyInvoices();

            if (hoaDons.Count == 0)
            {
                panel.Controls.Add(new Label
                {
                    Text = "📭 Bạn chưa có hóa đơn nào.",
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.Gray,
                    Location = new Point(20, yPos),
                    AutoSize = true
                });
            }
            else
            {
                foreach (var hd in hoaDons)
                {
                    panel.Controls.Add(CreateInvoiceCard(hd, yPos));
                    yPos += 85;
                }
            }

            pnlMainArea.Controls.Add(panel);
        }

        private Panel CreateInvoiceCard(HoaDonDTO hd, int yPos)
        {
            var card = new Panel
            {
                Size = new Size(Math.Min(700, pnlMainArea.Width - 60), 75),
                Location = new Point(20, yPos),
                BackColor = Color.FromArgb(250, 248, 255),
                Cursor = Cursors.Hand,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Xác định trạng thái hiển thị
            string trangThaiHienThi;
            Color trangThaiColor;

            switch (hd.TrangThai)
            {
                case "Đã thanh toán":
                case "Hoàn thành":
                case "Đã giao":
                    trangThaiHienThi = "✅ Đã thanh toán";
                    trangThaiColor = _accentGreen;
                    break;
                case "CHO_DUYET":
                    trangThaiHienThi = "⏳ Chờ duyệt";
                    trangThaiColor = Color.Orange;
                    break;
                case "CHO_XAC_NHAN_TT":
                    trangThaiHienThi = "🔄 Chờ xác nhận TT";
                    trangThaiColor = Color.DodgerBlue;
                    break;
                case "DA_DUYET":
                    trangThaiHienThi = "📋 Đã duyệt";
                    trangThaiColor = Color.MediumSeaGreen;
                    break;
                case "Đang giao":
                    trangThaiHienThi = "🚚 Đang giao";
                    trangThaiColor = Color.DodgerBlue;
                    break;
                case "Hủy":
                    trangThaiHienThi = "❌ Đã hủy";
                    trangThaiColor = _accentRed;
                    break;
                default:
                    trangThaiHienThi = "⏳ Chờ thanh toán";
                    trangThaiColor = Color.Orange;
                    break;
            }

            card.Controls.Add(new Label
            {
                Text = $"🧾 #{hd.MaHD} | 📅 {hd.NgayFormatted} | 💰 {hd.TongTienFormatted}",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = _primaryPurple,
                Location = new Point(10, 12),
                AutoSize = true
            });

            card.Controls.Add(new Label
            {
                Text = $"{trangThaiHienThi} | 📦 {hd.SoSanPham} SP",
                Font = new Font("Segoe UI", 10F),
                ForeColor = trangThaiColor,
                Location = new Point(10, 42),
                AutoSize = true
            });

            int maHD = hd.MaHD;
            card.Click += (s, e) => ShowInvoiceDetailDialog(maHD);

            return card;
        }

        private void ShowInvoiceDetailDialog(int maHD)
        {
            var detail = _khService.GetInvoiceDetail(maHD);
            if (detail == null)
            {
                XtraMessageBox.Show("Không tìm thấy hóa đơn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string message = $"══ HÓA ĐƠN #{detail.MaHD} ══\n\n";
            message += $"📅 Ngày: {detail.NgayLap:dd/MM/yyyy}\n";
            message += $"📊 Trạng thái: {detail.TrangThai}\n\n";
            message += "── SẢN PHẨM ──\n";

            foreach (var ct in detail.ChiTiet)
            {
                message += $"• {ct.TenSP}: {ct.SoLuong} x {ct.DonGiaFormatted} = {ct.ThanhTienFormatted}\n";
            }

            message += $"\n💰 TỔNG: {detail.TongTienFormatted}";

            XtraMessageBox.Show(message, "Chi tiết hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Payment

        private void ShowPaymentPanel()
        {
            var panel = CreateContentPanel("💳 THANH TOÁN HÓA ĐƠN");

            if (!CurrentUser.IsLoggedIn || CurrentUser.User == null)
            {
                AddNotLoggedInMessage(panel, 80);
                pnlMainArea.Controls.Add(panel);
                return;
            }

            // Lấy hóa đơn chưa thanh toán từ service
            var unpaidInvoices = _khService.GetUnpaidInvoices();

            if (unpaidInvoices.Count == 0)
            {
                panel.Controls.Add(new Label
                {
                    Text = "✅ Tất cả hóa đơn đã được thanh toán!",
                    Font = new Font("Segoe UI", 14F),
                    ForeColor = _accentGreen,
                    Location = new Point(20, 80),
                    AutoSize = true
                });
            }
            else
            {
                int yPos = 80;
                foreach (var hd in unpaidInvoices)
                {
                    panel.Controls.Add(CreatePaymentCard(hd, yPos));
                    yPos += 110;
                }
            }

            pnlMainArea.Controls.Add(panel);
        }

        private Panel CreatePaymentCard(HoaDonDTO hd, int yPos)
        {
            var card = new Panel
            {
                Size = new Size(Math.Min(650, pnlMainArea.Width - 60), 100),
                Location = new Point(20, yPos),
                BackColor = Color.FromArgb(255, 250, 245),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Xác định trạng thái hiển thị
            string trangThaiHienThi;
            Color trangThaiColor;
            bool canSelectPayment = false;

            switch (hd.TrangThai)
            {
                case "CHO_DUYET":
                    trangThaiHienThi = "⏳ Chờ nhân viên duyệt";
                    trangThaiColor = Color.Orange;
                    break;
                case "CHO_XAC_NHAN_TT":
                    trangThaiHienThi = "🔄 Chờ xác nhận thanh toán";
                    trangThaiColor = Color.DodgerBlue;
                    break;
                case "DA_DUYET":
                    trangThaiHienThi = "✅ Đã duyệt - Chờ thanh toán";
                    trangThaiColor = _accentGreen;
                    canSelectPayment = true;
                    break;
                default:
                    trangThaiHienThi = "📝 Chờ chọn phương thức thanh toán";
                    trangThaiColor = Color.Gray;
                    canSelectPayment = true;
                    break;
            }

            card.Controls.Add(new Label
            {
                Text = $"🧾 HĐ #{hd.MaHD} | {hd.NgayFormatted} | {hd.TongTienFormatted}",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            });

            card.Controls.Add(new Label
            {
                Text = trangThaiHienThi,
                Font = new Font("Segoe UI", 10F),
                ForeColor = trangThaiColor,
                Location = new Point(10, 35),
                AutoSize = true
            });

            // Chỉ hiển thị nút thanh toán nếu có thể chọn
            if (canSelectPayment)
            {
                int btnX = 10;
                var methods = new[] { ("COD", "🚚 COD"), ("Bank", "🏦 Chuyển khoản") };

                foreach (var (method, text) in methods)
                {
                    var btn = new Button
                    {
                        Text = text,
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                        Size = new Size(130, 30),
                        Location = new Point(btnX, 62),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = _lightPurple,
                        ForeColor = Color.White,
                        Cursor = Cursors.Hand
                    };
                    btn.FlatAppearance.BorderSize = 0;
                    
                    int maHD = hd.MaHD;
                    string payMethod = method;
                    btn.Click += (s, e) => ProcessPayment(maHD, payMethod);
                    card.Controls.Add(btn);
                    btnX += 140;
                }
            }
            else
            {
                // Hiển thị phương thức thanh toán đã chọn
                if (!string.IsNullOrEmpty(hd.PhuongThucTT))
                {
                    card.Controls.Add(new Label
                    {
                        Text = $"💳 Phương thức: {hd.PhuongThucTT}",
                        Font = new Font("Segoe UI", 9F),
                        ForeColor = Color.Gray,
                        Location = new Point(10, 62),
                        AutoSize = true
                    });
                }
            }

            return card;
        }

        private void ProcessPayment(int maHD, string paymentMethod)
        {
            string confirmMessage = paymentMethod == "COD"
                ? $"Xác nhận chọn thanh toán khi nhận hàng (COD) cho hóa đơn #{maHD}?\n\n" +
                  "📝 Đơn hàng sẽ được gửi cho nhân viên xác nhận.\n" +
                  "📦 Bạn sẽ thanh toán khi nhận hàng."
                : $"Xác nhận đã chuyển khoản cho hóa đơn #{maHD}?\n\n" +
                  "⚠️ Vui lòng chỉ xác nhận sau khi đã hoàn tất chuyển khoản.\n" +
                  "📝 Nhân viên sẽ kiểm tra và xác nhận thanh toán.";

            var dialogResult = XtraMessageBox.Show(confirmMessage,
                paymentMethod == "COD" ? "Xác nhận phương thức thanh toán" : "Xác nhận chuyển khoản",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                var result = _khService.SelectPaymentMethod(maHD, paymentMethod);

                if (result.Success)
                {
                    XtraMessageBox.Show(
                        $"✅ {result.Message}\n\n" +
                        $"📝 Mã đơn hàng: #{maHD}",
                        "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ShowPaymentPage();
                }
                else
                {
                    XtraMessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Account Info

        private void ShowAccountInfo()
        {
            var panel = CreateContentPanel("👤 THÔNG TIN TÀI KHOẢN");

            if (!CurrentUser.IsLoggedIn || CurrentUser.User == null)
            {
                AddNotLoggedInMessage(panel, 80);
                pnlMainArea.Controls.Add(panel);
                return;
            }

            // Lấy thông tin từ service
            var accountInfo = _khService.GetAccountInfo();
            
            string hoTen = accountInfo?.HoTen ?? CurrentUser.User.HoTen ?? "Chưa cập nhật";
            string email = accountInfo?.Email ?? CurrentUser.User.Email ?? "Chưa cập nhật";
            string tenDN = CurrentUser.User.TenDN ?? "Chưa cập nhật";
            string sdt = !string.IsNullOrEmpty(accountInfo?.SDT) ? accountInfo.SDT : "Chưa cập nhật";
            string diaChi = !string.IsNullOrEmpty(accountInfo?.DiaChi) ? accountInfo.DiaChi : "Chưa cập nhật";
            string gioiTinh = !string.IsNullOrEmpty(accountInfo?.GioiTinh) ? accountInfo.GioiTinh : "Chưa cập nhật";

            var infoItems = new[]
            {
                ("Họ tên:", hoTen),
                ("Email:", email),
                ("Tài khoản:", tenDN),
                ("SĐT:", sdt),
                ("Địa chỉ:", diaChi),
                ("Giới tính:", gioiTinh)
            };

            int yPos = 80;
            foreach (var (label, value) in infoItems)
            {
                panel.Controls.Add(new Label
                {
                    Text = label,
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.Gray,
                    Location = new Point(20, yPos),
                    Size = new Size(100, 22)
                });

                panel.Controls.Add(new Label
                {
                    Text = value,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = value == "Chưa cập nhật" ? Color.OrangeRed : Color.FromArgb(45, 45, 48),
                    Location = new Point(130, yPos),
                    AutoSize = true,
                    MaximumSize = new Size(400, 0)
                });
                yPos += 30;
            }

            // Nút chỉnh sửa thông tin
            yPos += 20;
            var btnEdit = new Button
            {
                Text = "✏️ Cập nhật thông tin",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Size = new Size(180, 40),
                Location = new Point(20, yPos),
                FlatStyle = FlatStyle.Flat,
                BackColor = _lightPurple,
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Click += (s, e) => ShowEditAccountForm();
            panel.Controls.Add(btnEdit);

            pnlMainArea.Controls.Add(panel);
        }

        private void ShowEditAccountForm()
        {
            var accountInfo = _khService.GetAccountInfo();
            
            using (var form = new Form())
            {
                form.Text = "✏️ Cập nhật thông tin";
                form.Size = new Size(450, 380);
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.BackColor = Color.White;

                int yPos = 20;

                // Title
                form.Controls.Add(new Label
                {
                    Text = "CẬP NHẬT THÔNG TIN CÁ NHÂN",
                    Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                    ForeColor = _primaryPurple,
                    Location = new Point(20, yPos),
                    AutoSize = true
                });
                yPos += 45;

                // Họ tên
                form.Controls.Add(new Label
                {
                    Text = "Họ tên:",
                    Font = new Font("Segoe UI", 10F),
                    Location = new Point(20, yPos),
                    Size = new Size(80, 22)
                });
                var txtHoTen = new TextBox
                {
                    Name = "txtHoTen",
                    Text = accountInfo?.HoTen ?? "",
                    Font = new Font("Segoe UI", 10F),
                    Location = new Point(110, yPos),
                    Size = new Size(300, 25)
                };
                form.Controls.Add(txtHoTen);
                yPos += 35;

                // SĐT
                form.Controls.Add(new Label
                {
                    Text = "SĐT:",
                    Font = new Font("Segoe UI", 10F),
                    Location = new Point(20, yPos),
                    Size = new Size(80, 22)
                });
                var txtSDT = new TextBox
                {
                    Name = "txtSDT",
                    Text = accountInfo?.SDT ?? "",
                    Font = new Font("Segoe UI", 10F),
                    Location = new Point(110, yPos),
                    Size = new Size(300, 25)
                };
                form.Controls.Add(txtSDT);
                yPos += 35;

                // Địa chỉ
                form.Controls.Add(new Label
                {
                    Text = "Địa chỉ:",
                    Font = new Font("Segoe UI", 10F),
                    Location = new Point(20, yPos),
                    Size = new Size(80, 22)
                });
                var txtDiaChi = new TextBox
                {
                    Name = "txtDiaChi",
                    Text = accountInfo?.DiaChi ?? "",
                    Font = new Font("Segoe UI", 10F),
                    Location = new Point(110, yPos),
                    Size = new Size(300, 50),
                    Multiline = true
                };
                form.Controls.Add(txtDiaChi);
                yPos += 60;

                // Giới tính
                form.Controls.Add(new Label
                {
                    Text = "Giới tính:",
                    Font = new Font("Segoe UI", 10F),
                    Location = new Point(20, yPos),
                    Size = new Size(80, 22)
                });
                var cboGioiTinh = new System.Windows.Forms.ComboBox
                {
                    Name = "cboGioiTinh",
                    Font = new Font("Segoe UI", 10F),
                    Location = new Point(110, yPos),
                    Size = new Size(150, 25),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cboGioiTinh.Items.AddRange(new[] { "Nam", "Nữ", "Khác" });
                cboGioiTinh.SelectedItem = accountInfo?.GioiTinh ?? "Khác";
                form.Controls.Add(cboGioiTinh);
                yPos += 45;

                // Buttons
                var btnSave = new Button
                {
                    Text = "💾 Lưu thay đổi",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Size = new Size(140, 38),
                    Location = new Point(110, yPos),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = _accentGreen,
                    ForeColor = Color.White,
                    Cursor = Cursors.Hand,
                    DialogResult = DialogResult.OK
                };
                btnSave.FlatAppearance.BorderSize = 0;
                form.Controls.Add(btnSave);

                var btnCancel = new Button
                {
                    Text = "❌ Hủy",
                    Font = new Font("Segoe UI", 10F),
                    Size = new Size(100, 38),
                    Location = new Point(260, yPos),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(189, 195, 199),
                    ForeColor = Color.White,
                    Cursor = Cursors.Hand,
                    DialogResult = DialogResult.Cancel
                };
                btnCancel.FlatAppearance.BorderSize = 0;
                form.Controls.Add(btnCancel);

                form.AcceptButton = btnSave;
                form.CancelButton = btnCancel;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Lưu thông tin
                    bool success = _khService.UpdateCustomerInfo(
                        txtHoTen.Text.Trim(),
                        txtSDT.Text.Trim(),
                        txtDiaChi.Text.Trim(),
                        null, // Không đổi email
                        cboGioiTinh.SelectedItem?.ToString()
                    );

                    if (success)
                    {
                        XtraMessageBox.Show("✅ Cập nhật thông tin thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Refresh trang thông tin
                        ShowAccountInfoPage();
                    }
                    else
                    {
                        XtraMessageBox.Show("❌ Có lỗi xảy ra khi cập nhật!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region Cart & Actions

        private void AddToCart(int maSP)
        {
            var result = _khService.AddToCart(maSP);
            
            if (result.Success)
            {
                UpdateCartCount();
                XtraMessageBox.Show($"✅ {result.Message}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show($"❌ {result.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateCartCount()
        {
            int count = _khService.GetCartCount();
            lblGioHang.Text = $"🛒 Giỏ ({count})";
        }

        private void ShowProductDetail(int maSP)
        {
            var product = _khService.GetProductById(maSP);
                
            if (product != null)
            {
                using (var form = new fSanPhamDetail(product))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var qty = form.SelectedQuantity;
                        if (qty <= 0) qty = 1;
                        var result = _khService.AddToCart(maSP, qty);
                        if (result.Success)
                        {
                            UpdateCartCount();
                            XtraMessageBox.Show($"✅ {result.Message}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void btnGioHang_Click(object sender, EventArgs e)
        {
            var cartItems = _khService.GetCartItems();
            
            if (cartItems.Count == 0)
            {
                XtraMessageBox.Show("🛒 Giỏ hàng trống!", "Giỏ hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var form = new fGioHang())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateCartCount();
                    _cachedTopProducts = null;
                    _cachedAllProducts = null;
                    ShowHomePage();
                }
            }
        }

        #endregion

        #region Search

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                ShowHomePage();
                return;
            }

            HideAllDynamicPanels();
            pnlHero.Visible = false;
            pnlProducts.Visible = true;
            UpdateProductsPosition();
            
            lblSectionTitle.Text = $"🔍 \"{keyword.ToUpper()}\"";
            var products = _khService.SearchProducts(keyword);
            DisplayProducts(products);
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
                e.Handled = true;
            }
        }

        #endregion

        #region Helper Methods

        private Panel CreateContentPanel(string title)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20),
                AutoScroll = true
            };

            panel.Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = _primaryPurple,
                Location = new Point(20, 25),
                AutoSize = true
            });

            return panel;
        }

        private void AddNotLoggedInMessage(Panel panel, int yPos)
        {
            panel.Controls.Add(new Label
            {
                Text = "⚠️ Vui lòng đăng nhập để sử dụng chức năng này.",
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.OrangeRed,
                Location = new Point(20, yPos),
                AutoSize = true
            });
        }

        #endregion

        #region Events

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _khService.ClearCart();
                CurrentUser.Logout();
                this.Hide();
                var loginForm = new Forms.fLogin();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

        private void btnMuaNgay_Click(object sender, EventArgs e)
        {
            ShowProductsPage();
        }

        private void lblDangNhap_Click(object sender, EventArgs e)
        {
            if (CurrentUser.IsLoggedIn)
                ShowAccountInfoPage();
        }

        private void searchControl_TextChanged(object sender, EventArgs e) { }

        #endregion

        #region Cleanup

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (CurrentUser.IsLoggedIn)
            {
                var result = XtraMessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    CurrentUser.Logout();
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
            base.OnFormClosing(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bannerTimer?.Stop();
                _bannerTimer?.Dispose();
                _khService?.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        private void flowSidebar_Paint(object sender, PaintEventArgs e) { }
    }
}
