namespace PPM.Model
{
    public interface IEmployeeProjectDomain
    {
        public void AddEmployeeToProject(int projectId, string? projectName, int employeeId, string? firstName, string? lastName, int roleId);
        public void DeleteEmployeeFromProject(int? projectId, int? employeeId);


    }
}