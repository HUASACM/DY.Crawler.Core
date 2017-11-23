using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DY.Crawler.Core.Domains;
using DY.Crawler.Domains;
using DY.Crawler.Domains.enums;

namespace DY.Crawler.Core.Speces
{
    public static class 自定义任务字段
    {
        public static DocumentNodeParseRule 笔下文学书名 = new DocumentNodeParseRule() { Name = "书名", AttributeName = "content", RuleValue = "/html/body/div[2]/table/tr/td[2]/div/a[1]" };
        public static DocumentNodeParseRule 笔下文学作者名 = new DocumentNodeParseRule() { Name = "作者名", AttributeName = "content", RuleValue = "/html/body/div[2]/table/tr/td[2]/div/span[1]" };
        public static DocumentNodeParseRule 笔下文学链接 = new DocumentNodeParseRule() { Name = "链接", AttributeName = "href", RuleValue = "/html/body/div[2]/table/tr/td[1]/a" };
    }
}
