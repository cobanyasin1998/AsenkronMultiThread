using System;
using System.Linq;

namespace PLINQApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = Enumerable.Range(1, 1000).ToList();

            var newArray = array.AsParallel().AsOrdered().Where(x => x % 2 == 0);

            newArray.ForAll(x =>
            {
                Console.WriteLine(x);
            });
        }
    }
}
