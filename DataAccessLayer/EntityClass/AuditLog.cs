using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityClass
{
    public class AuditLog
    {
        [Key]
        public int MaLog { get; set; }

        public DateTime ThoiGian { get; set; }

        [Required]
        public string HanhDong { get; set; }

        public string DuLieuCu { get; set; }
        public string DuLieuMoi { get; set; }

        public string MaBanGhi { get; set; }

        public int? MaNV { get; set; }

        [ForeignKey("MaNV")]
        public virtual NhanVien NhanVien { get; set; }
    }


}
