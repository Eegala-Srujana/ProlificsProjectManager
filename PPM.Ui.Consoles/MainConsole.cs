using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace PPM.Ui.Consoles
{
    public class MainConsole
    {
        public  static int MenuData()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("-------------------------");
            Console.WriteLine(" Show The Menu");
            Console.WriteLine("1.Project Module");
            Console.WriteLine("2.Employee Module");
            Console.WriteLine("3.Role Module");
            Console.WriteLine("4.save Module");
            Console.WriteLine("5.Quit");
            Console.WriteLine("-------------------------");
            Console.ResetColor();
            Console.WriteLine("enter the option");
             int choice = int.Parse(Console.ReadLine() ?? string.Empty);
             return choice;
        }
    

        public void Exit()
        {
            Console.WriteLine("Exit the Apllication");
        }
        public void InvalidChoice()
        {
            Console.WriteLine("Invalid Choice");
        }
    }

}