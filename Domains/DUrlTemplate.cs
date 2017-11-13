using System;
using System.Collections.Generic;
using DY.Crawler.Domains.interfaces;

namespace DY.Crawler.Core.Domains
{
    public class DUrlTemplate : Aggregate
    {
        private IList<TemplateDataBag> databags { get; set; }
        public virtual Guid Identifier { get; set; }
        public virtual string Url { get; set; }

        public virtual IEnumerable<TemplateDataBag> DataBags
        {
            get { return databags; }
        }

        public virtual void data_bag(TemplateDataBag data_bag)
        {
            databags.Add(data_bag);
        }
    }
}