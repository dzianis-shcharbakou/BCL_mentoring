using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BCL.Configuration
{
    public class CultureElement : ConfigurationElement
    {
        // change type
        [ConfigurationProperty("name")]
        public string Culture
        {
            get { return (string)this["name"]; }
        }
    }
}
