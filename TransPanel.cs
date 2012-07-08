using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using WeifenLuo.WinFormsUI.Docking;
using System.Xml;

namespace client
{
    public partial class TransPanel : Form
    {
        public TransPanel()
        {
            InitializeComponent();
        }

        private ArrayList dcList = new ArrayList();

        protected override void OnLoad(EventArgs e)
        {
            this.tsbNew.Tag = ApplyforToolStripMenuItem1;
            this.tsbOpen.Tag = OpenToolStripMenuItem;
            this.tsbSave.Tag = SaveToolStripMenuItem;
            this.tsbSubmit.Tag = SubmitToolStripMenuItem;
            base.OnLoad(e);
        }
        private DockContentSample CreateDockContent(string text)
        {
            DockContentSample dc = new DockContentSample();
            dc.Text = text;
            return dc;
        }

        //private bool FindDockContent(string text)
        //{
        //    foreach (Form form in 
        //}
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开(Open)";
            ofd.FileName = "";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//为了获取特定的系统文件夹，可以使用System.Environment类的静态方法GetFolderPath()。该方法接受一个Environment.SpecialFolder枚举，其中可以定义要返回路径的哪个系统目录
            ofd.Filter = "文本文件(*.txt)|*.txt";
            ofd.RestoreDirectory = true;
            ofd.ValidateNames = true;     //文件有效性验证ValidateNames，验证用户输入是否是一个有效的Windows文件名
            ofd.CheckFileExists = true;  //验证路径有效性
            ofd.CheckPathExists = true; //验证文件有效性
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fullname = ofd.FileName;
                    string txtname = Path.GetFileName(fullname);
                    DockContentSample dc = CreateDockContent(txtname);
                    StreamReader sr = new StreamReader(ofd.FileName, System.Text.Encoding.UTF8);
                    string idSrc = sr.ReadLine();
                    string titleSrc = sr.ReadLine();
                    string contentSrc = sr.ReadLine ();
                    //sr.ReadLine();
                    string idDst = sr.ReadLine();
                    string titleDst = sr.ReadLine();
                    string contentDst = sr.ReadLine ();
                    List<string> contentListSrc = new List<string>();
                    List<string> contentListDst = new List<string>();
                    contentListSrc=StringtoList(contentSrc);
                    contentListDst=StringtoList(contentDst);
                    dc.SetDockContent(idSrc, titleSrc, contentListSrc, idDst, titleDst, contentListDst);
                    //dc.RtbSrc.AppendText(sr.ReadLine()+"\n");
                    //dc.RtbSrc.AppendText(sr.ReadLine()+"\n");
                    //dc.RtbSrc.AppendText(sr.ReadLine()+"\n");
                    //sr.ReadLine();
                    //dc.RtbDst.AppendText(sr.ReadLine()+"\n");
                    //dc.RtbDst.AppendText(sr.ReadLine()+"\n");
                    //dc.RtbDst.AppendText(sr.ReadLine()+"\n");
                    dc.Show(this.dockPanel1);
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
                MessageBox.Show("所选文件格式不符！");
            }
            finally
            {
                ofd.Dispose();
            }
        }

        private List <string> StringtoList(string s)
        {
            List<string> strlist=new List<string> ();
            int i, j;
            i = s.IndexOf("|");
            if (i == -1 || i == s.Length)
                return strlist;
            else
            {
                j = s.IndexOf("|", i + 1);
                while (i != -1 && j != -1)
                {
                    string str;
                    str = new string(s.ToArray(), i + 1, j - i - 1);
                    strlist.Add(str.Trim());
                    i = j + 1;
                    if (i > s.Length)
                        break;
                    else 
                        j = s.IndexOf("|", i);
                }
                return strlist;
            }
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "txt";
            saveDialog.AddExtension = true;
            string name;
            DockContentSample  dcActive=(DockContentSample )dockPanel1 .ActiveContent ;
            if (dcActive != null)
            {
                name = dcActive.Text;
                string srcText = dcActive.RtbSrc.Text;
                string dstText = dcActive.RtbDst.Text;
                saveDialog.FileName = name;
                saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveDialog.OverwritePrompt = true;
                saveDialog.Title = "保存到本地";
                saveDialog.ValidateNames = true;
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(saveDialog.FileName);
                    writer.WriteLine(srcText);
                    writer.WriteLine(dstText);
                    writer.Close();
                    MessageBox.Show("保存成功！");
                    writer.Close();
                }
                saveDialog.Dispose();
            }
        }

        private void ApplyforToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            string str = "&#GET";
            str = str + "1";
            MainWindow.Client.Send(Encoding.UTF8.GetBytes(str));
            byte[] data = new byte[1024 * 1024];
            int datalen;
            datalen = MainWindow.Client.Receive(data);
            string s = Encoding.UTF8.GetString(data, 0, datalen);
            string[] article = s.Split(new string[] { "&#" }, StringSplitOptions.RemoveEmptyEntries);
            int articleLen = article.Length;
            
            if (articleLen == 1)
            {
                string[] content = article[article.Length - articleLen].Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                if (content.Length == 1)
                    MessageBox.Show("No more article to be translate.");
                else
                {
                    DockContentSample dc = CreateDockContent(content[1]);
                    //dc.RtbSrc.AppendText("文章ID：" + content[0] + "\n");
                    //dc.RtbSrc.AppendText(content[1] + "\n");
                    //dc.RtbDst.AppendText("文章ID：" + content[0] + "\n");
                    //dc.RtbDst.AppendText("\n");
                    //XmlDocument xmlDoc = new XmlDocument();
                    //string strbody = "<body>" + content[2] + "</body>";
                    //xmlDoc.Load(new StringReader(strbody));
                    //XmlNodeList sbody = xmlDoc.SelectNodes("/body/b");
                    //for (int i = 0; i < sbody.Count; i++)
                    //{
                    //    dc.RtbSrc.AppendText("|  " + sbody[i].InnerText + "  ");
                    //    dc.RtbDst.AppendText("|  " + new string(' ', sbody[i].InnerText.Length) + "  ");
                    //}

                    //dc.RtbSrc.AppendText("  | ");
                    //dc.RtbDst.AppendText("  | ");
                    //dc.RtbDst.ReadOnly = true;
                    //dc.RtbSrc.ReadOnly = true;
                    //dc.Show(this.dockPanel1);
                    XmlDocument xmlDoc = new XmlDocument();
                    string strbody = "<body>" + content[2] + "</body>";
                    xmlDoc.Load(new StringReader(strbody));
                    XmlNodeList sbody = xmlDoc.SelectNodes("/body/b");
                    List <string > contentList=new List<string>() ;
                    for (int i = 0; i < sbody.Count; i++)
                        contentList.Add(sbody[i].InnerText);
                    dc.SetDockContent(content[0], content[1], contentList);
                    dc.Show(this.dockPanel1);
                }
            }
            
        }

        private void TransPanelnew_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭登录窗口，断开连接
            Environment.Exit(0);
        }

        private void tbs_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            if (item != null)
            {
                ToolStripMenuItem mi = item.Tag as ToolStripMenuItem;
                if (mi != null)
                    mi.PerformClick();
            }
        }

        private void SubmitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DockContentSample dcActive = (DockContentSample)dockPanel1.ActiveContent;
            if (dcActive != null)
            {
                //XmlDocument xmlDoc = new XmlDocument();
                //XmlElement rootElem = xmlDoc.CreateElement("body");
                //xmlDoc.AppendChild(rootElem);
                string toPost = "&#POST1&#";
                string[] srcLines = dcActive.RtbSrc.Lines;
                string[] dstLines = dcActive.RtbDst.Lines;
                if (srcLines.Length == 3 && dstLines.Length == 3)
                {
                    toPost = toPost + srcLines[0] + "::" + "NULL" + "::" + MainWindow.Translator + "::" + srcLines[1] + "::";
                    int srci, srcj,dsti,dstj;
                    string srcbody = srcLines[2];
                    string dstbody = dstLines[2];
                    srci = srcbody.IndexOf("|");
                    dsti = dstbody.IndexOf("|");
                    string str;
                    while (srci != -1&&srci <srcbody .Length )
                    {
                        srcj = srcLines[2].IndexOf("|", srci + 1);
                        dstj = dstLines[2].IndexOf("|", dsti + 1);
                        str = srcbody.Substring(srci+1, srcj - srci - 1);
                        toPost =toPost +"<b>"+str .Trim ()+"</b>";
                        //XmlElement srcxml=xmlDoc .CreateElement ("<b>");
                        //srcxml .InnerText =str.Trim ();
                        //rootElem .AppendChild (srcxml );
                        str = dstbody.Substring(dsti+1, dstj - dsti - 1);
                        toPost =toPost +"<t>"+str .Trim ()+"</t>";
                        //XmlElement dstxml = xmlDoc.CreateElement("<t>");
                        //dstxml.InnerText = str.Trim();
                        //rootElem.AppendChild(dstxml);
                        srci = srcj + 1;
                        dsti = dstj + 1;
                    }
                }

                toPost += "&#";
                MainWindow.Client.Send(Encoding.UTF8.GetBytes(toPost));
                MessageBox.Show("提交成功！");
            }
        }

        private void tsbSubmit_Click(object sender, EventArgs e)
        {
            SubmitToolStripMenuItem.PerformClick();
        }

        private void OperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ApplyforToolStripMenuItem1.PerformClick();
        }

        private void TranslatedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string toPost = string.Empty;
            toPost = "&#INFO&#";
            toPost += MainWindow.Translator;
            toPost += "&#";
            MainWindow.Client.Send(Encoding .UTF8 .GetBytes (toPost ),System.Net.Sockets.SocketFlags.None );
            byte[] info = new byte[1024];
            int num;
            num = MainWindow.Client.Receive(info);
            string articlenum = Encoding.UTF8.GetString(info);
            SearchTranslated ST = new SearchTranslated(articlenum);
            ST.ShowDialog();
        }
    }
}
