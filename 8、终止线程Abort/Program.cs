using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 终止线程Abort
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 40; i++)
            {
                try
                {
                    Thread thread = new Thread((item) =>
                    {
                        Console.WriteLine(item);

                    });
                    thread.Abort(); // 会引发异常
                    thread.Start(i);
                }

                catch (ThreadAbortException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
