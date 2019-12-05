using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 参数化Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            /* int m = 5;
             Thread thread = new Thread(() =>
             {
                 Console.WriteLine("i="+m);
             });
             thread.Start();
             m = 6;

             Console.ReadKey();

             for (int i = 0; i < 10; i++)
             {
                 Thread thread1 = new Thread(()=> {
                     Console.WriteLine(i);
                 });

                 thread1.Start();
             }

             Console.ReadKey();*/


            /*在线程中传递参数使用ParameterizedThreadStart */
            //Thread thread = new Thread(Run1);
            //thread.Start(1);
            //Console.ReadKey();

            /* 上面的写法改成如下 */
            int m = 5;
            Thread thread1 = new Thread((obj) => {
                Console.WriteLine(obj);
            });
            thread1.Start(m);
            m = 6;
            Console.ReadKey();


            for (int i = 0; i < 10; i++)
            {
                Thread thread2 = new Thread((item)=> 
                {
                    Console.WriteLine("i="+item);
                });

                thread2.Start(i);
            }

            Console.ReadKey();
                 
        }

        public static void Run1(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
