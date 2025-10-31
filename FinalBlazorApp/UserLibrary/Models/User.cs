using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLibrary.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column(TypeName = "VARCHAR(20)")]
        public string UserId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string Password { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
