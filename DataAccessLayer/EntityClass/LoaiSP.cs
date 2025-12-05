using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.EntityClass
{

    public class LoaiSP
    {
        [Key]
        public int MaLoai { get; set; }

        [Required(ErrorMessage = "Tên loại là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên loại không được quá 100 ký tự")]
        public string TenLoai { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được quá 500 ký tự")]
        public string MoTa { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}