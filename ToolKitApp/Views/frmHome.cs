using ToolKitApp.Services;

namespace ToolKitApp.Views
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            ListView lvHome = new ListView();

            InitializeComponent();

        }


        private void txtComputerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                var frmLoginComputer_ = new frmLoginComputer();
                frmLoginComputer_.Show(this);
            }

        }


        private async void btnSystem_Click(object sender, EventArgs e)
        {
            treeViewAudit.Nodes.Clear();
            try
            {

                await Populate_TreeViewAudit();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Populate_TreeViewAudit()
        {
            var credentials = new ToolKitApp.Models.CredentialsModel(
                txtDomain.Text,
                txtComputerName.Text,
                txtUsername.Text,
                txtPassword.Text
                );

            // Fetching section.
            var computerSystem = await ComputerSystemServices.Get_ComputerSystem(credentials);
            var monitors = await MonitorServices.Get_Monitors(credentials);
            var processor = await ProcessorServices.Get_Processor(credentials);
            var physicalMemories = await PhysicalMemoryServices.Get_PhysicalMemories(credentials);
            var videoControllers = await VideoControllerServices.Get_VideoControllers(credentials);
            var operatingSystem = await OperatingSystemServices.Get_OperatingSystem(credentials);
            var logicalDisks = await LogicalDiskServices.Get_LogicalDisks(credentials);
            var diskDrives = await DiskDriveServices.Get_DiskDrives(credentials);

            // Update computer description textbox.
            if (operatingSystem != null)
                txtComputerDescription.Text = operatingSystem.Description;

            // Tree builder section.
            if (computerSystem != null)
                Views.Controllers.TreeViewAudit.Build_TreeViewAudit_ComputerSystem(treeViewAudit, computerSystem);

            if (monitors != null)
                await Views.Controllers.TreeViewAudit.Build_TreeViewAudit_Monitors(treeViewAudit, monitors);

            if (processor != null)
                Views.Controllers.TreeViewAudit.Build_TreeViewAudit_Processor(treeViewAudit, processor);

            if (physicalMemories != null)
                Views.Controllers.TreeViewAudit.Build_TreeViewAudit_PhysicalMemories(treeViewAudit, physicalMemories);

            if (videoControllers != null)
                Views.Controllers.TreeViewAudit.Build_TreeView_VideoController(treeViewAudit, videoControllers);

            if (operatingSystem != null)
                Views.Controllers.TreeViewAudit.Build_TreeViewAudit_OperatingSystem(treeViewAudit, operatingSystem);

            if (logicalDisks != null)
                Views.Controllers.TreeViewAudit.Build_TreeViewAudit_LogicalDisks(treeViewAudit, logicalDisks);

            if (diskDrives != null)
                Views.Controllers.TreeViewAudit.Build_TreeView_DiskDrives(treeViewAudit, diskDrives);
        }

        private void cmdUpdateComputerDescription_Click(object sender, EventArgs e)
        {
            Models.CredentialsModel credentials = new Models.CredentialsModel(
                txtDomain.Text,
                txtComputerName.Text,
                txtUsername.Text,
                txtPassword.Text
                );
            Models.OperatingSystemDescriptionModel updateInfo = new Models.OperatingSystemDescriptionModel(
                txtComputerDescription.Text
                );

            OperatingSystemServices.Update_OperatingSystem_Description(
                    credentials,
                    updateInfo
                );
            MessageBox.Show($"Computer description of {txtComputerName.Text} has been updated.", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void btnAuditInstalledPrograms_Click(object sender, EventArgs e)
        {
            treeViewAudit.Nodes.Clear();
            Models.CredentialsModel credentials = new Models.CredentialsModel(
                txtDomain.Text,
                txtComputerName.Text,
                txtUsername.Text,
                txtPassword.Text
                );

            var programs = await InstalledWin32ProgramServices.Get_InstalledWin32Programs(credentials);

            if (programs != null)
                Views.Controllers.TreeViewAudit.Build_TreeView_InstalledPrograms(treeViewAudit, programs);

        }
    }
}
