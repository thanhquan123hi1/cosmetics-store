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

        // UI Colors
        private readonly Color _primaryColor = Color.FromArgb(52, 73, 94);
        private readonly Color _successColor = Color.FromArgb(39, 174, 96);
        private readonly Color _dangerColor = Color.FromArgb(231, 76, 60);

        public fNhanVien()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += NhanVienForm_Load;
        }

        private void NhanVienForm_Load(object sender, EventArgs e)
        {
            SetupUI();
            SetupGridColumns();
            LoadData();
        }

        private void SetupUI()
        {
            this.Text = "👥 QUẢN LÝ NHÂN VIÊN";
            this.BackColor = Color.FromArgb(245, 246, 250);
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
            gridView1.Columns.AddVisible("CoTaiKhoan", "Tài khoản");

            gridView1.Columns["MaNV"].Width = 60;
            gridView1.Columns["HoTen"].Width = 150;
            gridView1.Columns["GioiTinh"].Width = 80;
            gridView1.Columns["NgaySinh"].Width = 100;
            gridView1.Columns["DiaChi"].Width = 180;
            gridView1.Columns["ChucVu"].Width = 130;
            gridView1.Columns["SDT"].Width = 120;
            gridView1.Columns["CoTaiKhoan"].Width = 90;

            gridView1.Columns["NgaySinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["NgaySinh"].DisplayFormat.FormatString = "dd/MM/yyyy";

            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.RowAutoHeight = true;

            // Highlight theo chức vụ
            gridView1.RowStyle += (s, e) =>
            {
                if (e.RowHandle >= 0)
                {
                    var chucVu = gridView1.GetRowCellValue(e.RowHandle, "ChucVu")?.ToString();
                    if (chucVu == "Quản trị viên")
                    {
                        e.Appearance.BackColor = Color.FromArgb(255, 230, 230);
                    }
                    else if (chucVu == "Quản lý")
                    {
                        e.Appearance.BackColor = Color.FromArgb(230, 255, 230);
                    }
                }
            };
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
                        nv.SDT,
                        CoTaiKhoan = _context.TaiKhoans.Any(tk => tk.MaNV == nv.MaNV) ? "✅ Có" : "❌ Chưa"
                    })
                    .ToList();

                gridControl1.DataSource = data;

                // Cập nhật thống kê
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics()
        {
            var totalNV = _context.NhanViens.Count();
            var totalWithAccount = _context.TaiKhoans.Count();
            var quanLy = _context.NhanViens.Count(nv => nv.ChucVu == "Quản lý" || nv.ChucVu == "Quản trị viên");

            // Cập nhật title thay vì dùng lblThongKe
            this.Text = $"👥 NHÂN VIÊN | Tổng: {totalNV} NV | Có TK: {totalWithAccount} | Quản lý: {quanLy}";
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
                                 nv.ChucVu.ToLower().Contains(keyword) ||
                                 nv.DiaChi.ToLower().Contains(keyword))
                    .Select(nv => new
                    {
                        nv.MaNV,
                        nv.HoTen,
                        nv.GioiTinh,
                        nv.NgaySinh,
                        nv.DiaChi,
                        nv.ChucVu,
                        nv.SDT,
                        CoTaiKhoan = _context.TaiKhoans.Any(tk => tk.MaNV == nv.MaNV) ? "✅ Có" : "❌ Chưa"
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
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var nhanVien = editForm.GetNhanVien();
                        _context.NhanViens.Add(nhanVien);
                        _context.SaveChanges();

                        // Tạo tài khoản nếu được chọn
                        if (editForm.ShouldCreateAccount)
                        {
                            var taiKhoan = editForm.GetTaiKhoan(nhanVien.MaNV);
                            if (taiKhoan != null)
                            {
                                _context.TaiKhoans.Add(taiKhoan);
                                _context.SaveChanges();

                                LogAction("CREATE", "TaiKhoan", taiKhoan.MaNV.ToString(), null,
                                    $"Tạo TK cho NV: {nhanVien.HoTen}, TenDN: {taiKhoan.TenDN}");
                            }
                        }

                        // Ghi Audit Log
                        LogAction("CREATE", "NhanVien", nhanVien.MaNV.ToString(), null,
                            $"Thêm NV: {nhanVien.HoTen}, Chức vụ: {nhanVien.ChucVu}");

                        string msg = $"✅ Thêm nhân viên thành công!\n\nMã NV: {nhanVien.MaNV}\nHọ tên: {nhanVien.HoTen}";
                        if (editForm.ShouldCreateAccount)
                        {
                            msg += "\n\n🔑 Đã tạo tài khoản đăng nhập.";
                        }

                        XtraMessageBox.Show(msg, "Thành công",
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
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string oldData = $"Họ tên: {nhanVien.HoTen}, Chức vụ: {nhanVien.ChucVu}";

                        editForm.UpdateNhanVien(nhanVien);
                        _context.SaveChanges();

                        string newData = $"Họ tên: {nhanVien.HoTen}, Chức vụ: {nhanVien.ChucVu}";
                        LogAction("UPDATE", "NhanVien", nhanVien.MaNV.ToString(), oldData, newData);

                        XtraMessageBox.Show("✅ Cập nhật thành công!", "Thông báo",
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
            string chucVu = gridView1.GetFocusedRowCellValue("ChucVu")?.ToString();

            // Không cho xóa admin
            if (chucVu == "Quản trị viên")
            {
                XtraMessageBox.Show("Không thể xóa tài khoản Quản trị viên!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = XtraMessageBox.Show(
                $"⚠️ Bạn có chắc chắn muốn xóa nhân viên?\n\n" +
                $"👤 {hoTen}\n" +
                $"📋 Chức vụ: {chucVu}\n\n" +
                "Hành động này không thể hoàn tác!",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
                            var confirmDeleteTK = XtraMessageBox.Show(
                                $"Nhân viên này có tài khoản đăng nhập.\n\n" +
                                $"🔑 Tên đăng nhập: {taiKhoan.TenDN}\n\n" +
                                "Bạn có muốn xóa cả tài khoản?",
                                "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                            if (confirmDeleteTK == DialogResult.Cancel)
                                return;

                            if (confirmDeleteTK == DialogResult.Yes)
                            {
                                _context.TaiKhoans.Remove(taiKhoan);
                                LogAction("DELETE", "TaiKhoan", maNV.ToString(),
                                    $"Xóa TK: {taiKhoan.TenDN}", null);
                            }
                            else
                            {
                                XtraMessageBox.Show("Không thể xóa nhân viên khi còn tài khoản liên kết!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // Kiểm tra có hóa đơn liên quan không
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
                            $"Xóa NV: {hoTen}", null);

                        XtraMessageBox.Show("✅ Xóa nhân viên thành công!", "Thông báo",
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            searchControl.Text = "";
            LoadData();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
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
