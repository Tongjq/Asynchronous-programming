using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 启用一个线程执行一段代码
{
    class Program
    {
        static void Main(string[] args)
        {
            // 两个线程是并行执行的
            Thread thread = new Thread(Run1);
            thread.Start();

            while (true)
            {
                Console.WriteLine("主线程中Main"+DateTime.Now);
            }
        }


        static void Run1()
        {
            while (true)
            {
                Console.WriteLine("子线程Child"+DateTime.Now);
            }
        }
    }
}
