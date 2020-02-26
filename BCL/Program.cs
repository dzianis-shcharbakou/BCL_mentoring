using BCL.Configuration;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;

namespace BCL
{
    class Program
    {
        static bool cancelled;
        static ListenerService service;
        static BclConfigurationSection bclSection;

        static void Main()
        {
            Setup();

            var watcherList = service.ListenFolders();         
            
            Console.CancelKeyPress += new ConsoleCancelEventHandler(ConsoleCancelKeyPress);

            Console.WriteLine(Resources.Resource.ExitWithKeys);
            while (true)
            {
                if (cancelled) 
                {
                    foreach (var item in watcherList)
                    {
                        item.Dispose();
                    }

                    break;
                }
            }
        }

        private static void Setup()
        {
            bclSection = (BclConfigurationSection)ConfigurationManager.GetSection("bclSection");
            Thread.CurrentThread.CurrentUICulture = bclSection.Culture.Culture;
            Thread.CurrentThread.CurrentCulture = bclSection.Culture.Culture;
            Console.OutputEncoding = Encoding.UTF8;

            var listeningFolders = bclSection.ListeningFolders;
            var rules = bclSection.Rules;
            var defaultFolder = bclSection.DefaultFolder;

            service = new ListenerService(listeningFolders, rules, defaultFolder);
            service.RuleExist += ConsoleLog;
            service.RuleNotExist += ConsoleLog;
            service.ListeningFolder += ConsoleLog;
            service.FileMoved += ConsoleLog;
            service.FileAppeared += ConsoleLog;
        }

        private static void ConsoleLog(object sender, FileSystemEventArgs e)
        {
            FileInfo newFile = new FileInfo(e.FullPath);
            Console.WriteLine(string.Format(Resources.Resource.FileAppered, e.Name, newFile.CreationTime));

            service.MoveFile(e.Name, e.FullPath);
        }

        private static void ConsoleLog(object sender, MessageEventArgs e)
        {
            Console.WriteLine($"{e.Message}");
        }

        private static void ConsoleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine(Resources.Resource.Exit);
            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
            {
                cancelled = true;
                e.Cancel = true;
            }
        }
    }
}
