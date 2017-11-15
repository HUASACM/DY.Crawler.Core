using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using DY.Crawler.Core.Domains;
using DY.Crawler.Core.Domains.DTOs;
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
                fields.each(x => task.result(x));
            }
        }

        private IEnumerable<ResourceInfo> parse_by(HtmlDocument doc, IEnumerable<ResourceFieldDef> defs)
         {
            var infos = new List<ResourceInfo>();
            var dtos = new List<ResourceFieldDTO>();
            foreach (var resource_field_def in defs)
            {
                dtos.Add(new ResourceFieldDTO()
                         {
                             Def = resource_field_def,
                             Nodes = doc.DocumentNode.SelectNodes(resource_field_def.Rule.Value)
                         });
            }
            var min_fields = dtos.Min(x => x.Nodes.Count);
            for (int i = 0; i < min_fields; i++)
            {
                var info = new ResourceInfo();
                foreach (var dto in dtos)
                {
                    var node = dto.Nodes.ElementAt(i);
                    var field = new CustomField() { Identifier = Guid.NewGuid() };
                    field.FieldDef = dto.Def;
                    field.Name = dto.Def.FieldDef.Name;
                    if (dto.Def.AttributeName == "content")
                        field.Value = node.InnerHtml;
                    else
                        field.Value = node.GetAttributeValue(dto.Def.AttributeName, "");
                    info.field(field);
                }
                infos.Add(info);
            }
            return infos;
        }
    }
}
