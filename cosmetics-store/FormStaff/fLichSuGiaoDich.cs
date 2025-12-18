using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormStaff
{
    public partial class fLichSuGiaoDich : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;

        public fLichSuGiaoDich()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += fLichSuGiaoDich_Load;
        }

        private void fLichSuGiaoDich_Load(object sender, EventArgs e)
        {
            if (CurrentUser.IsLoggedIn)
            {
                lblNhanVien.Text = $"Nhân viên: {CurrentUser.User.HoTen}";
            }
            LoadHoaDon();
        }

        private void LoadHoaDon()
        {
            try
            {
                int maNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : 0;

                var data = _context.HoaDons
                    .Include(hd => hd.KhachHang)
                    .Where(hd => hd.MaNV == maNV)
                    .OrderByDescending(hd => hd.NgayLap)
                    .Select(hd => new
                    {
                        MaHD = "HD" + hd.MaHD.ToString().PadLeft(2, '0'),
                        hd.NgayLap,
                        KhachHang = hd.KhachHang.HoTen,
                        hd.TongTien,
                        hd.TrangThai
                    })
                    .Take(100)
                    .ToList();

                gridHoaDon.DataSource = data;

                gridViewHD.Columns["MaHD"].Caption = "M? HÐ";
                gridViewHD.Columns["NgayLap"].Caption = "Ngày l?p";
                gridViewHD.Columns["KhachHang"].Caption = "Khách hàng";
                gridViewHD.Columns["TongTien"].Caption = "T?ng ti?n";
                gridViewHD.Columns["TrangThai"].Caption = "Tr?ng thái";

                gridViewHD.Columns["MaHD"].Width = 70;
                gridViewHD.Columns["NgayLap"].Width = 120;
                gridViewHD.Columns["KhachHang"].Width = 150;
                gridViewHD.Columns["TongTien"].Width = 120;
                gridViewHD.Columns["TrangThai"].Width = 100;

                gridViewHD.Columns["NgayLap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewHD.Columns["NgayLap"].DisplayFormat.FormatString = "dd/MM/yyyy";

                gridViewHD.Columns["TongTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewHD.Columns["TongTien"].DisplayFormat.FormatString = "#,##0";

                // Highlight theo tr?ng thái
                gridViewHD.RowStyle += (s, e) =>
                {
                    if (e.RowHandle >= 0)
                    {
                        var trangThai = gridViewHD.GetRowCellValue(e.RowHandle, "TrangThai")?.ToString();
                        if (trangThai == "Hoàn thành")
                        {
                            e.Appearance.ForeColor = System.Drawing.Color.Green;
                        }
                        else if (trangThai == "Ð? h?y")
                        {
                            e.Appearance.ForeColor = System.Drawing.Color.Red;
                            e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 240, 240);
                        }
                    }
                };
            }
            catch { }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
