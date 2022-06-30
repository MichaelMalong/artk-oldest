namespace ToolKitApp.Models
{
    public class LogicalDiskModel
    {
        public enum enumMediaType
        {
            Unknown = 0,
            Removeable = 11,
            FixedMedia = 12
        }
        public string? DeviceID { get; set; }
        public string? FileSystem { get; set; }
        public UInt64? FreeSpace { get; set; }
        public UInt32? MediaType { get; set; }

        public LogicalDiskModel(
            string? deviceID,
            string? fileSystem,
            UInt64? freeSpace,
            UInt32 mediaType
        )
        {
            #region Check.
            deviceID = Convert.ToString(deviceID);
            fileSystem = Convert.ToString(fileSystem);
            freeSpace = Convert.ToUInt64(freeSpace);
            mediaType = Convert.ToUInt32(mediaType);
            #endregion

            DeviceID = deviceID;
            FileSystem = fileSystem;
            FreeSpace = freeSpace;
            MediaType = mediaType;
        }
    }
}