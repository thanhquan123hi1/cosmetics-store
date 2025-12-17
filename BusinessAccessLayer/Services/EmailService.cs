using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Configuration;

namespace BusinessAccessLayer.Services
{
    public class EmailService : IDisposable
    {
        // SMTP Gmail (cố định)
        private string _smtpHost = "smtp.gmail.com";
        private int _smtpPort = 587;

        private string _senderEmail;
        private string _senderPassword;
        private string _senderDisplayName;

        private SmtpClient _smtpClient;

        public EmailService()
        {
            LoadConfig();
            InitializeSmtpClient();
        }

        private void LoadConfig()
        {
            _senderEmail = ConfigurationManager.AppSettings["SmtpEmail"];
            _senderPassword = ConfigurationManager.AppSettings["SmtpPassword"];
            _senderDisplayName = ConfigurationManager.AppSettings["SmtpDisplayName"];

            if (string.IsNullOrWhiteSpace(_senderEmail) ||
                string.IsNullOrWhiteSpace(_senderPassword))
            {
                throw new Exception("SMTP Email hoặc Password chưa được cấu hình trong App.config");
            }
        }

        private void InitializeSmtpClient()
        {
            _smtpClient = new SmtpClient(_smtpHost, _smtpPort)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_senderEmail, _senderPassword),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Timeout = 30000
            };
        }

        public bool SendResetPasswordEmail(string toEmail, string resetToken)
        {
            try
            {
                string subject = "🔒 Đặt lại mật khẩu - Cosmetics Store";

                // Sử dụng String Interpolation với CSS đã được escape ({{ }})
                string body = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <style>
                /* Cấu trúc cơ bản */
                body {{ font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0; }}
                .container {{ max-width: 550px; margin: 40px auto; background-color: #ffffff; border-radius: 8px; box-shadow: 0 4px 10px rgba(0,0,0,0.05); overflow: hidden; border: 1px solid #e0e0e0; }}
                
                /* Header: Logo chữ sang trọng */
                .header {{ background-color: #ffffff; padding: 30px 20px 20px; text-align: center; border-bottom: 2px solid #f0f0f0; }}
                .brand-text {{ color: #333; font-size: 24px; font-weight: 700; letter-spacing: 3px; text-transform: uppercase; margin: 0; }}
                .brand-sub {{ font-size: 12px; color: #888; letter-spacing: 1px; margin-top: 5px; text-transform: uppercase; }}

                /* Nội dung chính */
                .content {{ padding: 40px 35px; color: #444; line-height: 1.6; font-size: 15px; }}
                .title {{ color: #D81B60; font-size: 20px; font-weight: 600; margin-bottom: 20px; text-align: center; }}
                
                /* Hộp mã Token */
                .token-box {{ margin: 30px 0; text-align: center; }}
                .token {{ 
                    display: inline-block;
                    background-color: #fff5f8; 
                    color: #D81B60; 
                    font-size: 32px; 
                    font-weight: bold; 
                    padding: 15px 40px; 
                    border: 2px dashed #D81B60; 
                    border-radius: 6px; 
                    letter-spacing: 6px; 
                    font-family: 'Courier New', monospace; /* Font này giúp số và chữ rõ ràng */
                }}

                /* Ghi chú bảo mật */
                .security-note {{ font-size: 13px; color: #666; background: #f9f9f9; padding: 15px; border-radius: 4px; border-left: 3px solid #555; margin-top: 30px; }}
                
                /* Footer */
                .footer {{ background-color: #333; color: #fff; padding: 25px; text-align: center; font-size: 12px; }}
                .footer p {{ margin: 5px 0; opacity: 0.7; }}
                .divider {{ height: 1px; background-color: #555; margin: 15px auto; width: 50px; }}
            </style>
        </head>
        <body>
            <div class='container'>
                <div class='header'>
                    <h1 class='brand-text'>Cosmetics Store</h1>
                    <div class='brand-sub'>Premium Beauty & Care</div>
                </div>
                
                <div class='content'>
                    <div class='title'>Yêu cầu đặt lại mật khẩu</div>
                    <p>Xin chào,</p>
                    <p>Chúng tôi đã nhận được yêu cầu khôi phục quyền truy cập vào tài khoản của bạn. Đây là mã xác thực bảo mật của bạn:</p>
                    
                    <div class='token-box'>
                        <span class='token'>{resetToken}</span>
                    </div>

                    <p>Mã này có hiệu lực trong vòng <strong>30 phút</strong>.</p>
                    
                    <div class='security-note'>
                        Nếu bạn không thực hiện yêu cầu này, vui lòng bỏ qua email và kiểm tra lại bảo mật tài khoản của mình. Đừng chia sẻ mã này cho bất kỳ ai.
                    </div>
                </div>

                <div class='footer'>
                    <p>© {DateTime.Now.Year} Cosmetics Store Application</p>
                    <div class='divider'></div>
                    <p>Email này được gửi tự động từ hệ thống.</p>
                </div>
            </div>
        </body>
        </html>";

                return SendEmail(toEmail, subject, body, true);
            }
            catch
            {
                return false;
            }
        }

        public bool SendPasswordChangedNotification(string toEmail)
        {
            try
            {
                string subject = "🛡️ Thông báo bảo mật: Mật khẩu đã được thay đổi";

                string body = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <style>
                /* Cấu trúc chung (Giống email trước) */
                body {{ font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0; }}
                .container {{ max-width: 550px; margin: 40px auto; background-color: #ffffff; border-radius: 8px; box-shadow: 0 4px 10px rgba(0,0,0,0.05); overflow: hidden; border: 1px solid #e0e0e0; }}
                
                /* Header */
                .header {{ background-color: #ffffff; padding: 30px 20px 20px; text-align: center; border-bottom: 2px solid #f0f0f0; }}
                .brand-text {{ color: #333; font-size: 24px; font-weight: 700; letter-spacing: 3px; text-transform: uppercase; margin: 0; }}
                .brand-sub {{ font-size: 12px; color: #888; letter-spacing: 1px; margin-top: 5px; text-transform: uppercase; }}

                /* Nội dung chính */
                .content {{ padding: 40px 35px; color: #444; line-height: 1.6; font-size: 15px; text-align: center; }}
                
                /* Biểu tượng thành công (CSS thuần, không cần ảnh) */
                .success-icon {{ 
                    width: 60px; height: 60px; line-height: 60px; 
                    background-color: #e8f5e9; color: #2e7d32; 
                    border-radius: 50%; margin: 0 auto 20px; 
                    font-size: 30px; font-weight: bold;
                }}
                
                .title {{ color: #2e7d32; font-size: 22px; font-weight: 600; margin-bottom: 10px; }}
                .time-box {{ margin: 20px 0; background-color: #f8f9fa; padding: 15px; border-radius: 6px; border: 1px solid #eee; display: inline-block; width: 80%; }}
                .time-label {{ font-size: 12px; color: #888; text-transform: uppercase; display: block; margin-bottom: 5px; }}
                .time-value {{ font-size: 16px; font-weight: 600; color: #333; }}

                /* Cảnh báo quan trọng */
                .alert-box {{ margin-top: 30px; padding: 15px; background-color: #fff5f5; border-left: 4px solid #D81B60; color: #c0392b; text-align: left; font-size: 14px; border-radius: 4px; }}
                
                /* Footer */
                .footer {{ background-color: #333; color: #fff; padding: 25px; text-align: center; font-size: 12px; }}
                .footer p {{ margin: 5px 0; opacity: 0.7; }}
            </style>
        </head>
        <body>
            <div class='container'>
                <div class='header'>
                    <h1 class='brand-text'>Cosmetics Store</h1>
                    <div class='brand-sub'>Premium Beauty & Care</div>
                </div>
                
                <div class='content'>
                    <div class='success-icon'>✓</div>
                    
                    <div class='title'>Đổi mật khẩu thành công</div>
                    <p>Mật khẩu cho tài khoản Cosmetics Store của bạn đã được cập nhật thành công.</p>
                    
                    <div class='time-box'>
                        <span class='time-label'>Thời gian thay đổi</span>
                        <span class='time-value'>{DateTime.Now:HH:mm - dd/MM/yyyy}</span>
                    </div>

                    <div class='alert-box'>
                        <strong>⚠️ Quan trọng:</strong> Nếu bạn KHÔNG thực hiện thao tác này, tài khoản của bạn có thể đang bị xâm nhập. Vui lòng liên hệ với bộ phận CSKH hoặc khôi phục mật khẩu ngay lập tức.
                    </div>
                </div>

                <div class='footer'>
                    <p>© {DateTime.Now.Year} Cosmetics Store Application</p>
                    <p>Email này được gửi tự động để bảo mật tài khoản của bạn.</p>
                </div>
            </div>
        </body>
        </html>";

                return SendEmail(toEmail, subject, body, true);
            }
            catch
            {
                return false;
            }
        }

        private bool SendEmail(string toEmail, string subject, string body, bool isHtml)
        {
            try
            {
                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(_senderEmail, _senderDisplayName);
                    message.To.Add(toEmail);
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = isHtml;

                    _smtpClient.Send(message);
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Email Error: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> SendResetPasswordEmailAsync(string toEmail, string resetToken)
        {
            return await Task.Run(() => SendResetPasswordEmail(toEmail, resetToken));
        }

        public void Dispose()
        {
            _smtpClient?.Dispose();
        }
    }
}
