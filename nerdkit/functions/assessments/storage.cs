using System.Diagnostics;

namespace nerdkit.functions.assessments
{
    internal class storage
    {
        public static void getinfo()
        {
            // Create new System Diagnostic process
            Process process = new Process();
            ProcessStartInfo startInfo = process.StartInfo;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C echo ####### SYSTEM INFO #######>> sysinfo.txt & systeminfo >> sysinfo.txt 2>&1";
            process.StartInfo = startInfo;

            // Start logger
            logger.Log("Started", "Get System Info");

            // Start Test
            process.Start();
            process.WaitForExit();

            // Finish logger calls
            logger.Log("Completed", "Get System Info");
        }
    }
}
