namespace Senior_Project
{
    partial class Form1
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
            this.lastLabel = new System.Windows.Forms.Label();
            this.nextLabel = new System.Windows.Forms.Label();
            this.titlePB = new System.Windows.Forms.PictureBox();
            this.leftArrowPB = new System.Windows.Forms.PictureBox();
            this.rightArrowPB = new System.Windows.Forms.PictureBox();
            this.panelPB = new System.Windows.Forms.PictureBox();
            this.howPlayButton = new System.Windows.Forms.Button();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.startGB = new System.Windows.Forms.GroupBox();
            this.loginInstructions = new System.Windows.Forms.Label();
            this.enterUPErrorLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.signingInLabel = new System.Windows.Forms.Label();
            this.incLoginLabel = new System.Windows.Forms.Label();
            this.takenLabel = new System.Windows.Forms.Label();
            this.signInButton = new System.Windows.Forms.Button();
            this.newUserButton = new System.Windows.Forms.Button();
            this.passTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.coinPB = new System.Windows.Forms.PictureBox();
            this.coinsLabel = new System.Windows.Forms.Label();
            this.leaderButton = new System.Windows.Forms.Button();
            this.updater = new System.ComponentModel.BackgroundWorker();
            this.leaderboardLB = new System.Windows.Forms.ListBox();
            this.leaderboardTitle = new System.Windows.Forms.Label();
            this.oldPanelPB = new System.Windows.Forms.PictureBox();
            this.newPanelPB = new System.Windows.Forms.PictureBox();
            this.menuInstLabel = new System.Windows.Forms.Label();
            this.coinPanel = new System.Windows.Forms.Panel();
            this.gamesPanel = new System.Windows.Forms.Panel();
            this.marioExPB = new System.Windows.Forms.PictureBox();
            this.tetrisExPB = new System.Windows.Forms.PictureBox();
            this.pongExPB = new System.Windows.Forms.PictureBox();
            this.astExPB = new System.Windows.Forms.PictureBox();
            this.snakeExPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.titlePB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftArrowPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightArrowPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPB)).BeginInit();
            this.startGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coinPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oldPanelPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newPanelPB)).BeginInit();
            this.coinPanel.SuspendLayout();
            this.gamesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marioExPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetrisExPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pongExPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.astExPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snakeExPB)).BeginInit();
            this.SuspendLayout();
            // 
            // lastLabel
            // 
            this.lastLabel.AutoSize = true;
            this.lastLabel.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lastLabel.Location = new System.Drawing.Point(50, 216);
            this.lastLabel.Name = "lastLabel";
            this.lastLabel.Size = new System.Drawing.Size(178, 32);
            this.lastLabel.TabIndex = 14;
            this.lastLabel.Text = "Previous Game";
            this.lastLabel.Click += new System.EventHandler(this.lastLabel_Click);
            // 
            // nextLabel
            // 
            this.nextLabel.AutoSize = true;
            this.nextLabel.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nextLabel.Location = new System.Drawing.Point(1149, 216);
            this.nextLabel.Name = "nextLabel";
            this.nextLabel.Size = new System.Drawing.Size(138, 32);
            this.nextLabel.TabIndex = 13;
            this.nextLabel.Text = "Next Game";
            // 
            // titlePB
            // 
            this.titlePB.Image = global::Senior_Project.Properties.Resources.Arcade_Neon_Sign_last;
            this.titlePB.Location = new System.Drawing.Point(178, -1);
            this.titlePB.Name = "titlePB";
            this.titlePB.Size = new System.Drawing.Size(1000, 150);
            this.titlePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.titlePB.TabIndex = 18;
            this.titlePB.TabStop = false;
            // 
            // leftArrowPB
            // 
            this.leftArrowPB.Image = global::Senior_Project.Properties.Resources.Left_White_Arrow;
            this.leftArrowPB.Location = new System.Drawing.Point(27, 247);
            this.leftArrowPB.Name = "leftArrowPB";
            this.leftArrowPB.Size = new System.Drawing.Size(224, 235);
            this.leftArrowPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.leftArrowPB.TabIndex = 11;
            this.leftArrowPB.TabStop = false;
            this.leftArrowPB.Click += new System.EventHandler(this.leftArrowPB_Click);
            // 
            // rightArrowPB
            // 
            this.rightArrowPB.Image = global::Senior_Project.Properties.Resources.White_Right_Arrow;
            this.rightArrowPB.Location = new System.Drawing.Point(1106, 247);
            this.rightArrowPB.Name = "rightArrowPB";
            this.rightArrowPB.Size = new System.Drawing.Size(224, 235);
            this.rightArrowPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rightArrowPB.TabIndex = 10;
            this.rightArrowPB.TabStop = false;
            this.rightArrowPB.Click += new System.EventHandler(this.rightArrowPB_Click);
            // 
            // panelPB
            // 
            this.panelPB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPB.Image = global::Senior_Project.Properties.Resources.Sample_Arcade;
            this.panelPB.Location = new System.Drawing.Point(12, 116);
            this.panelPB.Name = "panelPB";
            this.panelPB.Size = new System.Drawing.Size(50, 50);
            this.panelPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.panelPB.TabIndex = 9;
            this.panelPB.TabStop = false;
            this.panelPB.Visible = false;
            this.panelPB.Click += new System.EventHandler(this.panelPB_Click);
            // 
            // howPlayButton
            // 
            this.howPlayButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(80)))), ((int)(((byte)(130)))));
            this.howPlayButton.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howPlayButton.ForeColor = System.Drawing.Color.LightGray;
            this.howPlayButton.Location = new System.Drawing.Point(495, 590);
            this.howPlayButton.Name = "howPlayButton";
            this.howPlayButton.Size = new System.Drawing.Size(365, 68);
            this.howPlayButton.TabIndex = 19;
            this.howPlayButton.Text = "How To Play";
            this.howPlayButton.UseVisualStyleBackColor = false;
            this.howPlayButton.Visible = false;
            this.howPlayButton.Click += new System.EventHandler(this.howPlayButton_Click);
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.instructionsLabel.Font = new System.Drawing.Font("OCR A Extended", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.instructionsLabel.Location = new System.Drawing.Point(12, 42);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(50, 50);
            this.instructionsLabel.TabIndex = 20;
            this.instructionsLabel.Text = "label1";
            this.instructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.instructionsLabel.Visible = false;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(80)))), ((int)(((byte)(130)))));
            this.closeButton.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.Silver;
            this.closeButton.Location = new System.Drawing.Point(495, 590);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(367, 68);
            this.closeButton.TabIndex = 21;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Visible = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // startGB
            // 
            this.startGB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.startGB.Controls.Add(this.loginInstructions);
            this.startGB.Controls.Add(this.enterUPErrorLabel);
            this.startGB.Controls.Add(this.passLabel);
            this.startGB.Controls.Add(this.usernameLabel);
            this.startGB.Controls.Add(this.signingInLabel);
            this.startGB.Controls.Add(this.incLoginLabel);
            this.startGB.Controls.Add(this.takenLabel);
            this.startGB.Controls.Add(this.signInButton);
            this.startGB.Controls.Add(this.newUserButton);
            this.startGB.Controls.Add(this.passTB);
            this.startGB.Controls.Add(this.label2);
            this.startGB.Controls.Add(this.usernameTB);
            this.startGB.Controls.Add(this.label1);
            this.startGB.Location = new System.Drawing.Point(98, 116);
            this.startGB.Name = "startGB";
            this.startGB.Size = new System.Drawing.Size(74, 59);
            this.startGB.TabIndex = 22;
            this.startGB.TabStop = false;
            // 
            // loginInstructions
            // 
            this.loginInstructions.Font = new System.Drawing.Font("OCR A Extended", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginInstructions.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.loginInstructions.Location = new System.Drawing.Point(6, 196);
            this.loginInstructions.Name = "loginInstructions";
            this.loginInstructions.Size = new System.Drawing.Size(1340, 191);
            this.loginInstructions.TabIndex = 13;
            this.loginInstructions.Text = "Enter a username and password. Returning users click \"Sign In\". New users click \"" +
    "New Player\".";
            this.loginInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // enterUPErrorLabel
            // 
            this.enterUPErrorLabel.AutoSize = true;
            this.enterUPErrorLabel.Font = new System.Drawing.Font("OCR A Extended", 54.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterUPErrorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.enterUPErrorLabel.Location = new System.Drawing.Point(7, 265);
            this.enterUPErrorLabel.Name = "enterUPErrorLabel";
            this.enterUPErrorLabel.Size = new System.Drawing.Size(1338, 76);
            this.enterUPErrorLabel.TabIndex = 14;
            this.enterUPErrorLabel.Text = "Enter a username and password";
            this.enterUPErrorLabel.Visible = false;
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.passLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passLabel.Font = new System.Drawing.Font("OCR A Extended", 60F);
            this.passLabel.ForeColor = System.Drawing.Color.Silver;
            this.passLabel.Location = new System.Drawing.Point(683, 95);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(419, 83);
            this.passLabel.TabIndex = 10;
            this.passLabel.Text = "Password";
            this.passLabel.Click += new System.EventHandler(this.passLabel_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.usernameLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.usernameLabel.Font = new System.Drawing.Font("OCR A Extended", 60F);
            this.usernameLabel.ForeColor = System.Drawing.Color.Silver;
            this.usernameLabel.Location = new System.Drawing.Point(6, 95);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(419, 83);
            this.usernameLabel.TabIndex = 9;
            this.usernameLabel.Text = "Username";
            this.usernameLabel.Click += new System.EventHandler(this.usernameLabel_Click);
            // 
            // signingInLabel
            // 
            this.signingInLabel.AutoSize = true;
            this.signingInLabel.Font = new System.Drawing.Font("OCR A Extended", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signingInLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(205)))), ((int)(((byte)(102)))));
            this.signingInLabel.Location = new System.Drawing.Point(242, 262);
            this.signingInLabel.Name = "signingInLabel";
            this.signingInLabel.Size = new System.Drawing.Size(868, 83);
            this.signingInLabel.TabIndex = 8;
            this.signingInLabel.Text = "Signing you in...";
            this.signingInLabel.Visible = false;
            // 
            // incLoginLabel
            // 
            this.incLoginLabel.AutoSize = true;
            this.incLoginLabel.Font = new System.Drawing.Font("OCR A Extended", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incLoginLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.incLoginLabel.Location = new System.Drawing.Point(291, 262);
            this.incLoginLabel.Name = "incLoginLabel";
            this.incLoginLabel.Size = new System.Drawing.Size(770, 83);
            this.incLoginLabel.TabIndex = 7;
            this.incLoginLabel.Text = "Incorrect Login";
            this.incLoginLabel.Visible = false;
            // 
            // takenLabel
            // 
            this.takenLabel.AutoSize = true;
            this.takenLabel.Font = new System.Drawing.Font("OCR A Extended", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takenLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.takenLabel.Location = new System.Drawing.Point(316, 262);
            this.takenLabel.Name = "takenLabel";
            this.takenLabel.Size = new System.Drawing.Size(721, 83);
            this.takenLabel.TabIndex = 6;
            this.takenLabel.Text = "Username Taken";
            this.takenLabel.Visible = false;
            // 
            // signInButton
            // 
            this.signInButton.AutoSize = true;
            this.signInButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.signInButton.Enabled = false;
            this.signInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.signInButton.Location = new System.Drawing.Point(801, 410);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(508, 101);
            this.signInButton.TabIndex = 4;
            this.signInButton.Text = "Sign In";
            this.signInButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.signInButton.UseVisualStyleBackColor = false;
            this.signInButton.Click += new System.EventHandler(this.button1_Click);
            this.signInButton.MouseHover += new System.EventHandler(this.signInButton_MouseHover);
            // 
            // newUserButton
            // 
            this.newUserButton.AutoSize = true;
            this.newUserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.newUserButton.Enabled = false;
            this.newUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUserButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.newUserButton.Location = new System.Drawing.Point(45, 410);
            this.newUserButton.Name = "newUserButton";
            this.newUserButton.Size = new System.Drawing.Size(508, 101);
            this.newUserButton.TabIndex = 3;
            this.newUserButton.Text = "New Player";
            this.newUserButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newUserButton.UseVisualStyleBackColor = false;
            this.newUserButton.Click += new System.EventHandler(this.newUserButton_Click);
            this.newUserButton.MouseHover += new System.EventHandler(this.newUserButton_MouseHover);
            // 
            // passTB
            // 
            this.passTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.passTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passTB.Font = new System.Drawing.Font("OCR A Extended", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.passTB.Location = new System.Drawing.Point(702, 95);
            this.passTB.Name = "passTB";
            this.passTB.Size = new System.Drawing.Size(646, 83);
            this.passTB.TabIndex = 2;
            this.passTB.TabStop = false;
            this.passTB.UseSystemPasswordChar = true;
            this.passTB.Click += new System.EventHandler(this.passLabel_Click);
            this.passTB.TextChanged += new System.EventHandler(this.usernameTB_TextChanged_1);
            this.passTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passTB_KeyDown);
            this.passTB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.passTB_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(682, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(655, 91);
            this.label2.TabIndex = 12;
            this.label2.Text = "______________";
            this.label2.Click += new System.EventHandler(this.passLabel_Click);
            // 
            // usernameTB
            // 
            this.usernameTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.usernameTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.usernameTB.Font = new System.Drawing.Font("OCR A Extended", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.usernameTB.Location = new System.Drawing.Point(18, 95);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(667, 83);
            this.usernameTB.TabIndex = 1;
            this.usernameTB.TabStop = false;
            this.usernameTB.Click += new System.EventHandler(this.usernameTB_Click);
            this.usernameTB.TextChanged += new System.EventHandler(this.usernameTB_TextChanged_1);
            this.usernameTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernameTB_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(6, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(699, 91);
            this.label1.TabIndex = 11;
            this.label1.Text = "_______________";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // coinPB
            // 
            this.coinPB.Image = global::Senior_Project.Properties.Resources._1200px_CoinMK8;
            this.coinPB.Location = new System.Drawing.Point(232, 4);
            this.coinPB.Name = "coinPB";
            this.coinPB.Size = new System.Drawing.Size(73, 73);
            this.coinPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coinPB.TabIndex = 23;
            this.coinPB.TabStop = false;
            // 
            // coinsLabel
            // 
            this.coinsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coinsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.coinsLabel.Location = new System.Drawing.Point(3, 4);
            this.coinsLabel.Name = "coinsLabel";
            this.coinsLabel.Size = new System.Drawing.Size(218, 73);
            this.coinsLabel.TabIndex = 24;
            this.coinsLabel.Text = "1000000";
            this.coinsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // leaderButton
            // 
            this.leaderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(80)))), ((int)(((byte)(130)))));
            this.leaderButton.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderButton.ForeColor = System.Drawing.Color.LightGray;
            this.leaderButton.Location = new System.Drawing.Point(12, 590);
            this.leaderButton.Name = "leaderButton";
            this.leaderButton.Size = new System.Drawing.Size(357, 68);
            this.leaderButton.TabIndex = 25;
            this.leaderButton.Text = "Leaderboard";
            this.leaderButton.UseVisualStyleBackColor = false;
            this.leaderButton.Visible = false;
            this.leaderButton.Click += new System.EventHandler(this.leaderButton_Click);
            // 
            // updater
            // 
            this.updater.WorkerReportsProgress = true;
            this.updater.WorkerSupportsCancellation = true;
            this.updater.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updater_DoWork);
            this.updater.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.updater_ProgressChanged);
            // 
            // leaderboardLB
            // 
            this.leaderboardLB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(80)))), ((int)(((byte)(130)))));
            this.leaderboardLB.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboardLB.ForeColor = System.Drawing.Color.LightGray;
            this.leaderboardLB.FormattingEnabled = true;
            this.leaderboardLB.ItemHeight = 50;
            this.leaderboardLB.Location = new System.Drawing.Point(84, 42);
            this.leaderboardLB.Margin = new System.Windows.Forms.Padding(0);
            this.leaderboardLB.Name = "leaderboardLB";
            this.leaderboardLB.Size = new System.Drawing.Size(50, 54);
            this.leaderboardLB.TabIndex = 8;
            this.leaderboardLB.Visible = false;
            // 
            // leaderboardTitle
            // 
            this.leaderboardTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.leaderboardTitle.Location = new System.Drawing.Point(136, 51);
            this.leaderboardTitle.Name = "leaderboardTitle";
            this.leaderboardTitle.Size = new System.Drawing.Size(22, 28);
            this.leaderboardTitle.TabIndex = 27;
            this.leaderboardTitle.Text = "Leaderboard";
            this.leaderboardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.leaderboardTitle.Visible = false;
            // 
            // oldPanelPB
            // 
            this.oldPanelPB.Location = new System.Drawing.Point(1260, 60);
            this.oldPanelPB.Name = "oldPanelPB";
            this.oldPanelPB.Size = new System.Drawing.Size(55, 73);
            this.oldPanelPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.oldPanelPB.TabIndex = 28;
            this.oldPanelPB.TabStop = false;
            this.oldPanelPB.Visible = false;
            // 
            // newPanelPB
            // 
            this.newPanelPB.Location = new System.Drawing.Point(1238, 60);
            this.newPanelPB.Name = "newPanelPB";
            this.newPanelPB.Size = new System.Drawing.Size(69, 65);
            this.newPanelPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.newPanelPB.TabIndex = 29;
            this.newPanelPB.TabStop = false;
            this.newPanelPB.Visible = false;
            // 
            // menuInstLabel
            // 
            this.menuInstLabel.AutoSize = true;
            this.menuInstLabel.Font = new System.Drawing.Font("OCR A Extended", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuInstLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuInstLabel.Location = new System.Drawing.Point(208, 560);
            this.menuInstLabel.Name = "menuInstLabel";
            this.menuInstLabel.Size = new System.Drawing.Size(941, 78);
            this.menuInstLabel.TabIndex = 30;
            this.menuInstLabel.Text = "Use the arrows to cycle through the games.\r\nClick the image to play.";
            this.menuInstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // coinPanel
            // 
            this.coinPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.coinPanel.Controls.Add(this.coinsLabel);
            this.coinPanel.Controls.Add(this.coinPB);
            this.coinPanel.Location = new System.Drawing.Point(1032, 582);
            this.coinPanel.Name = "coinPanel";
            this.coinPanel.Size = new System.Drawing.Size(312, 84);
            this.coinPanel.TabIndex = 31;
            this.coinPanel.Visible = false;
            // 
            // gamesPanel
            // 
            this.gamesPanel.Controls.Add(this.marioExPB);
            this.gamesPanel.Controls.Add(this.tetrisExPB);
            this.gamesPanel.Controls.Add(this.pongExPB);
            this.gamesPanel.Controls.Add(this.astExPB);
            this.gamesPanel.Controls.Add(this.snakeExPB);
            this.gamesPanel.Location = new System.Drawing.Point(245, 192);
            this.gamesPanel.Name = "gamesPanel";
            this.gamesPanel.Size = new System.Drawing.Size(862, 337);
            this.gamesPanel.TabIndex = 32;
            // 
            // marioExPB
            // 
            this.marioExPB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.marioExPB.Image = global::Senior_Project.Properties.Resources.supermariothumbsup_800x400;
            this.marioExPB.Location = new System.Drawing.Point(447, 180);
            this.marioExPB.Name = "marioExPB";
            this.marioExPB.Size = new System.Drawing.Size(248, 141);
            this.marioExPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.marioExPB.TabIndex = 37;
            this.marioExPB.TabStop = false;
            // 
            // tetrisExPB
            // 
            this.tetrisExPB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tetrisExPB.Image = global::Senior_Project.Properties.Resources.Tetris_Panel_Image;
            this.tetrisExPB.Location = new System.Drawing.Point(594, 3);
            this.tetrisExPB.Name = "tetrisExPB";
            this.tetrisExPB.Size = new System.Drawing.Size(248, 141);
            this.tetrisExPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tetrisExPB.TabIndex = 36;
            this.tetrisExPB.TabStop = false;
            // 
            // pongExPB
            // 
            this.pongExPB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pongExPB.Image = global::Senior_Project.Properties.Resources.Pong_Panel_Image;
            this.pongExPB.Location = new System.Drawing.Point(306, 3);
            this.pongExPB.Name = "pongExPB";
            this.pongExPB.Size = new System.Drawing.Size(248, 141);
            this.pongExPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pongExPB.TabIndex = 35;
            this.pongExPB.TabStop = false;
            // 
            // astExPB
            // 
            this.astExPB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.astExPB.Image = global::Senior_Project.Properties.Resources.Asteroids_Panel_Image;
            this.astExPB.Location = new System.Drawing.Point(167, 180);
            this.astExPB.Name = "astExPB";
            this.astExPB.Size = new System.Drawing.Size(248, 141);
            this.astExPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.astExPB.TabIndex = 34;
            this.astExPB.TabStop = false;
            // 
            // snakeExPB
            // 
            this.snakeExPB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.snakeExPB.Image = global::Senior_Project.Properties.Resources.Snake;
            this.snakeExPB.Location = new System.Drawing.Point(21, 3);
            this.snakeExPB.Name = "snakeExPB";
            this.snakeExPB.Size = new System.Drawing.Size(248, 141);
            this.snakeExPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.snakeExPB.TabIndex = 33;
            this.snakeExPB.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(56)))), ((int)(((byte)(91)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1356, 672);
            this.Controls.Add(this.startGB);
            this.Controls.Add(this.gamesPanel);
            this.Controls.Add(this.menuInstLabel);
            this.Controls.Add(this.coinPanel);
            this.Controls.Add(this.newPanelPB);
            this.Controls.Add(this.oldPanelPB);
            this.Controls.Add(this.titlePB);
            this.Controls.Add(this.leaderboardTitle);
            this.Controls.Add(this.leaderboardLB);
            this.Controls.Add(this.leaderButton);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.howPlayButton);
            this.Controls.Add(this.lastLabel);
            this.Controls.Add(this.nextLabel);
            this.Controls.Add(this.leftArrowPB);
            this.Controls.Add(this.rightArrowPB);
            this.Controls.Add(this.panelPB);
            this.Controls.Add(this.closeButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arcade";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Enter += new System.EventHandler(this.Form1_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.titlePB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftArrowPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightArrowPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelPB)).EndInit();
            this.startGB.ResumeLayout(false);
            this.startGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coinPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oldPanelPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newPanelPB)).EndInit();
            this.coinPanel.ResumeLayout(false);
            this.gamesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.marioExPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetrisExPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pongExPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.astExPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snakeExPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lastLabel;
        private System.Windows.Forms.Label nextLabel;
        private System.Windows.Forms.PictureBox leftArrowPB;
        private System.Windows.Forms.PictureBox rightArrowPB;
        private System.Windows.Forms.PictureBox panelPB;
        private System.Windows.Forms.PictureBox titlePB;
        private System.Windows.Forms.Button howPlayButton;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.GroupBox startGB;
        private System.Windows.Forms.Button newUserButton;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.TextBox passTB;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.Label takenLabel;
        private System.Windows.Forms.Label incLoginLabel;
        private System.Windows.Forms.PictureBox coinPB;
        private System.Windows.Forms.Label coinsLabel;
        private System.Windows.Forms.Button leaderButton;
        private System.ComponentModel.BackgroundWorker updater;
        private System.Windows.Forms.ListBox leaderboardLB;
        private System.Windows.Forms.Label leaderboardTitle;
        private System.Windows.Forms.Label signingInLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox oldPanelPB;
        private System.Windows.Forms.PictureBox newPanelPB;
        private System.Windows.Forms.Label loginInstructions;
        private System.Windows.Forms.Label enterUPErrorLabel;
        private System.Windows.Forms.Label menuInstLabel;
        private System.Windows.Forms.Panel coinPanel;
        private System.Windows.Forms.Panel gamesPanel;
        private System.Windows.Forms.PictureBox marioExPB;
        private System.Windows.Forms.PictureBox tetrisExPB;
        private System.Windows.Forms.PictureBox pongExPB;
        private System.Windows.Forms.PictureBox astExPB;
        private System.Windows.Forms.PictureBox snakeExPB;
    }
}

