using ToolKitApp.Models;
namespace ToolKitApp.Views.Controllers
{
    internal class TreeViewAudit
    {
        private enum EnumMemoryType
        {
            Unknown = 0,
            Other = 1,
            SIP = 2,
            DIP = 3,
            ZIP = 4,
            SOJ = 5,
            Proprietary = 6,
            SIMM = 7,
            DIMM = 8,
            TSOP = 9,
            PGA = 10,
            RIMM = 11,
            SODIMM = 12,
            SRIM = 13,
            SMD = 14,
            SSMP = 15,
            QFP = 16,
            TQFP = 17,
            SOIC = 18,
            LLC = 19,
            PLCC = 20,
            BGA = 21,
            FPBGA = 22,
            LGA = 23,
            DDR3 = 24
        };

        public static void Build_TreeView_VideoController(TreeView treeView, List<VideoControllerModel> videoControllers)
        {
            var root_VideoController = treeView.Nodes.Add("GPU");

            if (videoControllers == null)
                return;

            // Build branch.
            foreach (var videoController in videoControllers)
            {
                var branch_Name = root_VideoController.Nodes.Add(videoController.Name);

                // Adapter Compatibility
                var branch_AdapterCompatibilityLabel = branch_Name.Nodes.Add("Brand");
                branch_AdapterCompatibilityLabel.Nodes.Add(videoController.AdapterCompatibility);

                // Adapter RAM
                var branch_AdapterRAM = branch_Name.Nodes.Add("Video Memory (MB)");
                branch_AdapterRAM.Nodes.Add(
                    ToolKitLibrary.ToolKit.Helper.ConvertBytesToMegaBytes(
                        videoController.AdapterRAM
                    ).ToString()
                );
            }


            // Adapter Compatibility

            // Name

            // AdapterRAM
        }
        public static void Build_TreeViewAudit_PhysicalMemories(TreeView treeView, List<PhysicalMemoryModel> physicalMemories)
        {
            var root_PhysicalMemories = treeView.Nodes.Add("Memory");

            if (physicalMemories == null)
                return;

            // Build branch.
            foreach (var memory in physicalMemories)
            {
                var branch_Manufacturer = root_PhysicalMemories.Nodes.Add(memory.Manufacturer);

                var branch_CapacityLabel = branch_Manufacturer.Nodes.Add("Capacity (MB)");
                var branch_Capacity = branch_CapacityLabel.Nodes.Add(
                    ToolKitLibrary.ToolKit.Helper.ConvertBytesToMegaBytes(
                        memory.Capacity
                    ).ToString()
                );

                var branch_partNumberLabel = branch_Manufacturer.Nodes.Add("Part Number");
                branch_partNumberLabel.Nodes.Add(memory.PartNumber);

                var branch_serialNumberLabel = branch_Manufacturer.Nodes.Add("Serial Number");
                branch_serialNumberLabel.Nodes.Add(memory.SerialNumber);

                var branch_MemoryTypeLabel = branch_Manufacturer.Nodes.Add("Memory Type");
                //MemoryType t = (MemoryType)memory.MemoryType;
                var memType = (EnumMemoryType)memory.MemoryType;
                branch_MemoryTypeLabel.Nodes.Add(memType.ToString());
            }

            //root_PhysicalMemories.ExpandAll();

        }

        public static void Build_TreeView_InstalledPrograms(TreeView treeView, List<InstalledWin32ProgramModel> programs)
        {
            var root_Program = treeView.Nodes.Add("Installed Programs");

            if (programs == null)
                return;

            // Build branch.
            foreach (var program in programs)
            {
                // Name
                var branch_Name = root_Program.Nodes.Add(program.Name);

                // Vendor
                var branch_Vendor_Label = branch_Name.Nodes.Add($"Vendor: {program.Vendor}");
                //branch_Vendor_Label.Nodes.Add(program.Vendor);

                // Version
                var branch_Version_Label = branch_Name.Nodes.Add($"Version: {program.Version}");
                //branch_Version_Label.Nodes.Add(program.Version);
            }

            root_Program.Expand();
        }
        public static void Build_TreeView_DiskDrives(TreeView treeView, List<DiskDriveModel> diskDrives)
        {
            var root_DiskDrive = treeView.Nodes.Add("Media");

            if (diskDrives == null)
                return;

            // Build branch.
            foreach (var disk in diskDrives)
            {
                // Model
                var branch_Model = root_DiskDrive.Nodes.Add(disk.Model);

                // Size
                var branch_Size_Label = branch_Model.Nodes.Add("Size (MB)");
                branch_Size_Label.Nodes.Add(
                    ToolKitLibrary.ToolKit.Helper.ConvertBytesToMegaBytes(
                        disk.Size
                    ).ToString()
                );

                // Partitions.
                var branch_Partitions_Label = branch_Model.Nodes.Add("Partition count");
                branch_Partitions_Label.Nodes.Add(disk.Partitions.ToString());

                // Serial Number.
                var branch_SerialNumber_Label = branch_Model.Nodes.Add("Serial Number");
                branch_SerialNumber_Label.Nodes.Add(disk.SerialNumber);
            }
        }

        public static void Build_TreeViewAudit_LogicalDisks(TreeView treeView, List<LogicalDiskModel> logicalDisks)
        {
            var root_LogicalDisks = treeView.Nodes.Add("Volumes");

            if (logicalDisks == null)
                return;

            // Build branch
            foreach (var disk in logicalDisks)
            {
                // Device ID.
                var branch_DeviceID = root_LogicalDisks.Nodes.Add(disk.DeviceID);

                // File System
                var branch_FileSystem_Label = branch_DeviceID.Nodes.Add("File System");
                branch_FileSystem_Label.Nodes.Add(disk.FileSystem);

                // Free Space
                var branch_FreeSpace_Label = branch_DeviceID.Nodes.Add("Free Space (MB)");
                branch_FreeSpace_Label.Nodes.Add(
                    ToolKitLibrary.ToolKit.Helper.ConvertBytesToMegaBytes(
                        disk.FreeSpace
                    ).ToString()
                );

                // Media type
                var branch_MediaType_Label = branch_DeviceID.Nodes.Add("Media Type");
                branch_MediaType_Label.Nodes.Add(((LogicalDiskModel.enumMediaType)disk.MediaType).ToString());
            }
        }
        public static void Build_TreeViewAudit_Monitors(TreeView treeView, MonitorListModel monitors)
        {
            var root_Monitors = treeView.Nodes.Add("Monitor");

            if (monitors == null)
                return;

            // Build branch.
            foreach (var monitor in monitors.MonitorList)
            {
                var branch_UserFriendlyName = root_Monitors.Nodes.Add(monitor.UserFriendlyName);

                var branch_ManufacturerLabel = branch_UserFriendlyName.Nodes.Add("Manufacturer");
                branch_ManufacturerLabel.Nodes.Add(monitor.ManufacturerName);

                var branch_ProductIDLabel = branch_UserFriendlyName.Nodes.Add("Product ID");
                branch_ProductIDLabel.Nodes.Add(monitor.ProductCodeID);

                var branch_SerialNumberIDLabel = branch_UserFriendlyName.Nodes.Add("Serial Number ID");
                branch_SerialNumberIDLabel.Nodes.Add(monitor.SerialNumberID);

                var branch_YearofManufacture = branch_UserFriendlyName.Nodes.Add("Year of Manufacture");
                branch_YearofManufacture.Nodes.Add(monitor.YearOfManufacture.ToString());
            }

            //root_Monitors.ExpandAll();
            return;
        }

        public static void Build_TreeViewAudit_Processor(TreeView treeView, ProcessorModel processor)
        {
            if (processor == null)
                return;

            // Root
            var root_Name = treeView.Nodes.Add("CPU");



            // Name
            var branch_NameLabel = root_Name.Nodes.Add(processor.Name);
            //branch_NameLabel.Nodes.Add(processor.Name);

            // Manufacturer
            var branch_ManufacturerLabel = branch_NameLabel.Nodes.Add("Manufacturer");
            branch_ManufacturerLabel.Nodes.Add(processor.Manufacturer);

            // Caption
            var branch_CaptionLabel = branch_NameLabel.Nodes.Add("Family");
            branch_CaptionLabel.Nodes.Add(processor.Caption);


            // Data Width
            var branch_DataWidthLabel = branch_NameLabel.Nodes.Add("Data Width");
            branch_DataWidthLabel.Nodes.Add(processor.DataWidth.ToString());

            // Thread Count
            //var branch_ThreadCountLabel = branch_NameLabel.Nodes.Add("Threads");
            //branch_ThreadCountLabel.Nodes.Add(processor.ThreadCount.ToString());

            // ProcessorID
            var branch_ProcessorID = branch_NameLabel.Nodes.Add("ID");
            branch_ProcessorID.Nodes.Add(processor.ProcessorID);

            //root_Name.ExpandAll();
        }

        public static void Build_TreeViewAudit_ComputerSystem(TreeView treeView, ComputerSystemModel computerSystem)
        {
            if (computerSystem == null)
                return;

            // Name
            var root_Name = treeView.Nodes.Add(computerSystem.Name);


            // Domain
            var branch_DomainLabel = root_Name.Nodes.Add("Domain");
            branch_DomainLabel.Nodes.Add(computerSystem.Domain);

            // Manufacturer
            var branch_ManufactuerLabel = root_Name.Nodes.Add("Manufacturer");
            branch_ManufactuerLabel.Nodes.Add(computerSystem.Manufacturer);

            // Model
            var branch_ModelLabel = root_Name.Nodes.Add("Model");
            branch_ModelLabel.Nodes.Add(computerSystem.Model);

            // Total Physical Memory
            var branch_TotalPhysicalMemoryLabel = root_Name.Nodes.Add("Total Memory (MB)");
            branch_TotalPhysicalMemoryLabel.Nodes.Add(
                ToolKitLibrary.ToolKit.Helper.ConvertBytesToMegaBytes(
                    computerSystem.TotalPhysicalMemory
                ).ToString()
            );

            root_Name.ExpandAll();
        }

        public static void Build_TreeViewAudit_OperatingSystem(TreeView treeView, OperatingSystemModel operatingSystem)
        {
            if (operatingSystem == null)
                return;

            var root_OperatingSystem = treeView.Nodes.Add("Operating System");

            // Caption.
            var branch_CaptionLabel = root_OperatingSystem.Nodes.Add(operatingSystem.Caption);

            // Build Number.
            var branch_BuildNumber_Label = branch_CaptionLabel.Nodes.Add("Build Number");
            branch_BuildNumber_Label.Nodes.Add(operatingSystem.BuildNumber);

            // OS Architecture.
            var branch_OSArchitecture_Label = branch_CaptionLabel.Nodes.Add("Architecture");
            branch_OSArchitecture_Label.Nodes.Add(operatingSystem.OSArchitecture);

            // Description.
            var branch_Description_Label = branch_CaptionLabel.Nodes.Add("Description");
            branch_Description_Label.Nodes.Add(operatingSystem.Description);
        }
    }
}