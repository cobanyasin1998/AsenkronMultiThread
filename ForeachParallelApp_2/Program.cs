using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ForeachParallelApp_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long filesByte = 0;

            Stopwatch sw = new Stopwatch();

            sw.Start();

            string picturePath = @"D:\Kisisel\Projeler\AsenkronMultiThread\ForeachParallelApp\img";

            var files = Directory.GetFiles(picturePath);

            Parallel.ForEach(files, (item) =>
            {
                Console.WriteLine("thread no: " + Thread.CurrentThread.ManagedThreadId);
                FileInfo f = new FileInfo(item);
                Interlocked.Add(ref filesByte, f.Length);
            });

            Console.WriteLine("Toplam Boyut: " + filesByte.ToString());


            sw.Stop();
        }
    }
}
