namespace ToolKitApp.Models
{
    public class ProcessorModel
    {
        public String? Name { get; set; }
        public String? Caption { get; set; }
        public String? Manufacturer { get; set; }
        public UInt16? DataWidth { get; set; }
        public String? ProcessorID { get; set; }
        //public UInt32? ThreadCount { get; set; }
        public UInt16? Revision { get; set; }

        public ProcessorModel(
            string? name,
            string? caption,
            string? manufacturer,
            UInt16? dataWidth,
            string? processorID,
            //UInt32? threadCount,
            UInt16? revision
        )
        {
            Name = name;
            Caption = caption;
            Manufacturer = manufacturer;
            DataWidth = dataWidth;
            ProcessorID = processorID;
            //ThreadCount = threadCount;
            Revision = revision;
        }
    }
}