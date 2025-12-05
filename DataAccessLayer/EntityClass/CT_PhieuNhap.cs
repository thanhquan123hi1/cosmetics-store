using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.EntityClass
{
    public class CT_PhieuNhap
    {

        [Key, Column(Order = 0)]
        public int MaPN { get; set; }

        [Key, Column(Order = 1)]
        public int MaSP { get; set; }

        [Key, Column(Order = 2)]
        public int STT { get; set; }

        [Required(ErrorMessage = "Số lượng nhập là bắt buộc")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng nhập phải lớn hơn 0")]
        public int SoLuong { get; set; }

        [Required(ErrorMessage = "Đơn giá nhập là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Đơn giá nhập phải >= 0")]
        public decimal DonGiaNhap { get; set; }

        [ForeignKey("MaPN")]
        public virtual PhieuNhap PhieuNhap { get; set; }

        [ForeignKey("MaSP")]
        public virtual SanPham SanPham { get; set; }
    }
}