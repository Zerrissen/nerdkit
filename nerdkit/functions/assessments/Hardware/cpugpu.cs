using System.Management;
using Microsoft.Win32;

namespace nerdkit.functions.assessments.Hardware
{
    internal class cpugpu
    {
        public static void controller()
        {
            Console.WriteLine("\nCPU Info");
            cpu();
            Console.WriteLine("\nGPU Info");
            gpu();
            logger.Out("Press any key to exit..");
            Console.ReadKey();
        }

        public static void cpu()
        {
            // Get the information for Processor and print.
            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_Processor");

            foreach (ManagementObject obj in myVideoObject.Get())
            {
                Console.WriteLine("Name: " + obj["Name"]);
                Console.WriteLine("Status: " + obj["Status"]);
                Console.WriteLine("Device ID: " + obj["DeviceID"]);
                Console.WriteLine("Manufacturer: " + obj["Manufacturer"]);
                Console.WriteLine("Cores: " + obj["NumberOfCores"]);
                Console.WriteLine("Enabled Cores: " + obj["NumberOfEnabledCore"]);
                Console.WriteLine("Logical Processors: " + obj["NumberOfLogicalProcessors"]);
                Console.WriteLine("Current Clock Speed: " + obj["CurrentClockSpeed"]);
                Console.WriteLine("Max Clock Speed: " + obj["MaxClockSpeed"]);

            }
        }

        public static void gpu()
        {
            // Get the GPU RAM from registry, WMI doesn't support 64-bit integers for VideController.
            const string localRoot = "HKEY_LOCAL_MACHINE";
            const string SubKey = "\\SYSTEM\\ControlSet001\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0001";
            const string keyName = localRoot + SubKey;
            long gpuMem = Convert.ToInt64(Registry.GetValue(keyName, "HardwareInformation.qwMemorySize", null)) / 1024 / 1024;

            // Get the rest of the information for VideController and print.
            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");

            foreach (ManagementObject obj in myVideoObject.Get())
            {
                Console.WriteLine("Name: " + obj["Name"]);
                Console.WriteLine("Status: " + obj["Status"]);
                Console.WriteLine("Device ID: " + obj["DeviceID"]);
                Console.WriteLine("Adapter RAM: " + gpuMem + " MiB");
                Console.WriteLine("Driver Version: " + obj["DriverVersion"]);
                Console.WriteLine("Video Processor: " + obj["VideoProcessor"]);
            }
        }
    }
}
