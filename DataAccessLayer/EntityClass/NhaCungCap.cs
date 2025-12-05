using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.EntityClass
{
    public class NhaCungCap
    {
        [Key]
        public int MaNCC { get; set; }

        [Required(ErrorMessage = "Tên nhà cung cấp là bắt buộc")]
        [StringLength(200, ErrorMessage = "Tên nhà cung cấp không được quá 200 ký tự")]
        public string TenNCC { get; set; }

        [StringLength(300, ErrorMessage = "Địa chỉ không được quá 300 ký tự")]
        public string DiaChi { get; set; }

        [StringLength(20, ErrorMessage = "SĐT không được quá 20 ký tự")]
        public string SDT { get; set; }

        [StringLength(100, ErrorMessage = "Email không được quá 100 ký tự")]
        public string Email { get; set; }
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
    }
}