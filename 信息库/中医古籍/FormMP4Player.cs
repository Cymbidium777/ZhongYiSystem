using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 中医信息管理系统.entity;

namespace 中医信息管理系统
{
    public partial class FormMP4Player : Form
    {
        string n;
        public FormMP4Player(string num)
        {
            InitializeComponent();
            n = num;
        }

        private void FormMP4Player_Load(object sender, EventArgs e)
        {
            Text = JingMai.Current.JingMaiName;
            MediaPlayer.URL = @"C:\Program Files (x86)\ZYS\video\" + n + ".mp4";
        }

        private void MediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                MediaPlayer.Ctlcontrols.play();
            }
        }
    }
}
