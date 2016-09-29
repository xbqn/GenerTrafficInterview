using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors;
using CSharpWin;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Xml;

namespace vlc.net
{
    public partial class VideoPlayerForm : Form
    {
        private VlcPlayer vlc_player_;
        private bool is_playinig_;
        private int ThisAll = 0;
        private string videoPath = string.Empty; //视频路径
        public string videoName = string.Empty; //视频名称
        private int Volume = 0; //当前声音大小
        private int ExtendWidth = 0; //多余出来的宽度,用于确定视频点在滑块的位置

        public VideoPlayerForm()
        {
            InitializeComponent();
            string pluginPath = System.Environment.CurrentDirectory + "\\plugins\\";
            vlc_player_ = new VlcPlayer(pluginPath);
            IntPtr render_wnd = this.panel1.Handle;
            vlc_player_.SetRenderWindow((int)render_wnd);

            tbVideoTime.Text = "00:00:00/00:00:00";

            is_playinig_ = false;

            //videoName = "S01E02.mp4";

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //设置图片透明
            SetPictureBoxTransparent(pictureBox1, Resource1.大暂停);
            pictureBox1.Visible = false;

            //播放视频
            videoPath = "video\\" + videoName;
            Play(videoPath);
        }
        /// <summary>
        /// 外部播放视频的方法
        /// </summary>
        /// <param name="videoPath">视频路径，带文件夹名</param>
        public void Play(string videoPath)
        {
            if (is_playinig_) //如果正在播放，则暂停播放
            {
                vlc_player_.Stop();
                trackBar1.Value = 0;
                timer1.Stop();
                is_playinig_ = false;
            }
            VideoPlay(videoPath);
            //设置声音
            if (is_playinig_)
            {
                trackBarVolume.SetRange(0, vlc_player_.GetVolume());
                trackBarVolume.Value = vlc_player_.GetVolume();
            }
        }
        private void VideoPlay(string video)
        {
            videoPath = video;

            videoName = videoPath.Substring(videoPath.LastIndexOf('\\') + 1);
            //video = video.Replace("video\\", "");
            //清空点的控件
            this.pointPanel.Controls.Clear();
            //播放视频
            vlc_player_.PlayFile(video);
            vlc_player_.Pause(); //先暂停，最后再播放
            trackBar1.SetRange(0, (int)vlc_player_.Duration());
            //trackBar1.SetRange(0, 1000);
            trackBar1.Value = 0;
            //存储最长时间
            ThisAll = (int)vlc_player_.Duration();
            is_playinig_ = true;

            //为了让视频点显示在滑块的中间，此处计算需要增加的时间宽度
            int barlength = trackBar1.Right - trackBar1.Left;
            //滑块宽14，此处取固定值
            //ExtendWidth = (int)((float)7 / (float)barlength * trackBar1.Maximum);
            ExtendWidth = 0; //由于不能解决白点所在容器和滚动条之间长度的换算，此处位置不要计算，先设为0了。

            #region 根据配置文件 加载视频点
            string xmlPath = "config\\videoPoint.xml";
            if (File.Exists(xmlPath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);
                XmlNode xn = xmlDoc.SelectSingleNode("configuration/video[@name='" + videoName + "']");
                if (xn != null)
                {
                    XmlNodeList dwkmList = xn.ChildNodes;
                    foreach (XmlElement dwkm in dwkmList)
                    {
                        string time = dwkm.Attributes["time"].Value;
                        string tip = dwkm.Attributes["tip"].Value;
                        if (time.Split(':').Length == 3) //只有包含三个:的才符合规则
                        {
                            //根据trackBar1的位置，确定Label的位置
                            int labelVal = GetIntByTime(time);
                            if (labelVal <= ThisAll)
                            {
                                //为了让滑块显示在点的中央，此处加3处理
                                int X = (int)((float)(labelVal + ExtendWidth) / (float)ThisAll * trackBar1.Right);
                                if (X >= trackBar1.Right) //如果超宽度了，则取最后的值
                                {
                                    X = trackBar1.Right;
                                }
                                //动态增加Label
                                LabelControl label1 = new LabelControl();
                                label1.Appearance.Image = Resource1.white;
                                label1.Size = new System.Drawing.Size(10, 5);
                                label1.Text = " ";
                                label1.ToolTip = tip;
                                label1.Click += new System.EventHandler(this.labelControl2_Click);
                                label1.MouseMove += new MouseEventHandler(lblTip_MouseMove);
                                label1.Location = new System.Drawing.Point(X, 0);
                                this.pointPanel.Controls.Add(label1);

                            }
                        }
                    }
                }
            }
            #endregion

            //播放
            timer1.Start();
            vlc_player_.Play();
            //timer1.Enabled = !timer1.Enabled;
            lblPause.Image = Resource1.暂停;
            lblPause.Tag = "暂停";
            pictureBox1.Visible = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
                vlc_player_.Stop();
                trackBar1.Value = 0;
                timer1.Stop();
                is_playinig_ = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
                if (trackBar1.Value == trackBar1.Maximum) //放完了
                {
                    vlc_player_.Stop();
                    timer1.Stop();
                    //播放完毕后，暂停键变播放键，进度条回归，时间回归
                    lblPause.Image = Resource1.播放;
                    lblPause.Tag = "播放";
                    trackBar1.Value = 0;
                    tbVideoTime.Text = "00:00:00/00:00:00";
                }
                else
                {
                    trackBar1.Value = trackBar1.Value + 1;
                    tbVideoTime.Text = string.Format("{0}/{1}",
                        GetTimeString(trackBar1.Value),
                        GetTimeString(trackBar1.Maximum));
                }
            }
        }

        /// <summary>
        /// 由数值得出时间
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string GetTimeString(int val)
        {
            int hour = val / 3600;
            val %= 3600;
            int minute = val / 60;
            int second = val % 60;
            return string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);
        }
        /// <summary>
        /// 由时间得出数值
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private int GetIntByTime(string time)
        {
            int Val = 0;
            string[] ArrTime = time.Split(':');
            if (ArrTime.Length == 3)
            {
                Val = Convert.ToInt16(ArrTime[0]) * 3600 + Convert.ToInt16(ArrTime[1]) * 60 + Convert.ToInt16(ArrTime[2]);
            }
            return Val;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
                vlc_player_.SetPlayTime(trackBar1.Value);
                trackBar1.Value = (int)vlc_player_.GetPlayTime();
            }
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            if (is_playinig_)
            {
                int barlength = trackBar1.Right - trackBar1.Left;
                trackBar1.Value = (int)((float)e.X / (float)barlength * ThisAll);
                vlc_player_.SetPlayTime(trackBar1.Value);
                //trackBar1.Value = (int)vlc_player_.GetPlayTime();
            }
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {
            LabelControl label = (LabelControl)sender;
            if (is_playinig_)
            {
                int barlength = trackBar1.Right - trackBar1.Left;
                //再减掉，添加label时加的时间宽度
                trackBar1.Value = (int)((float)(label.Left) / (float)barlength * ThisAll) - ExtendWidth;
                vlc_player_.SetPlayTime(trackBar1.Value);
                //trackBar1.Value = (int)vlc_player_.GetPlayTime();
            }
        }


        private void lblClose_Click(object sender, EventArgs e)
        {
            FormClose();
            this.Parent.Visible = false;
            this.Close();
        }
        //外部的关闭窗口方法
        public void FormClose()
        {
            if (is_playinig_)
            {
                vlc_player_.Stop();
                trackBar1.Value = 0;
                timer1.Stop();
                is_playinig_ = false;
            }
        }
        private void lblClose_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as Label).Cursor = Cursors.Hand;
        }
        private void lblTip_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as LabelControl).Cursor = Cursors.Hand;
        }


        /// <summary>
        ///  播放暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblPause_Click(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
                if (lblPause.Tag.ToString() == "暂停")
                {
                    vlc_player_.Pause();
                    timer1.Enabled = !timer1.Enabled;
                    lblPause.Image = Resource1.播放;
                    lblPause.Tag = "播放";
                    //根据当前播放窗口的大小，重新设置暂停按钮的位置
                    pictureBox1.Location = new Point(panel1.Width / 2 - 100, panel1.Height / 2 - 80);
                    pictureBox1.Visible = true;
                }
                else if (lblPause.Tag.ToString() == "播放")
                {
                    vlc_player_.Play();
                    timer1.Enabled = !timer1.Enabled;
                    lblPause.Image = Resource1.暂停;
                    lblPause.Tag = "暂停";
                    pictureBox1.Visible = false;
                }
            }
        }

        /// <summary>
        /// 上一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblPrev_Click(object sender, EventArgs e)
        {
            string filepath = videoPath.Substring(0, videoPath.LastIndexOf('\\') + 1);
            string[] filenames = Directory.GetFiles(filepath);
            for (int i = 0; i < filenames.Length; i++)
            {
                if (filenames[i].ToLower().Equals(videoPath.ToLower()))
                {
                    if (i > 0)
                    {
                        videoPath = filenames[i - 1];
                        //获取后缀名，此处没用到，先放着吧
                        string prefix = videoPath.Substring(videoPath.LastIndexOf('.'), videoPath.Length - videoPath.LastIndexOf('.'));
                        VideoPlay(videoPath);
                        break;
                    }
                    else
                    {
                        MessageBox.Show("没有上一个视频啦！");
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 下一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblNext_Click(object sender, EventArgs e)
        {
            string filepath = videoPath.Substring(0, videoPath.LastIndexOf('\\') + 1);
            string[] filenames = Directory.GetFiles(filepath);
            for (int i = 0; i < filenames.Length; i++)
            {
                if (filenames[i].ToLower().Equals(videoPath.ToLower()))
                {
                    if ((i + 1) < filenames.Length)
                    {
                        videoPath = filenames[i + 1];
                        VideoPlay(videoPath);
                        break;
                    }
                    else
                    {
                        MessageBox.Show("没有下一个视频啦！");
                        break;
                    }
                }
            }
        }
        //停止
        private void lblStop_Click(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
                vlc_player_.Stop();
                timer1.Stop();
                //播放完毕后，暂停键变播放键，进度条回归，时间回归
                lblPause.Image = Resource1.播放;
                lblPause.Tag = "播放";
                trackBar1.Value = 0;
                tbVideoTime.Text = "00:00:00/00:00:00";
            }
        }
        private void trackBarEx1_Scroll(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
                vlc_player_.SetVolume(trackBarVolume.Value);
                trackBarVolume.Value = (int)vlc_player_.GetVolume();
                Volume = trackBarVolume.Value; //记录当前音量
            }

        }

        private void lblRadio_Click(object sender, EventArgs e)
        {
            //静音
            if (lblRadio.Tag.ToString() == "声音")
            {
                lblRadio.Image = Resource1.静音;
                lblRadio.Tag = "静音";
                Volume = trackBarVolume.Value;
                vlc_player_.SetVolume(trackBarVolume.Minimum);
                trackBarVolume.Value = (int)vlc_player_.GetVolume();
            }
            else if (lblRadio.Tag.ToString() == "静音")
            {
                lblRadio.Image = Resource1.声音;
                lblRadio.Tag = "声音";
                vlc_player_.SetVolume(Volume);
                trackBarVolume.Value = (int)vlc_player_.GetVolume();
            }
        }
        /// <summary>
        /// 声音点击滚动条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarVolume_MouseDown(object sender, MouseEventArgs e)
        {
            if (is_playinig_)
            {
                int barlength = trackBarVolume.Right - trackBarVolume.Left;
                trackBarVolume.Value = (int)((float)e.X / (float)barlength * 100);
                if (trackBarVolume.Value > 0) //声音图片切换
                {
                    lblRadio.Image = Resource1.声音;
                    lblRadio.Tag = "声音";
                }
                vlc_player_.SetVolume(trackBarVolume.Value);

            }
        }

        // 使用不安全的指针
        // 返回不透明的图片路径
        private unsafe GraphicsPath NoteGraphicsPath(Image image)
        {
            if (image == null)
                return null;

            // 声明GraphicsPath类以便计算位图路径
            GraphicsPath graphicsPath = new GraphicsPath(FillMode.Alternate);
            Bitmap bitmap = new Bitmap(image);

            int picWidth = bitmap.Width;
            int picHeight = bitmap.Height;

            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, picWidth, picHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            byte* point = (byte*)bitmapdata.Scan0;
            int offset = bitmapdata.Stride - picWidth * 3;
            int p0, p1, p2;
            p0 = point[0];
            p1 = point[1];
            p2 = point[2];
            int start = -1;

            for (int h = 0; h < picHeight; h++)
            {
                for (int x = 0; x < picWidth; x++)
                {
                    // 如果之前的点没有不透明且不透明   
                    if (start == -1 && (point[0] != p0 || point[1] != p1 || point[2] != p2))
                    {
                        start = x;
                    }
                    else if (start > -1 && (point[0] == p0 && point[1] == p1 && point[2] == p2))
                    {
                        // 如果之前的点是不透明
                        graphicsPath.AddRectangle(new Rectangle(start, h, x - start - 1, 1));
                        start = -1;
                    }

                    // 如果之前的点是不透明且是最后一个点  
                    if (x == picWidth - 1 && start > -1)
                    {
                        graphicsPath.AddRectangle(new Rectangle(start, h, x - start + 1, 1));
                        start = -1;
                    }

                    point += 3;
                }

                point += offset;
            }

            bitmap.UnlockBits(bitmapdata);
            bitmap.Dispose();

            return graphicsPath;
        }

        /// <summary>
        /// 需要设置透明效果的控件调用该方法
        /// </summary>
        /// <param name="control">要设置透明效果的控件</param>
        /// <param name="image">控件的图片</param>
        public void SetPictureBoxTransparent(Control control, Image image)
        {
            GraphicsPath graphic = null;
            graphic = NoteGraphicsPath(image);

            if (graphic == null)
                return;

            control.Region = new Region(graphic);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
                vlc_player_.Play();
                timer1.Enabled = !timer1.Enabled;
                lblPause.Image = Resource1.暂停;
                lblPause.Tag = "暂停";
                pictureBox1.Visible = false;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Cursor = Cursors.Hand;
        }

        private void trackBar1_MouseMove(object sender, MouseEventArgs e)
        {
            TrackBarEx trackBar = sender as TrackBarEx;
            trackBar.Cursor = Cursors.Hand;
        }





    }
}
