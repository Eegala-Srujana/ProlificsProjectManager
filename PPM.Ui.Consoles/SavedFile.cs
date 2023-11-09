
using PPM.Domain;
namespace PPM.Ui.Consoles
{
    public class SavedStateRepo
    {
         public  static void SavedState()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Data saved in the XML file");
            Console.ResetColor();
            SaveStateRepo saveStateRepo = new SaveStateRepo();
            saveStateRepo.SaveState();
          
        }
    }
}