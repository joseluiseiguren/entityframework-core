using entFrExample.Models;
using System;
using System.Linq;

namespace entFrExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var dbctx = new DipositsContext())
            {
                var x = dbctx.Address.Where(p => p.Idaddress == 10010).FirstOrDefault();

                var y = dbctx.Address.Where(p => p.Idaddress == 100100).FirstOrDefault();
            }
        }
    }
}
