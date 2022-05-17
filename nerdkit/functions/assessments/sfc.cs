using System.Diagnostics;
using System.Security.Principal;
using Sharprompt;

namespace nerdkit.functions.assessments
{
    internal class sfc
    {
        public static void controller()
        {
            scan();
            logger.Out("Press any key to exit..");
            Console.ReadKey();
        }

        public static void scan()
        {
            bool isAdmin;
            string filePath = "C:\\Windows\\Logs\\CBS\\CBS.log";

            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);

                // If is administrator, the variable updates from False to True
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            // Check with a simple condition whether you are admin or not and if True, scan with SFC
            if (isAdmin)
            {
                // Create new System Diagnostic process
                Process process = new Process();
                ProcessStartInfo startInfo = process.StartInfo;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C sfc /scannow > nul 2>&1";
                process.StartInfo = startInfo;

                // Start logger
                logger.Log("Started", "Run SFC");

                // Start Test
                process.Start();
                process.WaitForExit();

                logger.Log("Completed", "Run SFC");

                var option = Prompt.Select("SFC Log", new[] { "Open Log", "Back" });
                switch (option)
                {
                    case "Open Log":
                        if (File.Exists(filePath))
                        {
                            Process.Start("notepad.exe",filePath);
                        }
                        else
                        {
                            logger.Out("Log File does not exist!");
                        }
                        break;
                    case "Back":
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                logger.Out("Run program as Administrator to scan disk with SFC.");
            }
        }
    }
}
