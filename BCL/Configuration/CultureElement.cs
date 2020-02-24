using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BCL.Configuration
{
    public class CultureElement : ConfigurationElement
    {
        [ConfigurationProperty("culture")]
        public string Culture
        {
            get { return (string)this["culture"]; }
        }
    }
}
