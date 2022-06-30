using ToolKitApp.Models;
namespace ToolKitApp.Services
{
    public class OperatingSystemServices
    {
        public static void Update_OperatingSystem_Description(CredentialsModel credentials, OperatingSystemDescriptionModel updateInfo)
        {
            ToolKitLibrary.ToolKit.SystemManagement.Remoting.Update(
                credentials.Domain,
                credentials.ComputerName,
                credentials.Username,
                credentials.UnSecurePassword,
                updateInfo.ClassName,
                updateInfo.PropertyName,
                updateInfo.NewDescription
            );
        }
        public static async Task<OperatingSystemModel?> Get_OperatingSystem(CredentialsModel credentials)
        {
            var result = await ToolKitLibrary.ToolKit.SystemManagement.Remoting.Query(
                credentials.Domain,
                credentials.ComputerName,
                credentials.Username,
                credentials.UnSecurePassword,
                "Win32_OperatingSystem"
            );

            if (result != null)
            {
                #region Checks.
                string buildNumber = Convert.ToString(result["BuildNumber"]);
                string caption = Convert.ToString(result["Caption"]);
                string description = Convert.ToString(result["Description"]);
                string osArchitecture = Convert.ToString(result["OSArchitecture"]);
                #endregion

                var retreived_OperatingSystem = new OperatingSystemModel(
                    buildNumber,
                    caption,
                    description,
                    osArchitecture
                );
                return retreived_OperatingSystem;
            }
            return null;
        }
    }
}