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

                task = new DTask();
                task.def(自定义任务字段.笔下文学书名);
                task.def(自定义任务字段.笔下文学作者名);
                task.def(自定义任务字段.笔下文学链接);

                task.Host = "http://m.bxwx9.org/";
                task.init("modules/article/waplist.php?fullflag=1&page=1");
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
    }
}
