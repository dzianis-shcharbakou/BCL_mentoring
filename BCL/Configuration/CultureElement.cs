using BCL.Configuration.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Text;

namespace BCL.Configuration
{
    public class CultureElement : ConfigurationElement
    {
        [TypeConverter(typeof(CultureInfoTypeConverter))]
        [ConfigurationProperty("name", DefaultValue = "ru-Ru", IsKey = true, IsRequired = true)]
        public CultureInfo Culture
        {
            get { return  (CultureInfo)this["name"]; }
        }
    }
}
