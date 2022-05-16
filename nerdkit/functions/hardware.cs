using Sharprompt;

namespace nerdkit.functions
{
    internal class hardware
    {
        public static void menu()
        {
            while (true)
            {
                nerdkit.Title();
                var option = Prompt.Select("Toolbox", new[] { "Generic System Info", "CPU & GPU Info", "Storage Info" , "Scan for Missing/Corrupt Files", "Repair Missing/Corrupt Files", "Back" });
                switch (option)
                {
                    case "Generic System Info":
                        assessments.sysinfo.controller();
                        break;
                    case "CPU & GPU Info":
                        assessments.cpugpu.controller();
                        break;
                    case "Storage Info":
                        assessments.storage.getinfo();
                        break;
                    case "Scan for Missing/Corrupt Files":
                        assessments.sfc.scan();
                        break;
                    case "Repair Missing/Corrupt Files":
                        assessments.repair.start();
                        break;
                    case "Back":
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();    
                }
                break;
            }
        }
    }
}
