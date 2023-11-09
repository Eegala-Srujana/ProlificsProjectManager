using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using PPM.Domain;
using PPM.Ui.Consoles;
using PPM.Model;


namespace PPM.Main
{
    public class ProlificsProjectManagement
    {

        public static void Main(string[] args)
        {
            int choice;

            Console.Clear();

            do
            {

                choice = MainConsole.MenuData();


                switch (choice)
                {
                    case 1:
                        {
                            ProjectConsole consoles = new ProjectConsole();
                            consoles.ProjectModule();
                            break;
                        }

                    case 2:
                        {
                            EmployeeConsole Consoles = new EmployeeConsole();
                            Consoles.EmployeeModule();
                            break;
                        }

                    case 3:
                        {
                            RoleConsole consoles = new RoleConsole();
                            consoles.RoleModule();
                            break;
                        }

                    case 4:
                        {

                            SavedStateRepo.SavedState();
                            break;
                        }


                    case 5:

                        MainConsole mainConsole = new MainConsole();
                        mainConsole.Exit();

                        break;
                    default:
                        MainConsole mainConsoles = new MainConsole();
                        mainConsoles.InvalidChoice();
                        break;
                }

            } while (choice != 5);

        }
    }
}
