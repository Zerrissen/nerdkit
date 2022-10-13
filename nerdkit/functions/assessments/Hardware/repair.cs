using System.Diagnostics;
using System.Security.Principal;
using Sharprompt;

namespace nerdkit.functions.assessments.Hardware
{
    internal class repair
    {
        public static void controller()
        {

            bool isAdmin;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);

                // If is administrator, the variable updates from False to True
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            // Check with a simple condition whether you are admin or not and if True, scan with SFC
            if (isAdmin)
            {
                var option = Prompt.MultiSelect("", new[] { "DISM CheckHealth", "DISM ScanHealth", "DISM RestoreHealth" });
                foreach (var item in option)
                {
                    switch (item)
                    {
                        case "DISM CheckHealth":
                            checkhealth();
                            break;
                        case "DISM ScanHealth":
                            scanhealth();
                            break;
                        case "DISM RestoreHealth":
                            restorehealth();
                            break;
                    }
                }
                logger.Out("Press any key to exit..");
                Console.ReadKey();
            }

            else
            {
                logger.Out("Run program as Administrator to scan or repair OS with DISM.");
                logger.Out("Press any key to exit..");
                Console.ReadKey();
            }
        }

        public static void checkhealth()
        {
            // Create new System Diagnostic process
            Process process = new Process();
            ProcessStartInfo startInfo = process.StartInfo;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C DISM /online /cleanup-image /checkhealth";
            process.StartInfo = startInfo;

            // Start logger
            Console.WriteLine();
            logger.Log("Started", "Run CheckHealth");

            // Start Test
            process.Start();
            process.WaitForExit();

            // Finish logger calls
            Console.WriteLine();
            logger.Log("Completed", "Run CheckHealth");
        }

        public static void scanhealth()
        {
            // Create new System Diagnostic process
            Process process = new Process();
            ProcessStartInfo startInfo = process.StartInfo;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C DISM /online /cleanup-image /scanhealth";
            process.StartInfo = startInfo;

            // Start logger
            Console.WriteLine();
            logger.Log("Started", "Run ScanHealth");

            // Start Test
            process.Start();
            process.WaitForExit();

            // Finish logger calls
            Console.WriteLine();
            logger.Log("Completed", "Run ScanHealth");
        }

        public static void restorehealth()
        {
            // Create new System Diagnostic process
            Process process = new Process();
            ProcessStartInfo startInfo = process.StartInfo;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C DISM /online /cleanup-image /restorehealth";
            process.StartInfo = startInfo;

            // Start logger
            logger.Log("Started", "Run RestoreHealth");

            // Start Test
            process.Start();
            process.WaitForExit();

            // Finish logger calls
            logger.Log("Completed", "Run RestoreHealth");
        }
    }
}
