namespace wfa2Mp4
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbSource = new System.Windows.Forms.TextBox();
            this.bnSource = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbQV = new System.Windows.Forms.TextBox();
            this.bnConvert = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "源文件：";
            // 
            // tbSource
            // 
            this.tbSource.Location = new System.Drawing.Point(84, 20);
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(327, 21);
            this.tbSource.TabIndex = 1;
            // 
            // bnSource
            // 
            this.bnSource.Location = new System.Drawing.Point(421, 18);
            this.bnSource.Name = "bnSource";
            this.bnSource.Size = new System.Drawing.Size(75, 23);
            this.bnSource.TabIndex = 2;
            this.bnSource.Text = "浏览...";
            this.bnSource.UseVisualStyleBackColor = true;
            this.bnSource.Click += new System.EventHandler(this.bnSource_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "视频质量：";
            // 
            // tbQV
            // 
            this.tbQV.Location = new System.Drawing.Point(84, 60);
            this.tbQV.Name = "tbQV";
            this.tbQV.Size = new System.Drawing.Size(100, 21);
            this.tbQV.TabIndex = 4;
            this.tbQV.Text = "10";
            // 
            // bnConvert
            // 
            this.bnConvert.Location = new System.Drawing.Point(84, 98);
            this.bnConvert.Name = "bnConvert";
            this.bnConvert.Size = new System.Drawing.Size(75, 23);
            this.bnConvert.TabIndex = 5;
            this.bnConvert.Text = "开始压缩";
            this.bnConvert.UseVisualStyleBackColor = true;
            this.bnConvert.Click += new System.EventHandler(this.bnConvert_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbContent);
            this.groupBox1.Location = new System.Drawing.Point(13, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 207);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // rtbContent
            // 
            this.rtbContent.Location = new System.Drawing.Point(7, 15);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(470, 186);
            this.rtbContent.TabIndex = 0;
            this.rtbContent.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 353);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bnConvert);
            this.Controls.Add(this.tbQV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bnSource);
            this.Controls.Add(this.tbSource);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "视频压缩";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.Button bnSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbQV;
        private System.Windows.Forms.Button bnConvert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbContent;
    }
}

