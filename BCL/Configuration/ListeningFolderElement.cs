using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BCL.Configuration
{
    class ListeningFolderElement : ConfigurationElement
    {
        // change type
        [ConfigurationProperty("path", IsKey = true)]
        public string Path
        {
            get { return (string)this["path"]; }
        }
    }
}
