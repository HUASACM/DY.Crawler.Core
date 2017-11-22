using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DY.Crawler.Domains;

namespace DY.Crawler.Core.Domains.Extensions
{
    public static class ResourceInfoExtensions
    {
        public static string get_content(this ResourceInfo source, HttpClient client)
        {
            return client.GetStringAsync(source.Fields.First(x => x.Name == "Url").Value).Result;
        }
    }
}
