using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainerLibrary.Models
{
    public class TypeValidation
    {
        public static ValidationResult IsValidType(string type)
        {
            if (type == "I" || type == "E")
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid Type");
            }
        }
    }
    [Table("Trainer")]
    public class Trainer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrainerId { get; set; }
        [Column(TypeName = "VARCHAR(20)")]
        [Required]
        public string TrainerName { get; set; }
        [Column(TypeName = "CHAR(1)")]
        [CustomValidation(typeof(TypeValidation), "IsValidType")]
        public string Type { get; set; }
        [Column(TypeName = "VARCHAR(20)")]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR(10)")]
        public string Phone { get; set; }
      
    }
}

