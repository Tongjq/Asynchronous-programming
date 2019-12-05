using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSleep
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(()=> 
            {
                Console.WriteLine("线程1我要睡了");
                Thread.Sleep(3000);
                Console.WriteLine("线程1我睡醒了");
            });

            thread.Start();
            Console.ReadKey();
        }
    }
}
