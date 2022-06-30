namespace ToolKitApp.Models;

public class PhysicalMemoryModel
{
    public UInt64? Capacity { get; set; }
    public string? Manufacturer { get; set; }
    public UInt16? MemoryType { get; set; }
    public string? PartNumber { get; set; }
    public string? SerialNumber { get; set; }

    public PhysicalMemoryModel(
        UInt64? capacity,
        string? manufacturer,
        UInt16? memoryType,
        string? partNumber,
        string? serialNumber
    )
    {
        Capacity = capacity;
        Manufacturer = manufacturer;
        MemoryType = memoryType;
        PartNumber = partNumber;
        SerialNumber = serialNumber;
    }
}