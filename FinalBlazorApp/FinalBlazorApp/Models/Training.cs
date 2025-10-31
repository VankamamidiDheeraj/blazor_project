using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBlazorApp.Models
{
    public class Training
    {
        public int TrainingId { get; set; }
        public int TrainerId { get; set; }
        public int TechnologyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        // Navigation properties
    }
}
