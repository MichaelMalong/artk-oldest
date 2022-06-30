namespace ToolKitApp.Models
{

    public class MonitorListModel
    {
        public List<MonitorModel>? MonitorList { get; set; }

        public MonitorListModel(List<MonitorModel> monitorList)
        {
            MonitorList = monitorList;
        }
    }
}