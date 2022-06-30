using ToolKitApp.Models;

namespace ToolKitApp.Services
{
    public class VideoControllerServices
    {
        public static List<VideoControllerModel>? Get_VideoControllers(CredentialsModel credentials)
        {
            try
            {
                var result = ToolKitLibrary.ToolKit.SystemManagement.Remoting.QueryCollection(
                    credentials.Domain,
                    credentials.ComputerName,
                    credentials.Username,
                    credentials.UnSecurePassword,
                    "Win32_VideoController"
                );

                List<VideoControllerModel> videoControllers = new List<VideoControllerModel>();
                if (result != null)
                {
                    foreach (var videoController in result)
                    {

                        #region Checks.
                        string? adapterCompatibility = Convert.ToString(videoController["AdapterCompatibility"]);
                        UInt32? adapterRAM = Convert.ToUInt32(videoController["AdapterRAM"]);
                        string? name = Convert.ToString(videoController["Name"]);
                        #endregion

                        videoControllers.Add(
                            new VideoControllerModel(
                                adapterCompatibility,
                                adapterRAM,
                                name
                            )
                        );
                    }
                    return videoControllers;
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