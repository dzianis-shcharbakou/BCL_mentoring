using BCL.Configuration.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace BCL.Configuration
{
    public class RuleElement : ConfigurationElement
    {
        [TypeConverter(typeof(DirectoryInfoTypeConverter))]
        [ConfigurationProperty("outputFolder", IsKey = true, IsRequired = true)]
        public DirectoryInfo OutputFolder
        {
            get { return (DirectoryInfo)this["outputFolder"]; }
        }

        [TypeConverter(typeof(RegexTypeConverter))]
        [ConfigurationProperty("fileNameMask", IsRequired = true, IsKey = false)]
        public Regex FileNameMask
        {
            get { return (Regex)this["fileNameMask"]; }
        }

        [ConfigurationProperty("isIndexNumber", DefaultValue = true)]
        public bool IsIndexNumber
        {
            get { return (bool)this["isIndexNumber"]; }
        }

        [ConfigurationProperty("isRelocationDate", DefaultValue = true)]
        public bool IsRelocationDate
        {
            get { return (bool)this["isRelocationDate"]; }
        }
    }
}
