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



    class Person
    {
        private static Person instance = new Person();
        private Person()
        { }
        public static Person GetInstance()
        {
            return instance;
        }
    }


    // 有时候需要真正第一次用到的时候再创建那个唯一实例（懒汉）。

    class User
    {
        private static User instance = null;

        private User() { }

        public static User GetInstance1()
        {
            if (instance == null)
            {
                return new User();
            }
            return instance;
        }
    }

    // 这样写在多线程的环境下可能无法保证单例。
    //用 lock 可以保证
    class Dog
    {
        private static Dog instance = null;
        private static object locker = new object();
        private Dog()
        { }
        public static Dog GetInstance()
        {
            lock (locker)
            {
                if (instance == null)
                {
                    instance = new Dog();
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

class Cat
{
    private static Cat instance = null;
    private static object locker = new object();
    private Cat()
    { }
    public static Cat GetInstance()
    {
        if (instance == null)
        {
            lock (locker)
            {
                if (instance == null)
                {
                    instance = new Cat();
                }
            }
        }
        return instance;
    }
}
