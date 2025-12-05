using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.EntityClass
{
    public class PhieuNhap
    {
        [Key]
        public int MaPN { get; set; }

        [Required(ErrorMessage = "Ngày nhập là bắt buộc")]
        public DateTime NgayNhap { get; set; }

        [Required(ErrorMessage = "Mã nhà cung cấp là bắt buộc")]
        public int MaNCC { get; set; }

        [ForeignKey("MaNCC")]
        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual ICollection<CT_PhieuNhap> CT_PhieuNhaps { get; set; }
    }
}