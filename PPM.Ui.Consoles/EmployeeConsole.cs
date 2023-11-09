using System.Text.RegularExpressions;
using System.Collections.Generic;
using PPM.Model;
using PPM.Domain;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.Emit;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;
using System.Runtime.CompilerServices;
namespace PPM.Ui.Consoles
{

    public class EmployeeConsole

    {
        public void EmployeeModule()
        {
            int choice1;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("-------------------------");
                Console.WriteLine(" Show The Menu");
                Console.WriteLine("1.Add Employee");
                Console.WriteLine("2.List All Employees");
                Console.WriteLine("3.List All Employees By Id");
                Console.WriteLine("4.Delete Employees");
                Console.WriteLine("5.return to main");
                Console.WriteLine("-------------------------");
                Console.ResetColor();
                Console.WriteLine("enter the option");
                choice1 = int.Parse(Console.ReadLine() ?? string.Empty);
                switch (choice1)
                {
                    case 1:
                        {
                            EmployeeRepo employeeRepo = new EmployeeRepo();
                            employeeRepo.AddEmployeeMethod();
                        }
                        break;
                    case 2:
                        {
                            EmployeeRepo employeeRepo = new EmployeeRepo();
                            employeeRepo.ListEmployees();
                        }

                        break;
                    case 3:
                        {
                            EmployeeRepo employeeRepo = new EmployeeRepo();
                            employeeRepo.ListEmployeesById();
                        }
                        break;
                    case 4:
                        {
                            EmployeeRepo employeeRepo = new EmployeeRepo();
                            employeeRepo.DeleteEmployeeMethod();
                        }
                        break;
                    case 5:
                        return;

                }
            } while (choice1 != 5);



        }


    }
}

