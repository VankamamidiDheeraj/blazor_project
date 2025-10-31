using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingLibrary.Models
{
    [Table("Training")]
    public class Training
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrainingId { get; set; }

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }

        [ForeignKey("Technology")]
        public int TechnologyId { get; set; }
        [Column(TypeName = "DATETIME")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "DATETIME")]
        public DateTime EndDate { get; set; }
        // Navigation properties

        public Technology? Technology { get; set; }
        public Trainer? Trainer { get; set; }
        public ICollection<Trainee>? Trainees { get; set; }
    }
}
