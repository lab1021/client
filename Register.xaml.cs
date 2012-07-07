using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace client
{
    /// <summary>
    /// Register.xaml 的交互逻辑
    /// </summary>
    public partial class Register : Window
    {
        private Socket client;
        private ManualResetEvent allDone = new ManualResetEvent(false);
        private byte[] data = new byte[1024];
        private int recv;

        public Register()
        {
            InitializeComponent();
        }

        private void button_register_Click(object sender, RoutedEventArgs e)
        {
            if (Regx.IsNull(textBox_user.Text) || Regx.IsNull(passwordBox_password.Password) || Regx.IsNull(passwordBox_confirm.Password) || Regx.IsNull(textBox_ip.Text) || Regx.IsNull(textBox_port.Text))
            {
                MessageBox.Show("用户名,密码,IP,端口不能为空！", "提示");
            }
            else if (passwordBox_password.Password != passwordBox_confirm.Password)
            {
                MessageBox.Show("密码不一致！", "提示");
            }
            else
            {
                try
                {
                    IPEndPoint serverip = new IPEndPoint(IPAddress.Parse(textBox_ip.Text), Int32.Parse(textBox_port.Text));
                    try
                    {
                        client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        client.Connect(serverip);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("ip地址，端口号错误或服务器端拒绝访问", "警告");
                        client.Dispose();
                        client.Close();
                        return;
                    }

                    Power p = new Power();
                    if ((bool)radioButton_admin.IsChecked)
                    {
                        p = Power.管理员;
                    }
                    else if ((bool)radioButton_translator.IsChecked)
                    {
                        p = Power.翻译人员;
                    }
                    else
                    {
                        MessageBox.Show("权限错误！");
                    }
                    string reg = "&#REG&#" + textBox_user.Text + "&#" + passwordBox_password.Password + "&#" + (int)p + "&#";
                    data = Encoding.UTF8.GetBytes(reg);
                    client.Send(data);
                    recv = client.Receive(data);
                    if ((Encoding.UTF8.GetString(data, 0, recv))[0] == '1')
                    {
                        MessageBox.Show("注册成功！", "通知");
                        MainWindow MW = new MainWindow();
                        switch (p)
                        {
                            case Power.管理员:
                                MW.radioButton_admin.IsChecked = true;
                                break;
                            case Power.翻译人员:
                                MW.radioButton_translator.IsChecked = true;
                                break;
                            default:
                                MW.radioButton_translator.IsChecked = true;
                                break;
                        }
                        MW.textBox_ip.Text = textBox_ip.Text;
                        MW.textBox_port.Text = textBox_port.Text;
                        MW.textBox_user.Text = textBox_user.Text;
                        MW.passwordBox_password.Password = passwordBox_password.Password;

                        MainWindow.config.Save(textBox_user.Text, passwordBox_password.Password, textBox_ip.Text, textBox_port.Text, p);

                        client.Dispose();
                        client.Close();
                        this.Close();

                        MW.Show();
                    }
                    else
                    {
                        client.Dispose();
                        client.Close();
                        MessageBox.Show("注册失败！", "错误");
                    }
                }
                catch (Exception ex)
                {
                    client.Dispose();
                    client.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}