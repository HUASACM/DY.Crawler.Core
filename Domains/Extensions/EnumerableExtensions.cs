using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DY.Crawler.Core.Domains.Extensions
{
    public static class EnumerableExtensions
    {
        public static void each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (T item in items)
            {
                action(item);
            }
        }

        public static IEnumerable<int> to(this int start, int end)
        {
            for (int i = start; i <= end; i++) yield return i;
        }

        public static string get_content(this string url, HttpClient client)
        {
            return client.GetStringAsync(url).Result;
        }
    }
}
