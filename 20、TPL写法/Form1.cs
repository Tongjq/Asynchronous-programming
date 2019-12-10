using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20_TPL写法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            /*  string i1 = await F1Async();
              MessageBox.Show("i1=" + i1);
              string i2 = await F2Async();
              MessageBox.Show("i2=" + i2);
              */


            // Task.Run()一个用来把一个代码段包装为 Task<T>的方法 Run 中委托的代码体就是异步任
            //务执行的逻辑，最后 return 返回值。
            //把 button1_click 改成：
            Task<string> task1 = F1Async();
            Task<string> task2 = F2Async();
            string i1 = await task1;
            MessageBox.Show("i1=" + i1);
            string i2 = await task2;
            MessageBox.Show("i2=" + i2);

        }


        static Task<string> F1Async()
        {
            MessageBox.Show("F1 Start");
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(1000);
                MessageBox.Show("F1 Run");
                return "F1";
            });
        }
        static Task<string> F2Async()
        {
            MessageBox.Show("F2 Start");
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                MessageBox.Show("F2 Run");
                return "F2";
            });
        }



        static Task<string> GetRuPengAsync()
        {
            return Task.Run(() =>
            {
                return "a";
            });
            //这里可以return Task<string> 类型的值，不能return “a”;
        }
        static async Task<string> GetRuPengAsync1()
        {
            return  "a";
            //这里不可以return Task<string> 类型的值， 而可以能return “a”;
        }



        //1、 只要方法是 Task<T>类型的返回值，都可以用 await 来等待调用获取返回值
        //2、 如果一个返回 Task<T>类型的方法被标记了 async，那么只要方法内部直接 return T 这个类型的实例就可以。
        //3、 一个返回 Task<T>类型的方法没有被标记了 async，那么需要方法内部直接 Task 实例

        private async void button2_Click(object sender, EventArgs e)
        {
            //int i = await F1Async();
            int i = await M2Async();
            MessageBox.Show(i.ToString());
        }

        static Task<int> M1Async()
        {
            return Task.Run(() => {
                return 2;
            });
        }
        static async Task<int> M2Async()
        {
            return 2;
        }
    }
}
