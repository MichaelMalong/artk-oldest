namespace ToolKitApp.Models
{
    public class CredentialsModel
    {
        public string Domain { get; private set; }
        public string ComputerName { get; private set; }
        public string Username { get; private set; }
        public string UnSecurePassword { get; private set; }

        public CredentialsModel(
            string domain,
            string computerName,
            string username,
            string unSecurePassword
        )
        {
            Domain = domain;
            ComputerName = computerName;
            Username = username;
            UnSecurePassword = unSecurePassword;

            //ToolKitLibrary.ToolKit.Helper.DebugAgent(
            //    domain,
            //    computerName,
            //    username,
            //    unSecurePassword
            //);
        }
    }
}

