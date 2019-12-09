using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17_EAP编程模型
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


     

        private void button1_Click(object sender, EventArgs e)
        {
            //          EAP 是 Event - based Asynchronous Pattern（ 基于事件的异步模型） 的简写， 类似于 Ajax 中的
            //XmlHttpRequest， send 之后并不是处理完成了，而是在 onreadystatechange 事件中再通知处理完成


            WebClient client = new WebClient();
            client.DownloadStringCompleted += Client_DownloadStringCompleted;
            client.DownloadStringAsync(new Uri("http://www.baidu.com")); ;

            //        优点是简单，缺点是当实现复杂的业务的时候很麻烦，比如下载 A 成功后再下载 b，如果下载 b
            //成功再下载 c，否则就下载 d。
            //EAP 的类的特点是：一个异步方法配一个*** Completed 事件。 .Net 中基于 EAP 的类比较少。也有更
            // 好的替代品，因此了解即可。
        }

        private void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Result);
        }
    }
}
