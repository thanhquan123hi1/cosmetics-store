using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.EntityClass
{
    public class SanPham
    {

        [Key]
        public int MaSP { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
        [StringLength(200, ErrorMessage = "Tên sản phẩm không được quá 200 ký tự")]
        public string TenSP { get; set; }

        [StringLength(1000)]
        public string MoTa { get; set; }

        [Required(ErrorMessage = "Số lượng tồn là bắt buộc")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn phải >= 0")]
        public int SoLuongTon { get; set; }

        [Required(ErrorMessage = "Đơn giá là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Đơn giá phải >= 0")]
        public decimal DonGia { get; set; }

        [Required(ErrorMessage = "Mã loại là bắt buộc")]
        public int MaLoai { get; set; }

        [Required(ErrorMessage = "Mã thương hiệu là bắt buộc")]
        public int MaThuongHieu { get; set; }

        [StringLength(500)]
        public string HinhAnh { get; set; }


        [ForeignKey("MaLoai")]
        public virtual LoaiSP LoaiSP { get; set; }

        [ForeignKey("MaThuongHieu")]
        public virtual ThuongHieu ThuongHieu { get; set; }

        public virtual ICollection<CT_HoaDon> CT_HoaDons { get; set; }

        public virtual ICollection<CT_PhieuNhap> CT_PhieuNhaps { get; set; }
    }
}