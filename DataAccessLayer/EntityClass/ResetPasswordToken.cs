using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.EntityClass
{
    public class ResetPasswordToken
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Token { get; set; }

        [Required]
        public DateTime ExpiredAt { get; set; }

        public bool IsUsed { get; set; } = false;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        public bool IsValid => !IsUsed && DateTime.Now <= ExpiredAt;
    }
}
