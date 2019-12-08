using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程同步1
{
    class Program
    {
        private static int counter = 0;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    counter++;
                    Thread.Sleep(1);
                }
            });

            t1.Start();
            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    counter++;
                    Thread.Sleep(1);
                }
            });

            t2.Start();
            //while (t1.IsAlive) { } //如果线程存活就一直循环
            //while (t2.IsAlive) { }

            t1.Join(); // 让当前线程等待t1线程执行结束
            t2.Join();
            Console.WriteLine(counter);
            Console.ReadKey();

        }
    }
}
