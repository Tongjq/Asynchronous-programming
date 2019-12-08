using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interrupt提前唤醒线程
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => {
                Console.WriteLine("t1要睡了");
                try
                {
                    Thread.Sleep(5000);
                }
                catch (ThreadInterruptedException)
                {
                    Console.WriteLine("擦，叫醒我干啥");
                }
                Console.WriteLine("t1醒了");
            });
            t1.Start();
            Thread.Sleep(1000);
            t1.Interrupt();
            Console.ReadKey();
        }
    }
}
