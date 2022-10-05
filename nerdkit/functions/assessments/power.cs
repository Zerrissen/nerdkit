using System.Diagnostics;
using System.Security.Principal;
using System.IO;
using Sharprompt;
using System.IO.Enumeration;

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
            process.StartInfo = new ProcessStartInfo(@"C:/Windows/System32/cmd.exe")
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = "/C cd reports & powercfg /energy > nul 2>&1"
            };

            // Start logger
            Console.WriteLine();
            logger.Log("Started", "Run CheckHealth");

            // Start Test
            process.Start();
            process.WaitForExit();

            // Finish logger calls
            Console.WriteLine();
            logger.Log("Completed", "Run CheckHealth");

            Process process2 = new Process();
            process2.StartInfo = new ProcessStartInfo(@"reports\energy-report.html")
            {
                UseShellExecute = true
            };
            process2.Start();
        }

        public static void systempower()
        {
            // Create new System Diagnostic process
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(@"C:/Windows/System32/cmd.exe")
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = "/C cd reports & powercfg /systempowerreport > nul 2>&1"
            };

            // Start logger
            Console.WriteLine();
            logger.Log("Started", "Run SystemPowerReport");

            // Start Test
            process.Start();
            process.WaitForExit();

            // Finish logger calls
            Console.WriteLine();
            logger.Log("Completed", "Run SystemPowerReport");

            Process process2 = new Process();
            process2.StartInfo = new ProcessStartInfo(@"reports\sleepstudy-report.html")
            {
                UseShellExecute = true
            };
            process2.Start();
        }

        public static void battery()
        {
            // Create new System Diagnostic process
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(@"C:/Windows/System32/cmd.exe")
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = "/C cd reports & powercfg /batteryreport > nul 2>&1"
            };

            // Start logger
            Console.WriteLine();
            logger.Log("Started", "Run BatteryReport");

            // Start Test
            process.Start();
            process.WaitForExit();

            // Finish logger calls
            Console.WriteLine();
            logger.Log("Completed", "Run BatteryReport");

            Process process2 = new Process();
            process2.StartInfo = new ProcessStartInfo(@"reports\battery-report.html")
            {
                UseShellExecute = true
            };
            process2.Start();
        }
    }
}
