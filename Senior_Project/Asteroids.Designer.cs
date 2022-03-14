namespace Senior_Project
{
    partial class Asteroids
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
            this.moveSpaceShip = new System.ComponentModel.BackgroundWorker();
            this.whileKey = new System.ComponentModel.BackgroundWorker();
            this.moveAsteroids = new System.ComponentModel.BackgroundWorker();
            this.checkCollision = new System.ComponentModel.BackgroundWorker();
            this.moveBullets = new System.ComponentModel.BackgroundWorker();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.spawnShip = new System.ComponentModel.BackgroundWorker();
            this.deadGB = new System.Windows.Forms.GroupBox();
            this.playAgainLabel = new System.Windows.Forms.Label();
            this.continueLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.againButton = new System.Windows.Forms.Button();
            this.deadPointsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.minigameButton = new System.Windows.Forms.Button();
            this.ufo = new System.Windows.Forms.PictureBox();
            this.shipPB = new System.Windows.Forms.PictureBox();
            this.life3 = new System.Windows.Forms.PictureBox();
            this.life2 = new System.Windows.Forms.PictureBox();
            this.life1 = new System.Windows.Forms.PictureBox();
            this.ufoWorker = new System.ComponentModel.BackgroundWorker();
            this.titleLabel = new System.Windows.Forms.Label();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.playLabel = new System.Windows.Forms.Label();
            this.pauseMenu = new System.Windows.Forms.GroupBox();
            this.howPlayButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.controlsButton = new System.Windows.Forms.Button();
            this.pauseExitButton = new System.Windows.Forms.Button();
            this.pausePlayButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.htpLabel = new System.Windows.Forms.Label();
            this.instLabel = new System.Windows.Forms.Label();
            this.colorPickerPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.exitSaveButton = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.colorSelectorButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.exampleShipPB = new System.Windows.Forms.PictureBox();
            this.colorDia = new System.Windows.Forms.ColorDialog();
            this.changeShipColorButton = new System.Windows.Forms.Label();
            this.deadGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ufo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life1)).BeginInit();
            this.pauseMenu.SuspendLayout();
            this.colorPickerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exampleShipPB)).BeginInit();
            this.SuspendLayout();
            // 
            // moveSpaceShip
            // 
            this.moveSpaceShip.WorkerReportsProgress = true;
            this.moveSpaceShip.WorkerSupportsCancellation = true;
            this.moveSpaceShip.DoWork += new System.ComponentModel.DoWorkEventHandler(this.moveSpaceShip_DoWork);
            this.moveSpaceShip.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.moveSpaceShip_ProgressChanged);
            // 
            // whileKey
            // 
            this.whileKey.WorkerReportsProgress = true;
            this.whileKey.WorkerSupportsCancellation = true;
            this.whileKey.DoWork += new System.ComponentModel.DoWorkEventHandler(this.whileKey_DoWork);
            this.whileKey.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.whileKey_ProgressChanged);
            // 
            // moveAsteroids
            // 
            this.moveAsteroids.WorkerReportsProgress = true;
            this.moveAsteroids.WorkerSupportsCancellation = true;
            this.moveAsteroids.DoWork += new System.ComponentModel.DoWorkEventHandler(this.moveAsteroids_DoWork);
            this.moveAsteroids.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.moveAsteroids_ProgressChanged);
            // 
            // checkCollision
            // 
            this.checkCollision.WorkerReportsProgress = true;
            this.checkCollision.WorkerSupportsCancellation = true;
            this.checkCollision.DoWork += new System.ComponentModel.DoWorkEventHandler(this.checkCollision_DoWork);
            this.checkCollision.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.checkCollision_ProgressChanged);
            // 
            // moveBullets
            // 
            this.moveBullets.WorkerReportsProgress = true;
            this.moveBullets.WorkerSupportsCancellation = true;
            this.moveBullets.DoWork += new System.ComponentModel.DoWorkEventHandler(this.moveBullets_DoWork);
            this.moveBullets.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.moveBullets_ProgressChanged);
            // 
            // pointsLabel
            // 
            this.pointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pointsLabel.Location = new System.Drawing.Point(3, 9);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(230, 70);
            this.pointsLabel.TabIndex = 2;
            this.pointsLabel.Text = "0";
            this.pointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spawnShip
            // 
            this.spawnShip.WorkerReportsProgress = true;
            this.spawnShip.WorkerSupportsCancellation = true;
            this.spawnShip.DoWork += new System.ComponentModel.DoWorkEventHandler(this.spawnShip_DoWork);
            this.spawnShip.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.spawnShip_ProgressChanged);
            // 
            // deadGB
            // 
            this.deadGB.Controls.Add(this.playAgainLabel);
            this.deadGB.Controls.Add(this.continueLabel);
            this.deadGB.Controls.Add(this.label4);
            this.deadGB.Controls.Add(this.exitButton);
            this.deadGB.Controls.Add(this.againButton);
            this.deadGB.Controls.Add(this.deadPointsLabel);
            this.deadGB.Controls.Add(this.label2);
            this.deadGB.Controls.Add(this.label1);
            this.deadGB.Controls.Add(this.pictureBox1);
            this.deadGB.Controls.Add(this.minigameButton);
            this.deadGB.Location = new System.Drawing.Point(1083, 414);
            this.deadGB.Name = "deadGB";
            this.deadGB.Size = new System.Drawing.Size(65, 53);
            this.deadGB.TabIndex = 6;
            this.deadGB.TabStop = false;
            this.deadGB.Visible = false;
            // 
            // playAgainLabel
            // 
            this.playAgainLabel.Font = new System.Drawing.Font("OCR A Extended", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playAgainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.playAgainLabel.Location = new System.Drawing.Point(467, 361);
            this.playAgainLabel.Name = "playAgainLabel";
            this.playAgainLabel.Size = new System.Drawing.Size(348, 83);
            this.playAgainLabel.TabIndex = 9;
            this.playAgainLabel.Text = "Play again, starting from 0";
            this.playAgainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.playAgainLabel.Visible = false;
            // 
            // continueLabel
            // 
            this.continueLabel.Font = new System.Drawing.Font("OCR A Extended", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.continueLabel.Location = new System.Drawing.Point(4, 323);
            this.continueLabel.Name = "continueLabel";
            this.continueLabel.Size = new System.Drawing.Size(451, 121);
            this.continueLabel.TabIndex = 8;
            this.continueLabel.Text = "Play a minigame for a chance to keep your score";
            this.continueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.continueLabel.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(25, 453);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 60);
            this.label4.TabIndex = 6;
            this.label4.Text = "50";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(847, 445);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(320, 73);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // againButton
            // 
            this.againButton.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.againButton.Location = new System.Drawing.Point(481, 445);
            this.againButton.Name = "againButton";
            this.againButton.Size = new System.Drawing.Size(320, 73);
            this.againButton.TabIndex = 3;
            this.againButton.Text = "Play Again";
            this.againButton.UseVisualStyleBackColor = true;
            this.againButton.Click += new System.EventHandler(this.againButton_Click);
            this.againButton.MouseLeave += new System.EventHandler(this.againButton_MouseLeave);
            this.againButton.MouseHover += new System.EventHandler(this.againButton_MouseHover);
            // 
            // deadPointsLabel
            // 
            this.deadPointsLabel.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deadPointsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.deadPointsLabel.Location = new System.Drawing.Point(0, 213);
            this.deadPointsLabel.Name = "deadPointsLabel";
            this.deadPointsLabel.Size = new System.Drawing.Size(1180, 50);
            this.deadPointsLabel.TabIndex = 2;
            this.deadPointsLabel.Text = "0";
            this.deadPointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(478, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 50);
            this.label2.TabIndex = 1;
            this.label2.Text = "Points:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(308, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 99);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Over";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Image = global::Senior_Project.Properties.Resources._1200px_CoinMK8;
            this.pictureBox1.Location = new System.Drawing.Point(111, 453);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // minigameButton
            // 
            this.minigameButton.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minigameButton.Location = new System.Drawing.Point(24, 447);
            this.minigameButton.Name = "minigameButton";
            this.minigameButton.Size = new System.Drawing.Size(410, 73);
            this.minigameButton.TabIndex = 5;
            this.minigameButton.Text = "Continue";
            this.minigameButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.minigameButton.UseVisualStyleBackColor = true;
            this.minigameButton.Click += new System.EventHandler(this.minigameButton_Click);
            this.minigameButton.MouseLeave += new System.EventHandler(this.minigameButton_MouseLeave);
            this.minigameButton.MouseHover += new System.EventHandler(this.minigameButton_MouseHover);
            // 
            // ufo
            // 
            this.ufo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ufo.Image = global::Senior_Project.Properties.Resources.UFO;
            this.ufo.Location = new System.Drawing.Point(1015, 25);
            this.ufo.Margin = new System.Windows.Forms.Padding(0);
            this.ufo.Name = "ufo";
            this.ufo.Size = new System.Drawing.Size(88, 54);
            this.ufo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ufo.TabIndex = 7;
            this.ufo.TabStop = false;
            this.ufo.Visible = false;
            // 
            // shipPB
            // 
            this.shipPB.BackColor = System.Drawing.Color.White;
            this.shipPB.Image = global::Senior_Project.Properties.Resources.Transparent_Ship;
            this.shipPB.Location = new System.Drawing.Point(561, 253);
            this.shipPB.Margin = new System.Windows.Forms.Padding(0);
            this.shipPB.Name = "shipPB";
            this.shipPB.Size = new System.Drawing.Size(55, 55);
            this.shipPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.shipPB.TabIndex = 0;
            this.shipPB.TabStop = false;
            // 
            // life3
            // 
            this.life3.Image = global::Senior_Project.Properties.Resources.Ship___Copy__2_;
            this.life3.Location = new System.Drawing.Point(149, 82);
            this.life3.Name = "life3";
            this.life3.Size = new System.Drawing.Size(50, 50);
            this.life3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.life3.TabIndex = 5;
            this.life3.TabStop = false;
            // 
            // life2
            // 
            this.life2.Image = global::Senior_Project.Properties.Resources.Ship___Copy__2_;
            this.life2.Location = new System.Drawing.Point(93, 82);
            this.life2.Name = "life2";
            this.life2.Size = new System.Drawing.Size(50, 50);
            this.life2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.life2.TabIndex = 4;
            this.life2.TabStop = false;
            // 
            // life1
            // 
            this.life1.Image = global::Senior_Project.Properties.Resources.Ship___Copy__2_;
            this.life1.Location = new System.Drawing.Point(37, 82);
            this.life1.Name = "life1";
            this.life1.Size = new System.Drawing.Size(50, 50);
            this.life1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.life1.TabIndex = 3;
            this.life1.TabStop = false;
            // 
            // ufoWorker
            // 
            this.ufoWorker.WorkerReportsProgress = true;
            this.ufoWorker.WorkerSupportsCancellation = true;
            this.ufoWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ufoWorker_DoWork);
            this.ufoWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ufoWorker_ProgressChanged);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("OCR A Extended", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.titleLabel.Location = new System.Drawing.Point(307, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(564, 99);
            this.titleLabel.TabIndex = 8;
            this.titleLabel.Text = "Asteroids";
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.instructionsLabel.Location = new System.Drawing.Point(165, 108);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(896, 112);
            this.instructionsLabel.TabIndex = 9;
            this.instructionsLabel.Text = "Shoot the asteroids and avoid getting hit.\r\n";
            this.instructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playLabel
            // 
            this.playLabel.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.playLabel.Location = new System.Drawing.Point(165, 315);
            this.playLabel.Name = "playLabel";
            this.playLabel.Size = new System.Drawing.Size(896, 120);
            this.playLabel.TabIndex = 10;
            this.playLabel.Text = "Press any key to start.";
            this.playLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pauseMenu
            // 
            this.pauseMenu.Controls.Add(this.howPlayButton);
            this.pauseMenu.Controls.Add(this.label3);
            this.pauseMenu.Controls.Add(this.resetButton);
            this.pauseMenu.Controls.Add(this.controlsButton);
            this.pauseMenu.Controls.Add(this.pauseExitButton);
            this.pauseMenu.Controls.Add(this.pausePlayButton);
            this.pauseMenu.Controls.Add(this.closeButton);
            this.pauseMenu.Controls.Add(this.htpLabel);
            this.pauseMenu.Controls.Add(this.instLabel);
            this.pauseMenu.Location = new System.Drawing.Point(1115, 70);
            this.pauseMenu.Name = "pauseMenu";
            this.pauseMenu.Size = new System.Drawing.Size(37, 36);
            this.pauseMenu.TabIndex = 11;
            this.pauseMenu.TabStop = false;
            this.pauseMenu.Visible = false;
            // 
            // howPlayButton
            // 
            this.howPlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howPlayButton.Location = new System.Drawing.Point(128, 175);
            this.howPlayButton.Name = "howPlayButton";
            this.howPlayButton.Size = new System.Drawing.Size(224, 53);
            this.howPlayButton.TabIndex = 16;
            this.howPlayButton.Text = "How to play";
            this.howPlayButton.UseVisualStyleBackColor = true;
            this.howPlayButton.Click += new System.EventHandler(this.howPlayButton_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(142, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 64);
            this.label3.TabIndex = 12;
            this.label3.Text = "Paused";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(128, 247);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(224, 53);
            this.resetButton.TabIndex = 15;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // controlsButton
            // 
            this.controlsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlsButton.Location = new System.Drawing.Point(128, 103);
            this.controlsButton.Name = "controlsButton";
            this.controlsButton.Size = new System.Drawing.Size(224, 53);
            this.controlsButton.TabIndex = 14;
            this.controlsButton.Text = "Controls";
            this.controlsButton.UseVisualStyleBackColor = true;
            this.controlsButton.Click += new System.EventHandler(this.controlsButton_Click);
            // 
            // pauseExitButton
            // 
            this.pauseExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseExitButton.Location = new System.Drawing.Point(255, 329);
            this.pauseExitButton.Name = "pauseExitButton";
            this.pauseExitButton.Size = new System.Drawing.Size(187, 68);
            this.pauseExitButton.TabIndex = 13;
            this.pauseExitButton.Text = "Exit";
            this.pauseExitButton.UseVisualStyleBackColor = true;
            this.pauseExitButton.Click += new System.EventHandler(this.pauseExitButton_Click);
            // 
            // pausePlayButton
            // 
            this.pausePlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pausePlayButton.Location = new System.Drawing.Point(39, 329);
            this.pausePlayButton.Name = "pausePlayButton";
            this.pausePlayButton.Size = new System.Drawing.Size(187, 68);
            this.pausePlayButton.TabIndex = 12;
            this.pausePlayButton.Text = "Resume";
            this.pausePlayButton.UseVisualStyleBackColor = true;
            this.pausePlayButton.Click += new System.EventHandler(this.pausePlayButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(147, 306);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(187, 68);
            this.closeButton.TabIndex = 18;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Visible = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // htpLabel
            // 
            this.htpLabel.Font = new System.Drawing.Font("OCR A Extended", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.htpLabel.ForeColor = System.Drawing.Color.White;
            this.htpLabel.Location = new System.Drawing.Point(6, 8);
            this.htpLabel.Name = "htpLabel";
            this.htpLabel.Size = new System.Drawing.Size(468, 403);
            this.htpLabel.TabIndex = 19;
            this.htpLabel.Text = "Move around the screen, dodging the asteroids. Shoot and destroy them to get poin" +
    "ts. Avoid the ufo\'s bullets.\r\n\r\n";
            this.htpLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.htpLabel.Visible = false;
            // 
            // instLabel
            // 
            this.instLabel.Font = new System.Drawing.Font("OCR A Extended", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instLabel.ForeColor = System.Drawing.Color.White;
            this.instLabel.Location = new System.Drawing.Point(6, 12);
            this.instLabel.Name = "instLabel";
            this.instLabel.Size = new System.Drawing.Size(468, 399);
            this.instLabel.TabIndex = 17;
            this.instLabel.Text = "Moving - WASD or Arrow Keys\r\n\r\nShooting - Space\r\n\r\nHyper Jump - Shift\r\n";
            this.instLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.instLabel.Visible = false;
            // 
            // colorPickerPanel
            // 
            this.colorPickerPanel.Controls.Add(this.button1);
            this.colorPickerPanel.Controls.Add(this.exitSaveButton);
            this.colorPickerPanel.Controls.Add(this.pictureBox5);
            this.colorPickerPanel.Controls.Add(this.pictureBox4);
            this.colorPickerPanel.Controls.Add(this.pictureBox3);
            this.colorPickerPanel.Controls.Add(this.pictureBox2);
            this.colorPickerPanel.Controls.Add(this.colorSelectorButton);
            this.colorPickerPanel.Controls.Add(this.label5);
            this.colorPickerPanel.Controls.Add(this.exampleShipPB);
            this.colorPickerPanel.Location = new System.Drawing.Point(979, 454);
            this.colorPickerPanel.Name = "colorPickerPanel";
            this.colorPickerPanel.Size = new System.Drawing.Size(73, 55);
            this.colorPickerPanel.TabIndex = 13;
            this.colorPickerPanel.Visible = false;
            this.colorPickerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.colorPickerPanel_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("OCR A Extended", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(583, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(309, 90);
            this.button1.TabIndex = 21;
            this.button1.Text = "Exit Without Saving";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // exitSaveButton
            // 
            this.exitSaveButton.BackColor = System.Drawing.Color.Black;
            this.exitSaveButton.Font = new System.Drawing.Font("OCR A Extended", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitSaveButton.ForeColor = System.Drawing.SystemColors.Control;
            this.exitSaveButton.Location = new System.Drawing.Point(287, 444);
            this.exitSaveButton.Name = "exitSaveButton";
            this.exitSaveButton.Size = new System.Drawing.Size(271, 90);
            this.exitSaveButton.TabIndex = 20;
            this.exitSaveButton.Text = "Exit and Save";
            this.exitSaveButton.UseVisualStyleBackColor = false;
            this.exitSaveButton.Click += new System.EventHandler(this.exitSaveButton_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Black;
            this.pictureBox5.Location = new System.Drawing.Point(281, 144);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(200, 44);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 19;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Black;
            this.pictureBox4.Location = new System.Drawing.Point(258, 159);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(53, 200);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Location = new System.Drawing.Point(281, 334);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(200, 49);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(444, 159);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 200);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // colorSelectorButton
            // 
            this.colorSelectorButton.BackColor = System.Drawing.Color.Black;
            this.colorSelectorButton.Font = new System.Drawing.Font("OCR A Extended", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorSelectorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.colorSelectorButton.Location = new System.Drawing.Point(600, 227);
            this.colorSelectorButton.Name = "colorSelectorButton";
            this.colorSelectorButton.Size = new System.Drawing.Size(271, 90);
            this.colorSelectorButton.TabIndex = 15;
            this.colorSelectorButton.Text = "Color Selector";
            this.colorSelectorButton.UseVisualStyleBackColor = false;
            this.colorSelectorButton.Click += new System.EventHandler(this.colorSelectorButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("OCR A Extended", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(133, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(912, 99);
            this.label5.TabIndex = 14;
            this.label5.Text = "Color Selection";
            // 
            // exampleShipPB
            // 
            this.exampleShipPB.BackColor = System.Drawing.Color.White;
            this.exampleShipPB.Image = global::Senior_Project.Properties.Resources.Transparent_Ship;
            this.exampleShipPB.Location = new System.Drawing.Point(281, 173);
            this.exampleShipPB.Margin = new System.Windows.Forms.Padding(0);
            this.exampleShipPB.Name = "exampleShipPB";
            this.exampleShipPB.Size = new System.Drawing.Size(200, 200);
            this.exampleShipPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exampleShipPB.TabIndex = 14;
            this.exampleShipPB.TabStop = false;
            // 
            // colorDia
            // 
            this.colorDia.AnyColor = true;
            this.colorDia.FullOpen = true;
            // 
            // changeShipColorButton
            // 
            this.changeShipColorButton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.changeShipColorButton.Font = new System.Drawing.Font("OCR A Extended", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeShipColorButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.changeShipColorButton.Location = new System.Drawing.Point(12, 444);
            this.changeShipColorButton.Name = "changeShipColorButton";
            this.changeShipColorButton.Size = new System.Drawing.Size(264, 93);
            this.changeShipColorButton.TabIndex = 14;
            this.changeShipColorButton.Text = "Change Ship Color";
            this.changeShipColorButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.changeShipColorButton.Click += new System.EventHandler(this.changeShipColorButton_Click_1);
            // 
            // Asteroids
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1179, 546);
            this.Controls.Add(this.colorPickerPanel);
            this.Controls.Add(this.changeShipColorButton);
            this.Controls.Add(this.deadGB);
            this.Controls.Add(this.pauseMenu);
            this.Controls.Add(this.playLabel);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.ufo);
            this.Controls.Add(this.shipPB);
            this.Controls.Add(this.life3);
            this.Controls.Add(this.life2);
            this.Controls.Add(this.life1);
            this.Controls.Add(this.pointsLabel);
            this.Name = "Asteroids";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asteroids";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Asteroids_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Asteroids_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Asteroids_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Asteroids_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Asteroids_KeyUp);
            this.deadGB.ResumeLayout(false);
            this.deadGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ufo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life1)).EndInit();
            this.pauseMenu.ResumeLayout(false);
            this.colorPickerPanel.ResumeLayout(false);
            this.colorPickerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exampleShipPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox shipPB;
        private System.ComponentModel.BackgroundWorker moveSpaceShip;
        private System.ComponentModel.BackgroundWorker whileKey;
        private System.ComponentModel.BackgroundWorker moveAsteroids;
        private System.ComponentModel.BackgroundWorker checkCollision;
        private System.ComponentModel.BackgroundWorker moveBullets;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.PictureBox life1;
        private System.Windows.Forms.PictureBox life2;
        private System.Windows.Forms.PictureBox life3;
        private System.ComponentModel.BackgroundWorker spawnShip;
        private System.Windows.Forms.GroupBox deadGB;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button againButton;
        private System.Windows.Forms.Label deadPointsLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ufo;
        private System.ComponentModel.BackgroundWorker ufoWorker;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Label playLabel;
        private System.Windows.Forms.GroupBox pauseMenu;
        private System.Windows.Forms.Button pauseExitButton;
        private System.Windows.Forms.Button pausePlayButton;
        private System.Windows.Forms.Button controlsButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button howPlayButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label instLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label htpLabel;
        private System.Windows.Forms.Button minigameButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label playAgainLabel;
        private System.Windows.Forms.Label continueLabel;
        private System.Windows.Forms.Panel colorPickerPanel;
        private System.Windows.Forms.PictureBox exampleShipPB;
        private System.Windows.Forms.ColorDialog colorDia;
        private System.Windows.Forms.Button colorSelectorButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button exitSaveButton;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label changeShipColorButton;
    }
}