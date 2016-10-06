using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace vlc.net
{
    public class PanelEX: Panel 
    {
        public PanelEX()  
        {  
  
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |  
                ControlStyles.Opaque, true);  
            this.BackColor = Color.Transparent;  
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //e.Graphics.DrawString("test", new Font("Tahoma", 8.25f), Brushes.Red, new PointF(20, 20));
        }
        
        //protected override CreateParams CreateParams  
        //{  
        //    get  
        //    {  
        //        CreateParams cp = base.CreateParams;  
        //        cp.ExStyle = 0x20;  
        //        return cp;  
        //    }  
        //}  
    }
}
