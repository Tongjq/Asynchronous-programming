using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_单例模式与多线程
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }



    class God
    {
        private static God instance = new God();
        private God()
        { }
        public static God GetInstance()
        {
            return instance;
        }
    }


    // 有时候需要真正第一次用到的时候再创建那个唯一实例（懒汉）。

    class God1
    {
        private static God1 instance1 = null;

        private God1() { }

        public static God1 GetInstance1()
        {
            if (instance1 == null)
            {
                return new God1();
            }
            return instance1;
        }
    }

    // 这样写在多线程的环境下可能无法保证单例。
    //用 lock 可以保证
    class God2
    {
        private static God2 instance = null;
        private static object locker = new object();
        private God2()
        { }
        public static God2 GetInstance()
        {
            lock (locker)
            {
                if (instance == null)
                {
                    instance = new God2();
                }
                return instance;
            }
        }
    }
}

//   但是每次其实只有instance为null的时候的那次加锁时候有意义的，以后的千万次调用，
//  每个线程都要锁定 locker，就会造成性能下降。 如下改造，进行双重检查（double-check）
//  class God
//

class God3
{
    private static God3 instance = null;
    private static object locker = new object();
    private God3()
    { }
    public static God3 GetInstance()
    {
        if (instance == null)
        {
            lock (locker)
            {
                if (instance == null)
                {
                    instance = new God3();
                }
            }
        }
        return instance;
    }
}
