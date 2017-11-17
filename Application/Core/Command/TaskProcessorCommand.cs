using DY.Crawler.Domains;

namespace DY.Crawler.Core.Application.Core.Command
{
    public interface TaskProcessorCommand
    {
        void run(DTask task);
    }
}