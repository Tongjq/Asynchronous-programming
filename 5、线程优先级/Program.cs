using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程优先级
{
    class Program
    {
        static void Main(string[] args)
        {
            // 先执行这段代码查看结果
            /* int i = 0, j = 0;
             Thread t1 = new Thread(() => {
                 while (true)
                 {
                     i++;
                 }
             });
             t1.Start();

             Thread t2 = new Thread(() =>
             {
                 while (true)
                 {
                     j++;
                 }
             });
             t2.Start();
             Thread.Sleep(3000);
             Console.WriteLine("i=" + i + ",j=" + j);
             Console.ReadKey(); */



            // 设置优先级后再查看结果
            int i = 0, j = 0;
            Thread t1 = new Thread(() => {
                while (true)
                {
                    i++;
                }
            });
            t1.Priority = ThreadPriority.Highest; // 优先执行
            t1.Start();

            Thread t2 = new Thread(() =>
            {
                while (true)
                {
                    j++;
                }
            });
            t2.Priority = ThreadPriority.Lowest;
            t2.Start();
            Thread.Sleep(3000);
            Console.WriteLine("i=" + i + ",j=" + j);
            Console.ReadKey();
        }
    }
}
