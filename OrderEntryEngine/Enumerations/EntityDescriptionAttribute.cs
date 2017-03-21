using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EntityDescriptionAttribute : Attribute
    {
        public EntityDescriptionAttribute(string description)
        {
            this.Description = description;
        }

        public string Description { get; private set; }
    }
}
