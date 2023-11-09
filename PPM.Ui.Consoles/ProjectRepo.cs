using System.Text.RegularExpressions;
using System.Collections.Generic;
using PPM.Model;
using PPM.Domain;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.Emit;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
namespace PPM.Ui.Consoles
{
    public class ProjectRepo
    {
        Project project = new Project();
        public void AddProjectMethod()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("enter the size");
         
            int size = int.Parse(Console.ReadLine() ?? string.Empty);

            for (int i = 0; i < size; i++)
            {
                ProjectDetails projectDetails = new ProjectDetails();

                while (true)
                {

                    try
                    {

                        Console.WriteLine("enter the ProjectId");
                        int id = int.Parse(Console.ReadLine() ?? string.Empty);
                        while (id <= 0)
                        {
                            Console.WriteLine("projectId id should not be zero and negative");
                            id = int.Parse(Console.ReadLine() ?? string.Empty);

                        }


                        var existingProject = Project.projectList.Find(p => p.ProjectId == id);
                        while (existingProject != null)
                        {
                            Console.WriteLine("Project with the same ID already exists.");
                            id = int.Parse(Console.ReadLine() ?? string.Empty);
                            break;

                        }

                        projectDetails.ProjectId = id;
                        

                        Console.WriteLine("Enter the project name");
                        projectDetails.ProjectName = Console.ReadLine();
                        Console.WriteLine("Enter the start date");
                        projectDetails.StartDate = DateOnly.Parse(Console.ReadLine() ?? string.Empty);
                        Console.WriteLine("Enter the end date");
                        projectDetails.EndDate = DateOnly.Parse(Console.ReadLine() ?? string.Empty);

                        while (projectDetails.StartDate >= projectDetails.EndDate)
                        {

                            Console.WriteLine("Invalid project dates.");
                            projectDetails.EndDate = DateOnly.Parse(Console.ReadLine() ?? string.Empty);


                        }
                        System.Console.WriteLine("do you want to add employee's to the project");

                        string choice = Console.ReadLine() ?? string.Empty;

                        if (choice == "YES" | choice == "yes" | choice == "Yes")
                        {

                            if (Employee.employeeList.Count == 0)
                            {
                                System.Console.WriteLine("there no employees in the list");
                                return;
                            }
                            else
                            {

                                EmployeeProjectProperties employeeProjectProperties = new EmployeeProjectProperties();

                                Consoles consoles = new Consoles();
                                consoles.AddEmployeeToProject(projectDetails.ProjectId, projectDetails.ProjectName ?? string.Empty);
                                System.Console.WriteLine("Employee with EmployeeId added to the project");
                                System.Console.WriteLine("\n");
                            }
                        }



                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("*******************");
                        Console.WriteLine("Project  Added");
                        Console.WriteLine("*******************");

                        Console.ResetColor();
                        Project project = new Project();
                        project.AddEntity(projectDetails);
                        break;


                    }
                    catch (FormatException exp)
                    {
                        System.Console.WriteLine("Exception ocurred in the Application. Check the exception details below:");
                        System.Console.WriteLine("Technical Message : {0}", exp.Message);
                        System.Console.WriteLine("User Friendly Message  : Please enter numbers only.");
                    }
                }


            }
        }
        public void ListProjects()
        {
            var getProject = project.ListAll();
            foreach (ProjectDetails items in getProject)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("projectId={0},projectName={1},startDate={2},endDate={3}", items.ProjectId, items.ProjectName, items.StartDate, items.EndDate);
                Console.ResetColor();

            }
        }
        public void ListProjectsById()
        {
            System.Console.WriteLine("Enter the project Id");
            int id = int.Parse(Console.ReadLine() ?? string.Empty);
            //
            ProjectDetails projectDetails = project.ListById(id);
            if (projectDetails != null)
            {


                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("projectId={0},projectName={1},startDate={2},endDate={3}", projectDetails.ProjectId, projectDetails.ProjectName, projectDetails.StartDate, projectDetails.EndDate);
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                System.Console.WriteLine(" --------project  Id doesn't exists ----------");
                Console.ResetColor();
            }
        }
        public void DeleteProjectMethod()
        {
            ProjectDetails ProjectDetails = new ProjectDetails();
            Console.WriteLine("enter the project Id from which you want to remove the employee");
            int projectId = int.Parse(Console.ReadLine() ?? string.Empty);
            bool projectExist = Project.projectList.Any(p => p.ProjectId == projectId);

            if (projectExist)
            {

                bool projectAssigned = EmployeeProject.employeeProjectList.Any(p => p.ProjectId == projectId);
                if (!projectAssigned)
                {


                    Project project = new Project();
                    project.DeleteById(projectId);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("******************************");
                    Console.WriteLine("Project Deleted successfully");
                    Console.WriteLine("*******************************");
                    Console.ResetColor();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Project  assigned to employees");
                    Console.ResetColor();
                }


            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Project id does not exists ");
                Console.ResetColor();

            }
        }
    }
}