using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpId { get; set; }
        [Column(TypeName = "VARCHAR(20)")]
        public string EmpName { get; set; }
        [Column(TypeName = "VARCHAR(10)")]
        public string Designation { get; set; }
        [Column(TypeName = "VARCHAR(20)")]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR(10)")]
        public string Phone { get; set; }

        
    }
}
