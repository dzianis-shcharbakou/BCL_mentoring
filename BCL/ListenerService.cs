using BCL.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BCL
{
    public class ListenerService
    {
        private readonly ListeningFolderElementCollection listeningFolders;
        private readonly RuleElementCollection rules;
        private readonly DefaultFolderElement defaultFolder;

        public event EventHandler<MessageEventArgs> RuleExist;
        public event EventHandler<MessageEventArgs> RuleNotExist;
        public event EventHandler<MessageEventArgs> FileMoved;
        public event EventHandler<FileSystemEventArgs> FileAppeared;
        public event EventHandler<MessageEventArgs> ListeningFolder;

        public ListenerService(ListeningFolderElementCollection listeningFolders, RuleElementCollection rules, DefaultFolderElement defaultFolder)
        {
            this.listeningFolders = listeningFolders;
            this.rules = rules;
            this.defaultFolder = defaultFolder;
        }

        public List<FileSystemWatcher> ListenFolders()
        {
            var watcherList = new List<FileSystemWatcher>();

            foreach (ListeningFolderElement listeningFolder in listeningFolders)
            {
                var watcher = this.ListenFolder(listeningFolder.Path);

                watcherList.Add(watcher);
            }

            return watcherList;
        }

        public void MoveFile(string name, string fullPath)
        {
            var rule = CheckFileRules(name);
            if (EqualityComparer<RuleElement>.Default.Equals(rule, default(RuleElement)))
            {
                MoveToDefault(name, fullPath);
            }
            else
            {
                MoveWithRule(name, fullPath, rule);
            }
        }

        private FileSystemWatcher ListenFolder(DirectoryInfo directory)
        {
            var watcher = new FileSystemWatcher
            {
                Path = directory.FullName,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime
            };
            watcher.Created += OnFileAppear;
            watcher.IncludeSubdirectories = false;
            watcher.EnableRaisingEvents = true;

            OnListeningFolder(new MessageEventArgs { Message = string.Format(Resources.Resource.FolderListening, directory.FullName) });
            return watcher;
        }

        private void MoveWithRule(string name, string fullPath, RuleElement rule)
        {
            StringBuilder fileNameResult = new StringBuilder();

            if (rule.IsIndexNumber)
            {
                int countOfElementsInDirectory = Directory.GetDirectories(rule.OutputFolder.FullName).Length;
                fileNameResult.Append(++countOfElementsInDirectory);
                fileNameResult.Append("_");
            }

            if (rule.IsRelocationDate)
            {
                fileNameResult.Append(DateTime.Now.ToString("dd.MM.yyyy_HH.mm"));
                fileNameResult.Append("_");
            }
            
            fileNameResult.Append(name);

            var pathResult = Path.Combine(rule.OutputFolder.FullName, fileNameResult.ToString());

            File.Move(fullPath,
                pathResult);

            OnFileMoved(new MessageEventArgs { Message = string.Format(Resources.Resource.FileMoved, rule.OutputFolder.FullName) });
        }

        private void MoveToDefault(string name, string fullPath)
        {
            File.Move(fullPath, 
                Path.Combine(defaultFolder.DefaultFolder.FullName, name));

            OnFileMoved(new MessageEventArgs { Message = string.Format(Resources.Resource.FileMovedDefaultFolder, defaultFolder.DefaultFolder.FullName)});
        }

        private RuleElement CheckFileRules(string appearedFileName)
        {
            foreach (RuleElement rule in rules)
            {
                if (rule.FileNameMask.IsMatch(appearedFileName))
                {
                    OnRuleExist(new MessageEventArgs { Message = string.Format(Resources.Resource.RuleExist, appearedFileName) });
                    return rule;
                }
            }

            OnRuleNotExist(new MessageEventArgs { Message = string.Format(Resources.Resource.RuleNotExist, appearedFileName) });
            return default(RuleElement);
        }

        #region Event methods
        protected void OnFileAppear(object sender, FileSystemEventArgs args)
        {
            var tmp = RuleExist;
            if (tmp != null)
                FileAppeared(this, args);
        }

        protected void OnListeningFolder(MessageEventArgs args)
        {
            var tmp = RuleExist;
            if (tmp != null)
                ListeningFolder(this, args);
        }

        protected void OnRuleExist(MessageEventArgs args)
        {
            var tmp = RuleExist;
            if (tmp != null)
                RuleExist(this, args);
        }

        protected void OnRuleNotExist(MessageEventArgs args)
        {
            var tmp = RuleNotExist;
            if (tmp != null)
                RuleNotExist(this, args);
        }

        protected void OnFileMoved(MessageEventArgs args)
        {
            var tmp = RuleNotExist;
            if (tmp != null)
                FileMoved(this, args);
        }
        #endregion
    }

    public class MessageEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
