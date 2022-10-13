using Sharprompt;

namespace nerdkit.functions.menus
{
    internal class software
    {
        public static void menu()
        {
            // TODO LIST
            // Get driver information
            // Get top 5 largest/resource hungry programs
            // Display currently running processes
            while (true)
            {
                nerdkit.Title();
                var option = Prompt.Select("Software Tools", new[] { "Driver Information", "Large Program Information", "Running Processes", "Back" });
                switch (option)
                {
                    case "Driver Information":
                        break;
                    case "Large Program Information":
                        break;
                    case "Running Processes":
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