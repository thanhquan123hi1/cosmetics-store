using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormKH
{
    /// <summary>
    /// Form hi?n th? QR code thanh toán sau khi thanh toán thành công
    /// </summary>
    public partial class fThanhToanThanhCong : DevExpress.XtraEditors.XtraForm
    {
        private int _maHD;
        private decimal _tongTien;
        private string _phuongThucTT;

        public fThanhToanThanhCong(int maHD, decimal tongTien, string phuongThucTT)
        {
            InitializeComponent();
            _maHD = maHD;
            _tongTien = tongTien;
            _phuongThucTT = phuongThucTT;
            
            this.Load += FThanhToanThanhCong_Load;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(500, 650);
            this.BackColor = Color.White;
        }

        private void FThanhToanThanhCong_Load(object sender, EventArgs e)
        {
            SetupUI();
            LoadQRCode();
        }

        private void SetupUI()
        {
            // === ICON SUCCESS ===
            var picSuccess = new PictureBox
            {
                Size = new Size(80, 80),
                Location = new Point((this.ClientSize.Width - 80) / 2, 20),
                SizeMode = PictureBoxSizeMode.CenterImage,
                BackColor = Color.FromArgb(46, 204, 113)
            };
            
            // V? icon checkmark
            picSuccess.Paint += (s, pe) =>
            {
                pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (var pen = new Pen(Color.White, 8))
                {
                    // V? d?u tick
                    pe.Graphics.DrawLine(pen, 20, 40, 35, 55);
                    pe.Graphics.DrawLine(pen, 35, 55, 60, 25);
                }
            };
            this.Controls.Add(picSuccess);

            // === TITLE ===
            var lblTitle = new Label
            {
                Text = "Thanh toán thành công!",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 204, 113),
                AutoSize = true,
                Location = new Point(0, 115)
            };
            lblTitle.Location = new Point((this.ClientSize.Width - lblTitle.PreferredWidth) / 2, 115);
            this.Controls.Add(lblTitle);

            // === INFO PANEL ===
            var pnlInfo = new Panel
            {
                Size = new Size(420, 100),
                Location = new Point(40, 160),
                BackColor = Color.FromArgb(245, 245, 250)
            };

            pnlInfo.Controls.Add(new Label
            {
                Text = $"Hóa ??n: HD{_maHD:D5}",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 48),
                Location = new Point(15, 15),
                AutoSize = true
            });

            pnlInfo.Controls.Add(new Label
            {
                Text = $"T?ng ti?n: {_tongTien:N0} VN?",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(231, 76, 60),
                Location = new Point(15, 45),
                AutoSize = true
            });

            pnlInfo.Controls.Add(new Label
            {
                Text = $"Ph??ng th?c: {_phuongThucTT}",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.Gray,
                Location = new Point(15, 75),
                AutoSize = true
            });

            this.Controls.Add(pnlInfo);

            // === QR CODE PANEL ===
            var lblQRTitle = new Label
            {
                Text = "?? Quét mã QR ?? thanh toán",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 48),
                AutoSize = true,
                Location = new Point(0, 280)
            };
            lblQRTitle.Location = new Point((this.ClientSize.Width - lblQRTitle.PreferredWidth) / 2, 280);
            this.Controls.Add(lblQRTitle);

            // === QR CODE IMAGE ===
            var picQR = new PictureBox
            {
                Name = "picQRCode",
                Size = new Size(250, 250),
                Location = new Point((this.ClientSize.Width - 250) / 2, 315),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                SizeMode = PictureBoxSizeMode.CenterImage
            };
            this.Controls.Add(picQR);

            // === CLOSE BUTTON ===
            var btnClose = new SimpleButton
            {
                Text = "?óng",
                Size = new Size(120, 40),
                Location = new Point((this.ClientSize.Width - 120) / 2, 575),
                Appearance = { 
                    BackColor = Color.FromArgb(52, 152, 219),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold)
                }
            };
            btnClose.Click += (s, args) => this.Close();
            this.Controls.Add(btnClose);
        }

        private void LoadQRCode()
        {
            try
            {
                var picQR = this.Controls.Find("picQRCode", false)[0] as PictureBox;
                if (picQR == null) return;

                // T?o n?i dung QR: Thông tin hóa ??n cho ví ?i?n t?
                // Format: BankTransfer|HoaDon|HD00005|32333330
                string qrContent = $"BankTransfer|HoaDon|HD{_maHD:D5}|{_tongTien}";

                // Ph??ng án 1: S? d?ng API Google Charts (??n gi?n nh?t)
                string qrUrl = $"https://api.qrserver.com/v1/create-qr-code/?size=250x250&data={Uri.EscapeDataString(qrContent)}";

                // T?i QR code t? API
                using (WebClient client = new WebClient())
                {
                    byte[] imageData = client.DownloadData(qrUrl);
                    using (var ms = new System.IO.MemoryStream(imageData))
                    {
                        picQR.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                // N?u không t?i ???c QR, hi?n th? placeholder
                var picQR = this.Controls.Find("picQRCode", false)[0] as PictureBox;
                if (picQR != null)
                {
                    picQR.Paint += (s, pe) =>
                    {
                        pe.Graphics.Clear(Color.FromArgb(245, 245, 250));
                        
                        string errorText = "??\n\nKhông th? t?o mã QR\n\nVui lòng chuy?n kho?n theo\nthông tin sau:\n\n" +
                                         $"N?i dung: HD{_maHD:D5}\n" +
                                         $"S? ti?n: {_tongTien:N0} VN?";
                        
                        var sf = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };
                        
                        pe.Graphics.DrawString(errorText, 
                            new Font("Segoe UI", 10F), 
                            Brushes.Gray, 
                            picQR.ClientRectangle, 
                            sf);
                    };
                    picQR.Invalidate();
                }
                
                System.Diagnostics.Debug.WriteLine($"LoadQRCode Error: {ex.Message}");
            }
        }

        private void fThanhToanThanhCong_Load_1(object sender, EventArgs e)
        {

        }
    }
}
