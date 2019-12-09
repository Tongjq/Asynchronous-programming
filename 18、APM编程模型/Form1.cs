using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18_APM编程模型
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //  APM(Asynchronous Programming Model)是.Net 旧版本中广泛使用的异步编程模型。使用了 APM
            //的异步方法会返回一个 IAsyncResult 对象， 这个对象有一个重要的属性 AsyncWaitHandle， 他是一个
            //用来等待异步任务执行结束的一个同步信号。

            FileStream fs = File.OpenRead("d:/1.txt");
            byte[] buffer = new byte[16];
            IAsyncResult aResult = fs.BeginRead(buffer, 0, buffer.Length, null, null);
            aResult.AsyncWaitHandle.WaitOne();//等待任务执行结束
            MessageBox.Show(Encoding.UTF8.GetString(buffer));
            fs.EndRead(aResult);


            // 如果不加 aResult.AsyncWaitHandle.WaitOne() 那么很有可能打印出空白，因为 BeginRead
            //只是“开始读取”。调用完成一般要调用 EndXXX 来回收资源。
            //APM 的特点是：方法名字以 BeginXXX 开头，返回类型为 IAsyncResult， 调用结束后需要
            //EndXXX。
            //.Net 中有如下的常用类支持 APM： Stream、 SqlCommand、 Socket 等。
            //APM 还是太复杂，了解即可
        }
    }
}
