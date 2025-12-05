using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.EntityClass
{
    public class NhanVien
    {
        [Key]
        public int MaNV { get; set; }

        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [StringLength(100, ErrorMessage = "Họ tên không được quá 100 ký tự")]
        public string HoTen { get; set; }

        [StringLength(10, ErrorMessage = "Giới tính không được quá 10 ký tự")]
        public string GioiTinh { get; set; }

        [Required(ErrorMessage = "Ngày sinh là bắt buộc")]
        public DateTime NgaySinh { get; set; }

        [StringLength(300, ErrorMessage = "Địa chỉ không được quá 300 ký tự")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Chức vụ là bắt buộc")]
        [StringLength(50, ErrorMessage = "Chức vụ không được quá 50 ký tự")]
        public string ChucVu { get; set; }

        [StringLength(20, ErrorMessage = "SĐT không được quá 20 ký tự")]
        public string SDT { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}