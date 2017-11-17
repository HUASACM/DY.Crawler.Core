using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using DY.Crawler.Core.Application.Core.Command;
using DY.Crawler.Core.Application.Core.DataAnalysis;
using DY.Crawler.Core.Domains;
using DY.Crawler.Core.Domains.Extensions;
using DY.Crawler.Domains;
using HtmlAgilityPack;

namespace DY.Crawler.Core.Application.Core.Processors
{
    public class TaskProcessor : TaskProcessorCommand
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

                var fields = parse_by(content, task.ResultDefs);
                fields.each(x => task.result(x));
            }
        }

        private IEnumerable<ResourceInfo> parse_by(string content, IEnumerable<ResourceFieldDef> defs)
         {
             var dtos = new ResourceFieldDefAnalysis().on(content).parse(defs);
             var min_fields = dtos.Min(x => x.Nodes.Count);
             return new ResourceFieldDTOAnalysis().on(min_fields).parse(dtos);
         }
    }
}
