using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vlc.net
{
    public partial class FirstForm : Form
    {
        private VlcPlayer vlc_player_;
        private int playertime = 0; //播放时间
        private bool is_playinig_ = false;
        public FirstForm()
        {
            InitializeComponent();

            string pluginPath = System.Environment.CurrentDirectory + "\\plugins\\";
            vlc_player_ = new VlcPlayer(pluginPath);
            IntPtr render_wnd = this.panel1.Handle;
            vlc_player_.SetRenderWindow((int)render_wnd);
            //播放视频
            vlc_player_.PlayFile("video\\Wildlife.wmv");
            is_playinig_ = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
                if (playertime == (int)vlc_player_.Duration()) //播放完毕
                {
                    vlc_player_.Stop();
                    timer1.Stop();
                    this.Close();
                    //Form1.
                }
                else
                {
                    playertime++;
                }
            }
        }
    }
}
