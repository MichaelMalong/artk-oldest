namespace ToolKitApp.Models
{
    public class InstalledWin32ProgramModel
    {
        public string? Name { get; set; }
        public string? Vendor { get; set; }
        public string? Version { get; set; }

        public InstalledWin32ProgramModel(
            string? name,
            string? vendor,
            string? version
        )
        {
            Name = name;
            Vendor = vendor;
            Version = version;
        }
    }
}