namespace Application.Models.EmployeeDtos
{
    public class NewEmployeeDto
    {
        public required string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string BloodGroup { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
    }
}
