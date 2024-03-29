﻿using Sharprompt;
using System.IO;

namespace nerdkit
{
    class nerdkit
    {
        private static void Setup()
        {
            try 
            {
                if (!Directory.Exists("reports"))
                {
                    Console.WriteLine("Reports directory missing : Creating directory");
                    Directory.CreateDirectory("reports");
                    Console.WriteLine("Directory created");
                }
            }
            catch (Exception e)
            { 
                Console.WriteLine("Process failed: {0}", e.ToString());
            }
            finally {}
            
        }
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
            Console.WriteLine("\nMade by Zerrissen\t\t\t    v1.0.1");
            Console.WriteLine("https://github.com/Zerrissen\n\n");
        }
        public static void Main()
        {
            Console.Title = "NerdKit";

            // Call directory check
            Setup();

            // Start Menu Selection
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
                        var option2 = Prompt.Select("Toolbox", new[] { "Networking", "Hardware", "Back" });
                        switch (option2)
                        {
                            case "Networking":
                                functions.networking.menu();
                                break;
                            case "Hardware":
                                functions.hardware.menu();
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