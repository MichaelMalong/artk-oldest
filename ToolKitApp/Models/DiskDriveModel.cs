namespace ToolKitApp.Models
{
    public class DiskDriveModel
    {
        public string? Model { get; set; }
        public UInt32? Partitions { get; set; }
        public string? SerialNumber { get; set; }
        public UInt64? Size { get; set; }

        public DiskDriveModel(
            string? model,
            UInt32? partitions,
            string? serialNumber,
            UInt64? size
        )
        {
            Model = model;
            Partitions = partitions;
            SerialNumber = serialNumber;
            Size = size;
        }
    }
}