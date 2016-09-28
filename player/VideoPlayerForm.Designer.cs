namespace vlc.net
{
    partial class VideoPlayerForm
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
            CSharpWin.TrackBarColorTable trackBarColorTable1 = new CSharpWin.TrackBarColorTable();
            CSharpWin.TrackBarColorTable trackBarColorTable2 = new CSharpWin.TrackBarColorTable();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoPlayerForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trackBarVolume = new CSharpWin.TrackBarEx();
            this.trackBar1 = new CSharpWin.TrackBarEx();
            this.tbVideoTime = new System.Windows.Forms.TextBox();
            this.pointPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblStop = new System.Windows.Forms.Label();
            this.lblRadio = new System.Windows.Forms.Label();
            this.lblNext = new System.Windows.Forms.Label();
            this.lblPause = new System.Windows.Forms.Label();
            this.lblPrev = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 335);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(202)))));
            this.panel2.Controls.Add(this.lblStop);
            this.panel2.Controls.Add(this.trackBarVolume);
            this.panel2.Controls.Add(this.lblRadio);
            this.panel2.Controls.Add(this.lblNext);
            this.panel2.Controls.Add(this.lblPause);
            this.panel2.Controls.Add(this.lblPrev);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.tbVideoTime);
            this.panel2.Controls.Add(this.pointPanel);
            this.panel2.Location = new System.Drawing.Point(0, 361);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(602, 67);
            this.panel2.TabIndex = 1;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVolume.AutoSize = false;
            this.trackBarVolume.ColorTable = trackBarColorTable1;
            this.trackBarVolume.Location = new System.Drawing.Point(458, 31);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(120, 16);
            this.trackBarVolume.TabIndex = 15;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarEx1_Scroll);
            this.trackBarVolume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarVolume_MouseDown);
            this.trackBarVolume.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseMove);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.ColorTable = trackBarColorTable2;
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBar1.Location = new System.Drawing.Point(0, 7);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(602, 15);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseDown);
            this.trackBar1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseMove);
            // 
            // tbVideoTime
            // 
            this.tbVideoTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(202)))));
            this.tbVideoTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbVideoTime.Location = new System.Drawing.Point(27, 32);
            this.tbVideoTime.Name = "tbVideoTime";
            this.tbVideoTime.ReadOnly = true;
            this.tbVideoTime.Size = new System.Drawing.Size(108, 14);
            this.tbVideoTime.TabIndex = 6;
            this.tbVideoTime.TabStop = false;
            // 
            // pointPanel
            // 
            this.pointPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pointPanel.Location = new System.Drawing.Point(0, 0);
            this.pointPanel.Name = "pointPanel";
            this.pointPanel.Size = new System.Drawing.Size(602, 7);
            this.pointPanel.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(202)))));
            this.panel3.Controls.Add(this.lblClose);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(603, 25);
            this.panel3.TabIndex = 2;
            // 
            // lblClose
            // 
            this.lblClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClose.Location = new System.Drawing.Point(538, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(65, 25);
            this.lblClose.TabIndex = 1;
            this.lblClose.Text = "返回";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Visible = false;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseMove);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "视  频";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::vlc.net.Resource1.大暂停;
            this.pictureBox1.InitialImage = global::vlc.net.Resource1.大暂停;
            this.pictureBox1.Location = new System.Drawing.Point(187, 108);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 160);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // lblStop
            // 
            this.lblStop.Image = global::vlc.net.Resource1.停止;
            this.lblStop.Location = new System.Drawing.Point(296, 32);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(28, 15);
            this.lblStop.TabIndex = 16;
            this.lblStop.Tag = "停止";
            this.lblStop.Click += new System.EventHandler(this.lblStop_Click);
            this.lblStop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseMove);
            // 
            // lblRadio
            // 
            this.lblRadio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRadio.Image = ((System.Drawing.Image)(resources.GetObject("lblRadio.Image")));
            this.lblRadio.Location = new System.Drawing.Point(438, 32);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(23, 15);
            this.lblRadio.TabIndex = 14;
            this.lblRadio.Tag = "声音";
            this.lblRadio.Click += new System.EventHandler(this.lblRadio_Click);
            this.lblRadio.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseMove);
            // 
            // lblNext
            // 
            this.lblNext.Image = global::vlc.net.Resource1.下一个;
            this.lblNext.Location = new System.Drawing.Point(259, 32);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(28, 15);
            this.lblNext.TabIndex = 13;
            this.lblNext.Tag = "下一个";
            this.lblNext.Click += new System.EventHandler(this.lblNext_Click);
            this.lblNext.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseMove);
            // 
            // lblPause
            // 
            this.lblPause.Image = global::vlc.net.Resource1.播放;
            this.lblPause.Location = new System.Drawing.Point(222, 32);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(28, 15);
            this.lblPause.TabIndex = 12;
            this.lblPause.Tag = "暂停";
            this.lblPause.Click += new System.EventHandler(this.lblPause_Click);
            this.lblPause.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseMove);
            // 
            // lblPrev
            // 
            this.lblPrev.Image = global::vlc.net.Resource1.上一个;
            this.lblPrev.Location = new System.Drawing.Point(185, 32);
            this.lblPrev.Name = "lblPrev";
            this.lblPrev.Size = new System.Drawing.Size(28, 15);
            this.lblPrev.TabIndex = 11;
            this.lblPrev.Tag = "上一个";
            this.lblPrev.Click += new System.EventHandler(this.lblPrev_Click);
            this.lblPrev.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseMove);
            // 
            // VideoPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 428);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VideoPlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "视  频";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbVideoTime;
        private CSharpWin.TrackBarEx trackBar1;
        private System.Windows.Forms.Panel pointPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label lblPause;
        private System.Windows.Forms.Label lblPrev;
        private System.Windows.Forms.Label lblRadio;
        private CSharpWin.TrackBarEx trackBarVolume;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblStop;
    }
}

