using System.Text.RegularExpressions;
using System.Collections.Generic;
using PPM.Model;
using PPM.Domain;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.Emit;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;
namespace PPM.Ui.Consoles
{
    public class EmployeeRepo
    {

        Employee employee = new Employee();
        public void AddEmployeeMethod()
        {
            Console.WriteLine("Enter the number of Employees to add");
            int size = int.Parse(Console.ReadLine() ?? string.Empty);


            for (int i = 0; i < size; i++)
            {
                try
                {


                    EmployeeDetails employeeDetais = new EmployeeDetails();

                    Console.WriteLine("Enter the Employee id");
                    int id = int.Parse(Console.ReadLine() ?? string.Empty);


                    while (id <= 0)
                    {
                        Console.WriteLine("Employee id should not be 0 and  negative");
                        Console.WriteLine("enter employeeid");
                        id = int.Parse(Console.ReadLine() ?? string.Empty);

                    }


                    var existingEmployee = Employee.employeeList.Find(p => p.EmployeeId == id);

                    if (existingEmployee != null)
                    {
                        Console.WriteLine("Employee with the same ID already exists.");
                        Console.WriteLine("enter employeeid");
                        id = int.Parse(Console.ReadLine() ?? string.Empty);
                    }




                    employeeDetais.EmployeeId = id;

                    Console.WriteLine("Enter the First name");
                    employeeDetais.FirstName = Console.ReadLine();

                    Console.WriteLine("Enter the Last name");
                    employeeDetais.LastName = Console.ReadLine();



                    Console.WriteLine("Enter EmailId ");

                    string email = Console.ReadLine() ?? string.Empty;

                    if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|in|co.in)$"))

                    {
                        System.Console.WriteLine("Incorrect email format.Please try again!");
                        email = Console.ReadLine() ?? string.Empty;


                    }


                    employeeDetais.Email = email;
                    Console.WriteLine("Enter the phone number");
                    BigInteger phoneNumber = BigInteger.Parse(Console.ReadLine() ?? string.Empty);
                    while (phoneNumber.ToString().Length < 10 || phoneNumber.ToString().Length > 10)
                    {
                        Console.WriteLine("Invalid Phone number.");
                        phoneNumber = BigInteger.Parse(Console.ReadLine() ?? string.Empty);


                    }

                    employeeDetais.PhoneNumber = phoneNumber;
                    Console.WriteLine("Enter the address ");
                    employeeDetais.Address = Console.ReadLine();

                    int roleId;
                    while (true)

                    {

                        System.Console.WriteLine("Enter the role Id that you want to add employee");

                        roleId = int.Parse(System.Console.ReadLine() ?? string.Empty);


                        var roleExist = Role.roleList.Find(p => p.RoleId == roleId);

                        if (roleExist != null)

                        {
                            employeeDetais.RoleId = roleId;
                            break;


                        }

                        else

                        {
                            System.Console.WriteLine("roleId doesnt exist");
                            break;



                        }

                    }


                    var query1 = from item in Role.roleList

                                 where item.RoleId == roleId

                                 select new { item.RoleId };



                    foreach (var item in query1)

                    {

                        roleId = item.RoleId;


                    }




                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("*******************");
                    Console.WriteLine("Employee Added");
                    Console.WriteLine("*******************");
                    Console.ResetColor();

                    employee.AddEntity(employeeDetais);


                }
                catch (FormatException exp)
                {
                    System.Console.WriteLine("Exception ocurred in the Application. Check the exception details below:");
                    System.Console.WriteLine("Technical Message : {0}", exp.Message);
                    System.Console.WriteLine("User Friendly Message  : Please enter numbers only.");
                }
            }

        }
        public void ListEmployees()
        {



            var getEmployess = employee.ListAll();

            foreach (EmployeeDetails details in getEmployess)
            {
                Console.WriteLine("employeeId={0},firstName={1},lastName={2},Email={3},phoneNumber={4},Address={5},roleId={6}", details.EmployeeId, details.FirstName, details.LastName, details.Email, details.PhoneNumber, details.Address, details.RoleId);
            }
        }
        public void ListEmployeesById()
        {
            System.Console.WriteLine("Enter the Employee Id");
            int id = int.Parse(Console.ReadLine() ?? string.Empty);
            EmployeeDetails employeeDetails = employee.ListById(id);

            if (employeeDetails != null)
            {


                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Employee Id : {0}   First Name : {1}   Last Name : {2}   Email : {3}   Mobile Number : {4}   Address : {5}   Role Id : {6}", employeeDetails.EmployeeId, employeeDetails.FirstName, employeeDetails.LastName, employeeDetails.Email, employeeDetails.PhoneNumber, employeeDetails.Address, employeeDetails.RoleId);
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                System.Console.WriteLine(" --------Employee Id doesn't exists ----------");
                Console.ResetColor();
            }
        }
        public void DeleteEmployeeMethod()
        {
            EmployeeDetails employeeDetails = new EmployeeDetails();
            Console.WriteLine("enter the employee Id from which you want to delete");
            int employeeId = int.Parse(Console.ReadLine() ?? string.Empty);
            bool employeeExist = Employee.employeeList.Any(p => p.EmployeeId == employeeId);
            if (employeeExist)
            {
                bool employeeProjectExist = EmployeeProject.employeeProjectList.Any(p => p.EmployeeId == employeeId);
                if (!employeeProjectExist)
                {

                    Employee employee = new Employee();
                    employee.DeleteById(employeeId);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("******************************");
                    Console.WriteLine("Employee deleted successfully");
                    Console.WriteLine("******************************");
                    Console.ResetColor();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Employee assigned to project ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
            }
            else
            {
                Console.WriteLine("Employee does not exists");
            }
        }
    }
}