using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BCL.Configuration
{
    public class ListeningFolderElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ListeningFolderElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ListeningFolderElement)element).Path;
        }
    }
}
