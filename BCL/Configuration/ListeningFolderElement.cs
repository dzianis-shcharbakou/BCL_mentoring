using BCL.Configuration.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Text;

namespace BCL.Configuration
{
    public class ListeningFolderElement : ConfigurationElement
    {
        [TypeConverter(typeof(DirectoryInfoTypeConverter))]
        [ConfigurationProperty("path", IsKey = true, IsRequired = true)]
        public DirectoryInfo Path
        {
            get 
            {
         
                return (DirectoryInfo)this["path"];
            }
        }
    }
}
