namespace FinalBlazorApp.Models
{
    public class Employee
    {
        public int EmpId { get; set; }

        public string EmpName { get; set; } = null!;

        public string Designation { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
