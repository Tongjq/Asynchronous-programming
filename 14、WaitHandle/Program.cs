using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _14_WaitHandle
{
    class Program
    {
        static void Main(string[] args)
        {
            /* ManualResetEvent mre = new ManualResetEvent(false);
             //构造函数 false 表示“初始状态为关门”，设置为 true 则初始化为开门状态
             Thread t1 = new Thread(() => {
                 Console.WriteLine("开始等着开门");
                 mre.WaitOne();
                 Console.WriteLine("终于等到你");
             });
             t1.Start();
             Console.WriteLine("按任意键开门");
             Console.ReadKey();
             mre.Set();//开门
             Console.ReadKey();*/


            /*
            //WaitOne()还可以设置等待超时时间：
            ManualResetEvent mre = new ManualResetEvent(false);
            //false 表示“初始状态为关门”
            Thread t1 = new Thread(() =>
            {
                Console.WriteLine("开始等着开门");
                if (mre.WaitOne(5000))
                {
                    Console.WriteLine("终于等到你");
                }
                else
                {
                    Console.WriteLine("等了 5 秒钟都没等到");
                }
            });
            t1.Start();
            Console.WriteLine("按任意键开门");
            Console.ReadKey();
            mre.Set();//开门
            Console.ReadKey();
            */


            /*
            // ManualResetEvent 是一旦设定 Set()后就一直开门，除非调用 Reset 关门。 Manual：手动；
            // Reset：关门
                        ManualResetEvent mre = new ManualResetEvent(false);
            //false 表示“初始状态为关门”
            Thread t1 = new Thread(() => {
                while (true)
                {
                    Console.WriteLine("开始等着开门");
                    mre.WaitOne(5000);
                    Console.WriteLine("终于等到你");
                }
            });
            t1.Start();
            Console.WriteLine("按任意键开门");
            Console.ReadKey();
            mre.Set();//开门
            Console.ReadKey();
            mre.Reset();//关门
            Console.ReadKey();*/




            // 还有一个类 AutoResetEvent， 他是在开门并且一个 WaitOne 通过后自动关门， 因此命名为
            //“AutoResetEvent”（Auto 自动-Reset 关门）
            AutoResetEvent are = new AutoResetEvent(false);
            Thread t1 = new Thread(() => {
                while (true)
                {
                    Console.WriteLine("开始等着开门");
                    are.WaitOne();
                    Console.WriteLine("终于等到你");
                }
            });
            t1.Start();
            Console.WriteLine("按任意键开门");
            Console.ReadKey();
            are.Set();//开门
            Console.WriteLine("按任意键开门");
            Console.ReadKey();
            are.Set();
            Console.WriteLine("按任意键开门");
            Console.ReadKey();
            are.Set();
            Console.ReadKey();


            // 总结：ManualResetEvent 就是学校的大门， 开门大家都可以进， 除非主动关门； AutoResetEvent
            //  就是火车地铁的闸机口， 过了一个后自动关门。




        }
    }
}
