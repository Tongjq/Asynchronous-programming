using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19_TPL编程模型
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //   TPL（Task Parallel Library）是.Net 4.0 之后带来的新特性，更简洁，更方便。现在在.Net
            //平台下已经大面积使用。

            FileStream fs = File.OpenRead("d:/1.txt");
            byte[] buffer = new byte[16];
            Task<int> task = fs.ReadAsync(buffer, 0, buffer.Length);
            task.Wait();
            MessageBox.Show("读取了" + task.Result + "个字节");
            MessageBox.Show(Encoding.UTF8.GetString(buffer));
        }

        //        这样用和 APM 比起来的好处是：不需要 EndXXX。
        //精彩不仅于此：
        private async void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = File.OpenRead("d:/1.txt");
            byte[] buffer = new byte[16];
            int len = await fs.ReadAsync(buffer, 0, buffer.Length);
            MessageBox.Show("读取了" + len + "个字节");
            MessageBox.Show(Encoding.UTF8.GetString(buffer));
        }


        //        注意方法中如果有 await，则方法必须标记为 async，不是所有方法都可以被轻松的标记
        //为 async。 WinForm 中的事件处理方法都可以标记为 async、 MVC 中的 Action 方法也可以标
        //记为 async、 控制台的 Main 方法不能标记为 async。
        //TPL 的特点是：方法都以 XXXAsync 结尾，返回值类型是泛型的 Task<T>。
        //TPL 让我们可以用线性的方式去编写异步程序，不再需要像 EAP 中那样搞一堆回调、逻
        //辑跳来跳去了。 await 现在已经被 JavaScript 借鉴走了！



        //        用 await 实现“先下载 A，如果下载的内容长度大于 100 则下载 B，否则下载 C”就很容易了
        //再看看 WebClient 的 TPL 用法
        private async void button3_Click(object sender, EventArgs e)
        {
            var wc = new WebClient();
            string html = await wc.DownloadStringTaskAsync("http://www.baidu.com");//不要丢了 await
            MessageBox.Show(html);
            //上面的代码并不是完全等价于
            WebClient wc1 = new WebClient();
            var task = wc1.DownloadStringTaskAsync("http://www.baidu.com");
            task.Wait();
            MessageBox.Show(task.Result);

            //            因为如果按照上面的写法，会卡死 UI 线程
            //而 await 则 不 会 。。。 好 像 不 是 ？ ？ ？ 那 只 是 因 为 把 html 这 么 长 的 字 符 串
            //MessageBox.Show 很慢， MessageBox.Show(html.Substring(10)); 就证明了这一点


            //            Task<T> 中的 T 是什么类型每个方法都不一样，要看文档。
            //WebClient、 Stream、 Socket 等这些“历史悠久”的类都同时提供了 APM、 TPL 风格的
            //API，甚至有的还提供了 EAP 风格的 API。尽可能使用 TPL 风格的
        }


        // 如何编写异步方法？
        // 1、返回值为 Task<T>，潜规则（不要求）是方法名字以 Async 结尾：
        static Task<string> F2Async()
        {
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                return "F2";
            });
        }

    }
}
