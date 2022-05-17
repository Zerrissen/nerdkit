using System.Management;
using System.Security.Principal;

namespace nerdkit.functions.assessments
{
    internal class storage
    {
        public static void controller()
        {
            drive();
            logger.Out("Press any key to exit..");
            Console.ReadKey();
        }

        public static void drive()
        {
            bool isAdmin;

            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);

                // If is administrator, the variable updates from False to True
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            // Check with a simple condition whether you are admin or not and if True, search for SMART
            if (isAdmin)
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                var searcher = new ManagementObjectSearcher("Select * from Win32_DiskDrive");
                searcher.Scope = new ManagementScope(@"\root\wmi");
                searcher.Query = new ObjectQuery("Select * from MSStorageDriver_FailurePredictStatus");
                Console.WriteLine("\nS.M.A.R.T Failure Prediction");
                foreach (ManagementObject data in searcher.Get())
                {
                    Console.WriteLine("SMART Instance Name: " + data.GetPropertyValue("InstanceName").ToString());
                    Console.WriteLine("SMART Predicts Failure: " + data.GetPropertyValue("PredictFailure").ToString());
                    Console.WriteLine("SMART Failure Reason: " + data.GetPropertyValue("Reason").ToString());
                }

                foreach (DriveInfo drive in drives)
                {
                    Console.WriteLine($"\nName: {drive.Name}");
                    Console.WriteLine($"Volume Label: {drive.VolumeLabel}");
                    Console.WriteLine($"Root Directory: {drive.RootDirectory}");
                    Console.WriteLine($"Drive Type: {drive.DriveType}");
                    Console.WriteLine($"Drive Format: {drive.DriveFormat}");
                    Console.WriteLine($"Is Ready: {drive.IsReady}");
                    Console.WriteLine($"Total Size: {drive.TotalSize / 1024 / 1024} MiB");
                    Console.WriteLine($"Available Free Space: {drive.AvailableFreeSpace / 1024 / 1024} MiB");
                }
            }
            else
            {
                logger.Out("Run program as Administrator to get S.M.A.R.T failure prediction!");
                DriveInfo[] drives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in drives)
                {
                    Console.WriteLine($"\nName: {drive.Name}");
                    Console.WriteLine($"Volume Label: {drive.VolumeLabel}");
                    Console.WriteLine($"Root Directory: {drive.RootDirectory}");
                    Console.WriteLine($"Drive Type: {drive.DriveType}");
                    Console.WriteLine($"Drive Format: {drive.DriveFormat}");
                    Console.WriteLine($"Is Ready: {drive.IsReady}");
                    Console.WriteLine($"Total Size: {drive.TotalSize / 1024 / 1024} MiB");
                    Console.WriteLine($"Available Free Space: {drive.AvailableFreeSpace / 1024 / 1024} MiB");
                }
            }
        }
    }
}
