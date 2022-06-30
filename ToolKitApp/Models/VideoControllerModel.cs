public class VideoControllerModel
{
    public string? AdapterCompatibility { get; set; }
    public UInt32? AdapterRAM { get; set; }

    public string? Name { get; set; }

    public VideoControllerModel(
        string? adapterCompatibility,
        UInt32? adapterRAM,
        string? name
    )
    {
        AdapterCompatibility = adapterCompatibility;
        AdapterRAM = adapterRAM;
        Name = name;
    }

}