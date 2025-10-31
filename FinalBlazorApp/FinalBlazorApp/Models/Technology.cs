using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBlazorApp.Models
{
    public class Technology
    {
        public int TechnologyId { get; set; }
        public string TechnologyName { get; set; }
        public string Level { get; set; }
        public int Duration { get; set; }
    }
}
