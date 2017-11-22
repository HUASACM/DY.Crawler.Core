using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DY.Crawler.Core.Domains.Extensions
{
    public static class DUrlTemplateExtensions
    {
        public static bool empty(this DUrlTemplate source)
        {
            return string.IsNullOrEmpty(source.Url);
        }

        public static IEnumerable<Task> generate(this DUrlTemplate source)
        {
            var data_bag = source.DataBag;
            var url = source.Url;
            return null;
        }
    }
}
