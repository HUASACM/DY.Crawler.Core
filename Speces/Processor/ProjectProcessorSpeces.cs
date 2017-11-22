using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DY.Crawler.Core.Application.Core.Processors;
using DY.Crawler.Core.Domains;
using DY.Crawler.Domains;
using Machine.Specifications;

namespace DY.Crawler.Core.Speces.Processor
{
    public class ProjectProcessorSpeces
    {
        private Establish that =
            () =>
            {
                subject = new ProjectProcessor();
                project = new DProject();
                project.UrlTemplate = new DUrlTemplate()
                                      {
                                          DataBag = new TemplateDataBag() { Key = "{page}", MinValue = 0, MaxValue = 19 },
                                          Url = "http://xx.cn?page={page}",
                                      };
            };

        private Because of =
            () =>
            {
                subject.run(project);
            };

        private It 应该生成20个任务 =
            () =>
            {
                project.Tasks.Count().ShouldEqual(20);
            };
        private static ProjectProcessor subject;
        private static DProject project;
    }
}
