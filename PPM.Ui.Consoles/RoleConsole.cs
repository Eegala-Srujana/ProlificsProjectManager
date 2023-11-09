using System.Text.RegularExpressions;
using System.Collections.Generic;
using PPM.Model;
using PPM.Domain;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.Emit;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
namespace PPM.Ui.Consoles
{

    public class RoleConsole

    {
        public void RoleModule()
        {
            int choice1;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("-------------------------");
                Console.WriteLine(" Show The Menu");
                Console.WriteLine("1.Add Role");
                Console.WriteLine("2.List All Roles");
                Console.WriteLine("3.List All Roles By Id");
                Console.WriteLine("4.Delete Role");
                Console.WriteLine("5.return to main");
                Console.WriteLine("-------------------------");
                Console.ResetColor();
                Console.WriteLine("enter the option");
                choice1 = int.Parse(Console.ReadLine() ?? string.Empty);
                switch (choice1)
                {
                    case 1:
                        {
                            RoleRepo roleRepo = new RoleRepo();
                            roleRepo.AddRoleMethods();
                        }

                        break;
                    case 2:
                        {
                            RoleRepo roleRepo = new RoleRepo();
                            roleRepo.ListAll();
                        }

                        break;
                    case 3:
                        {
                            RoleRepo roleRepo = new RoleRepo();
                            roleRepo.ListById();
                        }

                        break;
                    case 4:
                        {
                            RoleRepo roleRepo = new RoleRepo();
                            roleRepo.DeleteRoleMethod();
                        }

                        break;
                    case 5:

                        return;

                }
            } while (choice1 != 5);

        }

    }



}