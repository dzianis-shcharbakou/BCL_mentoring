using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BCL.Configuration
{
    class RuleElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new RuleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RuleElement)element).RuleName;
        }
    }
}
