using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DY.Crawler.Domains.enums;
using DY.Crawler.Domains.interfaces;

namespace DY.Crawler.Domains
{
    public class CustomFieldDef : Aggregate, Nameable
    {
        private IList<CustomCode> options;
        public virtual Guid Identifier { get; set; }
        public virtual string Name { get; set; }
        public virtual CustomType Type { get; set; }
        public virtual int MaxValue { get; }
        public virtual int MinValue { get; }
        public virtual int Length { get; }

        public virtual IEnumerable<CustomCode> Options
        {
            get { return options; }
            protected set { options = new List<CustomCode>(value); }
        }

        public virtual void option(CustomCode option)
        {
            options.Add(option);
        }
    }
}
