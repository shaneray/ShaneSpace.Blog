using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Raven.Client;
using Raven.Client.Document;

namespace ShaneSpace.Blog.DataImport
{
    public class BlogEntry
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
    }

    public static class Extension
    {
        public static IEnumerable<T> GetAllResults<T>(this IDocumentSession session)
        {
            int skip = 0;
            var results = new List<T>();
            var query = session.Query<T>();
            var totalCount = query.Count();
            while (skip < totalCount)
            {
                results.AddRange(query.Skip(skip).Take(1024).ToList());
                skip += 1024;
            }
            return results;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var blogDocumentStore = new DocumentStore
            {
                Url = "https://diver.ravenhq.com/databases/ShanesSpot-ShanesSpot",
                ApiKey = "1337dc28-7d1c-44a3-ba8a-4f5619f6df9f"
            };
            blogDocumentStore.Initialize();
            var ravenSession = blogDocumentStore.OpenSession();

            // get results
            var dbResult = ravenSession.GetAllResults<BlogEntry>().Take(1000).ToList();
            foreach (var blogEntry in dbResult)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Title: {blogEntry.Title.Replace(":", string.Empty)}");
                sb.AppendLine($"Published: {blogEntry.DateTime}");
                sb.AppendLine("Tags:");
                sb.AppendLine("- re-blog");
                sb.AppendLine("---");

                if (!string.IsNullOrWhiteSpace(blogEntry.Link))
                {
                    sb.AppendLine($"Source: {blogEntry.Link}");
                }

                sb.AppendLine($"{blogEntry.Body}");

                string fileName = $"{Regex.Replace(blogEntry.Title.Replace(" ", "-"), "[^a-zA-Z0-9-]", string.Empty)}.md";
                var fullPath = $"C:\\repo\\test\\input\\posts\\imported\\{fileName}";
                File.WriteAllText(fullPath, sb.ToString());
                Console.WriteLine($"wrote {fileName}");
            }
            Console.WriteLine(dbResult.Count);
            Console.ReadKey();
        }
    }
}
