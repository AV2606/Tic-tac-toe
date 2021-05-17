namespace tiktactoe
{
    partial class GameForm
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
            this.EasyB = new System.Windows.Forms.Button();
            this.MediumB = new System.Windows.Forms.Button();
            this.HardB = new System.Windows.Forms.Button();
            this.PvPB = new System.Windows.Forms.Button();
            this.Undo = new System.Windows.Forms.Button();
            this.ReWriteB = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Box1 = new System.Windows.Forms.PictureBox();
            this.Box2 = new System.Windows.Forms.PictureBox();
            this.Box3 = new System.Windows.Forms.PictureBox();
            this.Box4 = new System.Windows.Forms.PictureBox();
            this.Box5 = new System.Windows.Forms.PictureBox();
            this.Box6 = new System.Windows.Forms.PictureBox();
            this.Box7 = new System.Windows.Forms.PictureBox();
            this.Box8 = new System.Windows.Forms.PictureBox();
            this.Box9 = new System.Windows.Forms.PictureBox();
            this.Msg = new System.Windows.Forms.Label();
            this.ClearB = new System.Windows.Forms.Button();
            this.TurnL = new System.Windows.Forms.Label();
            this.helpL = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box9)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // EasyB
            // 
            this.EasyB.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.EasyB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.EasyB.Location = new System.Drawing.Point(640, 124);
            this.EasyB.Name = "EasyB";
            this.EasyB.Size = new System.Drawing.Size(93, 32);
            this.EasyB.TabIndex = 14;
            this.EasyB.Text = "Easy";
            this.EasyB.UseVisualStyleBackColor = false;
            this.EasyB.Click += new System.EventHandler(this.EasyB_Click);
            // 
            // MediumB
            // 
            this.MediumB.BackColor = System.Drawing.Color.DarkOrange;
            this.MediumB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MediumB.Location = new System.Drawing.Point(640, 174);
            this.MediumB.Name = "MediumB";
            this.MediumB.Size = new System.Drawing.Size(93, 32);
            this.MediumB.TabIndex = 15;
            this.MediumB.Text = "Medium";
            this.MediumB.UseVisualStyleBackColor = false;
            this.MediumB.Click += new System.EventHandler(this.MediumB_Click);
            // 
            // HardB
            // 
            this.HardB.BackColor = System.Drawing.Color.Crimson;
            this.HardB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.HardB.Location = new System.Drawing.Point(640, 230);
            this.HardB.Name = "HardB";
            this.HardB.Size = new System.Drawing.Size(93, 32);
            this.HardB.TabIndex = 16;
            this.HardB.Text = "Hard";
            this.HardB.UseVisualStyleBackColor = false;
            this.HardB.Click += new System.EventHandler(this.HardB_Click);
            // 
            // PvPB
            // 
            this.PvPB.BackColor = System.Drawing.Color.Navy;
            this.PvPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PvPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PvPB.ForeColor = System.Drawing.SystemColors.Control;
            this.PvPB.Location = new System.Drawing.Point(640, 286);
            this.PvPB.Name = "PvPB";
            this.PvPB.Size = new System.Drawing.Size(93, 32);
            this.PvPB.TabIndex = 17;
            this.PvPB.Text = "2 Players";
            this.PvPB.UseVisualStyleBackColor = false;
            this.PvPB.Click += new System.EventHandler(this.PvPB_Click);
            // 
            // Undo
            // 
            this.Undo.BackColor = System.Drawing.Color.SlateGray;
            this.Undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Undo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Undo.Location = new System.Drawing.Point(640, 342);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(93, 32);
            this.Undo.TabIndex = 18;
            this.Undo.Text = "Undo";
            this.Undo.UseVisualStyleBackColor = false;
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // ReWriteB
            // 
            this.ReWriteB.BackColor = System.Drawing.Color.DimGray;
            this.ReWriteB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ReWriteB.Location = new System.Drawing.Point(292, 342);
            this.ReWriteB.Name = "ReWriteB";
            this.ReWriteB.Size = new System.Drawing.Size(93, 32);
            this.ReWriteB.TabIndex = 19;
            this.ReWriteB.Text = "ReWrite";
            this.ReWriteB.UseVisualStyleBackColor = false;
            this.ReWriteB.Click += new System.EventHandler(this.ReWriteB_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::tiktactoe.Properties.Resources.PicsArt_04_27_02_21_22;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::tiktactoe.Properties.Resources.PicsArt_04_27_02_21_22;
            this.pictureBox1.Location = new System.Drawing.Point(9, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 162);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Box1
            // 
            this.Box1.BackColor = System.Drawing.Color.Transparent;
            this.Box1.BackgroundImage = global::tiktactoe.Properties.Resources.PicsArt_04_27_02_23_18;
            this.Box1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Box1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Box1.Image = global::tiktactoe.Properties.Resources.PicsArt_04_27_02_23_18;
            this.Box1.Location = new System.Drawing.Point(9, 3);
            this.Box1.Name = "Box1";
            this.Box1.Size = new System.Drawing.Size(50, 50);
            this.Box1.TabIndex = 0;
            this.Box1.TabStop = false;
            this.Box1.Click += new System.EventHandler(this.CellClick);
            // 
            // Box2
            // 
            this.Box2.BackColor = System.Drawing.Color.Transparent;
            this.Box2.BackgroundImage = global::tiktactoe.Properties.Resources.PicsArt_04_27_02_24_35;
            this.Box2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Box2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Box2.Location = new System.Drawing.Point(65, 3);
            this.Box2.Name = "Box2";
            this.Box2.Size = new System.Drawing.Size(50, 50);
            this.Box2.TabIndex = 1;
            this.Box2.TabStop = false;
            // 
            // Box3
            // 
            this.Box3.BackColor = System.Drawing.Color.Transparent;
            this.Box3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Box3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Box3.Location = new System.Drawing.Point(121, 3);
            this.Box3.Name = "Box3";
            this.Box3.Size = new System.Drawing.Size(50, 50);
            this.Box3.TabIndex = 2;
            this.Box3.TabStop = false;
            this.Box3.Click += new System.EventHandler(this.Box3_Click);
            // 
            // Box4
            // 
            this.Box4.BackColor = System.Drawing.Color.Transparent;
            this.Box4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Box4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Box4.Location = new System.Drawing.Point(9, 59);
            this.Box4.Name = "Box4";
            this.Box4.Size = new System.Drawing.Size(50, 50);
            this.Box4.TabIndex = 3;
            this.Box4.TabStop = false;
            // 
            // Box5
            // 
            this.Box5.BackColor = System.Drawing.Color.Transparent;
            this.Box5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Box5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Box5.Location = new System.Drawing.Point(65, 59);
            this.Box5.Name = "Box5";
            this.Box5.Size = new System.Drawing.Size(50, 50);
            this.Box5.TabIndex = 4;
            this.Box5.TabStop = false;
            // 
            // Box6
            // 
            this.Box6.BackColor = System.Drawing.Color.Transparent;
            this.Box6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Box6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Box6.Location = new System.Drawing.Point(121, 59);
            this.Box6.Name = "Box6";
            this.Box6.Size = new System.Drawing.Size(50, 50);
            this.Box6.TabIndex = 5;
            this.Box6.TabStop = false;
            // 
            // Box7
            // 
            this.Box7.BackColor = System.Drawing.Color.Transparent;
            this.Box7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Box7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Box7.Location = new System.Drawing.Point(9, 115);
            this.Box7.Name = "Box7";
            this.Box7.Size = new System.Drawing.Size(50, 50);
            this.Box7.TabIndex = 6;
            this.Box7.TabStop = false;
            this.Box7.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // Box8
            // 
            this.Box8.BackColor = System.Drawing.Color.Transparent;
            this.Box8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Box8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Box8.Location = new System.Drawing.Point(65, 115);
            this.Box8.Name = "Box8";
            this.Box8.Size = new System.Drawing.Size(50, 50);
            this.Box8.TabIndex = 7;
            this.Box8.TabStop = false;
            // 
            // Box9
            // 
            this.Box9.BackColor = System.Drawing.Color.Transparent;
            this.Box9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Box9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Box9.Location = new System.Drawing.Point(121, 115);
            this.Box9.Name = "Box9";
            this.Box9.Size = new System.Drawing.Size(50, 50);
            this.Box9.TabIndex = 8;
            this.Box9.TabStop = false;
            // 
            // Msg
            // 
            this.Msg.AutoSize = true;
            this.Msg.BackColor = System.Drawing.Color.Transparent;
            this.Msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Msg.ForeColor = System.Drawing.Color.Navy;
            this.Msg.Location = new System.Drawing.Point(306, 84);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(0, 25);
            this.Msg.TabIndex = 9;
            this.Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Msg.Click += new System.EventHandler(this.label1_Click);
            // 
            // ClearB
            // 
            this.ClearB.AutoSize = true;
            this.ClearB.BackColor = System.Drawing.Color.Transparent;
            this.ClearB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ClearB.Location = new System.Drawing.Point(311, 286);
            this.ClearB.Name = "ClearB";
            this.ClearB.Size = new System.Drawing.Size(65, 32);
            this.ClearB.TabIndex = 11;
            this.ClearB.Text = "Clear";
            this.ClearB.UseVisualStyleBackColor = false;
            this.ClearB.Click += new System.EventHandler(this.ClearB_Click);
            // 
            // TurnL
            // 
            this.TurnL.AutoSize = true;
            this.TurnL.BackColor = System.Drawing.Color.Transparent;
            this.TurnL.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnL.ForeColor = System.Drawing.Color.Orange;
            this.TurnL.Location = new System.Drawing.Point(313, 64);
            this.TurnL.Name = "TurnL";
            this.TurnL.Size = new System.Drawing.Size(71, 22);
            this.TurnL.TabIndex = 12;
            this.TurnL.Text = "X turn";
            // 
            // helpL
            // 
            this.helpL.AutoSize = true;
            this.helpL.BackColor = System.Drawing.Color.Transparent;
            this.helpL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.helpL.ForeColor = System.Drawing.SystemColors.Info;
            this.helpL.Location = new System.Drawing.Point(294, 28);
            this.helpL.Name = "helpL";
            this.helpL.Size = new System.Drawing.Size(91, 20);
            this.helpL.TabIndex = 13;
            this.helpL.Text = "Position 0,0";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.Box9);
            this.panel2.Controls.Add(this.Box8);
            this.panel2.Controls.Add(this.Box7);
            this.panel2.Controls.Add(this.Box6);
            this.panel2.Controls.Add(this.Box5);
            this.panel2.Controls.Add(this.Box4);
            this.panel2.Controls.Add(this.Box3);
            this.panel2.Controls.Add(this.Box2);
            this.panel2.Controls.Add(this.Box1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(266, 109);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(174, 171);
            this.panel2.TabIndex = 14;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.helpL);
            this.Controls.Add(this.TurnL);
            this.Controls.Add(this.ReWriteB);
            this.Controls.Add(this.ClearB);
            this.Controls.Add(this.Undo);
            this.Controls.Add(this.Msg);
            this.Controls.Add(this.PvPB);
            this.Controls.Add(this.HardB);
            this.Controls.Add(this.MediumB);
            this.Controls.Add(this.EasyB);
            this.Name = "GameForm";
            this.Text = "Tic Tac Toe";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Box9)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button EasyB;
        private System.Windows.Forms.Button MediumB;
        private System.Windows.Forms.Button HardB;
        private System.Windows.Forms.Button PvPB;
        private System.Windows.Forms.Button Undo;
        private System.Windows.Forms.Button ReWriteB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Box1;
        private System.Windows.Forms.PictureBox Box2;
        private System.Windows.Forms.PictureBox Box3;
        private System.Windows.Forms.PictureBox Box4;
        private System.Windows.Forms.PictureBox Box5;
        private System.Windows.Forms.PictureBox Box6;
        private System.Windows.Forms.PictureBox Box7;
        private System.Windows.Forms.PictureBox Box8;
        private System.Windows.Forms.PictureBox Box9;
        private System.Windows.Forms.Label Msg;
        private System.Windows.Forms.Button ClearB;
        private System.Windows.Forms.Label TurnL;
        private System.Windows.Forms.Label helpL;
        private System.Windows.Forms.Panel panel2;
    }
}

