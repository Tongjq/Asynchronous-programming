using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _10_线程同步2
{
    /// <summary>
    /// 会有两个线程同时修改一个余额的情况
    /// </summary>
    class Program
    {
        static int money = 10000;
        static void QuQian(string name)
        {
            Console.WriteLine(name + "查看一下余额" + money);
            int yue = money - 1;
            Console.WriteLine(name + "取钱");
            money = yue;//故意这样写，写成 money--其实就没问题
            Console.WriteLine(name + "取完了，剩" + money);
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
