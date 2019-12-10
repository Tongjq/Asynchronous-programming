using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_TPL高级
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  1、 如果方法内部有 await，则方法必须标记为 async。 asp.net mvc 的 Action、 WinForm 的事件处理函数都可以标记 async，
            // 控制台 Main 不能 async。对于不能标记为怎么办？
            // F1Async().Result 注意有的上下文下会有死锁。
            //2、 如果返回值就是一个立即可以随手可得的值，那么就用 Task.FromResult()
            //如果是一个需要休息一会的任务（比如下载失败则过 5 秒钟后重试。主线程不休息，和
            //Thread.Sleep 不一样），那么就用 Task.Delay()。
            //3、 Task.Factory.FromAsync()把 IAsyncResult 转换为 Task， 这样 APM 风格的 api 也可以用 await 来调
            //用。
            //4、 编写异步方法的简化写法。如果方法声明为 async，那么可以直接 return 具体的值，不再用创建
            //Task，由编译器创建 Task：


        }

        static async Task<int> F1Async()
        {
            return 1;
        }

        //2、 如果返回值就是一个立即可以随手可得的值，那么就用 Task.FromResult()
        static Task<int> F2Async()
        {
            return Task.FromResult(3);
        }
        static Task<int> F3Async()
        {
            return Task.Run(() =>
            {
                return 1 + 3;
            });
        }


        // 
        private async void button2_Click(object sender, EventArgs e)
        {
            /* HttpClient wc = new HttpClient();
             string s1 = await wc.GetStringAsync(textBox1.Text);
             label1.Text = s1.Length.ToString();
             string s2 = await wc.GetStringAsync(textBox2.Text);
             label2.Text = s2.Length.ToString();
             string s3 = await wc.GetStringAsync(textBox3.Text);
             label3.Text = s3.Length.ToString(); */





            HttpClient hc = new HttpClient();
            var task1 = hc.GetStringAsync(textBox1.Text);
            var task2 = hc.GetStringAsync(textBox2.Text);
            var task3 = hc.GetStringAsync(textBox3.Text);
            Task.WaitAll(task1, task2, task3);
            label1.Text = task1.Result.Length.ToString();
            label2.Text = task2.Result.Length.ToString();
            label3.Text = task3.Result.Length.ToString();

        }


        //6、 异步接口的声明
        interface ITest
        {
            Task<int> GetAsync();//不要标注 async
        }
        class Test : ITest
        {
            public async Task<int> GetAsync()
            {
                return 3;
            }
        }


        //1、 TPL 中，如果程序中出现异常，除非进行 try...catch，否则有可能是感觉不到出了异常的。
        // 测试，把上面下载程序的域名改成一个不存在的域名。
        //2、 TPL 程序有时候还会抛出 AggregateException， 这通常发生在并行有多个任务执行的情况下。 比如：
        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient hc = new HttpClient();
                var task1 = hc.GetStringAsync(textBox1.Text);
                var task2 = hc.GetStringAsync(textBox2.Text);
                var task3 = hc.GetStringAsync(textBox3.Text);
                Task.WaitAll(task1, task2, task3);
                label1.Text = task1.Result.Length.ToString();
                label2.Text = task2.Result.Length.ToString();
                label3.Text = task3.Result.Length.ToString();
            }
            catch (AggregateException ae)
            {
                MessageBox.Show(ae.GetBaseException().ToString());
            }
        }
        //        因为多个并行的任务可能有多个有异常，因此会包装为 AggregateException 异常，
        //AggregateException 的 InnerExceptions 属性可以获得多个异常对象信息
    }
}
