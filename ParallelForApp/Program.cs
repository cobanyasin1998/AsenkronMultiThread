using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelForApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long totalByte = 0;
            string picturePath = @"D:\Kisisel\Projeler\AsenkronMultiThread\ForeachParallelApp\img";

            var files = Directory.GetFiles(picturePath);

            Parallel.For(0, files.Length, (index) =>
            {
                var file = new FileInfo(files[index]);
                Interlocked.Add(ref totalByte, file.Length);

            });
            Console.WriteLine("Total Byte: " + totalByte.ToString());


            int total = 0;

            Parallel.ForEach(Enumerable.Range(0, 100).ToList(), () => 0, (x, loop, subtotal) =>
            {
                subtotal += x;
                return subtotal;

            }, (y) => Interlocked.Add(ref total, y));

            Console.WriteLine("Total: " + total);

            total = 0;

            Parallel.For(0, 100, () => 0, (x, loop, subtotal) => {
                subtotal += x;
                return subtotal;

            }, (y) => Interlocked.Add(ref total, y));
            Console.WriteLine("Total: " + total);

        }
    }
}
