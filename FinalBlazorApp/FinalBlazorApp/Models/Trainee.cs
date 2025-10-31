using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBlazorApp.Models
{
    public class Trainee
    {
        public int TrainingId { get; set; }
        public int EmpId { get; set; }
        public string Status { get; set; }

    }
}
