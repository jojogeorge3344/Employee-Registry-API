using Domain.Types;

namespace Domain.Models
{
    public class JobDetails : CommonModel
    {
        public int EmployeeId { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public ShiftType ShiftType { get; set; }
        public TimeType TimeType { get; set; }
    }
}