using System;
using System.IO;
using System.Threading;
using Injin;
using Interfaces;

namespace InjinClient
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stop = false;
            var fab = new Fabricator(Directory.GetCurrentDirectory() + "\\" + "config.json");

            new Thread(() =>
            {
                while (!stop)
                {
                    var foo = fab.Fabricate<IFoo>();
                    Console.WriteLine(foo.Hi());
                    Thread.Sleep(3000);
                }

            }).Start();

            do
            {

            } while (Console.ReadLine()!="exit");
            stop = true;
        }
    }
}
