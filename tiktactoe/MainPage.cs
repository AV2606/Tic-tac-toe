using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tiktactoe
{
    public partial class MainPage : Form
    {
        public PictureBox BackGroundGif;
        public MainPage()
        {
            InitializeComponent();
            BackGroundGif = new PictureBox();
            string ParentFolderPath = Environment.CurrentDirectory;
            ParentFolderPath=ParentFolderPath.Substring(0,ParentFolderPath.LastIndexOf("\\"));
            ParentFolderPath = ParentFolderPath.Substring(0, ParentFolderPath.LastIndexOf("\\"));
            string BGURL = ParentFolderPath + "\\Properties\\backGround.gif";
            BackGroundGif.Image = Image.FromFile(BGURL);
            this.Controls.Add(BackGroundGif);//Essential
            BackGroundGif.SendToBack();
            BackGroundGif.Size = this.Size;
            BackGroundGif.SizeMode = PictureBoxSizeMode.StretchImage;
            CC<object>.CenterVertical(easyBtn);
            CC<object>.CenterVertical(interBtn);
            CC<object>.CenterVertical(expertBtn);
            CC<object>.CenterVertical(pvpBtn);
            CC<object>.CenterVertical(StartNewGameLabel);
            this.Text = "Menu";
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void StartNewGameLabel_Click(object sender, EventArgs e)
        {

        }

        private void easyBtn_Click(object sender, EventArgs e)
        {
            var prevWS = this.WindowState;
           // this.WindowState = FormWindowState.Minimized;
            GameForm game = new GameForm(Difficulity.easy);
            game.ShowDialog();
            WindowState = prevWS;
        }

        private void interBtn_Click(object sender, EventArgs e)
        {
            var prevWS = this.WindowState;
            //this.WindowState = FormWindowState.Minimized;
            GameForm game = new GameForm(Difficulity.medium);
            game.ShowDialog();
            WindowState = prevWS;
        }

        private void expertBtn_Click(object sender, EventArgs e)
        {
            var prevWS = this.WindowState;
         //   this.WindowState = FormWindowState.Minimized;
            GameForm game = new GameForm(Difficulity.hard);
            game.ShowDialog();
            WindowState = prevWS;
        }

        private void pvpBtn_Click(object sender, EventArgs e)
        {
            var prevWS = this.WindowState;
         //   this.WindowState = FormWindowState.Minimized;
            GameForm game = new GameForm(Difficulity.pvp);
            game.ShowDialog();
            WindowState = prevWS;
        }
    }
}
