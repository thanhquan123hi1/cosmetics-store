using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class NhaCungCapForm : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;

        // UI Colors
        private readonly Color _primaryColor = Color.FromArgb(52, 73, 94);
        private readonly Color _successColor = Color.FromArgb(39, 174, 96);
        private readonly Color _dangerColor = Color.FromArgb(231, 76, 60);

        public NhaCungCapForm()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += NhaCungCapForm_Load;
        }

        private void NhaCungCapForm_Load(object sender, EventArgs e)
        {
            SetupUI();
            LoadNhaCungCap();
        }

        private void SetupUI()
        {
            this.Text = "🏭 QUẢN LÝ NHÀ CUNG CẤP";
            this.BackColor = Color.FromArgb(245, 246, 250);
        }

        private void LoadNhaCungCap(string keyword = "")
        {
            try
            {
                var query = _context.NhaCungCaps.AsQueryable();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    keyword = keyword.ToLower();
                    query = query.Where(n => n.TenNCC.ToLower().Contains(keyword) ||
                                             n.DiaChi.ToLower().Contains(keyword) ||
                                             n.SDT.Contains(keyword) ||
                                             n.Email.ToLower().Contains(keyword));
                }

                var data = query
                    .OrderBy(n => n.TenNCC)
                    .Select(n => new
                    {
                        n.MaNCC,
                        n.TenNCC,
                        n.DiaChi,
                        n.SDT,
                        n.Email,
                        SoPhieuNhap = n.PhieuNhaps.Count,
                        TongTienNhap = n.PhieuNhaps
                            .SelectMany(p => p.CT_PhieuNhaps)
                            .Sum(ct => (decimal?)(ct.SoLuong * ct.DonGiaNhap)) ?? 0
                    })
                    .ToList();

                gridControl1.DataSource = data;

                if (gridView1.Columns.Count > 0)
                {
                    gridView1.Columns.Clear();
                }

                gridView1.Columns.AddVisible("MaNCC", "Mã NCC");
                gridView1.Columns.AddVisible("TenNCC", "Tên nhà cung cấp");
                gridView1.Columns.AddVisible("DiaChi", "Địa chỉ");
                gridView1.Columns.AddVisible("SDT", "Điện thoại");
                gridView1.Columns.AddVisible("Email", "Email");
                gridView1.Columns.AddVisible("SoPhieuNhap", "Số phiếu nhập");
                gridView1.Columns.AddVisible("TongTienNhap", "Tổng tiền nhập");

                gridView1.Columns["MaNCC"].Width = 70;
                gridView1.Columns["TenNCC"].Width = 200;
                gridView1.Columns["DiaChi"].Width = 200;
                gridView1.Columns["SDT"].Width = 120;
                gridView1.Columns["Email"].Width = 180;
                gridView1.Columns["SoPhieuNhap"].Width = 100;
                gridView1.Columns["TongTienNhap"].Width = 130;

                gridView1.Columns["TongTienNhap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["TongTienNhap"].DisplayFormat.FormatString = "#,##0 đ";

                gridView1.OptionsView.ShowGroupPanel = false;
                gridView1.OptionsView.RowAutoHeight = true;

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
            var totalNCC = _context.NhaCungCaps.Count();
            var totalPhieuNhap = _context.PhieuNhaps.Count();
            var tongTienNhap = _context.CT_PhieuNhaps
                .Sum(ct => (decimal?)(ct.SoLuong * ct.DonGiaNhap)) ?? 0;

            // Cập nhật title thay vì dùng lblThongKe
            this.Text = $"🏭 NHÀ CUNG CẤP | Tổng: {totalNCC} NCC | {totalPhieuNhap} phiếu nhập | {tongTienNhap:N0} đ";
        }

        private void searchControl_TextChanged(object sender, EventArgs e)
        {
            LoadNhaCungCap(searchControl.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new NhaCungCapEditForm())
            {
                form.Text = "➕ Thêm nhà cung cấp mới";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var ncc = form.GetNhaCungCap();
                        _context.NhaCungCaps.Add(ncc);
                        _context.SaveChanges();

                        // Log
                        var log = new AuditLog
                        {
                            ThoiGian = DateTime.Now,
                            HanhDong = "CREATE_NhaCungCap",
                            MaBanGhi = ncc.MaNCC.ToString(),
                            DuLieuMoi = $"Thêm NCC: {ncc.TenNCC}",
                            MaNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : (int?)null
                        };
                        _context.AuditLogs.Add(log);
                        _context.SaveChanges();

                        XtraMessageBox.Show("Thêm nhà cung cấp thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNhaCungCap();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Lỗi thêm nhà cung cấp: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNCC = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MaNCC"));
            var ncc = _context.NhaCungCaps.Find(maNCC);

            if (ncc == null)
            {
                XtraMessageBox.Show("Không tìm thấy nhà cung cấp!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var form = new NhaCungCapEditForm(ncc))
            {
                form.Text = "✏️ Sửa thông tin nhà cung cấp";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        form.UpdateNhaCungCap(ncc);
                        _context.SaveChanges();

                        // Log
                        var log = new AuditLog
                        {
                            ThoiGian = DateTime.Now,
                            HanhDong = "UPDATE_NhaCungCap",
                            MaBanGhi = ncc.MaNCC.ToString(),
                            DuLieuMoi = $"Cập nhật NCC: {ncc.TenNCC}",
                            MaNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : (int?)null
                        };
                        _context.AuditLogs.Add(log);
                        _context.SaveChanges();

                        XtraMessageBox.Show("Cập nhật thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNhaCungCap();
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
                XtraMessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNCC = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MaNCC"));
            string tenNCC = gridView1.GetFocusedRowCellValue("TenNCC")?.ToString();
            int soPhieuNhap = Convert.ToInt32(gridView1.GetFocusedRowCellValue("SoPhieuNhap"));

            if (soPhieuNhap > 0)
            {
                XtraMessageBox.Show($"Không thể xóa nhà cung cấp '{tenNCC}' vì đã có {soPhieuNhap} phiếu nhập liên quan!", 
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = XtraMessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhà cung cấp:\n\n'{tenNCC}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var ncc = _context.NhaCungCaps.Find(maNCC);
                    if (ncc != null)
                    {
                        _context.NhaCungCaps.Remove(ncc);
                        
                        // Log
                        var log = new AuditLog
                        {
                            ThoiGian = DateTime.Now,
                            HanhDong = "DELETE_NhaCungCap",
                            MaBanGhi = maNCC.ToString(),
                            DuLieuCu = $"Xóa NCC: {tenNCC}",
                            MaNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : (int?)null
                        };
                        _context.AuditLogs.Add(log);
                        
                        _context.SaveChanges();

                        XtraMessageBox.Show("Xóa nhà cung cấp thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNhaCungCap();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Lỗi xóa nhà cung cấp: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            searchControl.Text = "";
            LoadNhaCungCap();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
        }

        private void searchControl_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
