


using System.Text.RegularExpressions;
using System.Collections.Generic;
using PPM.Model;
using PPM.Domain;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.Emit;
using System.Numerics;
using System.Runtime;
namespace PPM.Ui.Consoles
{
    public class Consoles
    {
       
        public static List<EmployeeDetails> ViewEmployees()
        {
            foreach (EmployeeDetails details in Employee.employeeList)
            {
                Console.WriteLine("employeeId={0},firstName={1},lastName={2},Email={3},phoneNumber={4},Address={5},roleId={6}", details.EmployeeId, details.FirstName, details.LastName, details.Email, details.PhoneNumber, details.Address, details.RoleId);
            }
            return Employee.employeeList;

        }

       
        public static List<ProjectDetails> ViewProjects()
        {
            foreach (ProjectDetails items in Project.projectList)
            {
                Console.WriteLine("projectId={0},projectName={1},startDate={2},endDate={3}", items.ProjectId, items.ProjectName, items.StartDate, items.EndDate);
            }
            return Project.projectList;
        }

       
        public static List<RoleDetails> ViewRoles()

        {
            foreach (RoleDetails details in Role.roleList)
            {
                Console.WriteLine("roleId = {0}, roleName = {1}", details.RoleId, details.RoleName);
            }
            return Role.roleList;
        }
        public void AddEmployeeToProject(int projectId, string projectName)
        {
            EmployeeProjectProperties employeeProjectProperties = new EmployeeProjectProperties();

           


            int employeeId;

            while (true)

            {

                while (true)

                {

                    System.Console.WriteLine("Enter the employee id that you want add Project");

                    employeeId = int.Parse(System.Console.ReadLine() ?? string.Empty);



                    bool employeeExist = Employee.employeeList.Any(p => p.EmployeeId == employeeId);

                    if (employeeExist)

                    {
                        employeeProjectProperties.EmployeeId = employeeId;
                        break;

                    }

                    else

                    {
                        System.Console.WriteLine("Enter Proper Id");
                    }

                }


                bool employeeProjectExist = EmployeeProject.employeeProjectList.Any(p => p.ProjectId == projectId && p.EmployeeId == employeeId);

                if (employeeProjectExist)

                {

                    System.Console.WriteLine("Enter employee already added to project");

                }

                else

                {


                    var query2 = from items in Employee.employeeList

                                 where items.EmployeeId == employeeId

                                 select new { items.EmployeeId, items.FirstName, items.LastName, items.RoleId };



                    foreach (var item in query2)

                    {

                        employeeId = item.EmployeeId;

                        employeeProjectProperties.FirstName = item.FirstName;

                        employeeProjectProperties.LastName = item.LastName;

                        employeeProjectProperties.RoleId = item.RoleId;

                    }

                    break;

                }

            }

            Console.WriteLine("Employee Added to Project");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("*******************");
            Console.WriteLine("Employee Added to Project");
            Console.WriteLine("******************");
            Console.ResetColor();
            EmployeeProject employeeProject=new EmployeeProject();
            employeeProject.AddEmployeeToProject(projectId, projectName, employeeProjectProperties.EmployeeId, employeeProjectProperties.FirstName, employeeProjectProperties.LastName, employeeProjectProperties.RoleId);

        }
        public void RemoveEmployeeMethod()

        {
            EmployeeProjectProperties employeeProjectProperties = new EmployeeProjectProperties();
            int projectId;
            int employeeId;
            while (true)
            {
                Console.WriteLine("enter the project Id from which you want to remove the employee");
                projectId = int.Parse(Console.ReadLine() ?? string.Empty);
                bool projectExist = Project.projectList.Any(p => p.ProjectId == projectId);
                if (projectExist)
                {
                    employeeProjectProperties.ProjectId = projectId;
                    break;
                }
                else
                {
                    Console.WriteLine("enter the proper projectId");
                }
            }

            bool continueRemoval = true;

            while (continueRemoval)
            {
                System.Console.WriteLine("Enter the employee id that you want to remove from the project");
                employeeId = int.Parse(System.Console.ReadLine() ?? string.Empty);

                bool employeeExist = Employee.employeeList.Any(p => p.EmployeeId == employeeId);
                if (employeeExist)
                {
                    bool employeeProjectExist = EmployeeProject.employeeProjectList.Any(p => p.ProjectId == projectId && p.EmployeeId == employeeId);
                    if (employeeProjectExist)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("******************");
                        Console.WriteLine("Employee removed from the project");
                        Console.WriteLine("******************");
                         EmployeeProject employeeProject=new EmployeeProject();
                        employeeProject.DeleteEmployeeFromProject(projectId, employeeId);
                    }
                    else
                    {

                        Console.WriteLine("Employee not associated with the project");

                    }
                }

                else

                {
                    System.Console.WriteLine("Enter a valid employee ID.");
                    employeeId = int.Parse(System.Console.ReadLine() ?? string.Empty);
                }

                System.Console.WriteLine("Do you want to remove another employee from the project? (yes/no)");
                string choice = System.Console.ReadLine() ?? string.Empty;

                if (choice != "yes")
                {
                    continueRemoval = false;
                }

            }

        }
        public static void ViewEmployeeProject()
        {
            foreach (EmployeeProjectProperties items in EmployeeProject.employeeProjectList)
            {
                Console.WriteLine("projectId={0},projectName={1},employeeId={2},firstName={3},lastName={4},roleId={5}", items.ProjectId, items.ProjectName, items.EmployeeId, items.FirstName, items.LastName, items.RoleId);
            }

        }

    }

}













