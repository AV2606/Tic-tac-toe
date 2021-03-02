namespace tiktactoe
{
    partial class MainPage
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
            this.easyBtn = new System.Windows.Forms.Button();
            this.pvpBtn = new System.Windows.Forms.Button();
            this.expertBtn = new System.Windows.Forms.Button();
            this.interBtn = new System.Windows.Forms.Button();
            this.StartNewGameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // easyBtn
            // 
            this.easyBtn.AutoSize = true;
            this.easyBtn.BackColor = System.Drawing.Color.LightGreen;
            this.easyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.easyBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyBtn.Location = new System.Drawing.Point(275, 120);
            this.easyBtn.Name = "easyBtn";
            this.easyBtn.Size = new System.Drawing.Size(106, 30);
            this.easyBtn.TabIndex = 0;
            this.easyBtn.Text = "Easy Mode";
            this.easyBtn.UseVisualStyleBackColor = false;
            this.easyBtn.Click += new System.EventHandler(this.easyBtn_Click);
            // 
            // pvpBtn
            // 
            this.pvpBtn.AutoSize = true;
            this.pvpBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pvpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pvpBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pvpBtn.Location = new System.Drawing.Point(275, 271);
            this.pvpBtn.Name = "pvpBtn";
            this.pvpBtn.Size = new System.Drawing.Size(104, 30);
            this.pvpBtn.TabIndex = 1;
            this.pvpBtn.Text = "P v P";
            this.pvpBtn.UseVisualStyleBackColor = false;
            this.pvpBtn.Click += new System.EventHandler(this.pvpBtn_Click);
            // 
            // expertBtn
            // 
            this.expertBtn.AutoSize = true;
            this.expertBtn.BackColor = System.Drawing.Color.Firebrick;
            this.expertBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.expertBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expertBtn.Location = new System.Drawing.Point(275, 188);
            this.expertBtn.Name = "expertBtn";
            this.expertBtn.Size = new System.Drawing.Size(119, 30);
            this.expertBtn.TabIndex = 2;
            this.expertBtn.Text = "Expert Mode";
            this.expertBtn.UseVisualStyleBackColor = false;
            this.expertBtn.Click += new System.EventHandler(this.expertBtn_Click);
            // 
            // interBtn
            // 
            this.interBtn.AutoSize = true;
            this.interBtn.BackColor = System.Drawing.Color.DarkOrange;
            this.interBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.interBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interBtn.Location = new System.Drawing.Point(251, 154);
            this.interBtn.Name = "interBtn";
            this.interBtn.Size = new System.Drawing.Size(169, 30);
            this.interBtn.TabIndex = 3;
            this.interBtn.Text = "Intermediate Mode";
            this.interBtn.UseVisualStyleBackColor = false;
            this.interBtn.Click += new System.EventHandler(this.interBtn_Click);
            // 
            // StartNewGameLabel
            // 
            this.StartNewGameLabel.AutoSize = true;
            this.StartNewGameLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.StartNewGameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartNewGameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartNewGameLabel.ForeColor = System.Drawing.Color.LightCoral;
            this.StartNewGameLabel.Location = new System.Drawing.Point(261, 99);
            this.StartNewGameLabel.Name = "StartNewGameLabel";
            this.StartNewGameLabel.Size = new System.Drawing.Size(147, 18);
            this.StartNewGameLabel.TabIndex = 4;
            this.StartNewGameLabel.Text = "Start a new game";
            this.StartNewGameLabel.Click += new System.EventHandler(this.StartNewGameLabel_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::tiktactoe.Properties.Resources.backGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(703, 450);
            this.Controls.Add(this.StartNewGameLabel);
            this.Controls.Add(this.interBtn);
            this.Controls.Add(this.expertBtn);
            this.Controls.Add(this.pvpBtn);
            this.Controls.Add(this.easyBtn);
            this.DoubleBuffered = true;
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button easyBtn;
        private System.Windows.Forms.Button pvpBtn;
        private System.Windows.Forms.Button expertBtn;
        private System.Windows.Forms.Button interBtn;
        private System.Windows.Forms.Label StartNewGameLabel;
    }
}