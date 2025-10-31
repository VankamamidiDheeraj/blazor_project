using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLibrary.Models
{
    [Table("UserRoles")]
    [PrimaryKey("UserId", "RoleId")]

    public class UserRole
    {
        [Column(TypeName = "VARCHAR(20)")]
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual User? User { get; set; }
        public virtual Role? Role { get; set; }
    }
}
