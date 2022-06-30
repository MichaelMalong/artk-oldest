namespace ToolKitApp.Models
{
    public class OperatingSystemDescriptionModel
    {
        public string ClassName => "Win32_OperatingSystem";
        public string PropertyName => "Description";
        public string? NewDescription { get; set; }

        public OperatingSystemDescriptionModel(
            string? newDescription
        )
        {
            NewDescription = newDescription;
        }
    }
}