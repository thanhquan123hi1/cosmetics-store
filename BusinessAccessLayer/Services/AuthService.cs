using System;
using DataAccessLayer;
using BusinessAccessLayer.DTOs;
using BusinessAccessLayer.Services.Auth;

namespace BusinessAccessLayer.Services
{
    /// <summary>
    /// AuthService chính - Facade cho các Auth services
    /// Giữ backward compatibility với code cũ
    /// </summary>
    public class AuthService : IDisposable
    {
        private readonly LoginService _loginService;
        private readonly RegisterService _registerService;
        private readonly PasswordService _passwordService;
        private readonly ResetPasswordService _resetPasswordService;

        public AuthService()
        {
            var context = new CosmeticsContext();
            _loginService = new LoginService(context);
            _registerService = new RegisterService(context);
            _passwordService = new PasswordService(context);
            _resetPasswordService = new ResetPasswordService(context);
        }

        /// <summary>
        /// Đăng nhập
        /// </summary>
        public LoginResult Login(string username, string password)
        {
            return _loginService.Login(username, password);
        }

        /// <summary>
        /// Đăng ký
        /// </summary>
        public RegisterResult Register(RegisterDTO registerInfo)
        {
            return _registerService.Register(registerInfo);
        }

        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            var result = _passwordService.ChangePassword(username, oldPassword, newPassword);
            return result.Success;
        }

        /// <summary>
        /// Yêu cầu reset mật khẩu
        /// </summary>
        public ResetPasswordResult RequestResetPassword(string email)
        {
            return _resetPasswordService.RequestResetPassword(email);
        }

        /// <summary>
        /// Xác thực token reset password
        /// </summary>
        public ResetPasswordResult ValidateResetToken(string token)
        {
            return _resetPasswordService.ValidateResetToken(token);
        }

        /// <summary>
        /// Reset mật khẩu với token
        /// </summary>
        public ResetPasswordResult ResetPassword(string token, string newPassword)
        {
            return _resetPasswordService.ResetPassword(token, newPassword);
        }

        public void Dispose()
        {
            _loginService?.Dispose();
            _registerService?.Dispose();
            _passwordService?.Dispose();
            _resetPasswordService?.Dispose();
        }
    }
}
