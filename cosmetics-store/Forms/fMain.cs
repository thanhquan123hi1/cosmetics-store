using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Windows.Forms.DataVisualization.Charting;
using BusinessAccessLayer.Services;

namespace cosmetics_store.Forms
{
    public partial class fMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public fMain()
        {
            InitializeComponent();
            InitializeContentPanels();
            ConfigureRoleBasedUI();

            this.btnTrangChu.Click += (s, e) => ShowPanel(pnlDashboard);
            this.btnBanHang.Click += (s, e) => ShowPanel(pnlPOS);
            this.btnSanPham.Click += (s, e) => ShowPanel(pnlProducts);
            this.btnDoiTac.Click += (s, e) => ShowPanel(pnlSuppliers);
            this.btnNhanSu.Click += (s, e) => ShowPanel(pnlStaff);
            this.btnBaoCao.Click += (s, e) => ShowPanel(pnlReports);
        }

        private void ConfigureRoleBasedUI()
        {
            if (!CurrentUser.IsLoggedIn)
            {
                XtraMessageBox.Show("Bạn chưa đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                Application.Exit();
                return;
            }

            // Update status bar or ribbon with user info
            this.Text = $"Hệ thống quản lý Cosmetics - {CurrentUser.User.HoTen} ({CurrentUser.User.Quyen})";

            if (CurrentUser.IsStaff)
            {
                // Staff: Hide admin-only features
                if (btnNhanSu != null)
                    btnNhanSu.Enabled = false;
                
                // Can add more restrictions based on business rules
                // For example: Staff can only view reports, not manage accounts
            }
            else if (CurrentUser.IsAdmin)
            {
                // Admin: Full access to all features
                // All buttons enabled by default
            }
        }

        private void InitializeContentPanels()
        {
    
            contentContainer.Dock = DockStyle.Fill;
            contentContainer.BackColor = SystemColors.Control;

           
            pnlDashboard.Dock = DockStyle.Fill;
            pnlProducts.Dock = DockStyle.Fill;
            pnlSuppliers.Dock = DockStyle.Fill;
            pnlStaff.Dock = DockStyle.Fill;
            pnlPOS.Dock = DockStyle.Fill;
            pnlReports.Dock = DockStyle.Fill;

            pnlDashboard.Visible = true;
            pnlProducts.Visible = false;
            pnlSuppliers.Visible = false;
            pnlStaff.Visible = false;
            pnlPOS.Visible = false;
            pnlReports.Visible = false;

       
            ShowPanel(pnlDashboard);
        }

        private Panel CreatePlaceholderPanel(string text)
        {
            if (text.StartsWith("Dashboard"))
                return CreateDashboardPanel();

            var p = new Panel();
            p.Dock = DockStyle.Fill;
            p.BackColor = Color.White;
            var lbl = new Label();
            lbl.Text = text;
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            p.Controls.Add(lbl);
            return p;
        }

        private Panel CreateDashboardPanel()
        {
            var p = new Panel() { Dock = DockStyle.Fill, BackColor = Color.White };

            var split = new SplitContainer();
            split.Dock = DockStyle.Fill;
            split.SplitterDistance = 260;

            var tv = new TreeView() { Dock = DockStyle.Fill };
            tv.Nodes.Add(new TreeNode("Cài đặt"));
            tv.Nodes.Add(new TreeNode("Tạo hóa đơn"));
            tv.Nodes.Add(new TreeNode("Quản lý thu/chi"));
            tv.Nodes.Add(new TreeNode("Nhà cung cấp"));
            tv.Nodes.Add(new TreeNode("Tạo phiếu/Thanh toán"));
            tv.Nodes.Add(new TreeNode("Tài khoản"));
            tv.Nodes.Add(new TreeNode("Báo cáo"));
            split.Panel1.Controls.Add(tv);

      
            var right = new TableLayoutPanel();
            right.Dock = DockStyle.Fill;
            right.RowCount = 2;
            right.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            right.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            right.ColumnCount = 1;

 
            var tileControl = new DevExpress.XtraEditors.TileControl();
            tileControl.Dock = DockStyle.Fill;
            var group = new DevExpress.XtraEditors.TileGroup();

            TileItem tile1 = new TileItem(); tile1.Text = "Dashboard\n€ 14,590.9"; tile1.AppearanceItem.Normal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            TileItem tile2 = new TileItem(); tile2.Text = "Bán hàng\n23%"; tile2.AppearanceItem.Normal.Font = new Font("Segoe UI", 10F);
            TileItem tile3 = new TileItem(); tile3.Text = "Số đơn\n38%"; tile3.AppearanceItem.Normal.Font = new Font("Segoe UI", 10F);
            TileItem tile4 = new TileItem(); tile4.Text = "Tồn kho thấp\n6"; tile4.AppearanceItem.Normal.Font = new Font("Segoe UI", 10F);

            group.Items.Add(tile1); group.Items.Add(tile2); group.Items.Add(tile3); group.Items.Add(tile4);
            tileControl.Groups.Add(group);

            right.Controls.Add(tileControl, 0, 0);

     
            var bottom = new SplitContainer();
            bottom.Dock = DockStyle.Fill;
            bottom.Orientation = Orientation.Vertical;
            bottom.SplitterDistance = (int)(this.ClientSize.Width * 0.35);

     
            var tabs = new TabControl();
            tabs.Dock = DockStyle.Fill;
            tabs.Font = new Font("Segoe UI", 9.75F);
            var tab1 = new TabPage("Dashboard");
            var lb = new ListBox() { Dock = DockStyle.Fill };
            lb.Font = new Font("Segoe UI", 9.75F);
            lb.Items.AddRange(new string[] { "Phân tích bán hàng", "Các công việc cần làm", "Thống kê nhanh" });
            tab1.Controls.Add(lb);
            tabs.TabPages.Add(tab1);
            bottom.Panel1.Controls.Add(tabs);

            var chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart1.Dock = DockStyle.Fill;
            var area1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea("area1");
            chart1.ChartAreas.Add(area1);
            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series("TopProducts") { ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar };
            series1.Points.AddXY("A", 10);
            series1.Points.AddXY("B", 25);
            chart1.Series.Add(series1);

            var chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2.Dock = DockStyle.Fill;
            var area2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea("area2");
            chart2.ChartAreas.Add(area2);
            var series2 = new System.Windows.Forms.DataVisualization.Charting.Series("Revenue") { ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line };
            series2.Points.AddXY("Day1", 100);
            series2.Points.AddXY("Day2", 180);
            chart2.Series.Add(series2);

            var charts = new TableLayoutPanel();
            charts.Dock = DockStyle.Fill;
            charts.ColumnCount = 1;
            charts.RowCount = 2;
            charts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            charts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            charts.Controls.Add(chart1, 0, 0);
            charts.Controls.Add(chart2, 0, 1);

            bottom.Panel2.Controls.Add(charts);

            right.Controls.Add(bottom, 0, 1);

            split.Panel2.Controls.Add(right);
            p.Controls.Add(split);
            return p;
        }

        private Control CreateTile(string title, string value, Color color)
        {
            var panel = new Panel();
            panel.Width = 180; panel.Height = 90; panel.Margin = new Padding(6);
            panel.BackColor = Color.WhiteSmoke; panel.BorderStyle = BorderStyle.FixedSingle;
            var lblTitle = new Label() { Text = title, Dock = DockStyle.Top, Height = 24, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9F, FontStyle.Regular) };
            var lblValue = new Label() { Text = value, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 18F, FontStyle.Bold), ForeColor = color };
            panel.Controls.Add(lblValue); panel.Controls.Add(lblTitle);
            return panel;
        }

        private Control CreateChartPlaceholder(string title)
        {
            var p = new Panel() { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke, BorderStyle = BorderStyle.FixedSingle };
            var lbl = new Label() { Text = title, Dock = DockStyle.Top, Height = 28, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(6,0,0,0), Font = new Font("Segoe UI", 9.75F) };
            var pic = new Panel() { Dock = DockStyle.Fill, BackColor = Color.White };
            p.Controls.Add(pic); p.Controls.Add(lbl);
            return p;
        }

        private void ShowPanel(Panel panel)
        {
            foreach (Control c in contentContainer.Controls)
            {
                c.Visible = false;
            }
            panel.Visible = true;
            panel.BringToFront();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlDashboard);
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void lblReports_Click(object sender, EventArgs e)
        {

        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {

        }

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
                }
            }
            base.OnFormClosing(e);
        }
    }
}