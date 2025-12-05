using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.EntityClass
{
    public class HoaDon
    {

        [Key]
        public int MaHD { get; set; }

        [Required(ErrorMessage = "Mã khách hàng là bắt buộc")]
        public int MaKH { get; set; }

        [Required(ErrorMessage = "Mã nhân viên là bắt buộc")]
        public int MaNV { get; set; }

        [Required(ErrorMessage = "Tổng tiền là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Tổng tiền phải >= 0")]
        public decimal TongTien { get; set; }

        [Required(ErrorMessage = "Ngày lập là bắt buộc")]
        public DateTime NgayLap { get; set; }

        [Required(ErrorMessage = "Trạng thái là bắt buộc")]
        [StringLength(50, ErrorMessage = "Trạng thái không được quá 50 ký tự")]
        public string TrangThai { get; set; }

        [Required(ErrorMessage = "Phương thức thanh toán là bắt buộc")]
        [StringLength(100)]
        public string PhuongThucTT { get; set; }

        [ForeignKey("MaKH")]
        public virtual KhachHang KhachHang { get; set; }

        [ForeignKey("MaNV")]
        public virtual NhanVien NhanVien { get; set; }

        public virtual ICollection<CT_HoaDon> CT_HoaDons { get; set; }
    }
}