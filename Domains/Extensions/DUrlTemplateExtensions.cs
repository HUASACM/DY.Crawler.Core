using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DY.Crawler.Domains;

namespace DY.Crawler.Core.Domains.Extensions
{
    public static class DUrlTemplateExtensions
    {
        public static bool empty(this DUrlTemplate source)
        {
            return string.IsNullOrEmpty(source.Url);
        }

        public static IEnumerable<DTask> generate(this DUrlTemplate source)
        {
            var data_bag = source.DataBag;
            var url = source.Url;
            return data_bag.MinValue
                           .to(data_bag.MaxValue)
                           .Select(x => url.Replace(data_bag.Key, x.ToString()))
                           .Select(x =>
                                   {
                                       return new CustomField()
                                              {
                                                  Name = "Url",
                                                  Value = x
                                              };
                                   })
                           .Select(x => new ResourceInfo().field(x))
                           .Select(x => new DTask().source(x));
        }
    }
}
