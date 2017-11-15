using System.Collections.Generic;
using System.Linq;
using DY.Crawler.Core.Application.Core.Processors;
using DY.Crawler.Domains;
using Machine.Specifications;

namespace DY.Crawler.Core.Speces.Processor
{
    public class TaskProcessorSpeces
    {
        private Establish context =
            () =>
            {
                subject = new TaskProcessor();

                base_field = new CustomField() { FieldDef = 自定义任务字段.笔下文学链接, Name = "Url", Value = "http://m.bxwx9.org/modules/article/waplist.php?fullflag=1&page=1" };

                source_info = new ResourceInfo();
                source_info.field(base_field);

                task = new DTask();
                task.def(自定义任务字段.笔下文学书名);
                task.def(自定义任务字段.笔下文学作者名);
                task.def(自定义任务字段.笔下文学链接);
                task.source(source_info);
            };

        private Because of =
            () =>
            {
                subject.run(task);
            };

        private It 应该采集二十个资源 =
            () =>
            {
                task.Results.Count().ShouldEqual(20);
            };

        private static TaskProcessor subject;
        private static DTask task;
        private static ResourceInfo source_info;
        private static CustomField base_field;
    }
}
