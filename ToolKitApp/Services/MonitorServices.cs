using ToolKitApp.Models;

namespace ToolKitApp.Services
{
    public class MonitorServices
    {
        public static MonitorListModel? Get_Monitors(CredentialsModel credentials)
        {
            try
            {
                var result = ToolKitLibrary.ToolKit.SystemManagement.Remoting.QueryCollection(
                credentials.Domain,
                credentials.ComputerName,
                credentials.Username,
                credentials.UnSecurePassword,
                "WMIMonitorID",
                "wmi"
            );
                List<MonitorModel> monitors = new List<MonitorModel>();

                if (result != null)
                {
                    foreach (var monitor in result)
                    {
                        #region Checks.
                        var objManufacturerName = monitor["ManufacturerName"];
                        String? manufacturerName = "";
                        if (objManufacturerName != null)
                        {
                            manufacturerName = ToolKitLibrary.ToolKit.Helper.DecodeUInt16(
                                (UInt16[])objManufacturerName
                            );
                        }

                        var objProductCodeID = monitor["ProductCodeID"];
                        string? productCodeID = "";
                        if (objProductCodeID != null)
                        {
                            productCodeID = ToolKitLibrary.ToolKit.Helper.DecodeUInt16(
                                (UInt16[])objProductCodeID
                            );
                        }

                        var objSerialNumberID = monitor["SerialNumberID"];
                        string? serialNumberID = "";
                        if (objSerialNumberID != null)
                        {
                            serialNumberID = ToolKitLibrary.ToolKit.Helper.DecodeUInt16(
                                (UInt16[])objSerialNumberID
                            );
                        }

                        var objUserFriendlyName = monitor["UserFriendlyName"];
                        string? userFriendlyName = "";
                        if (objUserFriendlyName != null)
                        {
                            userFriendlyName = ToolKitLibrary.ToolKit.Helper.DecodeUInt16(
                                (UInt16[])objUserFriendlyName
                            );
                        }

                        UInt16 yearOfManufacture = Convert.ToUInt16(monitor["YearOfManufacture"]);
                        #endregion
                        monitors.Add(
                            new MonitorModel(
                                manufacturerName,
                                productCodeID,
                                serialNumberID,
                                userFriendlyName,
                                yearOfManufacture
                            )
                        );
                    }
                    return new MonitorListModel(monitors);
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public static async Task<MonitorModel?> Get_Monitor(CredentialsModel credentials)
        {
            var result = await ToolKitLibrary.ToolKit.SystemManagement.Remoting.Query(
            credentials.Domain,
            credentials.ComputerName,
            credentials.Username,
            credentials.UnSecurePassword,
            "WmiMonitorID",
            "wmi"
            );

            if (result != null)
            {

                #region Checks.
                var objManufacturerName = result["ManufacturerName"];
                String? manufacturerName = "";
                if (objManufacturerName != null)
                {
                    manufacturerName = ToolKitLibrary.ToolKit.Helper.DecodeUInt16(
                        (UInt16[])objManufacturerName
                    );
                }

                var objProductCodeID = result["ProductCodeID"];
                string? productCodeID = "";
                if (objProductCodeID != null)
                {
                    productCodeID = ToolKitLibrary.ToolKit.Helper.DecodeUInt16(
                        (UInt16[])objProductCodeID
                    );
                }

                var objSerialNumberID = result["SerialNumberID"];
                string? serialNumberID = "";
                if (objSerialNumberID != null)
                {
                    serialNumberID = ToolKitLibrary.ToolKit.Helper.DecodeUInt16(
                        (UInt16[])objSerialNumberID
                    );
                }

                var objUserFriendlyName = result["UserFriendlyName"];
                string? userFriendlyName = "";
                if (objUserFriendlyName != null)
                {
                    userFriendlyName = ToolKitLibrary.ToolKit.Helper.DecodeUInt16(
                        (UInt16[])objUserFriendlyName
                    );
                }

                UInt16 yearOfManufacture = Convert.ToUInt16(result["YearOfManufacture"]);
                #endregion


                var retreived_Monitor = new MonitorModel(
                        manufacturerName,
                        productCodeID,
                        serialNumberID,
                        userFriendlyName,
                        yearOfManufacture
                        );

                return retreived_Monitor;
            }
            return new MonitorModel("Not found.", "Not found", "Not found", "Not found.", null);
        }
    }
}
