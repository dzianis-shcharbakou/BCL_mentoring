﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace BCL.Configuration
{
    public class ListeningFolderElement : ConfigurationElement
    {
        // change type
        [ConfigurationProperty("path", DefaultValue = "", IsKey = true, IsRequired = true)]
        public DirectoryInfo Path
        {
            get { return (DirectoryInfo)this["path"]; }
        }
    }
}
