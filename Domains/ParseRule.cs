using System;
using DY.Crawler.Domains.interfaces;

namespace DY.Crawler.Domains
{
    public class ParseRule : Aggregate, Nameable, Valueable
    {
        public virtual Guid Identifier { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }

        public virtual void rule(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}