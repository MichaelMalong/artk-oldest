namespace ToolKitApp.Models
{
    public class ComputerSystemModel
    {
        public String? Name { get; set; }
        public String? Domain { get; set; }
        public String? Manufacturer { get; set; }
        public String? Model { get; set; }

        public UInt64 TotalPhysicalMemory { get; set; }

        public ComputerSystemModel(
            string? name,
            string? domain,
            string? manufacturer,
            string? model,
        UInt64? totalPhysicalMemory
        )
        {
            Name = name;
            Domain = domain;
            Manufacturer = manufacturer;
            Model = model;

            if (totalPhysicalMemory == null) totalPhysicalMemory = 0;
            TotalPhysicalMemory = (UInt64)totalPhysicalMemory;
        }

        public ComputerSystemModel() { }
    }
}
