using System;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using VersionOne.ServiceHost.Core.Configuration;

namespace VersionOne.ServiceHost {
    public class Program {
        [STAThread]
        private static void Main(string[] args) {
            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            if(args.Length == 0)
                RunConsole();
            else if(args.Length != 1)
                Help();
            else if(args[0] == "--install")
                InstallService();
            else if(args[0] == "--uninstall")
                UninstallService();
            else if(args[0] == "--service")
                RunService();
            else
                Help();
        }

        private static void UninstallService() {
            try {
                try {
                    ServiceUtil.StopService(Config.ShortName);
                } catch { }

                if(ServiceUtil.UnInstallService(Config.ShortName))
                    Console.WriteLine("Service uninstall successful");
                else
                    Console.WriteLine("Service uninstall failed");
            } catch(Exception ex) {
                throw new ApplicationException("Uninstall failed - " + ex.Message);
            }
        }

        private static void InstallService() {
            try {
                if(ServiceUtil.InstallService("\"" + Assembly.GetEntryAssembly().Location + "\" --service",
                                               Config.ShortName, Config.LongName, ServiceUtil.LocalService, null)) {
                    Console.WriteLine("Service installation successful!");
                } else {
                    Console.WriteLine("Service installation failed");
                }

                try {
                    ServiceUtil.StartService(Config.ShortName);
                } catch { }
            } catch(Exception ex) {
                throw new ApplicationException("Install failed - " + ex.Message);
            }
        }

        private static void RunService() {
            ServiceBase.Run(new NtService(Config.ShortName));
        }

        private static void RunConsole() {
            new ConsoleMode().Run();
        }

        private static void Help() {
            Console.WriteLine("\t\t--install\t\tInstall Windows NT Service");
            Console.WriteLine("\t\t--uninstall\t\tUninstall Windows NT Service");
        }

        private static InstallerConfiguration config;

        private static InstallerConfiguration Config {
            get {
                return config ?? (config = (InstallerConfiguration) System.Configuration.ConfigurationManager.GetSection("Installer"));
            }
        }
    }
}