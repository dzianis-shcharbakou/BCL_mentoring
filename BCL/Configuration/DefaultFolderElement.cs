using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace BCL.Configuration
{
    public class DefaultFolderElement : ConfigurationElement
    {
        [ConfigurationProperty("path", IsKey = true, IsRequired = true)]
        public DirectoryInfo DefaultFolder
        {
            get { return (DirectoryInfo)this["path"]; }
        }
    }
}
