using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client
{
    public partial class ArticleNum : Form
    {
        public ArticleNum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str="&#GET" ;
            if (radioButton1.Checked)
            {
                str = str + "1";
                MainWindow.Client.Send(Encoding.UTF8.GetBytes(str));
                TransPanel tp = new TransPanel();
                tp.Show();
                this.Close();
            }
            if (radioButton2.Checked)
            {
                str = str + "2";
                MainWindow.Client.Send(Encoding.UTF8.GetBytes(str));
                TransPanel tp = new TransPanel();
                tp.Show();
                this.Close();
            }
            if (radioButton3.Checked)
            {
                str = str + "3";
                MainWindow.Client.Send(Encoding.UTF8.GetBytes(str));
                TransPanel tp = new TransPanel();
                tp.Show();
                this.Close();
            }
        }
    }
}
