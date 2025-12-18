using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using BusinessAccessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormKH
{
    /// <summary>
    /// Dashboard chính cho KHÁCH HÀNG (USER)
    /// Thiết kế hiện đại lấy cảm hứng từ BeautyBox/Sephora
    /// CHỈ có quyền: Xem sản phẩm, Xem hóa đơn, Thanh toán, Thông tin tài khoản
    /// KHÔNG có quyền: Admin, Báo cáo, Kho hàng, Nhân sự, Cấu hình
    /// </summary>
    public partial class fDashboardKH : DevExpress.XtraEditors.XtraForm
    {
        private KHService _khService;
        private CosmeticsContext _context;
        private Timer _bannerTimer;
        private Timer _hoverTimer;
        private Timer _promoScrollTimer;
        private int _currentBannerIndex = 0;
        private int _promoScrollPos = 0;
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
        private readonly Color _pastelPink = Color.FromArgb(255, 182, 193);
        private readonly Color _lightBg = Color.FromArgb(250, 248, 255);
        private readonly Color _accentGreen = Color.FromArgb(46, 204, 113);
        private readonly Color _accentRed = Color.FromArgb(231, 76, 60);

        // Menu hiện tại
        private string _currentMenu = "Trang chủ";
        private Panel _activeMenuPanel = null;

        public fDashboardKH()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            _khService = new KHService(_context);
            this.Load += fDashboardKH_Load;
            this.Resize += fDashboardKH_Resize;
            this.DoubleBuffered = true;
            
            // Enable double buffering for smoother rendering
            SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                     ControlStyles.AllPaintingInWmPaint | 
                     ControlStyles.UserPaint, true);
        }

        private void fDashboardKH_Load(object sender, EventArgs e)
        {
            // Seed sample products nếu chưa có
            _khService.SeedSampleProducts();
            
            SetupModernUI();
            SetupSidebarMenu();
            SetupCategoryNav();
            SetupHeader();
            ShowHomePage();
            StartBannerSlider();
            StartPromoScroll();
            AdjustLayoutForScreenSize();
        }

        private void fDashboardKH_Resize(object sender, EventArgs e)
        {
            AdjustLayoutForScreenSize();
        }

        #region Responsive Layout

        private void AdjustLayoutForScreenSize()
        {
            int screenWidth = this.ClientSize.Width;
            int screenHeight = this.ClientSize.Height;
            int sidebarWidth = pnlSidebar.Width;
            int mainWidth = screenWidth - sidebarWidth;

            // Điều chỉnh Hero section
            if (pnlHero.Visible)
            {
                // Banner chính chiếm 65% chiều rộng
                int bannerMainWidth = (int)(mainWidth * 0.62);
                int bannerSideWidth = (int)(mainWidth * 0.32);
                int bannerHeight = Math.Min(280, (int)(screenHeight * 0.35));

                pnlBannerMain.Size = new Size(bannerMainWidth, bannerHeight - 30);
                pnlBannerMain.Location = new Point(15, 15);

                pnlBannerSide1.Size = new Size(bannerSideWidth, (bannerHeight - 40) / 2);
                pnlBannerSide1.Location = new Point(bannerMainWidth + 30, 15);

                pnlBannerSide2.Size = new Size(bannerSideWidth, (bannerHeight - 40) / 2);
                pnlBannerSide2.Location = new Point(bannerMainWidth + 30, pnlBannerSide1.Bottom + 10);

                pnlHero.Height = bannerHeight;

                // Điều chỉnh nút banner
                btnBannerNext.Location = new Point(pnlBannerMain.Width - 50, pnlBannerMain.Height / 2 - 25);
            }

            // Điều chỉnh Product section
            if (pnlProducts.Visible)
            {
                lblSectionTitle.Location = new Point((pnlProducts.Width - lblSectionTitle.Width) / 2, 10);
                btnXemTatCa.Location = new Point((pnlProducts.Width - btnXemTatCa.Width) / 2, pnlProducts.Height - 45);
            }

            // Điều chỉnh số cột product cards
            AdjustProductGrid();

            // Refresh rounded corners
            ApplyRoundedCorners(pnlBannerMain, 15);
            ApplyRoundedCorners(pnlBannerSide1, 10);
            ApplyRoundedCorners(pnlBannerSide2, 10);
        }

        private void AdjustProductGrid()
        {
            if (flowProducts == null) return;

            int availableWidth = flowProducts.Width - 30;
            int cardWidth = 200;
            int cardMargin = 20;
            int columns = Math.Max(1, availableWidth / (cardWidth + cardMargin));

            // Điều chỉnh kích thước card dựa trên không gian có sẵn
            int newCardWidth = (availableWidth - (columns * cardMargin)) / columns;
            newCardWidth = Math.Max(180, Math.Min(220, newCardWidth));

            foreach (Control ctrl in flowProducts.Controls)
            {
                if (ctrl is Panel card && card.Tag?.ToString() == "ProductCard")
                {
                    card.Width = newCardWidth;
                }
            }
        }

        #endregion

        #region UI Setup

        private void SetupModernUI()
        {
            this.BackColor = _lightBg;
            ApplyRoundedCorners(pnlBannerMain, 15);
            ApplyRoundedCorners(pnlBannerSide1, 10);
            ApplyRoundedCorners(pnlBannerSide2, 10);
        }

        private void ApplyRoundedCorners(Control control, int radius)
        {
            if (control == null || control.Width <= radius * 2 || control.Height <= radius * 2) return;
            
            try
            {
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                path.CloseAllFigures();
                control.Region = new Region(path);
            }
            catch { }
        }

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
            AddHoverEffect(lblGioHang);
            AddHoverEffect(lblDangNhap);
            AddHoverEffect(lblYeuThich);
        }

        private void SetupCategoryNav()
        {
            flowNav.Controls.Clear();

            var categories = new[]
            {
                "Thương hiệu", "Khuyến mãi hot", "Trang điểm", 
                "Chăm sóc da mặt", "Chăm sóc cơ thể", "Sản phẩm mới",
                "Đặt hàng Online & Nhận tại cửa hàng"
            };

            foreach (var cat in categories)
            {
                var btn = new LinkLabel
                {
                    Text = cat,
                    Font = new Font("Segoe UI", 9.5F),
                    LinkColor = Color.FromArgb(60, 60, 60),
                    ActiveLinkColor = _primaryPurple,
                    VisitedLinkColor = Color.FromArgb(60, 60, 60),
                    LinkBehavior = LinkBehavior.HoverUnderline,
                    AutoSize = true,
                    Margin = new Padding(15, 5, 15, 5),
                    Padding = new Padding(5)
                };
                btn.Click += (s, e) => FilterByCategory(cat);
                flowNav.Controls.Add(btn);
            }
        }

        private void FilterByCategory(string category)
        {
            ShowProductsPage();
            lblSectionTitle.Text = $"📦 {category.ToUpper()}";
            // TODO: Filter products by category
        }

        private void AddHoverEffect(Control control)
        {
            Color originalColor = control.ForeColor;
            control.MouseEnter += (s, e) => control.ForeColor = _primaryPurple;
            control.MouseLeave += (s, e) => control.ForeColor = originalColor;
        }

        private void SetupSidebarMenu()
        {
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
                var menuItem = CreateSidebarMenuItem(icon, text, action);
                flowSidebar.Controls.Add(menuItem);
            }

            var logoutItem = CreateSidebarMenuItem("🚪", "Đăng xuất", new Action(DoLogout));
            logoutItem.Margin = new Padding(5, 30, 5, 5);
            flowSidebar.Controls.Add(logoutItem);
        }

        private void DoLogout()
        {
            btnDangXuat_Click(this, EventArgs.Empty);
        }

        private Panel CreateSidebarMenuItem(string icon, string text, Action clickAction)
        {
            var panel = new Panel
            {
                Size = new Size(flowSidebar.Width - 10, 50),
                Margin = new Padding(3, 3, 3, 3),
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
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            var lblText = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                ForeColor = Color.FromArgb(60, 60, 60),
                Size = new Size(150, 50),
                Location = new Point(55, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                AutoEllipsis = true
            };

            panel.Controls.Add(lblIcon);
            panel.Controls.Add(lblText);

            // Hover effect
            panel.MouseEnter += (s, e) => AnimateMenuHover(panel, true);
            panel.MouseLeave += (s, e) => AnimateMenuHover(panel, false);
            lblIcon.MouseEnter += (s, e) => AnimateMenuHover(panel, true);
            lblIcon.MouseLeave += (s, e) => AnimateMenuHover(panel, false);
            lblText.MouseEnter += (s, e) => AnimateMenuHover(panel, true);
            lblText.MouseLeave += (s, e) => AnimateMenuHover(panel, false);

            panel.Click += (s, e) => { SetActiveMenu(text); clickAction(); };
            lblIcon.Click += (s, e) => { SetActiveMenu(text); clickAction(); };
            lblText.Click += (s, e) => { SetActiveMenu(text); clickAction(); };

            return panel;
        }

        private void AnimateMenuHover(Panel panel, bool isHovering)
        {
            if (_activeMenuPanel == panel) return;
            panel.BackColor = isHovering ? Color.FromArgb(240, 230, 250) : Color.Transparent;
        }

        private void SetActiveMenu(string menuName)
        {
            _currentMenu = menuName;
            
            foreach (Control ctrl in flowSidebar.Controls)
            {
                if (ctrl is Panel panel)
                {
                    bool isActive = panel.Tag?.ToString() == menuName;
                    if (isActive)
                    {
                        panel.BackColor = Color.FromArgb(220, 200, 240);
                        _activeMenuPanel = panel;
                        
                        foreach (Control child in panel.Controls)
                        {
                            if (child is Label lbl && lbl.Location.X > 40)
                            {
                                lbl.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                                lbl.ForeColor = _primaryPurple;
                            }
                        }
                    }
                    else
                    {
                        panel.BackColor = Color.Transparent;
                        foreach (Control child in panel.Controls)
                        {
                            if (child is Label lbl && lbl.Location.X > 40)
                            {
                                lbl.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
                                lbl.ForeColor = Color.FromArgb(60, 60, 60);
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Banner & Promo Animation

        private void StartBannerSlider()
        {
            _bannerTimer = new Timer { Interval = 4000 };
            _bannerTimer.Tick += (s, e) =>
            {
                _currentBannerIndex = (_currentBannerIndex + 1) % _bannerTexts.Length;
                AnimateBannerChange();
            };
            _bannerTimer.Start();
            lblBannerMain.Text = _bannerTexts[0];
            UpdateBannerDots();
        }

        private void StartPromoScroll()
        {
            _promoScrollTimer = new Timer { Interval = 50 };
            _promoScrollTimer.Tick += (s, e) =>
            {
                _promoScrollPos++;
                if (_promoScrollPos > 100) _promoScrollPos = 0;
            };
            _promoScrollTimer.Start();
        }

        private void AnimateBannerChange()
        {
            lblBannerMain.Text = _bannerTexts[_currentBannerIndex];
            UpdateBannerDots();
        }

        private void UpdateBannerDots()
        {
            string dots = "";
            for (int i = 0; i < _bannerTexts.Length; i++)
            {
                dots += (i == _currentBannerIndex) ? " ● " : " ○ ";
            }
            lblBannerDots.Text = dots;
        }

        private void btnBannerPrev_Click(object sender, EventArgs e)
        {
            _currentBannerIndex = (_currentBannerIndex - 1 + _bannerTexts.Length) % _bannerTexts.Length;
            AnimateBannerChange();
        }

        private void btnBannerNext_Click(object sender, EventArgs e)
        {
            _currentBannerIndex = (_currentBannerIndex + 1) % _bannerTexts.Length;
            AnimateBannerChange();
        }

        #endregion

        #region Page Navigation

        private void ShowHomePage()
        {
            SetActiveMenu("Trang chủ");
            pnlHero.Visible = true;
            pnlProducts.Visible = true;
            LoadTopProducts();
            AdjustLayoutForScreenSize();
        }

        private void ShowProductsPage()
        {
            SetActiveMenu("Sản phẩm");
            pnlHero.Visible = false;
            pnlProducts.Visible = true;
            lblSectionTitle.Text = "🛍️ TẤT CẢ SẢN PHẨM";
            LoadAllProducts();
            AdjustLayoutForScreenSize();
        }

        private void ShowInvoicesPage()
        {
            SetActiveMenu("Hóa đơn mua hàng");
            pnlHero.Visible = false;
            pnlProducts.Visible = false;
            ClearMainContent();
            ShowInvoicesList();
        }

        private void ShowPaymentPage()
        {
            SetActiveMenu("Thanh toán");
            pnlHero.Visible = false;
            pnlProducts.Visible = false;
            ClearMainContent();
            ShowPaymentPanel();
        }

        private void ShowAccountInfoPage()
        {
            SetActiveMenu("Thông tin tài khoản");
            pnlHero.Visible = false;
            pnlProducts.Visible = false;
            ClearMainContent();
            ShowAccountInfo();
        }

        private void ClearMainContent()
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

        #endregion

        #region Products

        private void LoadTopProducts()
        {
            lblSectionTitle.Text = "🔥 TOP SẢN PHẨM BÁN CHẠY";
            var products = _khService.GetTopProducts(12);
            DisplayProducts(products);
        }

        private void LoadAllProducts()
        {
            var products = _khService.GetAllProducts(1, 30);
            DisplayProducts(products);
        }

        private void DisplayProducts(List<SanPhamDTO> products)
        {
            flowProducts.Controls.Clear();
            flowProducts.SuspendLayout();

            if (products.Count == 0)
            {
                var lblEmpty = new Label
                {
                    Text = "📭 Không có sản phẩm nào",
                    Font = new Font("Segoe UI", 14F),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(20)
                };
                flowProducts.Controls.Add(lblEmpty);
            }
            else
            {
                foreach (var sp in products)
                {
                    var card = CreateModernProductCard(sp);
                    flowProducts.Controls.Add(card);
                }
            }

            flowProducts.ResumeLayout();
        }

        private Panel CreateModernProductCard(SanPhamDTO sp)
        {
            var card = new Panel
            {
                Size = new Size(200, 310),
                BackColor = Color.White,
                Margin = new Padding(10),
                Cursor = Cursors.Hand,
                Tag = "ProductCard"
            };

            // Shadow effect
            card.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(30, 0, 0, 0), 1))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            // FREESHIP Badge
            var lblFreeship = new Label
            {
                Text = "FREESHIP",
                Font = new Font("Segoe UI", 7F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = _accentGreen,
                Size = new Size(58, 18),
                Location = new Point(8, 8),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblFreeship);

            // Price Badge
            var lblPriceTag = new Label
            {
                Text = sp.GiaShort,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = _accentRed,
                Size = new Size(55, 20),
                Location = new Point(card.Width - 63, 8),
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblPriceTag);

            // Wishlist
            var lblWishlist = new Label
            {
                Text = "♡",
                Font = new Font("Segoe UI", 16F),
                ForeColor = Color.FromArgb(200, 200, 200),
                Size = new Size(30, 30),
                Location = new Point(card.Width - 35, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };
            lblWishlist.Click += (s, e) =>
            {
                lblWishlist.Text = lblWishlist.Text == "♡" ? "♥" : "♡";
                lblWishlist.ForeColor = lblWishlist.Text == "♥" ? Color.Red : Color.FromArgb(200, 200, 200);
            };
            card.Controls.Add(lblWishlist);

            // Product Image
            var picProduct = new Panel
            {
                Size = new Size(180, 135),
                Location = new Point(10, 38),
                BackColor = Color.FromArgb(248, 248, 252),
                Cursor = Cursors.Hand
            };
            
            // Placeholder icon
            var lblImagePlaceholder = new Label
            {
                Text = "🧴",
                Font = new Font("Segoe UI Emoji", 40F),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(200, 180, 220)
            };
            picProduct.Controls.Add(lblImagePlaceholder);
            card.Controls.Add(picProduct);

            // Brand
            var lblBrand = new Label
            {
                Text = sp.TenThuongHieu?.ToUpper() ?? "N/A",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.Gray,
                Location = new Point(10, 178),
                Size = new Size(180, 18),
                AutoEllipsis = true
            };
            card.Controls.Add(lblBrand);

            // Product Name
            var lblName = new Label
            {
                Text = sp.TenSP,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(45, 45, 48),
                Location = new Point(10, 196),
                Size = new Size(180, 42),
                AutoEllipsis = true
            };
            card.Controls.Add(lblName);

            // Rating
            var lblRating = new Label
            {
                Text = "★★★★★ (0)",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(255, 193, 7),
                Location = new Point(10, 240),
                Size = new Size(100, 18)
            };
            card.Controls.Add(lblRating);

            // Price
            var lblPrice = new Label
            {
                Text = sp.GiaFormatted,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = _accentRed,
                Location = new Point(10, 260),
                Size = new Size(130, 25)
            };
            card.Controls.Add(lblPrice);

            // Add to cart button
            var btnAddCart = new Button
            {
                Text = "🛒",
                Font = new Font("Segoe UI Emoji", 14F),
                Size = new Size(45, 40),
                Location = new Point(card.Width - 55, 260),
                FlatStyle = FlatStyle.Flat,
                BackColor = _lightPurple,
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnAddCart.FlatAppearance.BorderSize = 0;
            btnAddCart.Click += (s, e) => AddToCart(sp.MaSP);
            card.Controls.Add(btnAddCart);

            // Hover effects
            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(252, 250, 255);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;
            picProduct.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(252, 250, 255);
            picProduct.MouseLeave += (s, e) => card.BackColor = Color.White;

            // Click for detail
            card.Click += (s, e) => ShowProductDetail(sp.MaSP);
            picProduct.Click += (s, e) => ShowProductDetail(sp.MaSP);
            lblName.Click += (s, e) => ShowProductDetail(sp.MaSP);

            return card;
        }

        #endregion

        #region Invoices

        private void ShowInvoicesList()
        {
            var panel = CreateContentPanel("📋 HÓA ĐƠN MUA HÀNG CỦA BẠN", 
                "Chỉ hiển thị hóa đơn của tài khoản đang đăng nhập. Bạn chỉ có quyền XEM, không thể chỉnh sửa.");

            if (!CurrentUser.IsLoggedIn)
            {
                AddNotLoggedInMessage(panel, 100);
                pnlMainArea.Controls.Add(panel);
                return;
            }

            var invoices = _khService.GetMyInvoices();

            var flowInvoices = new FlowLayoutPanel
            {
                Location = new Point(20, 90),
                Size = new Size(panel.Width - 60, panel.Height - 120),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };

            if (invoices.Count == 0)
            {
                flowInvoices.Controls.Add(new Label
                {
                    Text = "📭 Bạn chưa có hóa đơn nào.",
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.Gray,
                    AutoSize = true
                });
            }
            else
            {
                foreach (var hd in invoices)
                {
                    flowInvoices.Controls.Add(CreateInvoiceCard(hd));
                }
            }

            panel.Controls.Add(flowInvoices);
            pnlMainArea.Controls.Add(panel);
        }

        private Panel CreateInvoiceCard(HoaDonDTO hd)
        {
            var card = new Panel
            {
                Size = new Size(Math.Min(800, pnlMainArea.Width - 80), 105),
                BackColor = Color.FromArgb(250, 248, 255),
                Margin = new Padding(0, 8, 0, 8),
                Cursor = Cursors.Hand
            };

            card.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(220, 210, 230), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            card.Controls.Add(new Label
            {
                Text = $"🧾 Mã HĐ: #{hd.MaHD}",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = _primaryPurple,
                Location = new Point(15, 15),
                AutoSize = true
            });

            card.Controls.Add(new Label
            {
                Text = $"📅 {hd.NgayFormatted}",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.Gray,
                Location = new Point(15, 45),
                AutoSize = true
            });

            card.Controls.Add(new Label
            {
                Text = $"💰 {hd.TongTienFormatted}",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = _accentRed,
                Location = new Point(280, 30),
                AutoSize = true
            });

            card.Controls.Add(new Label
            {
                Text = hd.DaThanhToan ? "✅ Đã thanh toán" : "⏳ Chờ thanh toán",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = hd.DaThanhToan ? _accentGreen : Color.Orange,
                Location = new Point(500, 30),
                AutoSize = true
            });

            card.Controls.Add(new Label
            {
                Text = $"💳 {hd.PhuongThucTT ?? "N/A"} | 📦 {hd.SoSanPham} sản phẩm",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                Location = new Point(15, 75),
                AutoSize = true
            });

            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(240, 235, 250);
            card.MouseLeave += (s, e) => card.BackColor = Color.FromArgb(250, 248, 255);
            card.Click += (s, e) => ShowInvoiceDetailDialog(hd.MaHD);

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

            string message = $"═══ CHI TIẾT HÓA ĐƠN #{detail.MaHD} ═══\n\n";
            message += $"📅 Ngày: {detail.NgayFormatted}\n";
            message += $"💳 Phương thức: {detail.PhuongThucTT}\n";
            message += $"📊 Trạng thái: {detail.TrangThai}\n\n";
            message += "────── SẢN PHẨM ──────\n";

            foreach (var ct in detail.ChiTiet)
            {
                message += $"\n• {ct.TenSP}\n";
                message += $"  {ct.SoLuong} x {ct.DonGiaFormatted} = {ct.ThanhTienFormatted}\n";
            }

            message += $"\n══════════════════════\n";
            message += $"💰 TỔNG CỘNG: {detail.TongTienFormatted}";

            XtraMessageBox.Show(message, "Chi tiết hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Payment

        private void ShowPaymentPanel()
        {
            var panel = CreateContentPanel("💳 THANH TOÁN HÓA ĐƠN", "");

            if (!CurrentUser.IsLoggedIn)
            {
                AddNotLoggedInMessage(panel, 80);
                pnlMainArea.Controls.Add(panel);
                return;
            }

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
                panel.Controls.Add(new Label
                {
                    Text = $"⚠️ Bạn có {unpaidInvoices.Count} hóa đơn chờ thanh toán:",
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.Orange,
                    Location = new Point(20, 60),
                    AutoSize = true
                });

                int yPos = 100;
                foreach (var hd in unpaidInvoices)
                {
                    panel.Controls.Add(CreatePaymentCard(hd, yPos));
                    yPos += 130;
                }
            }

            pnlMainArea.Controls.Add(panel);
        }

        private Panel CreatePaymentCard(HoaDonDTO hd, int yPos)
        {
            var card = new Panel
            {
                Size = new Size(Math.Min(750, pnlMainArea.Width - 80), 115),
                Location = new Point(20, yPos),
                BackColor = Color.FromArgb(255, 250, 245),
                Padding = new Padding(15)
            };

            card.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(255, 200, 150), 2))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            card.Controls.Add(new Label
            {
                Text = $"🧾 HĐ #{hd.MaHD} | {hd.NgayFormatted} | {hd.TongTienFormatted}",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 48),
                Location = new Point(15, 15),
                AutoSize = true
            });

            card.Controls.Add(new Label
            {
                Text = "Chọn phương thức thanh toán:",
                Font = new Font("Segoe UI", 9F),
                Location = new Point(15, 48),
                AutoSize = true
            });

            int btnX = 15;
            var paymentMethods = new[]
            {
                ("🚚 COD", "COD - Thanh toán khi nhận hàng"),
                ("🏦 Chuyển khoản", "Chuyển khoản ngân hàng"),
                ("📱 Ví điện tử", "Ví điện tử (MoMo/ZaloPay)")
            };

            foreach (var (btnText, method) in paymentMethods)
            {
                var btn = CreatePaymentButton(btnText, btnX, 72, () => ProcessPayment(hd.MaHD, method));
                card.Controls.Add(btn);
                btnX += btn.Width + 15;
            }

            return card;
        }

        private Button CreatePaymentButton(string text, int x, int y, Action action)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Size = new Size(130, 32),
                Location = new Point(x, y),
                FlatStyle = FlatStyle.Flat,
                BackColor = _lightPurple,
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) => action();
            return btn;
        }

        private void ProcessPayment(int maHD, string paymentMethod)
        {
            var result = XtraMessageBox.Show(
                $"Xác nhận thanh toán hóa đơn #{maHD}?\n\nPhương thức: {paymentMethod}",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var payResult = _khService.PayInvoice(maHD, paymentMethod);
                
                if (payResult.Success)
                {
                    XtraMessageBox.Show(
                        $"✅ Thanh toán thành công!\n\nMã HĐ: #{payResult.MaHD}\nSố tiền: {payResult.TongTien:N0}đ",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ShowPaymentPage();
                }
                else
                {
                    XtraMessageBox.Show(payResult.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Account Info

        private void ShowAccountInfo()
        {
            var panel = CreateContentPanel("👤 THÔNG TIN TÀI KHOẢN", "");

            if (!CurrentUser.IsLoggedIn)
            {
                AddNotLoggedInMessage(panel, 80);
                
                var btnLogin = new Button
                {
                    Text = "Đăng nhập ngay",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    Size = new Size(160, 45),
                    Location = new Point(20, 130),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = _lightPurple,
                    ForeColor = Color.White,
                    Cursor = Cursors.Hand
                };
                btnLogin.FlatAppearance.BorderSize = 0;
                btnLogin.Click += (s, e) =>
                {
                    this.Hide();
                    var loginForm = new Forms.fLogin();
                    loginForm.FormClosed += (sender, args) => this.Close();
                    loginForm.Show();
                };
                panel.Controls.Add(btnLogin);
                pnlMainArea.Controls.Add(panel);
                return;
            }

            var accountInfo = _khService.GetAccountInfo();
            
            // Kiểm tra null
            if (accountInfo == null)
            {
                panel.Controls.Add(new Label
                {
                    Text = "⚠️ Không thể tải thông tin tài khoản.",
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.OrangeRed,
                    Location = new Point(20, 80),
                    AutoSize = true
                });
                pnlMainArea.Controls.Add(panel);
                return;
            }

            // Avatar
            var avatarPanel = new Panel
            {
                Size = new Size(110, 110),
                Location = new Point(20, 70),
                BackColor = Color.FromArgb(200, 180, 220)
            };
            
            string avatarChar = "U";
            if (!string.IsNullOrEmpty(accountInfo.HoTen) && accountInfo.HoTen.Length > 0)
            {
                avatarChar = accountInfo.HoTen.Substring(0, 1).ToUpper();
            }
            
            avatarPanel.Controls.Add(new Label
            {
                Text = avatarChar,
                Font = new Font("Segoe UI", 40F, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            });
            panel.Controls.Add(avatarPanel);

            // Info items
            var infoItems = new[]
            {
                ("👤 Họ tên:", accountInfo.HoTen ?? "Chưa cập nhật"),
                ("📧 Email:", accountInfo.Email ?? "Chưa cập nhật"),
                ("🔐 Tên đăng nhập:", accountInfo.TenDN ?? "Chưa cập nhật"),
                ("🎭 Loại tài khoản:", "Khách hàng"),
                ("📞 Số điện thoại:", accountInfo.SDT ?? "Chưa cập nhật")
            };

            int yPos = 80;
            foreach (var (label, value) in infoItems)
            {
                panel.Controls.Add(new Label
                {
                    Text = label,
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.Gray,
                    Location = new Point(150, yPos),
                    Size = new Size(160, 28)
                });

                panel.Controls.Add(new Label
                {
                    Text = value,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(45, 45, 48),
                    Location = new Point(320, yPos),
                    AutoSize = true,
                    MaximumSize = new Size(400, 0)
                });
                yPos += 38;
            }

            // Permissions info
            var permPanel = new Panel
            {
                Size = new Size(350, 160),
                Location = new Point(20, 300),
                BackColor = Color.FromArgb(245, 245, 250),
                Padding = new Padding(15)
            };
            
            permPanel.Controls.Add(new Label
            {
                Text = "ℹ️ Quyền hạn của bạn:\n\n" +
                       "✅ Xem sản phẩm\n" +
                       "✅ Thêm vào giỏ hàng\n" +
                       "✅ Xem hóa đơn của bạn\n" +
                       "✅ Thanh toán hóa đơn\n" +
                       "❌ Không có quyền quản trị",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(80, 80, 80),
                Dock = DockStyle.Fill
            });
            panel.Controls.Add(permPanel);

            pnlMainArea.Controls.Add(panel);
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
            var product = _context.SanPhams
                .Include(sp => sp.ThuongHieu)
                .FirstOrDefault(sp => sp.MaSP == maSP);
                
            if (product != null)
            {
                using (var form = new fSanPhamDetail(product, _context))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        AddToCart(maSP);
                    }
                }
            }
        }

        private void btnGioHang_Click(object sender, EventArgs e)
        {
            var cartItems = _khService.GetCartItems();
            
            if (cartItems.Count == 0)
            {
                XtraMessageBox.Show("🛒 Giỏ hàng trống!\nHãy thêm sản phẩm từ trang Sản phẩm.", 
                    "Giỏ hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Convert to legacy CartItem for fGioHang compatibility
            var legacyCart = cartItems.Select(c => new CartItem
            {
                MaSP = c.MaSP,
                TenSP = c.TenSP,
                DonGia = c.DonGia,
                SoLuong = c.SoLuong
            }).ToList();

            using (var form = new fGioHang(legacyCart, _context))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _khService.ClearCart();
                    UpdateCartCount();
                    LoadTopProducts();
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
                LoadTopProducts();
                return;
            }

            pnlHero.Visible = false;
            lblSectionTitle.Text = $"🔍 KẾT QUẢ TÌM KIẾM: \"{keyword.ToUpper()}\"";

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

        private Panel CreateContentPanel(string title, string subtitle)
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
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = _primaryPurple,
                Location = new Point(20, 20),
                AutoSize = true
            });

            if (!string.IsNullOrEmpty(subtitle))
            {
                panel.Controls.Add(new Label
                {
                    Text = subtitle,
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.Gray,
                    Location = new Point(20, 58),
                    AutoSize = true
                });
            }

            return panel;
        }

        private void AddNotLoggedInMessage(Panel panel, int yPos)
        {
            panel.Controls.Add(new Label
            {
                Text = "⚠️ Vui lòng đăng nhập để sử dụng chức năng này.",
                Font = new Font("Segoe UI", 13F),
                ForeColor = Color.OrangeRed,
                Location = new Point(20, yPos),
                AutoSize = true
            });
        }

        #endregion

        #region Other Events

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
            {
                ShowAccountInfoPage();
            }
            else
            {
                var result = XtraMessageBox.Show("Bạn chưa đăng nhập. Đăng nhập ngay?", "Thông báo",
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
                {
                    CurrentUser.Logout();
                }
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
                _hoverTimer?.Dispose();
                _promoScrollTimer?.Stop();
                _promoScrollTimer?.Dispose();
                _khService?.Dispose();
                _context?.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
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
