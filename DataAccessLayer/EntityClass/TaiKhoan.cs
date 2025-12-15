using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.EntityClass
{
    public class TaiKhoan
    {
        [Key, ForeignKey("NhanVien")]
        public int MaNV { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc")]
        [StringLength(50, ErrorMessage = "Tên đăng nhập không được quá 50 ký tự")]
        public string TenDN { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [StringLength(100, ErrorMessage = "Mật khẩu không được quá 100 ký tự")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Quyền là bắt buộc")]
        [StringLength(20, ErrorMessage = "Quyền không được quá 20 ký tự")]
        public string Quyen { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        public bool TrangThai { get; set; } = true;

        public virtual NhanVien NhanVien { get; set; }
    }
}