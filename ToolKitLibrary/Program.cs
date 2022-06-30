using System;
using System.Management;

namespace ToolKitLibrary.CLI
{
    public class Program
    {
        public static string? StoredDomain = string.Empty;
        public static string? StoredComputer = null;
        public static string? StoredUsername = string.Empty;
        public static string? StoredUnsecurePassword = string.Empty;
        public static bool loopProgram = true;
        public static void Main()
        {
            while (loopProgram)
            {
                try
                {
                    Console.Clear();
                    Console.Write("Remote Administrator Toolkit CLI\nPress any key to continue.");
                    Console.ReadKey();

                    if (StoredComputer == null)
                    {
                        PromptCredentials();
                    }

                    PrintMenu();

                    Console.Write("Execute new task? (y/n): ");
                    var willLoop = Console.ReadLine();
                    switch (willLoop)
                    {
                        case ("y"):
                            loopProgram = true;
                            break;

                        default:
                            loopProgram = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($"Error!\n{e.Message}");
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                }
            }
        }

        private static void PromptCredentials()
        {
            Console.Clear();
            Console.Write("Target domain: ");
            StoredDomain = Console.ReadLine();
            Console.Clear();
            Console.Write("Target computer: ");
            StoredComputer = Console.ReadLine();
            Console.Clear();
            Console.Write("Username: ");
            StoredUsername = Console.ReadLine();
            Console.Clear();
            Console.Write("Password: ");
            StoredUnsecurePassword = Console.ReadLine();
        }

        private static void PrintMenu()
        {
            string[] menuString = {
                "1 - Input new credentials.",
                "2 - Audit Computer System",
                "3 - Audit Operating System",
                "4 - Audit Installed Programs",
                "5 - Change Computer Description",
                "6 - Audit Monitor",
                "7 - Audit Store Programs",
                "8 - Audit Program Frameworks",
                "9 - Audit Local Disk",
                "10 - Audit Disk Drives",
                "11 - Audit Services",
                "12 - Audit Mouse",
                "13 - Audit Keyboard"
            };

            foreach (var m in menuString)
            {
                Console.WriteLine(m);
            }

            Console.Write("Menu selection: ");
            string? selection = Console.ReadLine();
            if (selection != null)
            {
                ProcessMenuSelection(UInt16.Parse(selection));
            }
            else
            {
                ProcessMenuSelection(-1);
            }
        }

        private static void ProcessMenuSelection(int selection)
        {
            switch (selection)
            {
                case (1):
                    PromptCredentials();
                    break;
                case (2):
                    AuditComputerSystem();
                    break;
                case (3):
                    AuditOperatingSystem();
                    break;
                case (4):
                    AuditInstalledPrograms();
                    break;
                case (5):
                    UpdateComputerDescription();
                    break;
                case (6):
                    AuditMonitor();
                    break;
                case (7):
                    AuditStorePrograms();
                    break;
                case (8):
                    AuditProgramFrameworks();
                    break;
                case (9):
                    AuditLocalDisk2();
                    break;
                case (10):
                    AuditDiskDrives();
                    break;
                case (11):
                    AuditServices();
                    break;
                case (12):
                    AuditMouse();
                    break;
                case (13):
                    AuditKeyboard();
                    break;
                default:
                    loopProgram = false;
                    break;
            }
        }

        private static void AuditServices()
        {
            var result = ToolKit.SystemManagement.Remoting.QueryCollection(
                StoredDomain,
                StoredComputer,
                StoredUsername,
                StoredUnsecurePassword,
                "Win32_Service"
            );

            if (result == null)
                return;

            foreach (ManagementObject service in result)
            {
                foreach (var prop in service.Properties)
                {
                    Console.WriteLine($"{prop.Name}: {service[prop.Name]}");
                }
                Console.WriteLine("");
            }
        }
        private static void AuditComputerSystem()
        {
            Console.Clear();
            var result = ToolKit.SystemManagement.Remoting.Query(
                StoredDomain,
                StoredComputer,
                StoredUsername,
                StoredUnsecurePassword,
                "Win32_ComputerSystem"
            );

            if (result != null)
            {
                foreach (var prop in result.Properties)
                {
                    Console.WriteLine($"{prop.Name}: {result[prop.Name]}");
                }
            }
        }

        private static void AuditOperatingSystem()
        {
            Console.Clear();
            var result = ToolKit.SystemManagement.Remoting.Query(
                StoredDomain,
                StoredComputer,
                StoredUsername,
                StoredUnsecurePassword,
                "Win32_OperatingSystem"
            );

            if (result != null)
            {
                foreach (var prop in result.Properties)
                {
                    Console.WriteLine($"{prop.Name}: {result[prop.Name]}");
                }
            }
        }

        private static void AuditInstalledPrograms()
        {
            Console.Clear();
            var result = ToolKit.SystemManagement.Remoting.QueryCollection(
                StoredDomain,
                StoredComputer,
                StoredUsername,
                StoredUnsecurePassword,
                "Win32_InstalledWin32Program"
            );

            if (result != null)
            {
                foreach (ManagementBaseObject obj in result)
                {
                    foreach (var prop in obj.Properties)
                    {
                        Console.WriteLine($"{prop.Name}: {obj[prop.Name]}");
                    }
                    Console.WriteLine("");
                }
            }
        }


        private static void AuditStorePrograms()
        {
            Console.Clear();
            var result = ToolKit.SystemManagement.Remoting.QueryCollection(
                StoredDomain,
                StoredComputer,
                StoredUsername,
                StoredUnsecurePassword,
                "Win32_InstalledStoreProgram"
            );

            if (result != null)
            {
                foreach (ManagementBaseObject obj in result)
                {
                    foreach (var prop in obj.Properties)
                    {
                        Console.WriteLine($"{prop.Name}: {obj[prop.Name]}");
                    }
                    Console.WriteLine("");
                }
            }
        }

        private static void AuditProgramFrameworks()
        {
            Console.Clear();
            var result = ToolKit.SystemManagement.Remoting.QueryCollection(
                StoredDomain,
                StoredComputer,
                StoredUsername,
                StoredUnsecurePassword,
                "Win32_InstalledProgramFramework"
            );

            if (result != null)
            {
                foreach (ManagementBaseObject obj in result)
                {
                    foreach (var prop in obj.Properties)
                    {
                        Console.WriteLine($"{prop.Name}: {obj[prop.Name]}");
                    }
                    Console.WriteLine("");
                }
            }
        }
        private static void UpdateComputerDescription()
        {
            Console.Clear();

            Console.WriteLine("New computer description: ");
            var newDesc = Console.ReadLine();

            var result = ToolKit.SystemManagement.Remoting.Update(
                StoredDomain,
                StoredComputer,
                StoredUsername,
                StoredUnsecurePassword,
                "Win32_OperatingSystem",
                "Description",
                newDesc
            );
            Console.Write("Done");
        }

        private static void AuditMonitor()
        {
            Console.Clear();
            var result = ToolKit.SystemManagement.Remoting.Query(
                StoredDomain,
                StoredComputer,
                StoredUsername,
                StoredUnsecurePassword,
                "WmiMonitorID",
                "wmi"
            );

            if (result != null)
            {
                foreach (var prop in result.Properties)
                {
                    var propIsArray = result[prop.Name] is Array;
                    if (propIsArray)
                    {
                        switch (prop.Name)
                        {
                            case ("ManufacturerName"):
                            case ("ProductCodeID"):
                            case ("SerialNumberID"):
                            case ("UserFriendlyName"):
                                var decoded = ToolKit.Helper.DecodeUInt16((UInt16[])result[prop.Name]);
                                Console.WriteLine($"{prop.Name}: {decoded}");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{prop.Name}: {result[prop.Name]}");
                    }
                }
            }
        }


        private static void AuditDiskDrives()
        {
            Console.Clear();

            var result = ToolKit.SystemManagement.Remoting.Query(
                StoredDomain,
                StoredComputer,
                StoredUsername,
                StoredUnsecurePassword,
                "Win32_DiskDrive"
            );

            if (result != null)
            {
                foreach (var prop in result.Properties)
                {
                    var propIsArray = result[prop.Name] is Array;
                    if (propIsArray)
                    {

                        Console.WriteLine($"{prop.Name}:");

                        foreach (var arrVal in (Array)result[prop.Name])
                        {
                            Console.Write($"[{arrVal}]");
                        }
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine($"{prop.Name}: {result[prop.Name]}");
                    }
                }
            }
        }
        private static void AuditLocalDisk2()
        {
            var result = ToolKit.SystemManagement.Remoting.QueryCollection(
            StoredDomain,
            StoredComputer,
            StoredUsername,
            StoredUnsecurePassword,
            "Win32_LogicalDisk"
       );

            if (result != null)
            {
                foreach (ManagementBaseObject obj in result)
                {
                    foreach (var prop in obj.Properties)
                    {
                        Console.WriteLine($"{prop.Name}: {obj[prop.Name]}");
                    }
                    Console.WriteLine("");
                }
            }
        }

        private static void AuditLocalDisk()
        {
            Console.Clear();
            var storageDevices = ToolKit.MiscrosoftManagementInfrastructure.Remoting.Query(
                StoredDomain,
                StoredComputer,
                StoredUsername,
                StoredUnsecurePassword,
                "Win32_LogicalDisk"
            );

            if (storageDevices != null)
            {
                foreach (var device in storageDevices)
                {
                    foreach (var prop in device.CimInstanceProperties)
                    {
                        Console.WriteLine($"{prop.Name}: {device.CimInstanceProperties[prop.Name].Value}");
                    }
                    Console.WriteLine("");
                }
            }

            Console.ReadLine();
        }


        private static void AuditMouse()
        {
            Console.Clear();
            var result = ToolKit.SystemManagement.Remoting.Query(
                StoredDomain,
                StoredComputer,
                StoredUsername,
                StoredUnsecurePassword,
                "Win32_PointingDevice"
            );

            if (result != null)
            {
                foreach (var prop in result.Properties)
                {
                    Console.WriteLine($"{prop.Name}: {result[prop.Name]}");
                }
            }
        }

        private static void AuditKeyboard()
        {
            Console.Clear();
            var result = ToolKit.SystemManagement.Remoting.Query(
                StoredDomain,
                StoredComputer,
                StoredUsername,
                StoredUnsecurePassword,
                "Win32_Keyboard"
            );

            if (result != null)
            {
                foreach (var prop in result.Properties)
                {
                    Console.WriteLine($"{prop.Name}: {result[prop.Name]}");
                }
            }
        }
    }
}