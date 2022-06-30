using System.Management;
using ToolKitApp.Models;

namespace ToolKitApp.Services
{
    public class DiskDriveServices
    {
        public static async Task<List<DiskDriveModel>> Get_DiskDrives(CredentialsModel credentials)
        {
            try
            {
                var result = await ToolKitLibrary.ToolKit.SystemManagement.Remoting.QueryCollection(
                    credentials.Domain,
                    credentials.ComputerName,
                    credentials.Username,
                    credentials.UnSecurePassword,
                    "Win32_DiskDrive"
                );

                List<DiskDriveModel> diskDrives = new List<DiskDriveModel>();
                if (result != null)
                {
                    foreach (var diskDrive in result)
                    {
                        #region  Checks.
                        string? model = Convert.ToString(diskDrive["Model"]);
                        UInt32? partitions = Convert.ToUInt32(diskDrive["Partitions"]);
                        string? serialNumber = Convert.ToString(diskDrive["SerialNumber"]);
                        UInt64? size = Convert.ToUInt64(diskDrive["Size"]);
                        #endregion

                        diskDrives.Add(
                            new DiskDriveModel(
                                model,
                                partitions,
                                serialNumber,
                                size
                            )
                        );
                    }
                    return diskDrives;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}