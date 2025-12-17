using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.EntityClass
{
    /// <summary>
    /// Entity lýu tr? token reset m?t kh?u
    /// Token có th?i h?n 30 phút và ch? s? d?ng ðý?c 1 l?n
    /// </summary>
    public class ResetPasswordToken
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Email c?a tài kho?n c?n reset m?t kh?u
        /// </summary>
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Token GUID duy nh?t ð? xác th?c
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Token { get; set; }

        /// <summary>
        /// Th?i ði?m token h?t h?n (CreatedAt + 30 phút)
        /// </summary>
        [Required]
        public DateTime ExpiredAt { get; set; }

        /// <summary>
        /// Ðánh d?u token ð? ðý?c s? d?ng (ch? dùng 1 l?n)
        /// </summary>
        public bool IsUsed { get; set; } = false;

        /// <summary>
        /// Th?i ði?m t?o token
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Ki?m tra token c?n hi?u l?c không
        /// </summary>
        [NotMapped]
        public bool IsValid => !IsUsed && DateTime.Now <= ExpiredAt;
    }
}
