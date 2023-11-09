using PPM.Model;

namespace PPM.Domain
{
    public class EmployeeProject:IEmployeeProjectDomain
    {
        public static List<EmployeeProjectProperties> employeeProjectList = new List<EmployeeProjectProperties>();
        public  void AddEmployeeToProject(int projectId, string? projectName, int employeeId, string? firstName, string? lastName, int roleId)
        {
            EmployeeProjectProperties employeeProjectObj = new EmployeeProjectProperties()
            {
                ProjectId = projectId,
                ProjectName = projectName,
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                RoleId = roleId,
            };
            employeeProjectList.Add(employeeProjectObj);
        }
        public  void DeleteEmployeeFromProject(int? projectId, int? employeeId)

        {

            int indexToRemove = employeeProjectList.FindIndex(item => item.ProjectId == projectId && item.EmployeeId == employeeId);
            while (indexToRemove >= 0)
            {
                employeeProjectList.RemoveAt(indexToRemove);

            }
           
        }



    }
}







