using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyLibrary.Models
{
    public class TechValidation
    {
        public static ValidationResult IsValidTech(string level)
        {
            if (level == "B" || level == "I" || level == "A")
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid level");
            }
        }
    }
    [Table("Technology")]
    public class Technology
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TechnologyId { get; set; }
        [Column(TypeName = "VARCHAR(20)")]
        public string TechnologyName { get; set; }
        [Column(TypeName = "CHAR(1)")]
        [CustomValidation(typeof(TechValidation), "IsValidTech")]
        public string Level { get; set; }
        public int Duration { get; set; }
        
    }
}
