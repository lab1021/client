namespace client
{
    partial class DockContentSample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbSrc = new System.Windows.Forms.GroupBox();
            this.rtbSrc = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SegmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbDst = new System.Windows.Forms.GroupBox();
            this.rtbDst = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbSrc.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.gbDst.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.48106F));
            this.tableLayoutPanel1.Controls.Add(this.gbSrc, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbDst, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.84531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 253F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(913, 588);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gbSrc
            // 
            this.gbSrc.Controls.Add(this.rtbSrc);
            this.gbSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSrc.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSrc.Location = new System.Drawing.Point(3, 3);
            this.gbSrc.Name = "gbSrc";
            this.gbSrc.Size = new System.Drawing.Size(907, 329);
            this.gbSrc.TabIndex = 0;
            this.gbSrc.TabStop = false;
            this.gbSrc.Text = "原文";
            // 
            // rtbSrc
            // 
            this.rtbSrc.ContextMenuStrip = this.contextMenuStrip1;
            this.rtbSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSrc.Location = new System.Drawing.Point(3, 22);
            this.rtbSrc.Name = "rtbSrc";
            this.rtbSrc.Size = new System.Drawing.Size(901, 304);
            this.rtbSrc.TabIndex = 0;
            this.rtbSrc.Text = "";
            this.rtbSrc.Click += new System.EventHandler(this.rtbSrc_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MergeToolStripMenuItem,
            this.SegmentToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ChangeToolStripMenuItem,
            this.ChangedToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 106);
            // 
            // MergeToolStripMenuItem
            // 
            this.MergeToolStripMenuItem.Name = "MergeToolStripMenuItem";
            this.MergeToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.MergeToolStripMenuItem.Text = "合并";
            this.MergeToolStripMenuItem.Click += new System.EventHandler(this.MergeToolStripMenuItem_Click);
            // 
            // SegmentToolStripMenuItem
            // 
            this.SegmentToolStripMenuItem.Name = "SegmentToolStripMenuItem";
            this.SegmentToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.SegmentToolStripMenuItem.Text = "分割";
            this.SegmentToolStripMenuItem.Click += new System.EventHandler(this.SegmentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(131, 6);
            // 
            // ChangeToolStripMenuItem
            // 
            this.ChangeToolStripMenuItem.Name = "ChangeToolStripMenuItem";
            this.ChangeToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.ChangeToolStripMenuItem.Text = "修改";
            this.ChangeToolStripMenuItem.Click += new System.EventHandler(this.ChangeToolStripMenuItem_Click);
            // 
            // ChangedToolStripMenuItem
            // 
            this.ChangedToolStripMenuItem.Name = "ChangedToolStripMenuItem";
            this.ChangedToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.ChangedToolStripMenuItem.Text = "完成修改";
            this.ChangedToolStripMenuItem.Click += new System.EventHandler(this.ChangedToolStripMenuItem_Click);
            // 
            // gbDst
            // 
            this.gbDst.Controls.Add(this.rtbDst);
            this.gbDst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDst.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbDst.Location = new System.Drawing.Point(3, 338);
            this.gbDst.Name = "gbDst";
            this.gbDst.Size = new System.Drawing.Size(907, 247);
            this.gbDst.TabIndex = 1;
            this.gbDst.TabStop = false;
            this.gbDst.Text = "译文";
            // 
            // rtbDst
            // 
            this.rtbDst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDst.Location = new System.Drawing.Point(3, 22);
            this.rtbDst.Name = "rtbDst";
            this.rtbDst.Size = new System.Drawing.Size(901, 222);
            this.rtbDst.TabIndex = 0;
            this.rtbDst.Text = "";
            this.rtbDst.Click += new System.EventHandler(this.rtbDst_Click);
            this.rtbDst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbDst_KeyDown);
            // 
            // DockContentSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 588);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DockContentSample";
            this.Text = "DockContentSample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DockContentSample_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbSrc.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.gbDst.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbSrc;
        private System.Windows.Forms.RichTextBox rtbSrc;
        private System.Windows.Forms.GroupBox gbDst;
        private System.Windows.Forms.RichTextBox rtbDst;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MergeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SegmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ChangedToolStripMenuItem;
    }
}
