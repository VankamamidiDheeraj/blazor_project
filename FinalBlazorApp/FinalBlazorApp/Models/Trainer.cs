using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBlazorApp.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
