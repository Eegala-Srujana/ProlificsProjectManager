using System.Text.RegularExpressions;
using System.Collections.Generic;
using PPM.Model;
using PPM.Domain;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.Emit;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
namespace PPM.Ui.Consoles
{

    public class ProjectConsole

    {
        public void ProjectModule()
        {
            int choice1;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("-------------------------");
                Console.WriteLine(" Show The Menu");
                Console.WriteLine("1.Add Project");
                Console.WriteLine("2.List All Projects");
                Console.WriteLine("3.List All Project By Id");
                Console.WriteLine("4.Delete Project");
                Console.WriteLine("5.View Employee Project");              
                Console.WriteLine("6.return to main");
                Console.WriteLine("-------------------------");
                Console.ResetColor();
                Console.WriteLine("enter the option");
                choice1 = int.Parse(Console.ReadLine() ?? string.Empty);
                switch (choice1)
                {
                    case 1:
                    {
                       ProjectRepo projectRepo=new ProjectRepo();
                       projectRepo.AddProjectMethod();
                    }


                        break;


                    case 2:
                    {
                       ProjectRepo projectRepo=new ProjectRepo();
                       projectRepo.ListProjects();
                    }


                        break;
                    case 3:
                    {

                       ProjectRepo projectRepo=new ProjectRepo();
                       projectRepo.ListProjectsById();
                    }


                        break;
                    case 4:
                    {
                       ProjectRepo projectRepo=new ProjectRepo();
                       projectRepo.DeleteProjectMethod();
                    }


                        break;
                    case 5:

                        Consoles.ViewEmployeeProject();
                        break;
                     
                    case 6:
                        return;

                }
            } while (choice1 != 6);



        }


    }
}