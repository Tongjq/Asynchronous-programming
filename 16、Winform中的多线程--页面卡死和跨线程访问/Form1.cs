using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16_Winform中的多线程__页面卡死和跨线程访问
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* WebClient webClient = new WebClient();
            string html = webClient.DownloadString("http://www.github.com");
            textBox1.Text = html; */

            ThreadPool.QueueUserWorkItem(s => 
            {
                WebClient client = new WebClient();
                string html= client.DownloadString("http://www.github.com");
                // TextBox.CheckForIllegalCrossThreadCalls = false; //取消跨线程访问
                // textBox1.Text = html; // 对于控件的操作只能在UI线程中执行
                textBox1.BeginInvoke(new Action(()=> 
                {
                    textBox1.Text = html;
                }));
            });
        }
    }
}
