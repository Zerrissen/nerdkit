using System.Diagnostics;

namespace nerdkit.functions.assessments
{
    internal class nettest
    {
        public static void hostname()
        {
            // Create new System Diagnostic process
            Process process = new Process();
            ProcessStartInfo startInfo = process.StartInfo;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C echo ####### HOSTNAME #######>> nettest_log.txt & hostname >> reports/nettest_log.txt";
            process.StartInfo = startInfo;

            // Start logger
            logger.Log("Started", "Get Hostname");

            // Start Test
            process.Start();
            process.WaitForExit();

            // Finish logger calls
            logger.Log("Completed", "Get Hostname");
        }

        public static void getmac()
        {
            // Create new System Diagnostic process
            Process process = new Process();
            ProcessStartInfo startInfo = process.StartInfo;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C echo. >> nettest_log.txt & echo | set /p=####### MAC ####### >> nettest_log.txt & getmac >> reports/nettest_log.txt";
            process.StartInfo = startInfo;

            // Start logger
            logger.Log("Started", "Get MAC");

            // Start Test
            process.Start();
            process.WaitForExit();

            // Finish logger calls
            logger.Log("Completed", "Get MAC");
        }

        public static void pathping()
        {
            // Create new System Diagnostic process
            Process process = new Process();
            ProcessStartInfo startInfo = process.StartInfo;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C echo. >> nettest_log.txt & echo | set /p=####### Path Ping ####### >> nettest_log.txt & pathping 8.8.8.8 >> reports/nettest_log.txt";
            process.StartInfo = startInfo;

            // Start logger
            logger.Log("Started", "Path Ping");
            logger.Out("Path Ping will take ~175 seconds.");
            // Start Test
            process.Start();
            process.WaitForExit();

            // Finish logger calls
            logger.Log("Completed", "Path Ping\n");
        }

        public static void controller()
        {
            // Create threads
            Thread hostThr = new Thread(hostname);
            Thread macThr = new Thread(getmac);
            Thread pingThr = new Thread(pathping);

            // Start threads, 150ms gap between threads to stop functions overwriting prints!
            hostThr.Start();
            Thread.Sleep(1000);
            macThr.Start();
            Thread.Sleep(1000);
            pingThr.Start();
            pingThr.Join();
            Thread.Sleep(1000);

            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(@"reports\nettest_log.txt")
            {
                UseShellExecute = true
            };
            process.Start();
        }
    }
}
