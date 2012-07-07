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
    public partial class DockContentSample : WeifenLuo .WinFormsUI .Docking .DockContent 
    {
        public DockContentSample()
        {
            InitializeComponent();
        }

        private string titleSrcRtb;
        private string idSrcRtb;
        private List <string > contentListSrc;
        private List<string> contentListDst;
        private string titleDstRtb;
        private string idDstRtb;
        private string sentenceSrc;
        private string sentenceDst;

        //public List<string> GetContentListSrc()
        //{
        //    string[] srcLines = rtbSrc.Lines;
        //    string[] dstLines = rtbDst.Lines;
        //    int line = 0;
        //    if (line < 2)
        //        return null;
        //    for (line = 2; line <= srcLines.Length; line++)
        //    {

        //    }
        //}
        //need to change,parameter should be List<string>
        public void SetDockContent(string idSR, string titleSR, List<string> contentListS, string idDR, string titleDR, List<string> contentListD)
        {
            rtbDst.ReadOnly = false;
            rtbSrc.ReadOnly = false;
            titleSrcRtb = titleSR;
            idSrcRtb = idSR;
            contentListSrc = contentListS;
            titleDstRtb = titleDR;
            idDstRtb = idDR;
            contentListDst = contentListD;
            rtbSrc.AppendText(idSR + "\n" + titleSrcRtb + "\n");
            rtbDst.AppendText(idDR + "\n" +titleDstRtb + "\n");
            try
            {
                for (int i = 0; i < contentListSrc.Count; i++)
                {
                    rtbSrc.AppendText("|  " + contentListSrc[i] + "  ");
                    rtbDst.AppendText("|  " + contentListDst[i] + "  ");
                }
            }
            catch
            {
                MessageBox.Show("所选文本格式不符！");
            }
            rtbSrc.AppendText("|");
            rtbDst.AppendText("|");
            rtbSrc.ReadOnly = true;
            RtbProtect(rtbDst);
        }

        public void SetDockContent(string idSR, string titleSR, List <string > contentListS)
        {
            rtbDst.ReadOnly = false;
            rtbSrc.ReadOnly = false;
            titleSrcRtb = titleSR;
            idSrcRtb = idSR;
            contentListSrc = contentListS;
            titleDstRtb = string .Empty ;
            idDstRtb = idSR;
            contentListDst = new List<string>(contentListSrc.Count);
            rtbSrc.AppendText(idSR + "\n" + titleSrcRtb + "\n");
            rtbDst.AppendText(idSR + "\n" + "\n");
            for (int i = 0; i < contentListSrc .Count ; i++)
            {
                rtbSrc.AppendText("|  " +contentListSrc[i] + "  ");
                rtbDst.AppendText("|  " + new string(' ', contentListSrc[i].Length) + "  ");
            }
            rtbSrc.AppendText("|");
            rtbDst.AppendText("|");
            rtbSrc.ReadOnly = true;
            RtbProtect(rtbDst);
        }
        public RichTextBox RtbSrc
        {
            get {return  rtbSrc; }
            set { rtbSrc = value; }
        }

        public RichTextBox RtbDst
        {
            get { return rtbDst; }
            set { rtbDst = value; }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rtbSrc_Click(object sender, EventArgs e)
        {
            /****
            int startIndex = rtbSrc.SelectionStart;
            rtbSrc.SelectAll();
            rtbSrc.SelectionColor = Color.Black;
            rtbDst.SelectAll();
            rtbDst.SelectionColor = Color.Black;
            string[] srcLine = rtbSrc.Lines;
            string[] dstLine = rtbDst.Lines;
            if(startIndex <=rtbSrc .Find ("|",rtbSrc .TextLength ,RichTextBoxFinds .Reverse ))
            {
                if(startIndex <=rtbSrc .Find ("|"))
                {
                    int line1len = srcLine[0].Length;
                    int line2len = srcLine[1].Length;
                    if (startIndex <= line1len)
                    {
                        rtbSrc.Select(0, line1len);
                        rtbSrc.SelectionColor = Color.Red;
                        rtbDst.Select(0, dstLine[0].Length);
                        rtbDst.SelectionColor = Color.Red;
                        tbSrc.Text = srcLine[0];
                    }
                    else
                    {
                        rtbSrc.Select(line1len + 1, srcLine[1].Length);
                        rtbSrc.SelectionColor = Color.Red;
                        rtbDst.Select(dstLine[0].Length + 1, dstLine[1].Length);
                        rtbDst.SelectionColor = Color.Red;
                        tbSrc.Text = srcLine[1];
                    }
                }
            }
             * *****/
        }

        private void MergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbSrc.SelectionLength > 0)
            {
                int curindex = rtbSrc.SelectionStart;
                string str = new string(rtbSrc.Text.ToArray(), rtbSrc.SelectionStart, rtbSrc.SelectionLength);
                int i = str.IndexOf("|");

                if (i != -1 && (i + curindex) != rtbSrc.Find("|", RichTextBoxFinds.Reverse))
                {
                    rtbSrc.ReadOnly = false;
                    int findex1, lindex1;
                    findex1 = rtbSrc.Find("|", 0, RichTextBoxFinds.None);
                    int k;
                    int fno = 0;
                    for (k = rtbSrc.Find("|", 0, RichTextBoxFinds.None); k < curindex; )
                    {
                        fno++;
                        findex1 = k;
                        k = rtbSrc.Find("|", k + 1, RichTextBoxFinds.None);
                    }
                    int lno = fno;
                    while (i != -1)
                    {
                        i = str.IndexOf("|", i + 1);
                        lno++;
                    }
                    lno++;
                    k = lno;
                    lindex1 = rtbSrc.Find("|", 0, RichTextBoxFinds.None);
                    while (--k > 0)
                    {
                        lindex1 = rtbSrc.Find("|", lindex1 + 1, RichTextBoxFinds.None);
                    }
                    if (lindex1 == -1)
                        lindex1 = rtbSrc.Find("|", RichTextBoxFinds.Reverse);
                    string s = new string(rtbSrc.Text.ToArray(), findex1 + 1, lindex1 - findex1 - 1);
                    str = s;
                    i = str.IndexOf("|");
                    int offset = 0;
                    while (i != -1)
                    {
                        s = s.Remove(i - offset, 1);
                        i = str.IndexOf("|", i + 1);
                        offset++;
                    }
                    rtbSrc.Select(findex1 + 1, lindex1 - findex1 - 1);
                    rtbSrc.Cut();
                    rtbSrc.SelectionStart = findex1 + 1;
                    rtbSrc.SelectionLength = 0;
                    rtbSrc.SelectedText = s;
                    rtbSrc.ReadOnly = true;
                    int findex2, lindex2;
                    k = fno;
                    findex2 = rtbDst.Find("|", 0, RichTextBoxFinds.None);
                    while (--k > 0)
                    {
                        findex2 = rtbDst.Find("|", findex2 + 1, RichTextBoxFinds.None);
                    }
                    k = lno;
                    lindex2 = rtbDst.Find("|", 0, RichTextBoxFinds.None);
                    while (--k > 0)
                    {
                        lindex2 = rtbDst.Find("|", lindex2 + 1, RichTextBoxFinds.None);
                    }
                    if (lindex2 == -1)
                        lindex2 = rtbDst.Find("|", RichTextBoxFinds.Reverse);
                    str = new string(rtbDst.Text.ToArray(), findex2 + 1, lindex2 - findex2 - 1);
                    s = str;
                    i = str.IndexOf("|");
                    offset = 0;
                    while (i != -1)
                    {
                        s = s.Remove(i - offset, 1);
                        i = str.IndexOf("|", i + 1);
                        offset++;
                    }
                    //由于被选中的“|”之前被设置为protected,所以应先改变其属性后剪切
                    rtbDst.SelectAll();
                    rtbDst.SelectionProtected = false;
                    rtbDst.Select(findex2 + 1, lindex2 - findex2 - 1);
                    rtbDst.Cut();
                    rtbDst.SelectionStart = findex2 + 1;
                    rtbDst.SelectionLength = 0;
                    rtbDst.SelectedText = s;
                    RtbProtect(rtbDst);
                }
            }
        }

        private void SegmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i;
            int curindex = rtbSrc.SelectionStart;
            if (curindex >= rtbSrc.Find("|", rtbSrc.TextLength, RichTextBoxFinds.Reverse))
                return;
            int indexno = 0;
            rtbSrc.ReadOnly = false;
            rtbSrc.SelectionStart = curindex;
            rtbSrc.SelectionLength = 0;
            rtbSrc.SelectedText = "|";
            rtbSrc.ReadOnly = true;
            for (i = rtbSrc.Find("|", 0, RichTextBoxFinds.None); i < curindex; )
            {
                indexno++;
                i = rtbSrc.Find("|", i + 1, RichTextBoxFinds.None);
            }
            int findex, lindex;
            findex = rtbDst.Find("|", 0, RichTextBoxFinds.None);
            for (i = 0; i < indexno - 1; i++)
            {
                findex = rtbDst.Find("|", findex + 1, RichTextBoxFinds.None);
            }
            lindex = rtbDst.Find("|", findex + 1, RichTextBoxFinds.None);
            rtbDst.SelectionStart = (findex + lindex) / 2;
            rtbDst.SelectionLength = 0;
            rtbDst.SelectedText = "|";
            rtbDst.Select(rtbDst.SelectionStart - 1, 1);
            rtbDst.SelectionProtected = true;
        }

        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbSrc.ReadOnly = false;
            RtbProtect(rtbSrc);
        }

        private void RtbProtect(RichTextBox rtb)
        {
            int i=-1;
            i = rtb.Find("|", 0, RichTextBoxFinds.None);
            while (i != -1)
            {
                rtb.Select(i, 1);
                rtb.SelectionProtected = true;
                if (i == rtb.TextLength - 1)
                {
                    rtb.Select(i, 1);
                    rtb.SelectionProtected = true;
                    break;
                }
                else 
                    i = rtb.Find("|", i + 1, RichTextBoxFinds.None);
            }
        }

        private void rtbDst_Click(object sender, EventArgs e)
        {
            int startIndex = rtbDst.SelectionStart;
            rtbSrc.SelectAll();
            rtbSrc.SelectionColor = Color.Black;
            //rtbDst.SelectAll();
            //rtbDst.SelectionColor = Color.Black;            
            if (startIndex <rtbDst.Find("|", rtbDst.TextLength, RichTextBoxFinds.Reverse))
            {
                if(startIndex <=rtbDst .Find ("|"))
                {
                    string[] srcLine = rtbSrc.Lines;
                    string[] dstLine = rtbDst.Lines;
                    int line = rtbDst.GetLineFromCharIndex(startIndex);
                    switch (line)
                    {
                        case 0:
                            rtbSrc.Select(0, srcLine[0].Length);
                            rtbSrc.SelectionColor = Color.Red;
                            //rtbDst.Select(0, dstLine[0].Length);
                            //rtbDst.SelectionColor = Color.Red;
                            rtbDst.SelectionStart = startIndex;
                            rtbDst.SelectionLength = 0;
                            break;
                        case 1:
                            rtbSrc.Select(srcLine[0].Length+1, srcLine[1].Length);
                            rtbSrc.SelectionColor = Color.Red;
                            //rtbDst.Select(dstLine[0].Length, dstLine[1].Length);
                            //rtbDst.SelectionColor = Color.Red;
                            rtbDst.SelectionStart = startIndex;
                            rtbDst.SelectionLength = 0;
                            break;
                        case 2:
                            break;
                    }
                }
                else 
                {
                    int findex = startIndex;
                    int lastchar = rtbDst.Find("|", startIndex, RichTextBoxFinds.None);
                    int count = 0;
                    int index = rtbDst.Find("|", 0, RichTextBoxFinds.None);
                    while (index != -1 && index < lastchar)
                    {
                        count++;
                        findex = index;
                        index = rtbDst.Find("|", index + 1, RichTextBoxFinds.None);
                    }
                    //rtbDst.Select(findex + 1, lastchar - findex - 1);
                    //rtbDst.Cut();
                    rtbDst.SelectionStart = startIndex;
                    int firstindex, lastindex;
                    firstindex = 0;
                    lastindex = rtbSrc.Find("|", 0, RichTextBoxFinds.None);
                    while (count > 0)
                    {
                        count--;
                        //firstindex = rtbSrc.Find("|", lastindex  + 1, RichTextBoxFinds.None);
                        firstindex = lastindex;
                        lastindex = rtbSrc.Find("|", firstindex + 1, RichTextBoxFinds.None);
                    }
                    rtbSrc.Select(firstindex + 1, lastindex - firstindex - 1);
                    rtbSrc.SelectionColor = Color.Red;
                    rtbDst.SelectionLength = 0;
                }
            }
        }

        private void ChangedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbSrc.ReadOnly = true;
        }

        private void rtbDst_KeyDown(object sender, KeyEventArgs e)
        {
            
            int indexstart=rtbDst .SelectionStart ;
            int firstchar=rtbDst .Find ("|");
            int lastchar=rtbDst .Find ("|",rtbDst .TextLength ,RichTextBoxFinds .Reverse );
            if (e.Control && e.KeyCode == Keys.Right)
            {
                int secondlastchar = rtbDst.Find("|", lastchar - 1, RichTextBoxFinds.Reverse);
                if (indexstart < secondlastchar)
                {
                    int nextchar = rtbDst.Find("|", indexstart,RichTextBoxFinds .None);
                    rtbDst.SelectionStart = nextchar + 1;
                    
                    int count = 0;
                    int i = 0, j = 0;
                    i = rtbDst.Find("|");
                    while (i != -1 && i <= indexstart)
                    {
                        count++;
                        i = rtbDst.Find("|", i + 1,RichTextBoxFinds .None);
                    }

                    int firstindex, lastindex;
                    firstindex = 0;
                    lastindex = rtbSrc.Find("|", 0, RichTextBoxFinds.None);
                    while (count > 0)
                    {
                        count--;
                        //firstindex = rtbSrc.Find("|", lastindex  + 1, RichTextBoxFinds.None);
                        firstindex = lastindex;
                        lastindex = rtbSrc.Find("|", firstindex + 1, RichTextBoxFinds.None);
                    }
                    rtbSrc.Select(firstindex + 1, lastindex - firstindex - 1);
                    rtbSrc.SelectionColor = Color.Red;
                    rtbDst.SelectionLength = 0;


                }
            }
            if (e.Control && e.KeyCode == Keys.Left)
            {
                
            }
            
        }
        
    }
}
