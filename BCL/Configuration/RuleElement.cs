using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BCL.Configuration
{
    public class RuleElement : ConfigurationElement
    {
        //[ConfigurationProperty("name", IsKey = true)]
        //public string RuleName
        //{
        //    get { return (string)this["name"]; }
        //}

        [ConfigurationProperty("outputFolder")]
        public string OutputFolder
        {
            get { return (string)this["outputFolder"]; }
        }

        [ConfigurationProperty("outputFileParam")]
        public string OutputFileParam
        {
            get { return (string)this["outputFileParam"]; }
        }

        //[ConfigurationProperty("fileNameTemplate", IsRequired = false)]
        //[RegexStringValidator()]
        //public string FileNameTemplate
        //{
        //    get { }
        //}
    }
}
