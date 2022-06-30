using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Management.Infrastructure;
using Microsoft.Management.Infrastructure.Options;

namespace ToolKitLibrary
{
    public class ToolKit
    {
        public class Helper
        {
            public static String DecodeUInt16(UInt16[] codeArray)
            {
                if (codeArray == null)
                    return "";
                var decodedString = "";

                foreach (var value in codeArray)
                {
                    byte[] bytes = BitConverter.GetBytes(value);
                    decodedString += BitConverter.ToChar(bytes);
                }
                return decodedString;
            }

            public static UInt64? ConvertBytesToMegaBytes(UInt64? recordedCapacity)
            {
                if (recordedCapacity <= 0)
                    return 0;
                if (recordedCapacity == null)
                    return 0;
                return (recordedCapacity / 1024 / 1024);
            }



            public static void DebugAgent(string? domain, string? computerName, string? userName, string password)
            {
                #region Checks.
                string? _domain = Convert.ToString(domain);
                string? _computerName = Convert.ToString(computerName);
                string? _userName = Convert.ToString(userName);
                string? _password = Convert.ToString(password);

                // Unique file name.
                var uniqueFileName = string.Format(@"TenthMan_{0}", Guid.NewGuid());

                // Directory
                var dir = AppDomain.CurrentDomain.BaseDirectory;
                using (FileStream fs = File.Create(uniqueFileName))
                {
                    byte[] infoDomain = new UTF8Encoding(true).GetBytes($"Domain: {_domain}\n");
                    fs.Write(infoDomain, 0, infoDomain.Length);
                    byte[] infoComputerName = new UTF8Encoding(true).GetBytes($"Computer name: {_computerName}\n");
                    fs.Write(infoComputerName, 0, infoComputerName.Length);
                    byte[] infoUserName = new UTF8Encoding(true).GetBytes($"Username: {_userName}\n");
                    fs.Write(infoUserName, 0, infoUserName.Length);
                    byte[] infoPassword = new UTF8Encoding(true).GetBytes($"Password: {_password}");
                    fs.Write(infoPassword, 0, infoPassword.Length);
                }

                Console.Write("No errors.");
                #endregion
            }
        }

        public class MiscrosoftManagementInfrastructure
        {
            public class ConnectionInstance
            {
                public CimSession Session { get; private set; }
                public ConnectionInstance(string? domainName, string? computer, string? username, string? unsecurePassword)
                {
                    unsecurePassword = unsecurePassword == null ? string.Empty : unsecurePassword;
                    var securePassword = new SecureString();
                    foreach (char c in unsecurePassword)
                        securePassword.AppendChar(c);

                    unsecurePassword = String.Empty;

                    // Create instance of credential.
                    var Credential = new CimCredential(
                            PasswordAuthenticationMechanism.Default,
                            domainName,
                            username,
                            securePassword
                        );

                    // Create session options.
                    WSManSessionOptions sessionOptions = new WSManSessionOptions();
                    sessionOptions.AddDestinationCredentials(Credential);
                    Session = CimSession.Create(computer, sessionOptions);
                }
            }
            public class Remoting
            {
                public static IEnumerable<CimInstance>? Query(
                            string? domainName,
                            string? computer,
                            string? username,
                            string? unsecurePassword,
                            string? className,
                            string? locale = "root",
                            string? nameSpace = "cimv2"
                            )
                {
                    try
                    {
                        var connection = new ConnectionInstance(
                                               domainName,
                                               computer,
                                               username,
                                               unsecurePassword
                                           );
                        var collection = connection.Session.QueryInstances($@"{locale}\{nameSpace}", "WQL", $"SELECT * FROM {className}");
                        return collection;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }

                }
            }
        }

        public class SystemManagement
        {
            private class ConnectionInstance
            {

                public ManagementScope? Scope { get; private set; }
                public ConnectionInstance(
                    string? domain,
                    string? computer,
                    string? username,
                    string? unsecurePassword,
                    string? classNameSpace
                )
                {
                    try
                    {
                        if (unsecurePassword == null)
                            unsecurePassword = string.Empty;

                        var securePassword = new SecureString();
                        foreach (char c in unsecurePassword)
                            securePassword.AppendChar(c);

                        unsecurePassword = string.Empty;

                        // INFO Initialize ConnectionOptions.
                        var connectionOptions = new ConnectionOptions();
                        connectionOptions.Username = username;
                        connectionOptions.SecurePassword = securePassword;
                        connectionOptions.Authority = $"NTLMDOMAIN:{domain}";
                        connectionOptions.Locale = "ms_409";
                        //connectionOptions.Authentication = AuthenticationLevel.Connect;
                        //connectionOptions.Impersonation = ImpersonationLevel.Impersonate;

                        // INFO Initialize ManagementScope.
                        Scope = new ManagementScope(
                             $"\\\\{computer}\\root\\{classNameSpace}", connectionOptions
                        );
                        Scope.Connect();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                }
            }

            public class Remoting
            {
                public static async Task<ManagementObjectCollection?> QueryCollection(
                               string? domainName,
                               string? computer,
                               string? username,
                               string? unsecurePassword,
                               string? className,
                               string classNameSpace = "cimv2" // Namespaces available are 'cimv2' and 'wmi'
                           )
                {

                    try
                    {
                        var conn = new ConnectionInstance(
                                              domainName,
                                              computer,
                                              username,
                                              unsecurePassword,
                                              classNameSpace
                                          );
                        var query = new ObjectQuery($"SELECT * FROM {className}");

                        using (var searcher = new ManagementObjectSearcher(conn.Scope, query))
                        {
                            return await Task.Run(() => { return searcher.Get(); });
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return null;
                    }
                }


                public static async Task<ManagementBaseObject?> Query(
                            string? domainName,
                            string? computer,
                            string? username,
                            string? unsecurePassword,
                            string? className,
                            string classNameSpace = "cimv2" // Namespaces available are 'cimv2' and 'wmi'
                        )
                {

                    var conn = new ConnectionInstance(
                                            domainName,
                                            computer,
                                            username,
                                            unsecurePassword,
                                            classNameSpace
                                        );
                    var query = new ObjectQuery($"SELECT * FROM {className}");

                    using (var searcher = new ManagementObjectSearcher(conn.Scope, query))
                    {
                        var collection = searcher.Get();
                        foreach (var obj in collection)
                        {
                            return await Task.Run(() => { return ((ManagementBaseObject)obj); });
                        }
                    }
                    return null;

                }

                public static async Task<bool> Update(
                    string? domainName,
                    string? computer,
                    string? username,
                    string? unsecurePassword,
                    string? className,
                    string? propertyName,
                    string? newPropertyValue
                )
                {
                    try
                    {
                        var queryObj = (ManagementObject)await Query(
                            domainName,
                            computer,
                            username,
                            unsecurePassword,
                            className
                        );

                        if (propertyName == null)
                            return false;

                        if (newPropertyValue == null)
                            return false;

                        if (queryObj == null)
                            return false;

                        queryObj[propertyName] = newPropertyValue;
                        queryObj.Put();
                        return true;
                    }
                    catch (ManagementException)
                    {
                        return false;
                    }
                }
            }
        }
    }


}
