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
    public class RoleRepo
    {
        
        public void AddRoleMethods()
        {
            
            
            Console.WriteLine("Enter the number of roles to add");
            int size = int.Parse(Console.ReadLine() ?? string.Empty);
            for (int i = 0; i < size; i++)

            {
                RoleDetails newRole = new RoleDetails();
                while (true)
                {
                    
                    


                    Console.WriteLine("Enter the role Id");
                    int id = int.Parse(Console.ReadLine() ?? string.Empty);

                    var existingRole = Role.roleList.Find(p => p.RoleId == id);

                    if (existingRole != null)
                    {
                        Console.WriteLine("Role with the same ID already exists.");
                    }
                    else
                    {
                        newRole.RoleId = id;
                        break;
                    }
                }

                Console.WriteLine("Enter the role name");
                newRole.RoleName = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("*******************");
                Console.WriteLine("Role Added");
                Console.WriteLine("******************");
                Console.ResetColor();
                Role role=new Role();
                role.AddEntity(newRole);
            }
        }
        public void ListAll()
        {
            Role role = new Role();
            foreach (RoleDetails details in role.ListAll())
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("roleId = {0}, roleName = {1}", details.RoleId, details.RoleName);
                Console.ResetColor();
            }
        }
        public void ListById()
        {
            System.Console.WriteLine("Enter the role Id");
            int Id = int.Parse(Console.ReadLine() ?? string.Empty);
            int roleById = Role.roleList.FindIndex(p => p.RoleId == Id);
            if (roleById >= 0)
            {
                RoleDetails details = Role.roleList[roleById];

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("roleId = {0}, roleName = {1}", details.RoleId, details.RoleName);
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                System.Console.WriteLine(" --------role  Id doesn't exists ----------");
                Console.ResetColor();
            }

        }
        public void DeleteRoleMethod()
        {
            RoleDetails roleDetails = new RoleDetails();
            Console.WriteLine("enter the role Id from which you want to remove the employee");
            int roleId = int.Parse(Console.ReadLine() ?? string.Empty);
            bool roleExist = Role.roleList.Any(p => p.RoleId == roleId);
            // bool roleExistInEmployees = Employee.employeeList.Any(p => p.RoleId == roleId);

            if (roleExist)
            {
                bool roleExistInEmployees = Employee.employeeList.Any(p => p.RoleId == roleId);
                if (!roleExistInEmployees)
                {
                    Role role=new Role();
                    role.DeleteById(roleId);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("******************************");
                    Console.WriteLine("Role deleted successfully");
                    Console.WriteLine("******************************");
                    Console.ResetColor();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("role is assigned to employee");
                    Console.ResetColor();
                }
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("role does not exist ");
                Console.ResetColor();

            }
        }

    }
}