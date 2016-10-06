using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using vlc.net;


namespace GenerTrafficInterview
{
    public partial class Form1 : Form
    {
        VideoPlayerForm form;
        PictureBox pbMain;
        public Form1()
        {
            InitializeComponent();
            labelControlbiaoti.Text = "依维柯NJ2046型1.5吨越野汽车操作使用多媒体教程";
            //开始视频
            //FirstForm firstForm = new FirstForm();
            //firstForm.WindowState = FormWindowState.Maximized;
            //firstForm.TopMost = true;
            //firstForm.Show();

            //开始图片
            pbMain = new PictureBox();
            pbMain.Image = Resource1.ZhuYeMian;
            pbMain.SizeMode = PictureBoxSizeMode.StretchImage;
            panel_NaviAndNr.Controls.Add(pbMain);
            pbMain.Location = new System.Drawing.Point(0, 0);
            pbMain.Size = panel_NaviAndNr.Size;
            pbMain.Anchor = ((AnchorStyles)(AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom));
            pbMain.BringToFront(); //置于顶层
        }


        private string apppath = Application.StartupPath;
        private string path = string.Empty;
        private void Form1_Load(object sender, EventArgs e)
        {
            loadNavi();
            BindNaviItemEvent();
            this.navBarGroup6.Expanded = false;
            //XmlReadMode("Label_gs");
            setNaviGroupVisible();
            setHeaderVisible();
            setShrink();
            this.Header1.Visible = true;
            this.Header1.Text = "用途";
            this.Header2.Visible = true;
            this.Header2.Text = "基本组成";
            this.Header3.Visible = true;
            this.Header3.Text = "主要战术技术性能";
            //webBrowser1.BeforeNewWindow += new EventHandler<WebBrowserExtendedNavigatingEventArgs>(WebBrowser4_BeforeNewWindow);
            //this.TopMost = true;
            this.Location = new Point(0, 0);
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }
        //加载导航，设置二级导航及其下级的名称
        private void loadNavi()
        {
            setNaviGroupName();
            //setNaviGroupItem();
            setHeaderVisible();
            setNaviGroupVisible();
            //考虑使用配置文件配置？以xml形式匹配ID和caption？
            Header1.MouseLeave += new EventHandler(labelControl_MouseLeave);
            Header2.MouseLeave += new EventHandler(labelControl_MouseLeave);
            Header3.MouseLeave += new EventHandler(labelControl_MouseLeave);
            Header4.MouseLeave += new EventHandler(labelControl_MouseLeave);
            Header5.MouseLeave += new EventHandler(labelControl_MouseLeave);
            Label_gs.MouseLeave += new EventHandler(labelControl_MouseLeave);
            Label_zbgz.MouseLeave += new EventHandler(labelControl_MouseLeave);
            Label_bybg.MouseLeave += new EventHandler(labelControl_MouseLeave);
            Label_jccl.MouseLeave += new EventHandler(labelControl_MouseLeave);
            Label_czsy.MouseLeave += new EventHandler(labelControl_MouseLeave);
            Label_dzjc.MouseLeave += new EventHandler(labelControl_MouseLeave);
            labelControlesc.MouseLeave += new EventHandler(labelControl_MouseLeave);
            labelControlhlp.MouseLeave += new EventHandler(labelControl_MouseLeave);


            Header1.MouseEnter += new EventHandler(labelControl_MouseEnter);
            Header2.MouseEnter += new EventHandler(labelControl_MouseEnter);
            Header3.MouseEnter += new EventHandler(labelControl_MouseEnter);
            Header4.MouseEnter += new EventHandler(labelControl_MouseEnter);
            Header5.MouseEnter += new EventHandler(labelControl_MouseEnter);
            Label_gs.MouseEnter += new EventHandler(labelControl_MouseEnter);
            Label_zbgz.MouseEnter += new EventHandler(labelControl_MouseEnter);
            Label_bybg.MouseEnter += new EventHandler(labelControl_MouseEnter);
            Label_jccl.MouseEnter += new EventHandler(labelControl_MouseEnter);
            Label_czsy.MouseEnter += new EventHandler(labelControl_MouseEnter);
            Label_dzjc.MouseEnter += new EventHandler(labelControl_MouseEnter);
            labelControlesc.MouseEnter += new EventHandler(labelControl_MouseEnter);
            labelControlhlp.MouseEnter += new EventHandler(labelControl_MouseEnter);

            labelControl1.MouseEnter += new EventHandler(labelControl_MouseEnter);
            labelControl2.MouseEnter += new EventHandler(labelControl_MouseEnter);
            labelControl3.MouseEnter += new EventHandler(labelControl_MouseEnter);
            //labelControlhlp.MouseEnter += new EventHandler(labelControl_MouseEnter);


        }
        //header1鼠标移入
        private void labelControl_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        //header1鼠标移出
        private void labelControl_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
        }
        //导航Group设置，共四个
        private void setNaviGroupName()
        {
            string xmlPath = "config\\setting.xml";
            string no = string.Empty;
            string text = string.Empty;
            if (File.Exists(xmlPath))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);
                XmlNode xn = xmlDoc.SelectSingleNode("configuration/title");
                if (xn != null)
                {
                    XmlNodeList dwkmList = xn.ChildNodes;
                    foreach (XmlElement dwkm in dwkmList)
                    {
                        labelControl1.Text = dwkm.Attributes["labelControl1"].Value;
                        labelControl2.Text = dwkm.Attributes["labelControl2"].Value;
                        labelControl3.Text = dwkm.Attributes["labelControl3"].Value;
                        labelControl4.Text = dwkm.Attributes["labelControl4"].Value;
                        labelControl5.Text = dwkm.Attributes["labelControl5"].Value;
                        labelControl6.Text = dwkm.Attributes["labelControl6"].Value;
                        labelControl7.Text = dwkm.Attributes["labelControl7"].Value;
                        labelControl8.Text = dwkm.Attributes["labelControl8"].Value;
                        labelControl9.Text = dwkm.Attributes["labelControl9"].Value;
                        labelControl10.Text = dwkm.Attributes["labelControl10"].Value;
                        labelControl11.Text = dwkm.Attributes["labelControl11"].Value;
                        labelControl12.Text = dwkm.Attributes["labelControl12"].Value;

                        labelControl13.Text = dwkm.Attributes["labelControl13"].Value;
                        labelControl14.Text = dwkm.Attributes["labelControl14"].Value;
                        labelControl15.Text = dwkm.Attributes["labelControl15"].Value;
                        labelControl16.Text = dwkm.Attributes["labelControl16"].Value;
                        labelControl17.Text = dwkm.Attributes["labelControl17"].Value;
                        labelControl18.Text = dwkm.Attributes["labelControl18"].Value;
                        labelControl19.Text = dwkm.Attributes["labelControl19"].Value;
                        labelControl20.Text = dwkm.Attributes["labelControl20"].Value;
                        labelControl21.Text = dwkm.Attributes["labelControl21"].Value;
                        labelControl22.Text = dwkm.Attributes["labelControl22"].Value;


                        labelControl23.Text = dwkm.Attributes["labelControl23"].Value;
                        labelControl24.Text = dwkm.Attributes["labelControl24"].Value;
                        labelControl25.Text = dwkm.Attributes["labelControl25"].Value;
                        labelControl26.Text = dwkm.Attributes["labelControl26"].Value;
                        labelControl27.Text = dwkm.Attributes["labelControl27"].Value;
                        labelControl28.Text = dwkm.Attributes["labelControl28"].Value;
                        labelControl29.Text = dwkm.Attributes["labelControl29"].Value;
                        labelControl30.Text = dwkm.Attributes["labelControl30"].Value;
                        labelControl31.Text = dwkm.Attributes["labelControl31"].Value;
                        labelControl32.Text = dwkm.Attributes["labelControl32"].Value;

                        labelControl33.Text = dwkm.Attributes["labelControl33"].Value;
                        labelControl34.Text = dwkm.Attributes["labelControl34"].Value;
                        labelControl35.Text = dwkm.Attributes["labelControl35"].Value;
                        labelControl36.Text = dwkm.Attributes["labelControl36"].Value;
                        labelControl37.Text = dwkm.Attributes["labelControl37"].Value;
                        labelControl38.Text = dwkm.Attributes["labelControl38"].Value;
                        labelControl39.Text = dwkm.Attributes["labelControl39"].Value;
                        labelControl40.Text = dwkm.Attributes["labelControl40"].Value;

                        labelControl41.Text = dwkm.Attributes["labelControl41"].Value;
                        labelControl42.Text = dwkm.Attributes["labelControl42"].Value;
                        labelControl43.Text = dwkm.Attributes["labelControl43"].Value;
                        labelControl44.Text = dwkm.Attributes["labelControl44"].Value;
                        labelControl45.Text = dwkm.Attributes["labelControl45"].Value;
                        labelControl46.Text = dwkm.Attributes["labelControl46"].Value;
                        labelControl47.Text = dwkm.Attributes["labelControl47"].Value;
                        labelControl48.Text = dwkm.Attributes["labelControl48"].Value;
                        labelControl49.Text = dwkm.Attributes["labelControl49"].Value;
                        labelControl50.Text = dwkm.Attributes["labelControl50"].Value;
                        labelControl51.Text = dwkm.Attributes["labelControl51"].Value;
                        labelControl52.Text = dwkm.Attributes["labelControl52"].Value;
                        labelControl53.Text = dwkm.Attributes["labelControl53"].Value;
                        labelControl54.Text = dwkm.Attributes["labelControl54"].Value;
                        labelControl55.Text = dwkm.Attributes["labelControl55"].Value;

                        //Group设置
                        this.navBarGroup2.Caption = dwkm.Attributes["navBarGroup2"].Value;
                        this.navBarGroup3.Caption = dwkm.Attributes["navBarGroup3"].Value;
                        this.navBarGroup4.Caption = dwkm.Attributes["navBarGroup4"].Value;
                        this.navBarGroup5.Caption = dwkm.Attributes["navBarGroup5"].Value;
                        this.navBarGroup6.Caption = dwkm.Attributes["navBarGroup6"].Value;
                        this.navBarGroup7.Caption = dwkm.Attributes["navBarGroup7"].Value;
                        this.navBarGroup8.Caption = dwkm.Attributes["navBarGroup8"].Value;
                        this.navBarGroup9.Caption = dwkm.Attributes["navBarGroup9"].Value;
                        this.navBarGroup10.Caption = dwkm.Attributes["navBarGroup10"].Value;
                        this.navBarGroup11.Caption = dwkm.Attributes["navBarGroup11"].Value;
                        this.navBarGroup12.Caption = dwkm.Attributes["navBarGroup12"].Value;
                        this.navBarGroup13.Caption = dwkm.Attributes["navBarGroup13"].Value;

                    }
                }
            }


        }
        //导航Item设置，共计20个
        private void setNaviGroupItem()
        {
            //“动力系统”标签设置【供给系统】、【润滑系统】、【冷却系统】、【起动系统】4个三级按钮；
            //“底盘系统”标签设置【传动系统】、【行驶系统】、【转向系统】、【制动系统】4个三级按钮；
            //“车身系统”标签设置【驾驶室】、【座椅布置】、【车厢】、【车架】4个三级按钮；
            //“电器及仪表”标签设置【电源】、【仪表】、【开关】、【保险】4个三级按钮；
            //“附属装置”标签设置【电动绞盘】、【空调系统】、【独立燃油暖风系统】、【牵引装置】、【涉水附件】
            //ITEM设置   动力系统
            this.navBarItem1.Caption = "供给系统";

            this.navBarItem2.Caption = "润滑系统";
            this.navBarItem3.Caption = "冷却系统";
            this.navBarItem4.Caption = "起动系统";
            //ITEM设置   底盘系统
            this.navBarItem5.Caption = "传动系统";
            this.navBarItem6.Caption = "行驶系统";
            this.navBarItem7.Caption = "转向系统";
            this.navBarItem8.Caption = "制动系统";
            //ITEM设置   车身系统
            this.navBarItem9.Caption = "驾驶室";
            this.navBarItem10.Caption = "座椅布置";
            this.navBarItem11.Caption = "车厢";
            this.navBarItem12.Caption = "车架";
            //ITEM设置   电气及仪表系统
            this.navBarItem13.Caption = "电源";
            this.navBarItem14.Caption = "仪表";
            this.navBarItem15.Caption = "开关";
            this.navBarItem16.Caption = "保险";
            //ITEM设置   附属装置
            this.navBarItem17.Caption = "电动绞盘";
            this.navBarItem18.Caption = "空调系统";
            this.navBarItem19.Caption = "独立燃油暖风系统";
            this.navBarItem20.Caption = "牵引装置";
            this.navBarItem21.Caption = "涉水附件";
        }

        //header  设置，内容窗格上的导航
        private void setHeaderVisible()
        {
            this.FL_NR_HEADER.Visible = false;
            this.Header1.Visible = false;
            this.Header2.Visible = false;
            this.Header3.Visible = false;
            this.Header4.Visible = false;
            this.Header5.Visible = false;
            this.Header6.Visible = false;
            this.Header7.Visible = false;
            this.Header8.Visible = false;
        }

        private void setNaviGroupVisible()
        {
            this.panelgsdaohang.Visible = false;

            this.navBarGroupgs.Visible = false;
            this.navBarGroup2.Visible = false;
            this.navBarGroup3.Visible = false;
            this.navBarGroup4.Visible = false;
            this.navBarGroup5.Visible = false;
            this.navBarGroup6.Visible = false;
            this.navBarGroup7.Visible = false;
            this.navBarGroup8.Visible = false;
            this.navBarGroup9.Visible = false;
            this.navBarGroup10.Visible = false;
            this.navBarGroup11.Visible = false;
            this.navBarGroup12.Visible = false;
            this.navBarGroup13.Visible = false;
        }


        //绑定naviItemItemEvent
        private void BindNaviItemEvent()
        {
            //this.esc.Click += new System.EventHandler(this.labelControlesc_Click);
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            this.labelControl2.Click += new System.EventHandler(this.labelControl1_Click);
            this.labelControl3.Click += new System.EventHandler(this.labelControl1_Click);
            this.labelControl4.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl5.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl6.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl7.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl8.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl9.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl10.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl11.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl12.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl13.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl14.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl15.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl16.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl17.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl18.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl19.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl20.Click += new System.EventHandler(this.labelControl1s_Click);

            this.labelControl21.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl22.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl23.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl24.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl25.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl26.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl27.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl28.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl29.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl30.Click += new System.EventHandler(this.labelControl1s_Click);

            this.labelControl31.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl32.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl33.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl34.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl35.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl36.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl37.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl38.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl39.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl40.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl41.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl42.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl43.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl44.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl45.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl46.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl47.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl48.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl49.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl50.Click += new System.EventHandler(this.labelControl1s_Click);

            this.labelControl51.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl52.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl53.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl54.Click += new System.EventHandler(this.labelControl1s_Click);
            this.labelControl55.Click += new System.EventHandler(this.labelControl1s_Click);

            this.Header1.Click += new EventHandler(this.labelControl1_Click);
            this.Header2.Click += new EventHandler(this.labelControl1_Click);
            this.Header3.Click += new EventHandler(this.labelControl1_Click);
            this.Header4.Click += new EventHandler(this.labelControl1_Click);
            this.Header5.Click += new EventHandler(this.labelControl1_Click);
            this.Header6.Click += new EventHandler(this.labelControl1_Click);
            this.Header7.Click += new EventHandler(this.labelControl1_Click);
            this.Header8.Click += new EventHandler(this.labelControl1_Click);
        }

        //全部折叠
        private void setShrink()
        {
            this.navBarGroup1.Expanded = false;
            this.navBarGroup2.Expanded = false;
            this.navBarGroup3.Expanded = false;
            this.navBarGroup4.Expanded = false;
            this.navBarGroup5.Expanded = false;
            this.navBarGroup6.Expanded = false;
            this.navBarGroup7.Expanded = false;
            this.navBarGroup8.Expanded = false;
            this.navBarGroup9.Expanded = false;
            this.navBarGroup10.Expanded = false;
            this.navBarGroup11.Expanded = false;
            this.navBarGroup12.Expanded = false;
            this.navBarGroup13.Expanded = false;
        }
        //根据控件id指定webBrowser的绑定内容
        private void XmlReadMode(string ControllerID)
        {
            switch (ControllerID)
            {
                case "navBarItem1":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem2":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem3":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem4":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem5":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem6":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem7":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem8":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem9":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem10":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem11":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem12":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem13":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem14":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem15":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem16":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem17":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem18":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem19":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem20":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "navBarItem21":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "Label_gs":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "Label_zbgz":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "Label_bybg":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "Label_jccl":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "Label_czsy":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "Label_dzjc":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "Header1":
                    path = apppath + "\\htm\\1.htm";
                    break;
                case "Header2":
                    path = apppath + "\\htm\\2.htm";
                    break;
                case "Header3":
                    path = apppath + "\\htm\\3.htm";
                    break;
                case "Header4":
                    path = apppath + "\\htm\\4.htm";
                    break;
                case "Header5":
                    path = apppath + "\\htm\\5.htm";
                    break;
                default:
                    break;
            }
        }

        private void labelControl9_Click(object sender, EventArgs e)
        {
            XmlReadMode("Header1");
            //extWebBrowser1.Navigate(path);
        }
        private void labelControl10_Click(object sender, EventArgs e)
        {
            XmlReadMode("Header2");
            //extWebBrowser1.Navigate(path);
        }

        private void labelControlesc_Click(object sender, EventArgs e)
        {
            if (form != null)
            {
                form.FormClose();
            }
            this.Close();
        }

        private void extWebBrowser1_BeforeNavigate(object sender, WebBrowserExtendedNavigatingEventArgs e)
        {
            if (e.Url.ToLower().IndexOf(".wmv") > 0 || e.Url.ToLower().IndexOf(".mp4") > 0 || e.Url.ToLower().IndexOf(".mov") > 0)
            {
                e.Cancel = true;
                string names = e.Url.Substring(e.Url.LastIndexOf("/") + 1);
                names = names.Substring(names.LastIndexOf("\\") + 1);

                vlc.net.VideoPlayerForm form = new vlc.net.VideoPlayerForm();

                form.videoName = names;
                form.TopLevel = false;  //非顶级控件
                panelPlayer.Controls.Add(form);
                panelPlayer.Visible = true;
                form.Dock = DockStyle.Fill;
                form.Show();
                form.Parent = panelPlayer;
            }
            else
            {

            }
        }


        //private void navBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    //setImgforNavi();
        //    DevExpress.XtraNavBar.NavBarItem GenerNaviItem = (sender as DevExpress.XtraNavBar.NavBarItem);
        //    //GenerNaviItem.SmallImage = Resource1.selected;
        //    XmlReadMode(GenerNaviItem.Name);
        //    if (GenerNaviItem.Name.Equals("navBarItem1"))
        //    {

        //        extWebBrowser1.Navigate(path);
        //    }
        //}

        #region  暂定注释

        //private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    setImgforNavi();
        //    this.navBarItem1.SmallImage = Resource1._32;
        //    //   this.Header1.Visible = true;
        //    // this.Header2.Visible = true;
        //    XmlReadMode("navBarItem1");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    setImgforNavi();
        //    this.navBarItem2.SmallImage = Resource1._32;
        //    //  this.Header3.Visible = true;
        //    XmlReadMode("navBarItem2");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    // this.Header4.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem3.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem3");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    // this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem4.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem4");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //   // this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem5.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem5");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem6.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem6");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem7.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem7");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem8.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem8");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem9.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem9");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem10.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem10");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem11.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem11");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem12.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem12");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem13.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem13");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem14.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem14");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem15.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem15");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem16.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem16");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem17.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem17");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem18.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem18");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem19_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem19.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem19");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem20.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem20");
        //    //extWebBrowser1.Navigate(path);
        //}
        //private void navBarItem21_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        //{
        //    setHeaderVisible();
        //    //this.Header5.Visible = true;
        //    setImgforNavi();
        //    this.navBarItem21.SmallImage = Resource1._32;
        //    XmlReadMode("navBarItem21");
        //    //extWebBrowser1.Navigate(path);
        //}
        #endregion

        private void Label_gs_Click(object sender, EventArgs e)
        {
            //开始图片隐藏
            pbMain.Visible = false;
            if (form == null) //加载视频
            {
                form = new vlc.net.VideoPlayerForm();

                form.TopLevel = false;  //非顶级控件
                panelPlayer.Controls.Add(form);
                panelPlayer.Visible = true;
                form.Dock = DockStyle.Fill;
                form.Show();
                form.Parent = panelPlayer;
            }
            //先设置颜色
            Label_gs.ForeColor = Color.White;
            Label_gs.Appearance.Image = Resource1.yiji2;
            Label_zbgz.ForeColor = Color.Black;
            Label_zbgz.Appearance.Image = Resource1.yiji1;
            Label_bybg.ForeColor = Color.Black;
            Label_bybg.Appearance.Image = Resource1.yiji1;
            Label_jccl.ForeColor = Color.Black;
            Label_jccl.Appearance.Image = Resource1.yiji1;
            Label_czsy.ForeColor = Color.Black;
            Label_czsy.Appearance.Image = Resource1.yiji1;

            XmlReadMode("Label_gs");
            setNaviGroupVisible();
            setHeaderVisible();
            this.panelgsdaohang.Visible = true;

            //this.Header1.Visible = true;
            //this.Header1.Text = "用途";
            //this.Header2.Visible = true;
            //this.Header2.Text = "基本组成";
            //this.Header3.Visible = true;
            //this.Header3.Text = "主要战术技术性能";

        }


        private void Label_zbgz_Click(object sender, EventArgs e)
        {
            //开始图片隐藏
            pbMain.Visible = false;
            if (form == null) //加载视频
            {
                form = new vlc.net.VideoPlayerForm();

                form.TopLevel = false;  //非顶级控件
                panelPlayer.Controls.Add(form);
                panelPlayer.Visible = true;
                form.Dock = DockStyle.Fill;
                form.Show();
                form.Parent = panelPlayer;
            }

            Label_zbgz.ForeColor = Color.White;
            Label_zbgz.Appearance.Image = Resource1.yiji2;
            Label_gs.ForeColor = Color.Black;
            Label_gs.Appearance.Image = Resource1.yiji1;
            Label_bybg.ForeColor = Color.Black;
            Label_bybg.Appearance.Image = Resource1.yiji1;
            Label_jccl.ForeColor = Color.Black;
            Label_jccl.Appearance.Image = Resource1.yiji1;
            Label_czsy.ForeColor = Color.Black;
            Label_czsy.Appearance.Image = Resource1.yiji1;

            setShrink();//全部折叠
            XmlReadMode("Label_zbgz");
            setNaviGroupVisible();
            setHeaderVisible();
            this.navBarGroup2.Visible = true;
            this.navBarGroup3.Visible = true;
            this.navBarGroup4.Visible = true;
            this.navBarGroup5.Visible = true;
            this.navBarGroup6.Visible = true;
            //extWebBrowser1.Navigate(path);
        }

        private void Label_bybg_Click(object sender, EventArgs e)
        {
            //开始图片隐藏
            pbMain.Visible = false;
            if (form == null) //加载视频
            {
                form = new vlc.net.VideoPlayerForm();

                form.TopLevel = false;  //非顶级控件
                panelPlayer.Controls.Add(form);
                panelPlayer.Visible = true;
                form.Dock = DockStyle.Fill;
                form.Show();
                form.Parent = panelPlayer;
            }

            Label_bybg.ForeColor = Color.White;
            Label_bybg.Appearance.Image = Resource1.yiji2;
            Label_gs.ForeColor = Color.Black;
            Label_gs.Appearance.Image = Resource1.yiji1;
            Label_zbgz.ForeColor = Color.Black;
            Label_zbgz.Appearance.Image = Resource1.yiji1;
            Label_jccl.ForeColor = Color.Black;
            Label_jccl.Appearance.Image = Resource1.yiji1;
            Label_czsy.ForeColor = Color.Black;
            Label_czsy.Appearance.Image = Resource1.yiji1;

            setShrink();
            XmlReadMode("Label_bybg");
            setNaviGroupVisible();
            setHeaderVisible();
            this.navBarGroup7.Visible = true;
            this.navBarGroup8.Visible = true;
            //extWebBrowser1.Navigate(path);
        }

        private void Label_jccl_Click(object sender, EventArgs e)
        {
            //开始图片隐藏
            pbMain.Visible = false;
            if (form == null) //加载视频
            {
                form = new vlc.net.VideoPlayerForm();

                form.TopLevel = false;  //非顶级控件
                panelPlayer.Controls.Add(form);
                panelPlayer.Visible = true;
                form.Dock = DockStyle.Fill;
                form.Show();
                form.Parent = panelPlayer;
            }

            Label_jccl.ForeColor = Color.White;
            Label_jccl.Appearance.Image = Resource1.yiji2;
            Label_gs.ForeColor = Color.Black;
            Label_gs.Appearance.Image = Resource1.yiji1;
            Label_zbgz.ForeColor = Color.Black;
            Label_zbgz.Appearance.Image = Resource1.yiji1;
            Label_bybg.ForeColor = Color.Black;
            Label_bybg.Appearance.Image = Resource1.yiji1;
            Label_czsy.ForeColor = Color.Black;
            Label_czsy.Appearance.Image = Resource1.yiji1;


            setShrink();
            XmlReadMode("Label_jccl");
            setNaviGroupVisible();
            setHeaderVisible();
            this.navBarGroup9.Visible = true;
            this.navBarGroup10.Visible = true;
            //extWebBrowser1.Navigate(path);
        }

        private void Label_czsy_Click(object sender, EventArgs e)
        {
            //开始图片隐藏
            pbMain.Visible = false;
            if (form == null) //加载视频
            {
                form = new vlc.net.VideoPlayerForm();

                form.TopLevel = false;  //非顶级控件
                panelPlayer.Controls.Add(form);
                panelPlayer.Visible = true;
                form.Dock = DockStyle.Fill;
                form.Show();
                form.Parent = panelPlayer;
            }

            Label_czsy.ForeColor = Color.White;
            Label_czsy.Appearance.Image = Resource1.yiji2;
            Label_gs.ForeColor = Color.Black;
            Label_gs.Appearance.Image = Resource1.yiji1;
            Label_zbgz.ForeColor = Color.Black;
            Label_zbgz.Appearance.Image = Resource1.yiji1;
            Label_bybg.ForeColor = Color.Black;
            Label_bybg.Appearance.Image = Resource1.yiji1;
            Label_jccl.ForeColor = Color.Black;
            Label_jccl.Appearance.Image = Resource1.yiji1;


            setShrink();
            XmlReadMode("Label_czsy");
            setNaviGroupVisible();
            setHeaderVisible();
            this.navBarGroup11.Visible = true;
            this.navBarGroup12.Visible = true;
            this.navBarGroup13.Visible = true;

            //extWebBrowser1.Navigate(path);
        }

        //按钮按下之后
        private void labelControlState()
        {
            labelControl4.Appearance.Image = Resource1.anniu1;

            labelControl6.Appearance.Image = Resource1.anniu1;
            labelControl5.Appearance.Image = Resource1.anniu1;

            labelControl7.Appearance.Image = Resource1.anniu1;
            labelControl11.Appearance.Image = Resource1.anniu1;
            labelControl10.Appearance.Image = Resource1.anniu1;
            labelControl9.Appearance.Image = Resource1.anniu1;
            labelControl8.Appearance.Image = Resource1.anniu1;
            labelControl12.Appearance.Image = Resource1.anniu1;
            labelControl13.Appearance.Image = Resource1.anniu1;
            labelControl14.Appearance.Image = Resource1.anniu1;
            labelControl15.Appearance.Image = Resource1.anniu1;
            labelControl16.Appearance.Image = Resource1.anniu1;
            labelControl17.Appearance.Image = Resource1.anniu1;
            labelControl18.Appearance.Image = Resource1.anniu1;
            labelControl19.Appearance.Image = Resource1.anniu1;
            labelControl20.Appearance.Image = Resource1.anniu1;
            labelControl21.Appearance.Image = Resource1.anniu1;
            labelControl22.Appearance.Image = Resource1.anniu1;
            labelControl23.Appearance.Image = Resource1.anniu1;
            labelControl24.Appearance.Image = Resource1.anniu1;
            labelControl25.Appearance.Image = Resource1.anniu1;
            labelControl26.Appearance.Image = Resource1.anniu1;
            labelControl27.Appearance.Image = Resource1.anniu1;
            labelControl28.Appearance.Image = Resource1.anniu1;
            labelControl29.Appearance.Image = Resource1.anniu1;
            labelControl30.Appearance.Image = Resource1.anniu1;
            labelControl31.Appearance.Image = Resource1.anniu1;
            labelControl32.Appearance.Image = Resource1.anniu1;
            labelControl33.Appearance.Image = Resource1.anniu1;
            labelControl34.Appearance.Image = Resource1.anniu1;
            labelControl35.Appearance.Image = Resource1.anniu1;
            labelControl36.Appearance.Image = Resource1.anniu1;
            labelControl37.Appearance.Image = Resource1.anniu1;
            labelControl38.Appearance.Image = Resource1.anniu1;
            labelControl39.Appearance.Image = Resource1.anniu1;
            labelControl40.Appearance.Image = Resource1.anniu1;
            labelControl41.Appearance.Image = Resource1.anniu1;
            labelControl42.Appearance.Image = Resource1.anniu1;
            labelControl43.Appearance.Image = Resource1.anniu1;
            labelControl44.Appearance.Image = Resource1.anniu1;
            labelControl45.Appearance.Image = Resource1.anniu1;
            labelControl46.Appearance.Image = Resource1.anniu1;
            labelControl47.Appearance.Image = Resource1.anniu1;
            labelControl48.Appearance.Image = Resource1.anniu1;
            labelControl49.Appearance.Image = Resource1.anniu1;
            labelControl50.Appearance.Image = Resource1.anniu1;
            labelControl51.Appearance.Image = Resource1.anniu1;
            labelControl52.Appearance.Image = Resource1.anniu1;
            labelControl53.Appearance.Image = Resource1.anniu1;
            labelControl54.Appearance.Image = Resource1.anniu1;
            labelControl55.Appearance.Image = Resource1.anniu1;

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            //labelControl1.Image = Resource1.anxia;
            DevExpress.XtraEditors.LabelControl GenerNaviItem = (sender as DevExpress.XtraEditors.LabelControl);
            //labelControlState();
            //GenerNaviItem.Appearance.Image = Resource1.anxia;

            form.Play("Video\\" + GenerNaviItem.Text.Trim() + ".mov");
            form.videoName = GenerNaviItem.Text.Trim() + ".mov";
        }

        private void labelControl1s_Click(object sender, EventArgs e)
        {
            //labelControl1.Image = Resource1.anxia;
            DevExpress.XtraEditors.LabelControl GenerNaviItem = (sender as DevExpress.XtraEditors.LabelControl);
            labelControlState();
            GenerNaviItem.Appearance.Image = Resource1.anxia;
            switch (GenerNaviItem.Name)
            {
                case "labelControl7":
                    setHeaderVisible();
                    this.FL_NR_HEADER.Visible = true;
                    Header1.Visible = true;
                    Header2.Visible = true;
                    Header1.Text = "燃油供给系统";
                    Header2.Text = "进排气系统";
                    break;
                case "labelControl12":
                    setHeaderVisible();
                    this.FL_NR_HEADER.Visible = true;
                    Header1.Visible = true;
                    Header2.Visible = true;
                    Header3.Visible = true;
                    Header4.Visible = true;
                    Header1.Text = "车桥";
                    Header2.Text = "车轮";
                    Header3.Text = "轮胎";
                    Header4.Text = "悬架";
                    break;
                case "labelControl14":
                    setHeaderVisible();
                    this.FL_NR_HEADER.Visible = true;
                    Header1.Visible = true;
                    Header2.Visible = true;

                    Header1.Text = "行车制动";
                    Header2.Text = "驻车制动装置";
                    break;
                case "labelControl19":
                    setHeaderVisible();
                    this.FL_NR_HEADER.Visible = true;
                    Header1.Visible = true;
                    Header2.Visible = true;
                    Header1.Text = "蓄电池";
                    Header2.Text = "发电机";
                    break;
                case "labelControl28":
                    setHeaderVisible();
                    this.FL_NR_HEADER.Visible = true;
                    Header1.Visible = true;
                    Header2.Visible = true;
                    Header3.Visible = true;
                    Header4.Visible = true;
                    Header5.Visible = true;
                    Header1.Text = "日常保养";
                    Header2.Text = "一级保养";
                    Header3.Text = "换季保养";
                    Header4.Text = "停驶车保养";
                    Header5.Text = "一期保养";
                    break;
                case "labelControl29":
                    setHeaderVisible();
                    this.FL_NR_HEADER.Visible = true;
                    Header1.Visible = true;
                    Header2.Visible = true;
                    Header3.Visible = true;
                    Header4.Visible = true;
                    Header5.Visible = true;
                    Header1.Text = "检查燃油";
                    Header2.Text = "检查与更换机油";
                    Header3.Text = "检查动力转向油";
                    Header4.Text = "检查制动液";
                    Header5.Text = "检查冷却液";
                    break;
                case "labelControl30":
                    setHeaderVisible();
                    this.FL_NR_HEADER.Visible = true;
                    Header1.Visible = true;
                    Header2.Visible = true;
                    Header1.Text = "固定车场停放";
                    Header2.Text = "临时车场停放";
                    break;
                case "labelControl31":
                    setHeaderVisible();
                    this.FL_NR_HEADER.Visible = true;
                    Header1.Visible = true;
                    Header2.Visible = true;
                    Header1.Text = "封存方式";
                    Header2.Text = "封存项目、方法与要求";
                    break;
                case "labelControl32":
                    setHeaderVisible();
                    this.FL_NR_HEADER.Visible = true;
                    Header1.Visible = true;
                    Header2.Visible = true;
                    Header3.Visible = true;
                    Header1.Text = "启封方式";
                    Header2.Text = "启封工作程序";
                    Header3.Text = "紧急启封工作程序";
                    break;
                case "labelControl41":
                    setHeaderVisible();
                    this.FL_NR_HEADER.Visible = true;
                    Header1.Visible = true;
                    Header2.Visible = true;
                    Header3.Visible = true;
                    Header1.Text = "发动机无法起动";
                    Header2.Text = "发动机冒黑烟";
                    Header3.Text = "发动机自行熄火";
                    break;
                case "labelControl42":
                    setHeaderVisible();
                    this.FL_NR_HEADER.Visible = true;
                    Header1.Visible = true;
                    Header2.Visible = true;
                    Header3.Visible = true;
                    Header4.Visible = true;
                    Header5.Visible = true;
                    Header6.Visible = true;
                    Header1.Text = "转向沉重";
                    Header2.Text = "制动拖滞、制动鼓发烫";
                    Header3.Text = "制动器有异响";
                    Header4.Text = "汽车偏驶";
                    Header5.Text = "轮胎磨损过快";
                    Header6.Text = "轮胎磨损不均";
                    break;
                case "labelControl43":
                    setHeaderVisible();
                    this.FL_NR_HEADER.Visible = true;
                    Header1.Visible = true;
                    Header2.Visible = true;
                    Header3.Visible = true;
                    Header4.Visible = true;
                    Header5.Visible = true;
                    Header1.Text = "全车无电";
                    Header2.Text = "起动机不工作";
                    Header3.Text = "发电机不发电";
                    Header4.Text = "前照灯不亮";
                    Header5.Text = "制动灯不亮";
                    break;
                default:
                    setHeaderVisible();
                    if (form == null)
                    {
                        form = new vlc.net.VideoPlayerForm();

                        form.TopLevel = false;  //非顶级控件
                        panelPlayer.Controls.Add(form);
                        panelPlayer.Visible = true;
                        form.Dock = DockStyle.Fill;
                        form.Show();
                        form.Parent = panelPlayer;
                    }
                    form.Play("Video\\" + GenerNaviItem.Text.Trim() + ".mov");
                    form.videoName = GenerNaviItem.Text.Trim() + ".mov";
                    break;
            }
        }

        
       /// <summary>
       /// 鼠标左键单击菜单功能组的时候展开对应组
       /// </summary>
        private void navBarControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DevExpress.XtraNavBar.NavBarControl navBar = sender as DevExpress.XtraNavBar.NavBarControl;
                DevExpress.XtraNavBar.NavBarHitInfo hitInfo = navBar.CalcHitInfo(new Point(e.X, e.Y));
                if (hitInfo.InGroupCaption && !hitInfo.InGroupButton)
                    hitInfo.Group.Expanded = !hitInfo.Group.Expanded;
            }
        }
        /// <summary>
        /// 鼠标进入菜单功能组上面的时候变成手状样式
        /// </summary>
        private void navBarControl1_MouseMove(object sender, MouseEventArgs e)
        {
            DevExpress.XtraNavBar.NavBarControl navBar = sender as DevExpress.XtraNavBar.NavBarControl;
            DevExpress.XtraNavBar.NavBarHitInfo hitInfo = navBar.CalcHitInfo(new Point(e.X, e.Y));
            if (hitInfo.InGroupCaption && !hitInfo.InGroupButton)
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;
        }


    }
}
