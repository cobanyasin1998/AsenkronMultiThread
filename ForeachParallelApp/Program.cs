using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ForeachParallelApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();


            string picturePath = @"D:\Kisisel\Projeler\AsenkronMultiThread\ForeachParallelApp\img";

            var files = Directory.GetFiles(picturePath);

            Parallel.ForEach(files, (item) =>
            {
                Console.WriteLine("thread no: " + Thread.CurrentThread.ManagedThreadId);

                Image img = new Bitmap(item);

                var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

                thumbnail.Save(Path.Combine(picturePath, "thumbail", Path.GetFileName(item)));
            });



            sw.Stop();

            Console.WriteLine("İşlem Bitti :" + sw.ElapsedMilliseconds);

            sw.Reset();

            Stopwatch sw_2 = new Stopwatch();

            files.ToList().ForEach(x =>
            {
                Console.WriteLine("thread no: " + Thread.CurrentThread.ManagedThreadId);

                Image img = new Bitmap(x);

                var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

                thumbnail.Save(Path.Combine(picturePath, "thumbail", Path.GetFileName(x)));

            });

            sw_2.Stop();
            Console.WriteLine("İşlem Bitti :" + sw_2.ElapsedMilliseconds);

        }
    }
}
