using System.Management;
using Microsoft.Win32;

namespace nerdkit.functions.assessments.Hardware
{
    internal class sysinfo
    {
        public static void controller()
        {
            os();
            processor();
            memory();
            logger.Out("Press any key to exit..");
            Console.ReadKey();
        }

        public static void os()
        {
            ManagementObjectSearcher myOperativeSystemObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            foreach (ManagementObject obj in myOperativeSystemObject.Get())
            {
                Console.WriteLine("\nOS Information");
                Console.WriteLine("Windows Edition: " + obj["Caption"]);
                Console.WriteLine("Root Directory: " + obj["WindowsDirectory"]);
                Console.WriteLine("Serial: " + obj["SerialNumber"]);
                Console.WriteLine("System Directory: " + obj["SystemDirectory"]);
                Console.WriteLine("Version: " + obj["Version"]);
            }
        }

        public static void processor()
        {
            ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");

            foreach (ManagementObject obj in myProcessorObject.Get())
            {
                Console.WriteLine("\nProcessor Information");
                Console.WriteLine("Name: " + obj["Name"]);
                Console.WriteLine("Device ID: " + obj["DeviceID"]);
                Console.WriteLine("Manufacturer: " + obj["Manufacturer"]);
            }
        }

        public static void memory()
        {
            ManagementObjectSearcher myMemoryObject = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
            string capacity = "";
            long capacityNum = 0;
            foreach (ManagementObject obj in myMemoryObject.Get())
            {
                capacity = obj["Capacity"].ToString();
                capacityNum += Convert.ToInt64(capacity);
            }
            Console.WriteLine("\nMemory Information");
            foreach (ManagementObject obj in myMemoryObject.Get())
            {
                Console.WriteLine("Module Capacity: " + obj["Capacity"]);
                Console.WriteLine("Part Number: " + obj["PartNumber"]);
                Console.WriteLine("Manufacturer: " + obj["Manufacturer"] + "\n");
            }
            Console.WriteLine("Total Capacity: " + capacityNum / 1024 / 1024 + " MiB\n");
        }
    }
}
