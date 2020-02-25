using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Text;

namespace BCL.Configuration
{
    public class CultureElement : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "ru-Ru", IsKey = true, IsRequired = true)]
        [RegexStringValidator(@"\D{2}-\D{2}")]
        public CultureInfo Culture
        {
            //get { return new CultureInfo((string)this["name"]); }
            get { return  (CultureInfo)this["name"]; }
        }
    }
}
