using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DY.Crawler.Core.Domains;
using DY.Crawler.Core.Domains.Extensions;
using DY.Crawler.Domains.Enums;
using DY.Crawler.Domains.interfaces;
using DY.Crawler.Domains.Interfaces;
using Machine.Specifications.Sdk;

namespace DY.Crawler.Domains
{
    public class DTask : Aggregate, Nameable, Taskable, Recordable, Projectable, Phaseable
    {
        public DTask()
        {
            rules = new List<DocumentNodeParseRule>();
            results = new List<ResourceInfo>();
            sources = new List<ResourceInfo>();    
            uris = new List<string>();
        }

        private IList<DocumentNodeParseRule> rules { get; set; }
        private IList<string> uris { get; set; }
        private IList<ResourceInfo> results { get; set; }
        private IList<ResourceInfo> sources { get; set; }
        public virtual Guid Identifier { get; set; }
        public virtual string Name { get; set; }
        public virtual Guid TaskIdentifier { get; protected set; }
        public virtual Guid ProjectIdentifier { get; protected set; }
        public virtual DateTime RecordTime { get; set; }
        public virtual int Level { get; set; }
        public virtual string Host { get; set; }
        public virtual Phase Phase { set; get; }
        public virtual Account Account { get; set; }

        public virtual IEnumerable<string> Uris
        {
            get { return uris; }
        }

        public virtual IEnumerable<DocumentNodeParseRule> Rules
        {
            get { return rules; }
        }

        public virtual IEnumerable<ResourceInfo> Sources
        {
            get { return sources; }
        }

        public virtual IEnumerable<ResourceInfo> Results
        {
            get { return results; }
        }


        public virtual DTask init(string url)
        {
            uris.Add(url);
            return this;
        }
        public virtual DTask source(ResourceInfo info)
        {
            info.task_by(Identifier);
            sources.Add(info);
            return this;
        }

        public virtual DTask result(ResourceInfo info)
        {
            info.task_by(Identifier);
            results.Add(info);
            return this;
        }

        public virtual DTask def(DocumentNodeParseRule def)
        {
            rules.Add(def);
            return this;
        }

        public virtual void task_by(Guid task_identifier)
        {
            TaskIdentifier = task_identifier;
        }

        public virtual void project_by(Guid project_identifier)
        {
            ProjectIdentifier = project_identifier;
        }

        public DTask add_result_range(IEnumerable<ResourceInfo> list)
        {
            list.each(results.Add);
            return this;
        }
    }
}
