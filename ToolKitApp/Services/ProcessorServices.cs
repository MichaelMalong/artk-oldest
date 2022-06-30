using ToolKitApp.Models;
namespace ToolKitApp.Services
{
    public class ProcessorServices
    {
        public static ProcessorModel? Get_Processor(CredentialsModel credentials)
        {
            var result = ToolKitLibrary.ToolKit.SystemManagement.Remoting.Query(
                credentials.Domain,
                credentials.ComputerName,
                credentials.Username,
                credentials.UnSecurePassword,
                "Win32_Processor"
            );

            if (result != null)
            {
                #region Checks.
                String? name = Convert.ToString(result["Name"]);
                String? caption = Convert.ToString(result["Caption"]);
                String? manufacturer = Convert.ToString(result["Manufacturer"]);
                UInt16? dataWidth = Convert.ToUInt16(result["DataWidth"]);
                String? processorID = Convert.ToString(result["ProcessorID"]);
                //UInt32? threadCount = Convert.ToUInt32(result["ThreadCount"]);
                UInt16? revision = Convert.ToUInt16(result["Revision"]);
                #endregion

                var retreived_Processor = new ProcessorModel(
                    name,
                    caption,
                    manufacturer,
                    dataWidth,
                    processorID,
                    //threadCount,
                    revision
                );
                return retreived_Processor;
            }

            return null;
        }
    }
}