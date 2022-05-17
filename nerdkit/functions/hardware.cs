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
                var option = Prompt.Select("Toolbox", new[] { "Generic System Info", "CPU & GPU Info", "Storage Info" , "Scan and Repair Missing/Corrupt Files", "Repair Windows 10 Image", "Battery/Power Test", "Back" });
                switch (option)
                {
                    case "Generic System Info":
                        assessments.sysinfo.controller();
                        break;
                    case "CPU & GPU Info":
                        assessments.cpugpu.controller();
                        break;
                    case "Storage Info":
                        assessments.storage.controller();
                        break;
                    case "Scan and Repair Missing/Corrupt Files":
                        assessments.sfc.controller();
                        break;
                    case "Repair Windows 10 Image":
                        assessments.repair.controller();
                        break;
                    case "Battery/Power Test":
                        assessments.power.controller();
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
