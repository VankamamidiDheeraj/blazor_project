using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingLibrary.Models
{
    [Table("Technology")]
    public class Technology
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TechnologyId { get; set; }
    }
}
