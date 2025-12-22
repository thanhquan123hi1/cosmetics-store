using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace cosmetics_store.Forms
{
    public partial class fNhanVien : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;

        public fNhanVien()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += NhanVienForm_Load;
        }

        private void NhanVienForm_Load(object sender, EventArgs e)
        {
            ApplyModernTheme();
            SetupGridColumns();
            LoadData();
        }

        private void ApplyModernTheme()
        {
            // Màu sắc theo mẫu AuditLogForm
            var darkBlue = Color.FromArgb(20, 30, 70);
            var mediumBlue = Color.FromArgb(45, 60, 110);
            var textWhite = Color.White;

            // Form background
            this.BackColor = darkBlue;

            // Font
            var mainFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            var boldFont = new Font("Segoe UI", 10F, FontStyle.Bold);

            try
            {
                // Style panels nếu có
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Panel panel)
                    {
                        panel.BackColor = mediumBlue;
                    }
                    else if (ctrl is DevExpress.XtraEditors.PanelControl panelCtrl)
                    {
                        panelCtrl.Appearance.BackColor = mediumBlue;
                        panelCtrl.Appearance.Options.UseBackColor = true;
                    }
                }

                // Style SearchControl
                if (searchControl != null)
                {
                    searchControl.Properties.Appearance.Font = mainFont;
                    searchControl.Properties.Appearance.BackColor = Color.FromArgb(60, 70, 110);
                    searchControl.Properties.Appearance.ForeColor = textWhite;
                    searchControl.Properties.Appearance.Options.UseFont = true;
                    searchControl.Properties.Appearance.Options.UseBackColor = true;
                    searchControl.Properties.Appearance.Options.UseForeColor = true;
                    searchControl.Properties.NullValuePrompt = "Tìm kiếm nhân viên...";
                }

                // Style Buttons
                if (btnAdd != null)
                    StyleButton(btnAdd, Color.FromArgb(0, 123, 255), textWhite, boldFont, "➕ Thêm");
                
                if (btnEdit != null)
                    StyleButton(btnEdit, Color.FromArgb(40, 167, 69), textWhite, boldFont, "✏️ Sửa");
                
                if (btnDelete != null)
                    StyleButton(btnDelete, Color.FromArgb(220, 53, 69), textWhite, boldFont, "🗑️ Xóa");

                // Style Grid
                if (gridControl1 != null && gridView1 != null)
                {
                    StyleGrid(gridControl1, gridView1);
                }
            }
            catch { }
        }

        private void StyleButton(DevExpress.XtraEditors.SimpleButton button, Color backColor, Color foreColor, Font font, string text)
        {
            if (button == null) return;
            button.Text = text;
            button.Appearance.BackColor = backColor;
            button.Appearance.ForeColor = foreColor;
            button.Appearance.Font = font;
            button.Appearance.Options.UseBackColor = true;
            button.Appearance.Options.UseForeColor = true;
            button.Appearance.Options.UseFont = true;
            button.LookAndFeel.UseDefaultLookAndFeel = false;
            button.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            button.Height = Math.Max(button.Height, 36);
            button.Padding = new Padding(8, 4, 8, 4);

            button.MouseEnter += (s, e) => { button.Appearance.BackColor = ControlPaint.Light(backColor, 0.2f); };
            button.MouseLeave += (s, e) => { button.Appearance.BackColor = backColor; };
        }

        private void StyleGrid(DevExpress.XtraGrid.GridControl grid, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            var textWhite = Color.White;
            grid.BackColor = Color.FromArgb(30, 40, 80);

            gridView.Appearance.Row.BackColor = Color.FromArgb(40, 50, 95);
            gridView.Appearance.Row.ForeColor = Color.FromArgb(240, 240, 240);
            gridView.Appearance.Row.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            gridView.Appearance.Row.Options.UseBackColor = true;
            gridView.Appearance.Row.Options.UseForeColor = true;
            gridView.Appearance.Row.Options.UseFont = true;

            gridView.Appearance.EvenRow.BackColor = Color.FromArgb(45, 55, 100);
            gridView.Appearance.EvenRow.ForeColor = Color.FromArgb(240, 240, 240);
            gridView.Appearance.EvenRow.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            gridView.Appearance.EvenRow.Options.UseBackColor = true;
            gridView.Appearance.EvenRow.Options.UseForeColor = true;
            gridView.Appearance.EvenRow.Options.UseFont = true;

            gridView.Appearance.HeaderPanel.BackColor = Color.FromArgb(220, 230, 245);
            gridView.Appearance.HeaderPanel.ForeColor = Color.Black;
            gridView.Appearance.HeaderPanel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView.Appearance.HeaderPanel.Options.UseFont = true;
            gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            gridView.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215);
            gridView.Appearance.FocusedRow.ForeColor = textWhite;
            gridView.Appearance.FocusedRow.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            gridView.Appearance.FocusedRow.Options.UseFont = true;

            gridView.Appearance.SelectedRow.BackColor = Color.FromArgb(30, 100, 180);
            gridView.Appearance.SelectedRow.ForeColor = textWhite;
            gridView.Appearance.SelectedRow.Font = new Font("Segoe UI", 11F, FontStyle.Regular);

            gridView.OptionsView.RowAutoHeight = true;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.RowHeight = 32;
        }

        private void SetupGridColumns()
        {
            gridView1.Columns.Clear();

            gridView1.Columns.AddVisible("MaNV", "Mã NV");
            gridView1.Columns.AddVisible("HoTen", "Họ tên");
            gridView1.Columns.AddVisible("GioiTinh", "Giới tính");
            gridView1.Columns.AddVisible("NgaySinh", "Ngày sinh");
            gridView1.Columns.AddVisible("DiaChi", "Địa chỉ");
            gridView1.Columns.AddVisible("ChucVu", "Chức vụ");
            gridView1.Columns.AddVisible("SDT", "Số điện thoại");

            gridView1.Columns["MaNV"].Width = 60;
            gridView1.Columns["HoTen"].Width = 150;
            gridView1.Columns["GioiTinh"].Width = 80;
            gridView1.Columns["NgaySinh"].Width = 100;
            gridView1.Columns["DiaChi"].Width = 200;
            gridView1.Columns["ChucVu"].Width = 120;
            gridView1.Columns["SDT"].Width = 120;

            gridView1.Columns["NgaySinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["NgaySinh"].DisplayFormat.FormatString = "dd/MM/yyyy";

            gridView1.BestFitColumns();
        }

        private void LoadData()
        {
            try
            {
                var data = _context.NhanViens
                    .Select(nv => new
                    {
                        nv.MaNV,
                        nv.HoTen,
                        nv.GioiTinh,
                        nv.NgaySinh,
                        nv.DiaChi,
                        nv.ChucVu,
                        nv.SDT
                    })
                    .ToList();

                gridControl1.DataSource = data;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchControl_TextChanged(object sender, EventArgs e)
        {
            string keyword = searchControl.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
                return;
            }

            try
            {
                var data = _context.NhanViens
                    .Where(nv => nv.HoTen.ToLower().Contains(keyword) ||
                                 nv.SDT.Contains(keyword) ||
                                 nv.ChucVu.ToLower().Contains(keyword))
                    .Select(nv => new
                    {
                        nv.MaNV,
                        nv.HoTen,
                        nv.GioiTinh,
                        nv.NgaySinh,
                        nv.DiaChi,
                        nv.ChucVu,
                        nv.SDT
                    })
                    .ToList();

                gridControl1.DataSource = data;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var editForm = new fNhanVienEdit())
            {
                editForm.Text = "Thêm nhân viên mới";
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var nhanVien = editForm.GetNhanVien();
                        _context.NhanViens.Add(nhanVien);
                        _context.SaveChanges();

                        // Ghi Audit Log
                        LogAction("CREATE", "NhanVien", nhanVien.MaNV.ToString(), null, 
                            $"Thêm nhân viên: {nhanVien.HoTen}");

                        XtraMessageBox.Show("Thêm nhân viên thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Lỗi thêm nhân viên: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNV = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MaNV"));
            var nhanVien = _context.NhanViens.Find(maNV);

            if (nhanVien == null)
            {
                XtraMessageBox.Show("Không tìm thấy nhân viên!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var editForm = new fNhanVienEdit(nhanVien))
            {
                editForm.Text = "Sửa thông tin nhân viên";
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string oldData = $"Họ tên: {nhanVien.HoTen}, Chức vụ: {nhanVien.ChucVu}";
                        
                        editForm.UpdateNhanVien(nhanVien);
                        _context.SaveChanges();

                        string newData = $"Họ tên: {nhanVien.HoTen}, Chức vụ: {nhanVien.ChucVu}";
                        LogAction("UPDATE", "NhanVien", nhanVien.MaNV.ToString(), oldData, newData);

                        XtraMessageBox.Show("Cập nhật thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Lỗi cập nhật: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNV = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MaNV"));
            string hoTen = gridView1.GetFocusedRowCellValue("HoTen")?.ToString();

            var result = XtraMessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên '{hoTen}'?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var nhanVien = _context.NhanViens.Find(maNV);
                    if (nhanVien != null)
                    {
                        // Kiểm tra có tài khoản liên kết không
                        var taiKhoan = _context.TaiKhoans.FirstOrDefault(tk => tk.MaNV == maNV);
                        if (taiKhoan != null)
                        {
                            XtraMessageBox.Show("Không thể xóa nhân viên đã có tài khoản!\nVui lòng xóa tài khoản trước.",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Kiểm tra có hoa đơn liên quan không
                        var hoaDon = _context.HoaDons.FirstOrDefault(hd => hd.MaNV == maNV);
                        if (hoaDon != null)
                        {
                            XtraMessageBox.Show("Không thể xóa nhân viên đã có hóa đơn bán hàng!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        _context.NhanViens.Remove(nhanVien);
                        _context.SaveChanges();

                        LogAction("DELETE", "NhanVien", maNV.ToString(), 
                            $"Xóa nhân viên: {hoTen}", null);

                        XtraMessageBox.Show("Xóa nhân viên thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Lỗi xóa nhân viên: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LogAction(string action, string tableName, string recordId, string oldData, string newData)
        {
            try
            {
                var log = new AuditLog
                {
                    ThoiGian = DateTime.Now,
                    HanhDong = $"{action}_{tableName}",
                    MaBanGhi = recordId,
                    DuLieuCu = oldData,
                    DuLieuMoi = newData,
                    MaNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : (int?)null
                };
                _context.AuditLogs.Add(log);
                _context.SaveChanges();
            }
            catch { /* Bỏ qua lỗi ghi log */ }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosed(e);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
