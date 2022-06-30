using ToolKitApp.Models;

namespace ToolKitApp.Services
{
    public class LogicalDiskServices
    {
        public static async Task<List<LogicalDiskModel>> Get_LogicalDisks(CredentialsModel credentials)
        {
            try
            {
                var result = await ToolKitLibrary.ToolKit.SystemManagement.Remoting.QueryCollection(
                    credentials.Domain,
                    credentials.ComputerName,
                    credentials.Username,
                    credentials.UnSecurePassword,
                    "Win32_LogicalDisk"
                );

                List<LogicalDiskModel> logicalDisks = new List<LogicalDiskModel>();
                if (result != null)
                {
                    foreach (var disk in result)
                    {
                        #region Checks.
                        string? deviceID = Convert.ToString(disk["DeviceID"]);
                        string? fileSystem = Convert.ToString(disk["FileSystem"]);
                        UInt64? freeSpace = Convert.ToUInt64(disk["FreeSpace"]);
                        UInt32 mediaType = Convert.ToUInt32(disk["MediaType"]);
                        #endregion

                        logicalDisks.Add(
                            new LogicalDiskModel(
                                deviceID,
                                fileSystem,
                                freeSpace,
                                mediaType
                            )
                        );
                    }
                }
                return logicalDisks;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}