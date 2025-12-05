using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.EntityClass
{
    public class CT_HoaDon
    {
        [Key, Column(Order = 0)]
        public int MaHD { get; set; }

        [Key, Column(Order = 1)]
        public int MaSP { get; set; }

        [Key, Column(Order = 2)]
        public int STT { get; set; }

        [Required(ErrorMessage = "Số lượng là bắt buộc")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int SoLuong { get; set; }

        [Required(ErrorMessage = "Đơn giá là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Đơn giá phải >= 0")]
        public decimal DonGia { get; set; }

        [ForeignKey("MaHD")]
        public virtual HoaDon HoaDon { get; set; }

        [ForeignKey("MaSP")]
        public virtual SanPham SanPham { get; set; }
    }
}