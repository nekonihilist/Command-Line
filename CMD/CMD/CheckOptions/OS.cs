using System;
using System.Management;

namespace CMD.CheckOptions
{
    class OS
    {
        public static void Options(string Input)
        {
            string[] modifPath = InputEdit.Edit(Input, "os");

            if (modifPath[0] == "-hd")
            {
                new OS().HardDrive_Info();
            }
            else if(modifPath[0] == "")
            {
                new OS().OS_Info();
            }
            else if(modifPath[0] == "-ip")
            {
                new OS().IP_Info();
            }
            else if(modifPath[0] == "-vd")
            {
                new OS().VideoCard_Info();
            }
            else if(modifPath[0] == "-p")
            {
                new OS().Processor_Info();
            }
            else if(modifPath[0] == "-ram")
            {
                new OS().RAM_Info();
            }
            else
            {
                Console.WriteLine("A bug in the extension");
            }
        }
        private void RAM_Info()
        {
            ManagementObjectSearcher searcher12 =
    new ManagementObjectSearcher("root\\CIMV2",
    "SELECT * FROM Win32_PhysicalMemory");

            Console.WriteLine("------------- Win32_PhysicalMemory instance --------");
            foreach (ManagementObject queryObj in searcher12.Get())
            {
                Console.WriteLine("BankLabel: {0} ; Capacity: {1} Gb; Speed: {2} ", queryObj["BankLabel"],
                                  Math.Round(System.Convert.ToDouble(queryObj["Capacity"]) / 1024 / 1024 / 1024, 2),
                                   queryObj["Speed"]);
            }
        }
        private void Processor_Info()
        {
            ManagementObjectSearcher searcher8 =
    new ManagementObjectSearcher("root\\CIMV2",
    "SELECT * FROM Win32_Processor");

            foreach (ManagementObject queryObj in searcher8.Get())
            {
                Console.WriteLine("------------- Win32_Processor instance ---------------");
                Console.WriteLine("Name: {0}", queryObj["Name"]);
                Console.WriteLine("NumberOfCores: {0}", queryObj["NumberOfCores"]);
                Console.WriteLine("ProcessorId: {0}", queryObj["ProcessorId"]);
            }
        }
        private void VideoCard_Info()
        {
            ManagementObjectSearcher searcher =
    new ManagementObjectSearcher("root\\CIMV2",
    "SELECT * FROM Win32_VideoController");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                Console.WriteLine("----------- Win32_VideoController instance -----------");
                Console.WriteLine("AdapterRAM: {0}", queryObj["AdapterRAM"]);
                Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                Console.WriteLine("Description: {0}", queryObj["Description"]);
                Console.WriteLine("VideoProcessor: {0}", queryObj["VideoProcessor"]);
            }
        }
        private void IP_Info()
        {
            ManagementObjectSearcher searcher =
   new ManagementObjectSearcher("root\\CIMV2",
   "SELECT * FROM Win32_NetworkAdapterConfiguration");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                Console.WriteLine("--------- Win32_NetworkAdapterConfiguration instance --------------");
                Console.WriteLine("Caption: {0}", queryObj["Caption"]);

                if (queryObj["DefaultIPGateway"] == null)
                    Console.WriteLine("DefaultIPGateway: {0}", queryObj["DefaultIPGateway"]);
                else
                {
                    String[] arrDefaultIPGateway = (String[])(queryObj["DefaultIPGateway"]);
                    foreach (String arrValue in arrDefaultIPGateway)
                    {
                        Console.WriteLine("DefaultIPGateway: {0}", arrValue);
                    }
                }

                if (queryObj["DNSServerSearchOrder"] == null)
                    Console.WriteLine("DNSServerSearchOrder: {0}", queryObj["DNSServerSearchOrder"]);
                else
                {
                    String[] arrDNSServerSearchOrder = (String[])(queryObj["DNSServerSearchOrder"]);
                    foreach (String arrValue in arrDNSServerSearchOrder)
                    {
                        Console.WriteLine("DNSServerSearchOrder: {0}", arrValue);
                    }
                }

                if (queryObj["IPAddress"] == null)
                    Console.WriteLine("IPAddress: {0}", queryObj["IPAddress"]);
                else
                {
                    String[] arrIPAddress = (String[])(queryObj["IPAddress"]);
                    foreach (String arrValue in arrIPAddress)
                    {
                        Console.WriteLine("IPAddress: {0}", arrValue);
                    }
                }

                if (queryObj["IPSubnet"] == null)
                    Console.WriteLine("IPSubnet: {0}", queryObj["IPSubnet"]);
                else
                {
                    String[] arrIPSubnet = (String[])(queryObj["IPSubnet"]);
                    foreach (String arrValue in arrIPSubnet)
                    {
                        Console.WriteLine("IPSubnet: {0}", arrValue);
                    }
                }
                Console.WriteLine("MACAddress: {0}", queryObj["MACAddress"]);
                Console.WriteLine("ServiceName: {0}", queryObj["ServiceName"]);
            }
        }
        private void HardDrive_Info()
        {
            ManagementObjectSearcher searcher =
           new ManagementObjectSearcher("root\\CIMV2",
           "SELECT * FROM Win32_Volume");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Win32_Volume instance");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Capacity: {0}", queryObj["Capacity"]);
                Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                Console.WriteLine("DriveLetter: {0}", queryObj["DriveLetter"]);
                Console.WriteLine("DriveType: {0}", queryObj["DriveType"]);
                Console.WriteLine("FileSystem: {0}", queryObj["FileSystem"]);
                Console.WriteLine("FreeSpace: {0}", queryObj["FreeSpace"]);
            }

        }
        private void OS_Info()
        {
            ManagementObjectSearcher searcher =
      new ManagementObjectSearcher("root\\CIMV2",
          "SELECT * FROM Win32_OperatingSystem");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Win32_OperatingSystem instance");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("BuildNumber: {0}", queryObj["BuildNumber"]);
                Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                Console.WriteLine("FreePhysicalMemory: {0}", queryObj["FreePhysicalMemory"]);
                Console.WriteLine("FreeVirtualMemory: {0}", queryObj["FreeVirtualMemory"]);
                Console.WriteLine("Name: {0}", queryObj["Name"]);
                Console.WriteLine("OSType: {0}", queryObj["OSType"]);
                Console.WriteLine("RegisteredUser: {0}", queryObj["RegisteredUser"]);
                Console.WriteLine("SerialNumber: {0}", queryObj["SerialNumber"]);
                Console.WriteLine("ServicePackMajorVersion: {0}", queryObj["ServicePackMajorVersion"]);
                Console.WriteLine("ServicePackMinorVersion: {0}", queryObj["ServicePackMinorVersion"]);
                Console.WriteLine("Status: {0}", queryObj["Status"]);
                Console.WriteLine("SystemDevice: {0}", queryObj["SystemDevice"]);
                Console.WriteLine("SystemDirectory: {0}", queryObj["SystemDirectory"]);
                Console.WriteLine("SystemDrive: {0}", queryObj["SystemDrive"]);
                Console.WriteLine("Version: {0}", queryObj["Version"]);
                Console.WriteLine("WindowsDirectory: {0}", queryObj["WindowsDirectory"]);
            }
        }
    }
}
