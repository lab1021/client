using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace client
{
    public partial class DockSampleClosing : Form
    {
        public DockSampleClosing(object oclient,string otranslator, string id, string srcText,string dstText)
        {
            InitializeComponent();
            articleID = id;
            srcRtbText = srcText;
            dstRtbText = dstText;
            label4.Text = id;
            client = (Socket)oclient;
            translator = otranslator;
        }

        private Socket client;
        private string translator;
        private string articleID;
        private string srcRtbText;
        private string dstRtbText;
        private void btSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "txt";
            saveDialog.AddExtension = true;
            saveDialog.FileName = articleID;
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveDialog.OverwritePrompt = true;
            saveDialog.Title = "保存到本地";
            saveDialog.ValidateNames = true;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveDialog.FileName);
                writer.WriteLine(srcRtbText );
                writer.WriteLine(dstRtbText );
                writer.Close();
                MessageBox.Show("保存成功！");
                writer.Close();
                saveDialog.Dispose();
                this.Close();
            }
            
        }

        private void btGiveup_Click(object sender, EventArgs e)
        {
            string toPost = "&#ABAN&#" + articleID + "&#" + translator + "&#";
            client.Send(Encoding.UTF8.GetBytes(toPost), System.Net.Sockets.SocketFlags.None);
            this.Close();
        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
