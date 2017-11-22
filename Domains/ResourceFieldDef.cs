using System.Collections.Generic;
using DY.Crawler.Domains;
using DY.Crawler.Domains.interfaces;
using HtmlAgilityPack;

namespace DY.Crawler.Core.Domains
{
    public class ResourceFieldDef : Nameable
    {
        public virtual string AttributeName { get; set; }
        public virtual ParseRule Rule { get; set; }
        public string Name { get; set; }
    }
}