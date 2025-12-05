using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.EntityClass
{
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }

        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [StringLength(100, ErrorMessage = "Họ tên không được quá 100 ký tự")]
        public string HoTen { get; set; }

        [StringLength(20, ErrorMessage = "SĐT không được quá 20 ký tự")]
        public string SDT { get; set; }

        [StringLength(10, ErrorMessage = "Giới tính không được quá 10 ký tự")]
        public string GioiTinh { get; set; }

        [StringLength(300, ErrorMessage = "Địa chỉ không được quá 300 ký tự")]
        public string DiaChi { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}