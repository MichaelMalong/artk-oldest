namespace ToolKitApp.Models
{
    public class OperatingSystemModel
    {
        public string? BuildNumber { get; set; }
        public string? Caption { get; set; }
        public string? Description { get; set; }
        public string? OSArchitecture { get; set; }

        public OperatingSystemModel(
            string? buildNumber,
            string? caption,
            string? description,
            string? osArchitecture
        )
        {
            BuildNumber = buildNumber;
            Caption = caption;
            Description = description;
            OSArchitecture = osArchitecture;
        }
    }
}

