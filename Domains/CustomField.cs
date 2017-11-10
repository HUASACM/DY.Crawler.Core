using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DY.Crawler.Domains.interfaces;

namespace DY.Crawler.Domains
{
    public class CustomField : Aggregate, Nameable, Valueable
    {
        public virtual Guid Identifier { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; protected set; }
        public virtual ResourceFieldDef FieldDef { get; protected set; }

        public virtual void field_def(ResourceFieldDef def)
        {
            FieldDef = def;
        }
    }
}
