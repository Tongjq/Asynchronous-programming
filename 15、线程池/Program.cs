using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _15_线程池
{
    class Program
    {
        static void Main(string[] args)
        {
            /*

           1、 线程池：因为每次创建线程、销毁线程都比较消耗 cpu 资源，因此可以通过线程池进行
               优化。线程池是一组已经创建好的线程，随用随取，用完了不是销毁线程，然后放到线程池
               中，供其他人用。如鹏网.Net 提高班《并发编程》课件 rupeng.com
           2、 用线程池之后就无法对线程进行精细化的控制了（线程启停、优先级控制等）
           3、 ThreadPool 类的一个重要方法：
           static bool QueueUserWorkItem(WaitCallback callBack)
           static bool QueueUserWorkItem(WaitCallback callBack, object state)
           第二个重载是用来传递一个参数给线程代码的。
           4、除非要对线程进行精细化的控制，否则建议使用线程池，因为又简单、性能调优又更好。

           */


            //ThreadPool.QueueUserWorkItem(s => 
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine(i);
            //    }
            //});

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine("Hi");
            //}

            //Console.ReadKey();


            // 线程池传参数
            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(s =>
                {
                    Console.WriteLine(s);
                    int workThreads, completportThreads;
                    ThreadPool.GetAvailableThreads(out workThreads, out completportThreads);
                    Console.WriteLine($"workThreads={workThreads},completportThreads={completportThreads}");
                }, i);

            }
            Console.ReadKey();

        }
    }
}
