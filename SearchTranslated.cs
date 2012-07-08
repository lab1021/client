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
    public partial class SearchTranslated : Form
    {

        public SearchTranslated(string num)
        {
            InitializeComponent();
            //lbName.Text = translator;
            lbArticleNum.Text = num;
        }


    }
}
