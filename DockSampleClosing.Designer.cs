namespace client
{
    partial class DockSampleClosing
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.btGiveup = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btCancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(52, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "您正试图关闭一个文件ID为";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "的翻译窗口。请选择您是要保存到本地";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(19, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "以待以后继续翻译还是不再翻译本篇。";
            // 
            // btSave
            // 
            this.btSave.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btSave.Location = new System.Drawing.Point(12, 176);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(92, 23);
            this.btSave.TabIndex = 4;
            this.btSave.Text = "保存到本地";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btGiveup
            // 
            this.btGiveup.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btGiveup.Location = new System.Drawing.Point(115, 176);
            this.btGiveup.Name = "btGiveup";
            this.btGiveup.Size = new System.Drawing.Size(75, 23);
            this.btGiveup.TabIndex = 5;
            this.btGiveup.Text = "不再翻译";
            this.btGiveup.UseVisualStyleBackColor = true;
            this.btGiveup.Click += new System.EventHandler(this.btGiveup_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "label4";
            // 
            // btCancle
            // 
            this.btCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancle.Location = new System.Drawing.Point(196, 176);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new System.Drawing.Size(75, 23);
            this.btCancle.TabIndex = 7;
            this.btCancle.Text = "取消";
            this.btCancle.UseVisualStyleBackColor = true;
            this.btCancle.Click += new System.EventHandler(this.btCancle_Click);
            // 
            // DockSampleClosing
            // 
            this.AcceptButton = this.btGiveup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 256);
            this.Controls.Add(this.btCancle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btGiveup);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DockSampleClosing";
            this.Text = "DockSampleClosing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btGiveup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btCancle;
    }
}