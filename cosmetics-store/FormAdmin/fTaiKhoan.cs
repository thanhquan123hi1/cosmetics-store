using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DataAccessLayer.Utilities;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class fTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;

        public fTaiKhoan()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += TaiKhoanForm_Load;
        }

        private void TaiKhoanForm_Load(object sender, EventArgs e)
        {
            SetupGridColumns();
            LoadData();
        }

        private void SetupGridColumns()
        {
            gridView.Columns.Clear();

            gridView.Columns.AddVisible("MaNV", "Mã NV");
            gridView.Columns.AddVisible("TenNhanVien", "Tên nhân viên");
            gridView.Columns.AddVisible("TenDN", "Tên đăng nhập");
            gridView.Columns.AddVisible("Email", "Email");
            gridView.Columns.AddVisible("Quyen", "Quyền");
            gridView.Columns.AddVisible("TrangThaiText", "Trạng thái");

            gridView.Columns["MaNV"].Width = 60;
            gridView.Columns["TenNhanVien"].Width = 150;
            gridView.Columns["TenDN"].Width = 120;
            gridView.Columns["Email"].Width = 180;
            gridView.Columns["Quyen"].Width = 100;
            gridView.Columns["TrangThaiText"].Width = 100;

            gridView.BestFitColumns();
        }

        private void LoadData()
        {
            try
            {
                var data = _context.TaiKhoans
                    .Include(tk => tk.NhanVien)
                    .Select(tk => new
                    {
                        tk.MaNV,
                        TenNhanVien = tk.NhanVien.HoTen,
                        tk.TenDN,
                        tk.Email,
                        tk.Quyen,
                        TrangThaiText = tk.TrangThai ? "Hoạt động" : "Bị khóa"
                    })
                    .ToList();

                grid.DataSource = data;
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
                var data = _context.TaiKhoans
                    .Include(tk => tk.NhanVien)
                    .Where(tk => tk.TenDN.ToLower().Contains(keyword) ||
                                 tk.Email.ToLower().Contains(keyword) ||
                                 tk.NhanVien.HoTen.ToLower().Contains(keyword) ||
                                 tk.Quyen.ToLower().Contains(keyword))
                    .Select(tk => new
                    {
                        tk.MaNV,
                        TenNhanVien = tk.NhanVien.HoTen,
                        tk.TenDN,
                        tk.Email,
                        tk.Quyen,
                        TrangThaiText = tk.TrangThai ? "Hoạt động" : "Bị khóa"
                    })
                    .ToList();

                grid.DataSource = data;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var editForm = new TaiKhoanEdit(_context))
            {
                editForm.Text = "Thêm tài khoản mới";
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var taiKhoan = editForm.GetTaiKhoan();
                        
                        // Hash mật khẩu trước khi lưu
                        taiKhoan.MatKhau = PasswordHasher.HashPassword(taiKhoan.MatKhau);
                        taiKhoan.TrangThai = true;

                        _context.TaiKhoans.Add(taiKhoan);
                        _context.SaveChanges();

                        LogAction("CREATE", "TaiKhoan", taiKhoan.MaNV.ToString(), null,
                            $"Thêm tài khoản: {taiKhoan.TenDN}, Quyền: {taiKhoan.Quyen}");

                        XtraMessageBox.Show("Thêm tài khoản thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Lỗi thêm tài khoản: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNV = Convert.ToInt32(gridView.GetFocusedRowCellValue("MaNV"));
            var taiKhoan = _context.TaiKhoans.Include(tk => tk.NhanVien).FirstOrDefault(tk => tk.MaNV == maNV);

            if (taiKhoan == null)
            {
                XtraMessageBox.Show("Không tìm thấy tài khoản!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var editForm = new TaiKhoanEdit(_context, taiKhoan))
            {
                editForm.Text = "Sửa thông tin tài khoản";
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string oldData = $"Username: {taiKhoan.TenDN}, Quyền: {taiKhoan.Quyen}";

                        editForm.UpdateTaiKhoan(taiKhoan);
                        _context.SaveChanges();

                        string newData = $"Username: {taiKhoan.TenDN}, Quyền: {taiKhoan.Quyen}";
                        LogAction("UPDATE", "TaiKhoan", taiKhoan.MaNV.ToString(), oldData, newData);

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
            if (gridView.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNV = Convert.ToInt32(gridView.GetFocusedRowCellValue("MaNV"));
            string tenDN = gridView.GetFocusedRowCellValue("TenDN")?.ToString();

            // Không cho xóa tài khoản admin
            if (tenDN?.ToLower() == "admin")
            {
                XtraMessageBox.Show("Không thể xóa tài khoản Admin hệ thống!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Không cho tự xóa chính mình
            if (CurrentUser.IsLoggedIn && CurrentUser.User.MaNV == maNV)
            {
                XtraMessageBox.Show("Bạn không thể xóa tài khoản của chính mình!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = XtraMessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản '{tenDN}'?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var taiKhoan = _context.TaiKhoans.Find(maNV);
                    if (taiKhoan != null)
                    {
                        _context.TaiKhoans.Remove(taiKhoan);
                        _context.SaveChanges();

                        LogAction("DELETE", "TaiKhoan", maNV.ToString(),
                            $"Xóa tài khoản: {tenDN}", null);

                        XtraMessageBox.Show("Xóa tài khoản thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Lỗi xóa tài khoản: {ex.Message}", "Lỗi",
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
    }
}
