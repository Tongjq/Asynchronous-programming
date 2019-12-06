using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 后台线程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 默认开启的线程都是前台线程，线程没有执行完毕，关闭程序是不会退出的，因为主线程没有关闭
            //for (int i = 0; i < 100; i++)
            //{
            //    Thread thread = new Thread((item) =>
            //    {
            //        //textBox1.Text = item.ToString();
            //        Thread.Sleep(3000);
            //        MessageBox.Show(item.ToString());
            //    });
            //    thread.Start(i);
            //}


            // 设置后台线程执行   秒关
            for (int i = 0; i < 100; i++)
            {
                Thread thread = new Thread((item) =>
                {
                    //textBox1.Text = item.ToString();
                    Thread.Sleep(3000);
                    MessageBox.Show(item.ToString());
                });

                thread.IsBackground = true;
                thread.Start(i);
            }
        }
    }
}
