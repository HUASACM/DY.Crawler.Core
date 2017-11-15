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
        public static ResourceFieldDef 笔下文学书名 = new ResourceFieldDef() { FieldDef = 自定义基本字段.书名, AttributeName = "content", Rule = new ParseRule() { Value = "/html/body/div[2]/table/tr/td[2]/div/a[1]" } };
        public static ResourceFieldDef 笔下文学作者名 = new ResourceFieldDef() { FieldDef = 自定义基本字段.作者名, AttributeName = "content", Rule = new ParseRule() { Value = "/html/body/div[2]/table/tr/td[2]/div/span[1]" } };
        public static ResourceFieldDef 笔下文学链接 = new ResourceFieldDef() { FieldDef = 自定义基本字段.链接, AttributeName = "href", Rule = new ParseRule() { Value = "/html/body/div[2]/table/tr/td[1]/a" } };
    }

    public static class 自定义基本字段
    {
        public static CustomFieldDef 书名 = new CustomFieldDef() {Name = "书名", Type = CustomType.Data};
        public static CustomFieldDef 作者名 = new CustomFieldDef() {Name = "作者名", Type = CustomType.Data};
        public static CustomFieldDef 链接 = new CustomFieldDef() {Name = "链接", Type = CustomType.Data};
    }
}
