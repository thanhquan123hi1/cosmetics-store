using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.EntityClass
{
    public class ThuongHieu
    {

        [Key]
        public int MaThuongHieu { get; set; }

        [Required(ErrorMessage = "Tên thương hiệu là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên thương hiệu không được quá 100 ký tự")]
        public string TenThuongHieu { get; set; }

        [Required(ErrorMessage = "Quốc gia là bắt buộc")]
        [StringLength(100, ErrorMessage = "Quốc gia không được quá 100 ký tự")]
        public string QuocGia { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}