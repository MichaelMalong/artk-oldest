using ToolKitApp.Models;
namespace ToolKitApp.Services
{
    public class InstalledWin32ProgramServices
    {
        public static async Task<List<InstalledWin32ProgramModel>> Get_InstalledWin32Programs(CredentialsModel credentials)
        {
            try
            {
                var result = await ToolKitLibrary.ToolKit.SystemManagement.Remoting.QueryCollection(
                    credentials.Domain,
                    credentials.ComputerName,
                    credentials.Username,
                    credentials.UnSecurePassword,
                    "Win32_InstalledWin32Program"
                );

                List<InstalledWin32ProgramModel> programs = new List<InstalledWin32ProgramModel>();
                if (result != null)
                {
                    foreach (var program in result)
                    {
                        #region Checks.
                        string? name = Convert.ToString(program["Name"]);
                        string? vendor = Convert.ToString(program["Vendor"]);
                        string? version = Convert.ToString(program["Version"]);
                        #endregion

                        programs.Add(
                            new InstalledWin32ProgramModel(
                                name,
                                vendor,
                                version
                            )
                        );
                    }
                    return programs;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n{ex.StackTrace}");
                return null;
            }
        }
    }
}