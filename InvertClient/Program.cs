using System;
using System.IO;
using System.Threading;
using Interfaces;
using Invert;

namespace InvertClient
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] stop = {false};
            var inv = new Inverter(Directory.GetCurrentDirectory() + "\\" + "config.json");

            new Thread(() =>
            {
                while (!stop[0])
                {
                    var foo = inv.Create<IFoo>();
                    Console.WriteLine(foo.Hi());
                    Thread.Sleep(3000);
                }

            }).Start();

            do
            {

            } while (Console.ReadLine()!="exit");
            stop[0] = true;
        }
    }
}
