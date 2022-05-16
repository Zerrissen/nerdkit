using System.Management;

namespace nerdkit.functions.assessments
{
    internal class cpugpu
    {
        public static void controller()
        {
            gpu();
            logger.Out("Press any key to exit..");
            Console.ReadKey();
        }

        public static void gpu()
        {
            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");
            string capacity = "";
            long capacityNum = 0;
            foreach (ManagementObject obj in myVideoObject.Get())
            {
                capacity = obj["AdapterRAM"].ToString();
                capacityNum = (Convert.ToInt64(capacity) / 1024) / 1024;
                Console.WriteLine(capacityNum);
            }
            foreach (ManagementObject obj in myVideoObject.Get())
            {
                Console.WriteLine("Name: " + obj["Name"]);
                Console.WriteLine("Status: " + obj["Status"]);
                Console.WriteLine("Device ID: " + obj["DeviceID"]);
                Console.WriteLine("Adapter RAM: " + capacityNum + " MiB");
                Console.WriteLine("Driver Version: " + obj["DriverVersion"]);
                Console.WriteLine("Video Processor: " + obj["VideoProcessor"]);
            }
        }
    }
}
