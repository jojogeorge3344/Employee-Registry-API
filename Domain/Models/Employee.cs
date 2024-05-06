namespace Domain.Models
{
    public class Employee 
    {
        public int Id { get; set; }
        public required string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public string Address { get; set; }
        public decimal Phone { get; set; }
        public string BloodGroup { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
    }
}
