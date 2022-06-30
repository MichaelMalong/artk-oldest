using ToolKitApp.Models;

namespace ToolKitApp.Services
{
    public class ComputerSystemServices
    {
        public static async Task<ComputerSystemModel?> Get_ComputerSystem(CredentialsModel credentials)
        {
            var result = await ToolKitLibrary.ToolKit.SystemManagement.Remoting.Query(
                    credentials.Domain,
                    credentials.ComputerName,
                    credentials.Username,
                    credentials.UnSecurePassword,
                    "Win32_ComputerSystem"
                );

            if (result != null)
            {
                #region Checks.
                String? name = Convert.ToString(result["Name"]);
                String? domain = Convert.ToString(result["Domain"]);
                String? manufacturer = Convert.ToString(result["Manufacturer"]);
                String? model = Convert.ToString(result["model"]);
                UInt64? totalPhysicalMemory = Convert.ToUInt64(result["TotalPhysicalMemory"]);
                #endregion

                var retreived_ComputerSystem = new ComputerSystemModel(
                    name,
                    domain,
                    manufacturer,
                    model,
                    totalPhysicalMemory
                 );

                return retreived_ComputerSystem;
            }
            return null;
        }
    }
}
