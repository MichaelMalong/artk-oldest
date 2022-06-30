namespace ToolKitApp.Models
{
    public class MonitorModel
    {
        public String ManufacturerName { get; set; }
        public String ProductCodeID { get; set; }
        public String SerialNumberID { get; set; }
        public String UserFriendlyName { get; set; }
        public UInt16? YearOfManufacture { get; set; }

        public MonitorModel(
            string? manufacturerName,
            string? productCodeID,
            string? serialNumberID,
            string? userFriendlyName,
            UInt16? yearOfManufacture
        )
        {
            ManufacturerName = manufacturerName;
            ProductCodeID = productCodeID;
            SerialNumberID = serialNumberID;
            UserFriendlyName = userFriendlyName;
            YearOfManufacture = yearOfManufacture;
        }
    }
}
