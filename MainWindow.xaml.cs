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
        private static  string translator;
        public static string Translator
        {
            get { return translator; }
        }
        private static Socket client;
        private byte[] data = new byte[1024];
        private int recv;
        public static Configuration config = new Configuration(@"C:\Users\schsun\Desktop\projects\client\");
        public static Socket Client
        {
            get { return client; }
        }
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
                        client.Close();
                        return;
                    }
                    Power p = new Power();
                    if ((bool)radioButton_admin.IsChecked)
                    {
                        p = Power.管理员;
                        string log = "&#LOG&#" + textBox_user.Text + "&#" + passwordBox_password.Password + "&#" + (int)p + "&#";
                        data = Encoding.UTF8.GetBytes(log);
                        client.Send(data);
                        recv = client.Receive(data);
                        if ((Encoding.UTF8.GetString(data, 0, recv))[0] == '1')
                        {
                            config.Save(textBox_user.Text, passwordBox_password.Password, textBox_ip.Text, textBox_port.Text, p);

                            Admin AdminForm = new Admin((object)client);//调用管理员界面 并将client 传递过去
                            this.Hide();
                            AdminForm.Show();
                        }
                        else
                        {
                            client.Close();
                            System.Windows.MessageBox.Show("用户名或密码错误！");
                        }
                    }
                    else if ((bool)radioButton_translator.IsChecked)
                    {
                        p = Power.翻译人员;
                        string log = "&#LOG&#" + textBox_user.Text + "&#" + passwordBox_password.Password + "&#" + (int)p + "&#";
                        data = Encoding.UTF8.GetBytes(log);
                        client.Send(data);
                        recv = client.Receive(data);
                        if ((Encoding.UTF8.GetString(data, 0, recv))[0] == '1')
                        {
                            config.Save(textBox_user.Text, passwordBox_password.Password, textBox_ip.Text, textBox_port.Text, p);
                            //AfterLogin afterForm = new AfterLogin();//调用翻译界面 并将client 传递过去
                            //FormTranslation ft = new FormTranslation();
                            translator = textBox_user.Text;
                            TransPanel tp = new TransPanel();
                            this.Hide();
                            tp.Show();
                        }
                        else
                        {
                            client.Close();
                            System.Windows.MessageBox.Show("用户名或密码错误！");
                        }
                    }
                    else
                    {
                        client.Close();
                        System.Windows.MessageBox.Show("权限错误！");
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            this.Hide();
            reg.Show();
        }
    }
}

                /*  *********************************************************
                //client.Connect("localhost", 8500);
                AsyncCallback requestCallBack = new AsyncCallback(RequestCallBack);
                
                client.BeginConnect(IPAddress .Parse ("10.108.16.103"),8500,requestCallBack,client);
                //jump to another page
                
                byte[] msg = new byte[1024]; 
                NetworkStream ns = client.GetStream();
                ns.Read(msg, 0, 1024);
                if (msg.ToString() == "1")
                {
                    AfterLogin afterForm = new AfterLogin();
                    this.Close();
                }
                else
                    MessageBox.Show("用户名或密码错误！");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
            
        }

        private void RequestCallBack(IAsyncResult iar)
        {
            allDone.Set();
            client = (TcpClient)iar.AsyncState;
            client.EndConnect(iar);
            ns = client.GetStream();
            Dispatcher.Invoke((Action)delegate
            {
                SendString(textBox1.Text + passwordBox1.Password);
            });
        }

        private void SendString(string str)
        {
            try
            {
                byte[] bytesdata = Encoding.ASCII.GetBytes(str);
                ns.BeginWrite(bytesdata, 0, bytesdata.Length, new AsyncCallback(SendCallBack), ns);
                ns.Flush();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
            }
        }

        private void SendCallBack(IAsyncResult iar)
        {
            try
            {
                ns.EndWrite(iar);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
*/