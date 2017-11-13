using System.Collections.Generic;
using DY.Crawler.Domains;
using DY.Crawler.Domains.interfaces;
using HtmlAgilityPack;

namespace DY.Crawler.Core.Domains
{
    public class ResourceFieldDef
    {
        public virtual CustomFieldDef FieldDef { get; set; }
        public virtual ParseRule Rule { get; set; }
        public virtual HtmlNodeCollection Nodes { get; set; }
    }
}