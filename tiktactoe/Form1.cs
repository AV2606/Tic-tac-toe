using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tiktactoe
{
    public enum Difficulity { pvp,easy,medium,hard};
    public enum GameStatus { X_turn, O_turn, draw, X_Won,O_won};
    public partial class GameForm : Form
    {
        public GameLogic game { get; private set; }
        public PictureBox[,] cellsP { get; private set; }
        public Image Ximg { get; private set; }
        public Image Oimg { get; private set; }
        public Image clearImg { get; private set; }
        public bool IsXTurn { get; private set; }
        public bool ended { get; private set; }
        public Difficulity difficulity { get; private set; }
        public bool aiThink
        {
            get { return this.Ai.IsThinking; }
        }
        public AI Ai { get; private set; }
        public GameStatus status { get; private set; }
        /// <summary>
        /// Occures when the game finished and give data about the last occupied cell's position and which player has won.
        /// </summary>
        public event EventHandler<GameStatus> GameFinished;

        private Thread AIthread;

        public GameForm(Difficulity difficulity)
        {  
            InitializeComponent();

            Ai = new AI(difficulity);
            status = GameStatus.X_turn;
            this.SizeChanged += (sender, e) => { CenterizeAllControls(); };
            GameFinished += OnGameFinished;
            AIthread = new Thread(AI);

            //Debug waste
            helpL.Enabled = false;
            EasyB.Enabled = false;
            MediumB.Enabled = false;
            HardB.Enabled = false;
            PvPB.Enabled = false;
            ReWriteB.Enabled = false;
            Undo.Enabled = false;

            helpL.Visible = false;
            EasyB.Visible = false;
            MediumB.Visible = false;
            HardB.Visible = false;
            PvPB.Visible = false;
            ReWriteB.Visible = false;
            Undo.Visible = false;
            //end of debug waste

            this.difficulity = difficulity;
            if (Program.Game == null)
                Program.Game = this;
            else
            {
                this.Close();
                this.Dispose();
                return;
            }
            ThreadPool.init();
            CheckForIllegalCrossThreadCalls = false;
            IsXTurn = true;
            ended = false;
            game = new GameLogic();
            cellsP = new PictureBox[3, 3];
            // Box1.Click+= CellClick;
            cellsP[0, 0] = Box1;
            cellsP[0, 1] = Box2;
            cellsP[0, 2] = Box3;
            cellsP[1, 0] = Box4;
            cellsP[1, 1] = Box5;
            cellsP[1, 2] = Box6;
            cellsP[2, 0] = Box7;
            cellsP[2, 1] = Box8;
            cellsP[2, 2] = Box9;
            Ximg = Box1.BackgroundImage;
            Oimg = Box2.BackgroundImage;
            clearImg = Box3.BackgroundImage;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!(i == 0 && j == 0))
                        cellsP[i, j].Click += CellClick;
                }
            }
            Clear();
            PvPB.FlatStyle = FlatStyle.Popup;
            this.FormClosing += (x, y) => {
                if (Program.Game == this)
                    Program.Game = null;
            };
            this.BackColor = Color.Empty;
            this.BackgroundImage = null;
            Color left, right;
            left = Color.Salmon;
            right = Color.DarkViolet;
            if(this.difficulity==Difficulity.easy)
            {
                left = Color.Green;
                right = Color.White;
            }
            if (this.difficulity == Difficulity.medium)
            {
                left = Color.Orange;
                right = Color.Green;
            }
            if (this.difficulity == Difficulity.hard)
            {
                left = Color.Red;
                right = Color.Orange;
            }
            if (this.difficulity == Difficulity.pvp)
            {
                left = Color.Navy;
                right = Color.Red;
            }
            Bitmap bitmap = CreateGradient(left, right, new Tools.Imageing.Resolution(Width, Height));
            this.BackgroundImage = Image.FromHbitmap(bitmap.GetHbitmap());
            CenterizeAllControls();
        }

        private void CenterVertical(object sender, EventArgs e)
        {
            var control = (Control)sender;
            CC<object>.CenterVertical(control);
        }
        private void CenterizeAllControls()
        {
            foreach(Control item in this.Controls)
            {
                CC<object>.CenterVertical(item);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            //VS waste
        }
        /// <summary>
        /// put x or o
        /// </summary>
        /// <param name="sender">pictureBox clicked</param>
        /// <param name="e"></param>
        private void CellClick(object sender, EventArgs e)
        {
            if (aiThink)
                return;
            PictureBox Sender = (PictureBox)sender;
            Position s = Find(Sender);
            helpL.Text = "Position " + s.row + "," + s.col;
            if (!ended)
            {
                if (IsXTurn)
                {
                    if (game.PutX(s))
                    {
                        Sender.BackgroundImage = Ximg;
                        IsXTurn = false;
                        TurnL.Text = "O turn";
                        status = GameStatus.O_turn;
                        if (AIthread.IsAlive==false)
                        {
                            AIthread.Abort();
                            AIthread = new Thread(AI);
                            AIthread.Start();
                        }
                        goto CheckEnd;
                    }
                }
                else
                    if (game.PutO(s))
                {
                    Sender.BackgroundImage = Oimg;
                    IsXTurn = true;
                    TurnL.Text = "X turn";
                    status = GameStatus.X_turn;
                    if (!AIthread.IsAlive)
                    {
                        AIthread.Abort();
                        AIthread = new Thread(AI);
                        AIthread.Start();
                    }
                    goto CheckEnd;
                }
                CheckEnd:
                if (game.IsXWon())
                {
                    Inform("X won!",2500);
                    Msg.ForeColor = Color.FromArgb(255, 255, 0);
                    ended = true;
                    status=GameStatus.X_Won;
                    GameFinished?.Invoke(s, GameStatus.X_Won);
                    return;
                }
                if (game.IsOWon())
                {
                    Inform("O won!",2500);
                    Msg.ForeColor = Color.FromArgb(255, 255, 0);
                    ended = true;
                    GameFinished?.Invoke(s, GameStatus.O_won);
                    status=GameStatus.O_won;
                    return;
                }
                if (game.IsDraw())
                {
                    Inform( "Draw!",2500);
                    Msg.ForeColor = Color.FromArgb(255, 255, 100);
                    ended = true;
                    GameFinished?.Invoke(s, GameStatus.draw);
                    status = GameStatus.draw;
                    return;
                }
                    
            }
            CenterizeAllControls();
        }
        private Bitmap CreateGradient(Color left, Color right, Tools.Imageing.Resolution resolution)
        {
            Tools.Imageing.GenericImage image = new Tools.Imageing.GenericImage(resolution);
            image.GradientLeftRight(left, right);
            return image.ToBitmap();
        }
        private void OnGameFinished(object sender, GameStatus gs)
        {
            Color back = difficulity == Difficulity.easy ? Color.Green :
                difficulity == Difficulity.medium ? Color.Orange :
                difficulity == Difficulity.hard ? Color.Red : Color.Navy;
            if (gs == GameStatus.O_won)
            {
                List<Position> cells;
                new Thread(() =>
                {
                    if (game.IsOWon(out cells))
                    {
                        foreach (var item in cells)
                        {
                            Thread.Sleep(150);
                            this.Invoke(new Action(() =>
                            {
                                cellsP[item.row, item.col].BackColor = back;

                            }));
                        }
                    }
                }).Start();
            }
            if (gs == GameStatus.X_Won)
            {
                List<Position> cells;
                new Thread(() =>
                {
                    if (game.IsXWon(out cells))
                    {
                        foreach (var item in cells)
                        {
                            Thread.Sleep(150);
                            this.Invoke(new Action(() =>
                        {
                            cellsP[item.row, item.col].BackColor = back;

                        }));
                        }
                    }
                }).Start();
            }
        }
        /// <summary>
        /// Returns the location of the <see cref="PictureBox"/> <paramref name="picture"/> center.
        /// </summary>
        /// <param name="picture"></param>
        private Point GetCenterLocationOfImage(PictureBox picture)
        {
            Point baseP = picture.Location;
            baseP.X += picture.Width / 2;
            baseP.Y += picture.Height / 2;
            return baseP;
        }
        private Point Add(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
        private Point Sub(Point substructed, Point substracting)
        {
            return new Point(substructed.X - substracting.X, substructed.Y - substracting.Y);
        }
        /// <summary>
        /// Returns the relative location of <paramref name="control"/> which inside the unknown level
        /// parent <paramref name="Grandparent"/>
        /// </summary>
        /// <param name="control">the control</param>
        /// <param name="Grandparent">the grandparent</param>
        /// <returns></returns>
        private Point GetGrandParentRelateLocation(Control control,Control Grandparent)
        {
            Point b = control.Location;
            var parent = control.Parent;
            bool rightGP = false;
            while(!(parent is null)&&!rightGP)
            {
                if (parent == Grandparent)
                    rightGP = true;
                b = Add(b, parent.Location);
            }
            if (rightGP)
                return b;
            return new Point(-1, -1);
        }

        public Position Find(PictureBox p)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cellsP[i, j] == p)
                        return new Position(i, j);
                }
            }
            throw new KeyNotFoundException("The pictureBox is not found.");
        }
        public void Clear()
        {
            game.Clear();
            IsXTurn = true;
            status = GameStatus.X_turn;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cellsP[i, j].BackgroundImage = clearImg;
                }
            }
            //Msg.ForeColor = Color.Navy;
            Msg.Text = "";
            TurnL.Text = "X turn";
            foreach(var item in cellsP)
                item.BackColor = Color.Transparent;
        }
        public void difChange(Difficulity d)
        {
            if ((int)difficulity == (int)d)
                return;
            if ((int)difficulity == 0)
                PvPB.FlatStyle = FlatStyle.Standard;
            if ((int)difficulity == 1)
                EasyB.FlatStyle = FlatStyle.Standard;
            if ((int)difficulity == 2)
                MediumB.FlatStyle = FlatStyle.Standard;
            if ((int)difficulity == 3)
                HardB.FlatStyle = FlatStyle.Standard;
            if (d==Difficulity.pvp)
            {
                difficulity = Difficulity.pvp;
                PvPB.FlatStyle = FlatStyle.Popup;
            }
            if ((int)d == 1)
            {
                difficulity = Difficulity.easy;
                EasyB.FlatStyle = FlatStyle.Flat;
            }
            if ((int)d == 2)
            {
                difficulity = Difficulity.medium;
                MediumB.FlatStyle = FlatStyle.Flat;
            }
            if ((int)d == 3)
            {
                difficulity = Difficulity.hard;
                HardB.FlatStyle = FlatStyle.Flat;
            }
        }
        public void AI()
        {
            if (aiThink)
                return;
            if (IsXTurn)
            {
                TurnL.Text = "X turn";
                return;
            }
            if (ended)
                return;
            TurnL.Text = "AI thinks";
            if (difficulity == (Difficulity)0)
            {
                TurnL.Text = "O turn";
                return;
            }
            Ai.difficulity = this.difficulity;
            EventArgs e = new AddingNewEventArgs("AI");
            Position p = Ai.DoTurn(game);
            TurnL.Invoke(new Action(() => {
                CC<object>.CenterVertical(TurnL);
            }));
            if (difficulity == Difficulity.easy)
                Thread.Sleep(1);
            if (difficulity == Difficulity.medium)
                Thread.Sleep(125);
            if (difficulity == Difficulity.hard)
                Thread.Sleep(500);
            if (p.row != -1) 
            this.Invoke(new Action(() => { CellClick(cellsP[p.row, p.col], e); }));
            
            //ThreadPool.Abort(ThreadPool.FindIndex("AI"));
        }
        /// <summary>
        /// Returns wether the AI did the last turn or a player
        /// </summary>
        /// <returns></returns>
        public bool IsAILastTurned()
        {
            if (IsXTurn)
                return true;
            return false;
        }
        private void Inform(string text, int miliseconds)
        {
            new Thread(() => {
                Msg.Invoke(new Action(() => { Msg.Text = text;
                    CC<object>.CenterVertical(Msg);
                }));
                Thread.Sleep(miliseconds);
                Msg.Text = "";
            }).Start();
        }

        private void ClearB_Click(object sender, EventArgs e)
        {
            Clear();
            ended = false;
        }

        private void EasyB_Click(object sender, EventArgs e)
        {
            difChange(Difficulity.easy);
            Clear();
        }

        private void MediumB_Click(object sender, EventArgs e)
        {
            difChange(Difficulity.medium);
            Clear();
        }

        private void HardB_Click(object sender, EventArgs e)
        {
            difChange(Difficulity.hard);
            Clear();
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            Position p = game.Undo();
            if (p.row != -1)
            {
                cellsP[p.row, p.col].BackgroundImage = clearImg;
                IsXTurn = !IsXTurn;
                TurnL.Text = IsXTurn ? "X turn" : "O turn";
            }
        }

        private void PvPB_Click(object sender, EventArgs e)
        {
            difChange(Difficulity.pvp);
            Clear();
        }

        private void ReWriteB_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cellsP[i, j].BackgroundImage = clearImg;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (game.board.board[i, j].player == CellE.o)
                        cellsP[i, j].BackgroundImage = Oimg;
                    if (game.board.board[i, j].player == CellE.x)
                        cellsP[i, j].BackgroundImage = Ximg;
                }
            }
        }

        private void Box3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
