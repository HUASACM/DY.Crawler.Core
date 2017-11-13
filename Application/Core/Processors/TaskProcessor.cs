using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using DY.Crawler.Core.Domains;
using DY.Crawler.Core.Domains.Extensions;
using DY.Crawler.Domains;
using HtmlAgilityPack;

namespace DY.Crawler.Core.Application.Core.Processors
{
    public class TaskProcessor
    {
        private HttpClient client;

        public TaskProcessor()
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            client = new HttpClient(handler);
        }
        public void run(DTask task)
        {
            foreach (var resource_info in task.Sources)
            {
                var url = resource_info.Fields.First(x => x.Name == "Url").Value;
                var content = client.GetStringAsync(url).Result;

                var doc = new HtmlDocument();
                doc.LoadHtml(content);

                var fields = parse_by(doc, task.ResultDefs);
            }
        }

        private IEnumerable<ResourceInfo> parse_by(HtmlDocument doc, IEnumerable<ResourceFieldDef> defs)
        {
            var infos = new List<ResourceInfo>();
            foreach (var resource_field_def in defs)
            {
                resource_field_def.Nodes = doc.DocumentNode.SelectNodes(resource_field_def.Rule.Value);
            }
            var min_def = defs.Min(x => x.Nodes.Count);
            for (int i = 0; i < min_def; i++)
            {
                var info = new ResourceInfo();
            }
            return infos;
        }
    }
}
