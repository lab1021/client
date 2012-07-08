using System;
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
using System.ComponentModel;
using System.Net.Sockets;

namespace client
{
    /// <summary>
    /// Admin.xaml 的交互逻辑
    /// </summary>
    public partial class Admin : Window
    {
        private List<UserData> LUserdata;
        private List<User> LUser;

        private List<string> Edit_list;

        private Socket client;

        public Admin(object oclient)
        {
            InitializeComponent();
            client = (Socket)oclient;
        }

        private void cBox_All_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            LUserdata.FindAll(p =>
            {
                p.user.Ischecked = cb.IsChecked.Value;
                p.Count = LUser.Count;                 
                return true; });
            LUserdata.FindAll(p => { p.Ischeckedcount = LUser.Count(t => t.Ischecked == true); return true; });
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            int recv;
            byte[] rdata = new byte[1024*1024];

            List<UserData> Delete_list = LUserdata.FindAll(p => { if (p.user.Ischecked) { return true; } return false; });
            Delete_list.FindAll(p => { p.Count = Delete_list.Count; return true; });
            Delete_list.FindAll(p => { p.Ischeckedcount = LUserdata.Count(t => t.user.Ischecked == true); return true; });
            if (Delete_list.Count != 0)
            {
                string post_data = "&#D" + Delete_list.Count.ToString();
                foreach (UserData item in Delete_list)
                {
                    post_data = post_data + "&#" + item.user.Id + "::" +
                        item.user.Password + "::" +
                        ((int)item.user.Power).ToString() + "::" +
                        ((int)item.user.State).ToString();
                }
                byte[] tmp_data = Encoding.UTF8.GetBytes(post_data);
                client.Send(tmp_data);
                recv = client.Receive(rdata);
                if (Encoding.UTF8.GetString(rdata, 0, recv) == "1")
                {
                    LUserdata = LUserdata.FindAll(p => { if (p.user.Ischecked) { p.user.Ischecked = false; return p.user.Id != p.user.Id; } return true; });
                    LUserdata.FindAll(p => { p.Count = LUserdata.Count; return true; });
                    LUserdata.FindAll(p => { p.Ischeckedcount = LUserdata.Count(t => t.user.Ischecked == true); return true; });
                    if (LUserdata.Count == 0)
                        Tb_SelectCount.Text = "0";
                    UserInfo.DataContext = LUserdata;
                    Grid_Data.DataContext = LUserdata;
                }
                else
                {
                    MessageBox.Show("删除用户失败！", "警告");
                }
            }
        }

        private void btn_show_Click(object sender, RoutedEventArgs e)
        {
            int recv;
            byte[] rdata = new byte[1024 * 1024];
            LUserdata = new List<UserData>();
            LUser = new List<User>();

            Edit_list = new List<string>();

            byte[] tmp_data = Encoding.UTF8.GetBytes("&#GET");
            client.Send(tmp_data);
            recv = client.Receive(rdata);
            string[] get_info = (Encoding.UTF8.GetString(rdata, 0, recv)).Split(new string[] { "&#" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in get_info)
            {
                string[] user = item.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                Power p = (Power)Int32.Parse(user[2]);
                State s = (State)Int32.Parse(user[3]);

                string Online = "";
                switch (user[6])
                {
                    case "0":
                        Online = "离线";
                        break;
                    case "1":
                        Online = "在线";
                        break;
                    default:
                        break;
                }

                LUser.Add(new User
                {
                    Id = user[0],
                    Password = user[1],
                    Power = p,
                    State = s,
                    Lastlogin = user[4],
                    Tcount = Int32.Parse(user[5]),
                    Isonline = Online,
                    Ischecked = false
                });
            }
            foreach (var item in LUser)
            {
                UserData Udata = new UserData();
                Udata.user = item;
                Udata.Count = LUser.Count;
                Udata.Ischeckedcount = LUser.Count(p => p.Ischecked == true);
                LUserdata.Add(Udata);
            }

            //bind
            UserInfo.DataContext = LUserdata;

            LUserdata = LUserdata.FindAll(p => { if (p.user.Ischecked) { p.user.Ischecked = false; return p.user.Id != p.user.Id; } return true; });
            LUserdata.FindAll(p => { p.Count = LUserdata.Count; return true; });
            LUserdata.FindAll(p => { p.Ischeckedcount = LUserdata.Count(t => t.user.Ischecked == true); return true; });
            if (LUserdata.Count == 0)
                Tb_SelectCount.Text = "0";
            Grid_Data.DataContext = LUserdata;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            string uid = cb.Tag.ToString();
            LUserdata.FindAll(p =>
                {
                    if (p.user.Id == uid)
                    {
                        p.user.Ischecked = cb.IsChecked.Value;
                        p.Count = LUser.Count;
                        return true;
                    }
                    return true;
                });
            LUserdata.FindAll(p => { p.Ischeckedcount = LUser.Count(t => t.Ischecked == true); return true; });
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            int recv;
            byte[] rdata = new byte[1024 * 1024];
            List<UserData> Change_list = LUserdata.FindAll(p => { if (Edit_list.Exists(q => { if (q == p.user.Id) { return true; } return false; })) { return true; } return false; });
            Change_list.FindAll(p => { p.Count = Change_list.Count; return true; });
            Change_list.FindAll(p => { p.Ischeckedcount = LUserdata.Count(t => t.user.Ischecked == true); return true; });
            if (Change_list.Count != 0)
            {
                string post_data = "&#C" + Change_list.Count.ToString();
                foreach (UserData item in Change_list)
                {
                    post_data = post_data + "&#" + item.user.Id + "::" +
                        item.user.Password + "::" +
                        ((int)item.user.Power).ToString() + "::" +
                        ((int)item.user.State).ToString();
                }
                byte[] tmp_data = Encoding.UTF8.GetBytes(post_data);
                client.Send(tmp_data);
                recv = client.Receive(rdata);
                if (Encoding.UTF8.GetString(rdata, 0, recv) == "1")
                {
                    MessageBox.Show("修改用户信息成功！", "通知");
                }
                else
                {
                    MessageBox.Show("修改用户失败！", "警告");
                }
            }
            Edit_list.Clear();
        }

        private void UserInfo_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            Edit_list.Add((LUserdata.Find(p=>{if(p.user.Id == ((UserData)e.Row.Item).user.Id) { return true; } return false;})).user.Id);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            byte[] tmp = new byte[0];
            client.Send(tmp);
            client.Dispose();
            client.Close();
            Environment.Exit(0);
        }
    }


    public enum State
    {
        待审核,
        禁用,
        正常
    };

    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class User: PropertyChangedBase
    {
        private string _id;
        private string _password;
        private Power _power;
        private State _state;
        private string _lastlogin;
        private bool _ischecked;
        private int _tcount;
        private string _Isonline;

        public string Id
        {
            get { return _id; }
            set { _id = value; Notify("Id"); }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; Notify("Password"); }
        }
        public Power Power
        {
            get { return _power; }
            set { _power = value; Notify("Power"); }
        }
        public State State
        {
            get { return _state; }
            set { _state = value; Notify("State"); }
        }
        public string Lastlogin
        {
            get { return _lastlogin; }
            set { _lastlogin = value; Notify("Lastlogin"); }
        }
        public bool Ischecked
        {
            get { return _ischecked; }
            set { _ischecked = value; Notify("Ischecked"); }
        }
        public int Tcount
        {
            get { return _tcount; }
            set { _tcount = value; Notify("Tcount"); }
        }
        public string Isonline
        {
            get { return _Isonline; }
            set { _Isonline = value; Notify("Isonline"); }
        }
    }
    public class UserData : PropertyChangedBase
    {
        private User _user;
        private int _count;
        private int _ischeckedcount;

        public User user
        {
            get { return _user; }
            set { _user = value; Notify("User"); }
        }
        public int Count
        {
            get { return _count; }
            set { _count = value; Notify("Count"); }
        }
        public int Ischeckedcount
        {
            get { return _ischeckedcount; }
            set { _ischeckedcount = value; Notify("Ischeckedcount"); }
        }
    }
}
