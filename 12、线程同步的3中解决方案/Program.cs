using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _12_线程同步的3中解决方案
{
    /// <summary>
    /// 解决思路：使用同步的技术避免两个线程同时修改一个余额。
    //解决方法 1：最大粒度——同步方法。

    //QuQian 方法上标注[MethodImpl(MethodImplOptions.Synchronized)]， 这样一个方法只能同时被
    //一个线程访问。

    // 解决方法 2：对象互斥锁  Lock锁
    /// </summary>
    class Program
    {
        static int money = 10000;
        // 第1种方法、 [MethodImpl(MethodImplOptions.Synchronized)]

        // 第2种方法
        static object locker = new object();

        // 解决方法 3（*）： Monitor
        static void QuQian(string name)
        {

            //lock (locker)
            //{
            Monitor.Enter(locker);//等待没有人锁定 locker 对象，我就锁定它，然后继续执行
                                  //Monitor 有 TryEnter 方法，如果 Enter 的时候有人在占用锁，它不会等待，而是会返回false

            try
            {
                Console.WriteLine(name + "查看一下余额" + money);
                int yue = money - 1;
                Console.WriteLine(name + "取钱");
                money = yue;//故意这样写，写成 money--其实就没问题
                Console.WriteLine(name + "取完了，剩" + money);
            }
            catch
            {
                Monitor.Exit(locker);//释放 locker 对象的锁
            }
            //}
        }


        static void F1(int i)
        {
            if (!Monitor.TryEnter(locker))
            {
                Console.WriteLine("有人在锁着呢");
                return;
            }
            Console.WriteLine(i);
            Monitor.Exit(locker);
        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    QuQian("t1");
                }
            });
            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    QuQian("t2");
                }
            });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine("余额" + money);
            Console.ReadKey();
        }
    }
}
