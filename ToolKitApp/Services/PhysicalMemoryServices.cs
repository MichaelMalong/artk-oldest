using ToolKitApp.Models;

namespace ToolKitApp.Services
{
    public class PhysicalMemoryServices
    {
        public static async Task<List<PhysicalMemoryModel>> Get_PhysicalMemories(CredentialsModel credentials)
        {
            try
            {
                var result = await ToolKitLibrary.ToolKit.SystemManagement.Remoting.QueryCollection(
                    credentials.Domain,
                    credentials.ComputerName,
                    credentials.Username,
                    credentials.UnSecurePassword,
                    "Win32_PhysicalMemory"
                );

                List<PhysicalMemoryModel> memories = new List<PhysicalMemoryModel>();
                if (result != null)
                {
                    foreach (var memory in result)
                    {
                        #region Checks.
                        UInt64? capacity = Convert.ToUInt64(memory["Capacity"]);
                        string? manufacturer = Convert.ToString(memory["Manufacturer"]);
                        UInt16? memoryType = Convert.ToUInt16(memory["MemoryType"]);
                        string? partNumber = Convert.ToString(memory["PartNumber"]);
                        string? serialNumber = Convert.ToString(memory["SerialNumber"]);
                        #endregion

                        memories.Add(
                            new PhysicalMemoryModel(
                                capacity,
                                manufacturer,
                                memoryType,
                                partNumber,
                                serialNumber
                            )
                        );
                    }
                    return memories;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public static async Task<PhysicalMemoryModel?> Get_PhysicalMemory(CredentialsModel credentials)
        {
            var result = await ToolKitLibrary.ToolKit.SystemManagement.Remoting.Query(
                credentials.Domain,
                credentials.ComputerName,
                credentials.Username,
                credentials.UnSecurePassword,
                "Win32_PhysicalMemory"
            );

            if (result != null)
            {
                #region Checks.
                UInt64? capacity = Convert.ToUInt64(result["Capacity"]);
                string? manufacturer = Convert.ToString(result["Manufacturer"]);
                UInt16? memoryType = Convert.ToUInt16(result["MemoryType"]);
                string? partNumber = Convert.ToString(result["PartNumber"]);
                string? serialNumber = Convert.ToString(result["SerialNumber"]);
                #endregion


                var retreived_PhysicalMemory = new PhysicalMemoryModel(
                    capacity,
                    manufacturer,
                    memoryType,
                    partNumber,
                    serialNumber
                    );
                return retreived_PhysicalMemory;
            }

            return new PhysicalMemoryModel(0, "Not Found", 0, "Not Found", "Not Found");
        }
    }
}
