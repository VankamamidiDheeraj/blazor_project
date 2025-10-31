using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingLibrary.Models;

namespace TrainingLibrary.Models
{
    public class StatusValidation
    {
        public static ValidationResult IsValidStatus(string status)
        {
            if (status == "C" || status == "N")
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid Status");
            }
        }
    }
}
[Table("Trainee")]
[PrimaryKey("TrainingId", "EmpId")]
public class Trainee
{

    [ForeignKey("Training")]
    public int TrainingId { get; set; }

    [ForeignKey("Employee")]
    public int EmpId { get; set; }
    [Column(TypeName = "CHAR(1)")]
    [CustomValidation(typeof(StatusValidation), "IsValidStatus")]
    public string Status { get; set; }

    public Training? Training { get; set; }
    public Employee? Employee { get; set; }

}

