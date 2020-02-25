using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BCL.Configuration
{
    class BclConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("culture")]
        public CultureElement Culture 
        {
            get { return (CultureElement)base["culture"];  } 
        }

        [ConfigurationProperty("defaultFolder")]
        public DefaultFolderElement DefaultFolder
        {
            get { return (DefaultFolderElement)base["defaultFolder"]; }
        }

        [ConfigurationProperty("listeningFolders")]
        public ListeningFolderElementCollection ListeningFolders
        {
            get { return (ListeningFolderElementCollection)base["listeningFolders"]; }
        }

        [ConfigurationProperty("rules")]
        public RuleElementCollection Rules
        {
            get { return (RuleElementCollection)base["rules"]; }
        }
    }
}
