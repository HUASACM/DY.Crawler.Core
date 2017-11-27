using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DY.Crawler.Core.Domains;
using HtmlAgilityPack;
using Machine.Specifications;

namespace DY.Crawler.Core.Speces.Domains
{
    public class AccountSpeces
    {
        private Establish that =
            () =>
            {
                client = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip });
                subject = new Account();
                subject.add_data(new AccountData() { Name = "username", Value = "632075803" });
                subject.add_data(new AccountData() { Name = "userpass", Value = "Wjy18975570580" });
                subject.add_data(new AccountData() { Name = "login", Value = "Sign In" });
            };

        private Because of =
            () =>
            {
                result = subject.login(url, client);
            };

        private It 应该登录成功 =
            () =>
            {
                var document = new HtmlDocument();
                document.LoadHtml(result);
                var nodes = document.DocumentNode.SelectNodes("/html/body/table/tr[2]/td/table/tr[2]/td[5]/div/a[1]");
                nodes.Select(x => x.GetAttributeValue("href", "")).ShouldContain("/userstatus.php?user=632075803");
            };

        private static HttpClient client;
        private static string url = "http://acm.hdu.edu.cn/userloginex.php?action=login";
        private static Account subject;
        private static string result;
    }
}
