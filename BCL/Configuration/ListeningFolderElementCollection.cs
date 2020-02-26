using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BCL.Configuration
{
    [ConfigurationCollection(typeof(ListeningFolderElement), AddItemName = "folder")]
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

        //public ListeningFolderElement this[int idx]
        //{
        //    get { return (ListeningFolderElement)BaseGet(idx); }
        //}
    }
}
