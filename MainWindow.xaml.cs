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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace client
{
    public enum Power
    {
        管理员=1,
        审核人员=2,
        翻译人员=3
    }
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Socket client;
        private byte[] data = new byte[1024];
        private int recv;
        public static Configuration config = new Configuration(@"F:\projects\C#\projects\client\");

        public MainWindow()
        {
            InitializeComponent();
            Load_cookies();
        }
        private void Load_cookies()
        {
            config.Load();
            textBox_user.Text = config.Id;
            passwordBox_password.Password = config.Password;
            textBox_ip.Text = config.Ip;
            textBox_port.Text = config.Port;
            switch (config.P)
            {
                case Power.管理员:
                    radioButton_admin.IsChecked = true;
                    break;
                case Power.翻译人员:
                    radioButton_translator.IsChecked = true;
                    break;
                default:
                    radioButton_translator.IsChecked = true;
                    break;

            }
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //IPAddress
            if (Regx.IsNull(textBox_user.Text) || Regx.IsNull(passwordBox_password.Password) || Regx.IsNull(textBox_ip.Text) || Regx.IsNull(textBox_port.Text))
            {
                System.Windows.MessageBox.Show("请输入正确的用户名，密码，服务器ip地址和端口号！", "提示");
                passwordBox_password.Password = "";
                return;
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
                        System.Windows.MessageBox.Show("ip地址，端口号错误或服务器端拒绝访问", "警告");
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
                        client.Dispose();
                        client.Close();
                        System.Windows.MessageBox.Show("权限错误！");
                        return;
                    }
                    string log = "&#LOG&#" + textBox_user.Text + "&#" + passwordBox_password.Password + "&#" + (int)p + "&#";
                    data = Encoding.UTF8.GetBytes(log);
                    client.Send(data);
                    recv = client.Receive(data);
                    if ((Encoding.UTF8.GetString(data, 0, recv))[0] == '1')
                    {
                        config.Save(textBox_user.Text, passwordBox_password.Password, textBox_ip.Text, textBox_port.Text, p);
                        CallForm(client, p);
                    }
                    else if ((Encoding.UTF8.GetString(data, 0, recv))[0] == '2')
                    {
                        DialogResult Result = System.Windows.Forms.MessageBox.Show("该用户已经登录，是否强制已登录用户下线", "警告", MessageBoxButtons.YesNo);
                        if (Result == System.Windows.Forms.DialogResult.Yes)
                        {
                            string feedback = "1";
                            data = Encoding.UTF8.GetBytes(feedback);
                            client.Send(data);
                            client.Dispose();
                            client.Close();
                        }
                    }
                    else
                    {
                        client.Dispose();
                        client.Close();
                        System.Windows.MessageBox.Show("用户名或密码错误！");
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
        private void CallForm(Socket client, Power p)
        {
            switch (p)
            {
                case Power.管理员:
                    Admin AdminForm = new Admin((object)client);//调用管理员界面 并将client 传递过去
                    AdminForm.Show();
                    break;
                case Power.审核人员:
                    break;
                case Power.翻译人员:
                    TransPanel TP = new TransPanel((object)client, textBox_user.Text);
                    TP.Show();
                    break;
                default:
                    return;
                    break;
            }
            this.Hide();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            this.Hide();
            reg.Show();
        }
    }
}