using Sharprompt;

namespace nerdkit
{
    class nerdkit
    {
        public static void Title()
        {
            Console.Clear();
            // Print Title
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string title = @"
 __   _ _______  ______ ______  _     _ _____ _______
 | \  | |______ |_____/ |     \ |____/    |      |   
 |  \_| |______ |    \_ |_____/ |    \_ __|__    |  ";
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nMade by Zerrissen\t\t\t    v1.0.0");
            Console.WriteLine("https://github.com/Zerrissen\n\n");
        }
        public static void Main()
        {
            Console.Title = "NerdKit";

            // Menu Selection
            while (true)
            {
                Title();
                var option = Prompt.Select("Menu Option", new[] { "Start NerdKit", "Exit" });
                if (option == "Start NerdKit")
                {
                    int flag = 0;
                    while (flag == 0)
                    {
                        Title();
                        var option2 = Prompt.Select("Toolbox", new[] { "Networking", "Hardware", "Software", "Back" });
                        switch (option2)
                        {
                            case "Networking":
                                functions.networking.menu();
                                break;
                            case "Hardware":
                                functions.hardware.menu();
                                break;
                            case "Software":
                                functions.software.menu();
                                break;
                            case "Back":
                                flag = 1;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }
                else
                {
                    Environment.Exit(1);
                }
            }
        }
    }
}