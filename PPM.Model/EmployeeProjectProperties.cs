using System.Dynamic;

namespace PPM.Model
{
    public class EmployeeProjectProperties
    {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }

        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int RoleId { get; set; }
    }
}