using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _9_t1.Join__当前线程等待_t1_线程执行结束
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("t1 " + i);
                }
            });
            t1.Start();
            Thread t2 = new Thread(() => {
                t1.Join();//等着 t1 执行结束
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("t2 " + i);
                }
            });
            t2.Start();
            Console.ReadKey();
        }
    }
}
