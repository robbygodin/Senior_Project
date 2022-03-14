
namespace Senior_Project
{
    partial class Mario
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mario));
            this.marioPB = new System.Windows.Forms.PictureBox();
            this.barrier1 = new System.Windows.Forms.PictureBox();
            this.barrier2 = new System.Windows.Forms.PictureBox();
            this.barrier3 = new System.Windows.Forms.PictureBox();
            this.barrier4 = new System.Windows.Forms.PictureBox();
            this.movement = new System.ComponentModel.BackgroundWorker();
            this.barrier5 = new System.Windows.Forms.PictureBox();
            this.barrier6 = new System.Windows.Forms.PictureBox();
            this.remover = new System.ComponentModel.BackgroundWorker();
            this.beginning = new System.ComponentModel.BackgroundWorker();
            this.titlePB = new System.Windows.Forms.PictureBox();
            this.instructionsPB = new System.Windows.Forms.PictureBox();
            this.coinsLabel = new System.Windows.Forms.Label();
            this.coinPB = new System.Windows.Forms.PictureBox();
            this.timerLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.ending = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.endKillsLabel = new System.Windows.Forms.Label();
            this.endCoinsLabel = new System.Windows.Forms.Label();
            this.endPanel = new System.Windows.Forms.PictureBox();
            this.throwLabel = new System.Windows.Forms.Label();
            this.charSelectPanel = new System.Windows.Forms.Panel();
            this.peachCharPB = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.toadCharPB = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.yoshiCharPB = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.luigiCharPB = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.marioCharPB = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.selectCharPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.marioPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titlePB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instructionsPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coinPB)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPanel)).BeginInit();
            this.charSelectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peachCharPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toadCharPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiCharPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luigiCharPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marioCharPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectCharPB)).BeginInit();
            this.SuspendLayout();
            // 
            // marioPB
            // 
            this.marioPB.Image = global::Senior_Project.Properties.Resources._223_2238299_mario_sprite_by_flamingdragon5000_mario_8_bit_png1;
            this.marioPB.Location = new System.Drawing.Point(532, -70);
            this.marioPB.Margin = new System.Windows.Forms.Padding(0);
            this.marioPB.Name = "marioPB";
            this.marioPB.Size = new System.Drawing.Size(50, 67);
            this.marioPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.marioPB.TabIndex = 0;
            this.marioPB.TabStop = false;
            // 
            // barrier1
            // 
            this.barrier1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("barrier1.BackgroundImage")));
            this.barrier1.Image = global::Senior_Project.Properties.Resources.Brick_Block1;
            this.barrier1.Location = new System.Drawing.Point(0, 149);
            this.barrier1.Margin = new System.Windows.Forms.Padding(0);
            this.barrier1.Name = "barrier1";
            this.barrier1.Size = new System.Drawing.Size(300, 75);
            this.barrier1.TabIndex = 1;
            this.barrier1.TabStop = false;
            // 
            // barrier2
            // 
            this.barrier2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("barrier2.BackgroundImage")));
            this.barrier2.Location = new System.Drawing.Point(825, 149);
            this.barrier2.Margin = new System.Windows.Forms.Padding(0);
            this.barrier2.Name = "barrier2";
            this.barrier2.Size = new System.Drawing.Size(300, 75);
            this.barrier2.TabIndex = 2;
            this.barrier2.TabStop = false;
            // 
            // barrier3
            // 
            this.barrier3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("barrier3.BackgroundImage")));
            this.barrier3.Location = new System.Drawing.Point(187, 368);
            this.barrier3.Margin = new System.Windows.Forms.Padding(0);
            this.barrier3.Name = "barrier3";
            this.barrier3.Size = new System.Drawing.Size(750, 75);
            this.barrier3.TabIndex = 3;
            this.barrier3.TabStop = false;
            // 
            // barrier4
            // 
            this.barrier4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("barrier4.BackgroundImage")));
            this.barrier4.Location = new System.Drawing.Point(0, 726);
            this.barrier4.Margin = new System.Windows.Forms.Padding(0);
            this.barrier4.Name = "barrier4";
            this.barrier4.Size = new System.Drawing.Size(1125, 75);
            this.barrier4.TabIndex = 4;
            this.barrier4.TabStop = false;
            // 
            // movement
            // 
            this.movement.WorkerReportsProgress = true;
            this.movement.WorkerSupportsCancellation = true;
            this.movement.DoWork += new System.ComponentModel.DoWorkEventHandler(this.movement_DoWork);
            this.movement.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.movement_ProgressChanged);
            // 
            // barrier5
            // 
            this.barrier5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("barrier5.BackgroundImage")));
            this.barrier5.Location = new System.Drawing.Point(0, 547);
            this.barrier5.Margin = new System.Windows.Forms.Padding(0);
            this.barrier5.Name = "barrier5";
            this.barrier5.Size = new System.Drawing.Size(75, 75);
            this.barrier5.TabIndex = 5;
            this.barrier5.TabStop = false;
            // 
            // barrier6
            // 
            this.barrier6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("barrier6.BackgroundImage")));
            this.barrier6.Location = new System.Drawing.Point(1050, 547);
            this.barrier6.Margin = new System.Windows.Forms.Padding(0);
            this.barrier6.Name = "barrier6";
            this.barrier6.Size = new System.Drawing.Size(75, 75);
            this.barrier6.TabIndex = 6;
            this.barrier6.TabStop = false;
            // 
            // remover
            // 
            this.remover.WorkerReportsProgress = true;
            this.remover.WorkerSupportsCancellation = true;
            this.remover.DoWork += new System.ComponentModel.DoWorkEventHandler(this.remover_DoWork);
            this.remover.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.remover_ProgressChanged);
            // 
            // beginning
            // 
            this.beginning.WorkerReportsProgress = true;
            this.beginning.WorkerSupportsCancellation = true;
            this.beginning.DoWork += new System.ComponentModel.DoWorkEventHandler(this.beginning_DoWork);
            this.beginning.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.beginning_ProgressChanged);
            // 
            // titlePB
            // 
            this.titlePB.Image = global::Senior_Project.Properties.Resources._1200px_Mario_Series_Logo1;
            this.titlePB.Location = new System.Drawing.Point(300, -2);
            this.titlePB.Margin = new System.Windows.Forms.Padding(0);
            this.titlePB.Name = "titlePB";
            this.titlePB.Size = new System.Drawing.Size(525, 246);
            this.titlePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.titlePB.TabIndex = 7;
            this.titlePB.TabStop = false;
            // 
            // instructionsPB
            // 
            this.instructionsPB.Image = global::Senior_Project.Properties.Resources._1eeb65ecac5df5a5e491f6f7bf2cfd51;
            this.instructionsPB.Location = new System.Drawing.Point(93, 260);
            this.instructionsPB.Margin = new System.Windows.Forms.Padding(0);
            this.instructionsPB.Name = "instructionsPB";
            this.instructionsPB.Size = new System.Drawing.Size(938, 53);
            this.instructionsPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.instructionsPB.TabIndex = 8;
            this.instructionsPB.TabStop = false;
            this.instructionsPB.Visible = false;
            // 
            // coinsLabel
            // 
            this.coinsLabel.AutoSize = true;
            this.coinsLabel.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coinsLabel.ForeColor = System.Drawing.Color.Black;
            this.coinsLabel.Location = new System.Drawing.Point(3, 9);
            this.coinsLabel.Name = "coinsLabel";
            this.coinsLabel.Size = new System.Drawing.Size(51, 50);
            this.coinsLabel.TabIndex = 9;
            this.coinsLabel.Text = "0";
            this.coinsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // coinPB
            // 
            this.coinPB.Image = global::Senior_Project.Properties.Resources._1200px_CoinMK81;
            this.coinPB.Location = new System.Drawing.Point(59, 9);
            this.coinPB.Margin = new System.Windows.Forms.Padding(0);
            this.coinPB.Name = "coinPB";
            this.coinPB.Size = new System.Drawing.Size(50, 50);
            this.coinPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coinPB.TabIndex = 10;
            this.coinPB.TabStop = false;
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.ForeColor = System.Drawing.Color.Black;
            this.timerLabel.Location = new System.Drawing.Point(493, 9);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(138, 50);
            this.timerLabel.TabIndex = 11;
            this.timerLabel.Text = "0:00";
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.timerLabel.Visible = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // ending
            // 
            this.ending.WorkerReportsProgress = true;
            this.ending.WorkerSupportsCancellation = true;
            this.ending.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ending_DoWork);
            this.ending.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ending_ProgressChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Controls.Add(this.endKillsLabel);
            this.panel1.Controls.Add(this.endCoinsLabel);
            this.panel1.Controls.Add(this.endPanel);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 725);
            this.panel1.TabIndex = 12;
            this.panel1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Senior_Project.Properties.Resources.Enemies_Squished_Mario;
            this.pictureBox2.Location = new System.Drawing.Point(218, 441);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(688, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Senior_Project.Properties.Resources.Coins_Earned_Mairo;
            this.pictureBox1.Location = new System.Drawing.Point(310, 281);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(505, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(231)))), ((int)(((byte)(241)))));
            this.exitButton.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(384, 578);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(356, 65);
            this.exitButton.TabIndex = 17;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // endKillsLabel
            // 
            this.endKillsLabel.AutoEllipsis = true;
            this.endKillsLabel.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endKillsLabel.Location = new System.Drawing.Point(3, 508);
            this.endKillsLabel.Name = "endKillsLabel";
            this.endKillsLabel.Size = new System.Drawing.Size(1122, 50);
            this.endKillsLabel.TabIndex = 16;
            this.endKillsLabel.Text = "000";
            this.endKillsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // endCoinsLabel
            // 
            this.endCoinsLabel.AutoEllipsis = true;
            this.endCoinsLabel.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endCoinsLabel.ForeColor = System.Drawing.Color.Black;
            this.endCoinsLabel.Location = new System.Drawing.Point(1, 349);
            this.endCoinsLabel.Name = "endCoinsLabel";
            this.endCoinsLabel.Size = new System.Drawing.Size(1122, 50);
            this.endCoinsLabel.TabIndex = 14;
            this.endCoinsLabel.Text = "000";
            this.endCoinsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // endPanel
            // 
            this.endPanel.Image = global::Senior_Project.Properties.Resources._1200px_Mario_Series_Logo1;
            this.endPanel.Location = new System.Drawing.Point(300, 0);
            this.endPanel.Margin = new System.Windows.Forms.Padding(0);
            this.endPanel.Name = "endPanel";
            this.endPanel.Size = new System.Drawing.Size(525, 246);
            this.endPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.endPanel.TabIndex = 13;
            this.endPanel.TabStop = false;
            // 
            // throwLabel
            // 
            this.throwLabel.AutoSize = true;
            this.throwLabel.Font = new System.Drawing.Font("OCR A Extended", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.throwLabel.ForeColor = System.Drawing.Color.Black;
            this.throwLabel.Location = new System.Drawing.Point(334, 68);
            this.throwLabel.Name = "throwLabel";
            this.throwLabel.Size = new System.Drawing.Size(457, 39);
            this.throwLabel.TabIndex = 13;
            this.throwLabel.Text = "Throw shell with \'E\'";
            this.throwLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.throwLabel.Visible = false;
            // 
            // charSelectPanel
            // 
            this.charSelectPanel.Controls.Add(this.peachCharPB);
            this.charSelectPanel.Controls.Add(this.pictureBox7);
            this.charSelectPanel.Controls.Add(this.toadCharPB);
            this.charSelectPanel.Controls.Add(this.pictureBox6);
            this.charSelectPanel.Controls.Add(this.yoshiCharPB);
            this.charSelectPanel.Controls.Add(this.pictureBox5);
            this.charSelectPanel.Controls.Add(this.luigiCharPB);
            this.charSelectPanel.Controls.Add(this.pictureBox4);
            this.charSelectPanel.Controls.Add(this.marioCharPB);
            this.charSelectPanel.Controls.Add(this.pictureBox3);
            this.charSelectPanel.Location = new System.Drawing.Point(19, 329);
            this.charSelectPanel.Name = "charSelectPanel";
            this.charSelectPanel.Size = new System.Drawing.Size(1087, 215);
            this.charSelectPanel.TabIndex = 16;
            // 
            // peachCharPB
            // 
            this.peachCharPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.peachCharPB.Image = global::Senior_Project.Properties.Resources.Peach_Standing;
            this.peachCharPB.Location = new System.Drawing.Point(451, 15);
            this.peachCharPB.Name = "peachCharPB";
            this.peachCharPB.Size = new System.Drawing.Size(185, 185);
            this.peachCharPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.peachCharPB.TabIndex = 4;
            this.peachCharPB.TabStop = false;
            this.peachCharPB.Click += new System.EventHandler(this.peachCharPB_Click);
            this.peachCharPB.MouseEnter += new System.EventHandler(this.marioCharPB_MouseEnter);
            this.peachCharPB.MouseLeave += new System.EventHandler(this.marioCharPB_MouseLeave);
            this.peachCharPB.MouseHover += new System.EventHandler(this.marioCharPB_MouseHover);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox7.Location = new System.Drawing.Point(443, 7);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(200, 200);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 9;
            this.pictureBox7.TabStop = false;
            // 
            // toadCharPB
            // 
            this.toadCharPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toadCharPB.Image = global::Senior_Project.Properties.Resources.Toad_Standing;
            this.toadCharPB.Location = new System.Drawing.Point(665, 15);
            this.toadCharPB.Name = "toadCharPB";
            this.toadCharPB.Size = new System.Drawing.Size(185, 185);
            this.toadCharPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.toadCharPB.TabIndex = 3;
            this.toadCharPB.TabStop = false;
            this.toadCharPB.Click += new System.EventHandler(this.toadCharPB_Click);
            this.toadCharPB.MouseEnter += new System.EventHandler(this.marioCharPB_MouseEnter);
            this.toadCharPB.MouseLeave += new System.EventHandler(this.marioCharPB_MouseLeave);
            this.toadCharPB.MouseHover += new System.EventHandler(this.marioCharPB_MouseHover);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox6.Location = new System.Drawing.Point(657, 7);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(200, 200);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 8;
            this.pictureBox6.TabStop = false;
            // 
            // yoshiCharPB
            // 
            this.yoshiCharPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yoshiCharPB.Image = global::Senior_Project.Properties.Resources.Yoshi_Running;
            this.yoshiCharPB.Location = new System.Drawing.Point(879, 15);
            this.yoshiCharPB.Name = "yoshiCharPB";
            this.yoshiCharPB.Size = new System.Drawing.Size(185, 185);
            this.yoshiCharPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.yoshiCharPB.TabIndex = 2;
            this.yoshiCharPB.TabStop = false;
            this.yoshiCharPB.Click += new System.EventHandler(this.yoshiCharPB_Click);
            this.yoshiCharPB.MouseEnter += new System.EventHandler(this.marioCharPB_MouseEnter);
            this.yoshiCharPB.MouseLeave += new System.EventHandler(this.marioCharPB_MouseLeave);
            this.yoshiCharPB.MouseHover += new System.EventHandler(this.marioCharPB_MouseHover);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Location = new System.Drawing.Point(871, 7);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(200, 200);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            // 
            // luigiCharPB
            // 
            this.luigiCharPB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(222)))), ((int)(((byte)(236)))));
            this.luigiCharPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.luigiCharPB.Image = global::Senior_Project.Properties.Resources.Luigi_Standing_Awkwardly;
            this.luigiCharPB.Location = new System.Drawing.Point(237, 15);
            this.luigiCharPB.Name = "luigiCharPB";
            this.luigiCharPB.Size = new System.Drawing.Size(185, 185);
            this.luigiCharPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.luigiCharPB.TabIndex = 1;
            this.luigiCharPB.TabStop = false;
            this.luigiCharPB.Click += new System.EventHandler(this.luigiCharPB_Click);
            this.luigiCharPB.MouseEnter += new System.EventHandler(this.marioCharPB_MouseEnter);
            this.luigiCharPB.MouseLeave += new System.EventHandler(this.marioCharPB_MouseLeave);
            this.luigiCharPB.MouseHover += new System.EventHandler(this.marioCharPB_MouseHover);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(182)))));
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(229, 7);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(200, 200);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // marioCharPB
            // 
            this.marioCharPB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(222)))), ((int)(((byte)(236)))));
            this.marioCharPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.marioCharPB.Image = global::Senior_Project.Properties.Resources.Mario_Standing_Awkwardly1;
            this.marioCharPB.Location = new System.Drawing.Point(23, 15);
            this.marioCharPB.Name = "marioCharPB";
            this.marioCharPB.Size = new System.Drawing.Size(185, 185);
            this.marioCharPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.marioCharPB.TabIndex = 0;
            this.marioCharPB.TabStop = false;
            this.marioCharPB.Click += new System.EventHandler(this.marioCharPB_Click);
            this.marioCharPB.MouseEnter += new System.EventHandler(this.marioCharPB_MouseEnter);
            this.marioCharPB.MouseLeave += new System.EventHandler(this.marioCharPB_MouseLeave);
            this.marioCharPB.MouseHover += new System.EventHandler(this.marioCharPB_MouseHover);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(15, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(200, 200);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // selectCharPB
            // 
            this.selectCharPB.Image = global::Senior_Project.Properties.Resources.Select_a_character_mario;
            this.selectCharPB.Location = new System.Drawing.Point(111, 260);
            this.selectCharPB.Margin = new System.Windows.Forms.Padding(0);
            this.selectCharPB.Name = "selectCharPB";
            this.selectCharPB.Size = new System.Drawing.Size(903, 52);
            this.selectCharPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.selectCharPB.TabIndex = 17;
            this.selectCharPB.TabStop = false;
            // 
            // Mario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(222)))), ((int)(((byte)(236)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1125, 749);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.selectCharPB);
            this.Controls.Add(this.charSelectPanel);
            this.Controls.Add(this.throwLabel);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.coinPB);
            this.Controls.Add(this.coinsLabel);
            this.Controls.Add(this.instructionsPB);
            this.Controls.Add(this.barrier4);
            this.Controls.Add(this.titlePB);
            this.Controls.Add(this.marioPB);
            this.Controls.Add(this.barrier3);
            this.Controls.Add(this.barrier1);
            this.Controls.Add(this.barrier2);
            this.Controls.Add(this.barrier5);
            this.Controls.Add(this.barrier6);
            this.Name = "Mario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Mario_FormClosed);
            this.Load += new System.EventHandler(this.Mario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mario_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Mario_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.marioPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titlePB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instructionsPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coinPB)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPanel)).EndInit();
            this.charSelectPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.peachCharPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toadCharPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yoshiCharPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luigiCharPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marioCharPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectCharPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox marioPB;
        private System.Windows.Forms.PictureBox barrier1;
        private System.Windows.Forms.PictureBox barrier2;
        private System.Windows.Forms.PictureBox barrier3;
        private System.Windows.Forms.PictureBox barrier4;
        private System.ComponentModel.BackgroundWorker movement;
        private System.Windows.Forms.PictureBox barrier5;
        private System.Windows.Forms.PictureBox barrier6;
        private System.ComponentModel.BackgroundWorker remover;
        private System.ComponentModel.BackgroundWorker beginning;
        private System.Windows.Forms.PictureBox titlePB;
        private System.Windows.Forms.PictureBox instructionsPB;
        private System.Windows.Forms.Label coinsLabel;
        private System.Windows.Forms.PictureBox coinPB;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.ComponentModel.BackgroundWorker ending;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox endPanel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label endKillsLabel;
        private System.Windows.Forms.Label endCoinsLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label throwLabel;
        private System.Windows.Forms.Panel charSelectPanel;
        private System.Windows.Forms.PictureBox peachCharPB;
        private System.Windows.Forms.PictureBox toadCharPB;
        private System.Windows.Forms.PictureBox yoshiCharPB;
        private System.Windows.Forms.PictureBox luigiCharPB;
        private System.Windows.Forms.PictureBox marioCharPB;
        private System.Windows.Forms.PictureBox selectCharPB;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}