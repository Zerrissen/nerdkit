using System.Diagnostics;
using System.Security.Principal;
using Sharprompt;

namespace nerdkit.functions.assessments
{
    internal class power
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
                var option = Prompt.MultiSelect("", new[] { "Generate Efficiency Report", "Generate System Power Report", "Get Battery Report (Laptop Only)" });
                foreach (var item in option)
                {
                    switch (item)
                    {
                        case "Generate Efficiency Report":
                            efficiency();
                            break;
                        case "Generate System Power Report":
                            systempower();
                            break;
                        case "Get Battery Report (Laptop Only)":
                            battery();
                            break;
                    }
                }
                logger.Out("Press any key to exit..");
                Console.ReadKey();
            }

            else
            {
                logger.Out("Run program as Administrator to generate power reports.");
                logger.Out("Press any key to exit..");
                Console.ReadKey();
            }
        }

        public static void efficiency()
        {
            // Create new System Diagnostic process
            Process process = new Process();
            ProcessStartInfo startInfo = process.StartInfo;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C powercfg /energy > nul 2>&1";
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

            Process.Start("C:/Windows/System32/energy-report.html");
        }

        public static void systempower()
        {
            // Create new System Diagnostic process
            Process process = new Process();
            ProcessStartInfo startInfo = process.StartInfo;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C powercfg /systempowerreport > nul 2>&1";
            process.StartInfo = startInfo;

            // Start logger
            Console.WriteLine();
            logger.Log("Started", "Run SystemPowerReport");

            // Start Test
            process.Start();
            process.WaitForExit();

            // Finish logger calls
            Console.WriteLine();
            logger.Log("Completed", "Run SystemPowerReport");

            Process.Start("C:/Windows/System32/sleepstudy-report.html");
        }

        public static void battery()
        {
            // Create new System Diagnostic process
            Process process = new Process();
            ProcessStartInfo startInfo = process.StartInfo;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C powercfg /batteryreport > nul 2>&1";
            process.StartInfo = startInfo;

            // Start logger
            Console.WriteLine();
            logger.Log("Started", "Run BatteryReport");

            // Start Test
            process.Start();
            process.WaitForExit();

            // Finish logger calls
            Console.WriteLine();
            logger.Log("Completed", "Run BatteryReport");

            Process.Start("C:/Windows/System32/battery-report.html");
        }
    }
}
