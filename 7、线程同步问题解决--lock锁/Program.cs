using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程同步问题解决__lock锁
{
    class Program
    {
        private static int counter = 0;
        private static Object locker = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    lock (locker) //注意 lock 要锁定同一个对象，而且必须是引用类型的对象
                    {
                        counter++;
                    }
                    Thread.Sleep(1);
                }
            });

            t1.Start();

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    lock (locker)
                    {
                        counter++;
                    }
                    Thread.Sleep(1);
                }
            });

            t2.Start();
            //while (t1.IsAlive) { }
            //while (t2.IsAlive) { }

            t1.Join(); // 让当前线程等待t1线程执行结束
            t2.Join();
            Console.WriteLine(counter);
            Console.ReadKey();
        }
    }
}
