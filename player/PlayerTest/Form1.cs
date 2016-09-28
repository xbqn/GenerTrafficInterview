using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vlc.net;

namespace PlayerTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FirstForm form = new FirstForm();
            form.ShowDialog();
        }
    }
}
