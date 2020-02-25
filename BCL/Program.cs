using BCL.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading;

namespace BCL
{
    class Program
    {
        static void Main(string[] args)
        {
            var section = (BclConfigurationSection)ConfigurationManager.GetSection("bclSection");
            Thread.CurrentThread.CurrentUICulture = section.Culture.Culture;

            var listeningFolders = section.ListeningFolders;
            //DirectoryInfo f = new DirectoryInfo("");
            //f.EnumerateFileSystemInfos("*.*", SearchOption.TopDirectoryOnly);

            var watcherList = new List<FileSystemWatcher>();

            foreach(ListeningFolderElement listeningFolder in listeningFolders)
            {
                var watcher = new FileSystemWatcher();
                watcher.Path = listeningFolder.Path.FullName;
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime;
                watcher.Changed += OnChanged;
                watcher.Filter = "*.txt";
                watcher.EnableRaisingEvents = true;

                watcherList.Add(watcher);
            }
            
            while (true)
            {

            }
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {

        }
    }
}
