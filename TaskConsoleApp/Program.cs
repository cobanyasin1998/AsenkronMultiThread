using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskConsoleApp
{
    internal class Program
    {
        #region Contiune With
        //private async static Task Main(string[] args)
        //{
        //    var myTask = new HttpClient().GetStringAsync("https://www.google.com")
        //        .ContinueWith((data) =>
        //        {
        //            Console.WriteLine("Data Uzunluk:" + data.Result.Length);
        //        });
        //    Console.WriteLine("Arada Yapılacak İşler");

        //    await myTask;
        //}
        #endregion
        #region When All
        //When All
        //private async static Task Main(string[] args)
        //{

        //    Console.WriteLine("Main thread: " + Thread.CurrentThread.ManagedThreadId);

        //    List<string> urlsList = new List<string>()
        //    {
        //        "https://www.google.com",
        //        "https://www.microsoft.com",
        //        "https://www.amazon.com",
        //        "https://www.n11.com",
        //        "https://www.haberturk.com",
        //    };

        //    List<Task<Content>> taskList = new List<Task<Content>>();

        //    urlsList.ToList().ForEach(url =>
        //    {
        //        taskList.Add(GetContentAsync(url));
        //    });

        //    var contents = await Task.WhenAll(taskList.ToArray());
        //    contents.ToList().ForEach(content =>
        //    {
        //        Console.WriteLine($"{content.Site} Boyut: {content.Length}");
        //    });

        //    Console.ReadLine();
        //}
        //public static async Task<Content> GetContentAsync(string url)
        //{
        //    Content content = new Content();
        //    var data = await new HttpClient().GetStringAsync(url);
        //    content.Site = url;
        //    content.Length = data.Length;

        //    Console.WriteLine("GetContentAsync thread: " + Thread.CurrentThread.ManagedThreadId);
        //    return content;
        //}
        //public class Content
        //{
        //    public string Site { get; set; }
        //    public int Length { get; set; }
        //}
        #endregion
        #region When Any

        //private async static Task Main(string[] args)
        //{

        //    Console.WriteLine("Main thread: " + Thread.CurrentThread.ManagedThreadId);

        //    List<string> urlsList = new List<string>()
        //    {
        //        "https://www.google.com",
        //        "https://www.microsoft.com",
        //        "https://www.amazon.com",
        //        "https://www.n11.com",
        //        "https://www.haberturk.com",
        //    };

        //    List<Task<Content>> taskList = new List<Task<Content>>();

        //    urlsList.ToList().ForEach(url =>
        //    {
        //        taskList.Add(GetContentAsync(url));
        //    });

        //    var content = await Task.WhenAny(taskList.ToArray()).Result;

        //        Console.WriteLine($"{content.Site} Boyut: {content.Length}");


        //    Console.ReadLine();
        //}
        //public static async Task<Content> GetContentAsync(string url)
        //{
        //    Content content = new Content();
        //    var data = await new HttpClient().GetStringAsync(url);
        //    content.Site = url;
        //    content.Length = data.Length;

        //    Console.WriteLine("GetContentAsync thread: " + Thread.CurrentThread.ManagedThreadId);
        //    return content;
        //}
        //public class Content
        //{
        //    public string Site { get; set; }
        //    public int Length { get; set; }
        //}
        #endregion

        //Wait All/Wait Any --> Main Thread' i bloklar.
        //Thread.Sleep() --> Main Thread'i geciktirir.
        //Delay -> Bulunduğu Thread'de geciktirme sağlar. Ana Thread' i bloklamaz


        #region Task Run StartsWith
        //public class Status
        //{
        //    public int threadId { get; set; }
        //    public DateTime date { get; set; }
        //}
        //private async static Task Main(string[] args)
        //{
        //    var myTask = Task.Factory.StartNew((obj) =>
        //    {
        //        Console.WriteLine("My Task Çalıştı");
        //        var status = obj as Status;
        //        status.threadId = Thread.CurrentThread.ManagedThreadId; 

        //    }, new Status() { date = DateTime.Now });

        //    await myTask;

        //    Status s = myTask.AsyncState as Status;
        //    Console.WriteLine(s.date);
        //    Console.WriteLine(s.threadId);
        //}
        #endregion

        #region FromResult

        //public static string CacheData { get; set; }

        //public async static Task Main(string[] args)
        //{

        //    CacheData = await GetDataAsync();

        //    Console.WriteLine(CacheData);

        //}
        //public static Task<string> GetDataAsync()
        //{
        //    if (String.IsNullOrEmpty(CacheData))
        //    {
        //        return File.ReadAllTextAsync("dosya.txt");
        //    }
        //    else
        //    {
        //        return Task.FromResult<string>(CacheData);
        //    }
        //}

        #endregion

        #region Task Result
        private async static Task Main(string[] args)
        {
           Console.WriteLine(GetData());    
        }
        public static string GetData()
        {
            var task = new HttpClient().GetStringAsync("https://www.google.com");
           return task.Result;
        }
        #endregion
    }
}
