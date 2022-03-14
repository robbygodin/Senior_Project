namespace Senior_Project
{
    partial class Pong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pong));
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.compPointsLabel = new System.Windows.Forms.Label();
            this.userPointsLabel = new System.Windows.Forms.Label();
            this.player1Label = new System.Windows.Forms.Label();
            this.ball = new System.Windows.Forms.PictureBox();
            this.userPanel = new System.Windows.Forms.PictureBox();
            this.compPanel = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.middleLinePB = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.movePanelBack = new System.ComponentModel.BackgroundWorker();
            this.compPanelBack = new System.ComponentModel.BackgroundWorker();
            this.startGB = new System.Windows.Forms.GroupBox();
            this.playButton = new System.Windows.Forms.Button();
            this.instlabel = new System.Windows.Forms.Label();
            this.twoPlayerButton = new System.Windows.Forms.Button();
            this.onePlayerButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleLinePB)).BeginInit();
            this.startGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.Font = new System.Drawing.Font("OCR A Extended", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.instructionsLabel.Location = new System.Drawing.Point(161, 96);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(479, 39);
            this.instructionsLabel.TabIndex = 31;
            this.instructionsLabel.Text = "Press Any Key to Play";
            // 
            // compPointsLabel
            // 
            this.compPointsLabel.AutoSize = true;
            this.compPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compPointsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.compPointsLabel.Location = new System.Drawing.Point(421, 9);
            this.compPointsLabel.Name = "compPointsLabel";
            this.compPointsLabel.Size = new System.Drawing.Size(39, 42);
            this.compPointsLabel.TabIndex = 30;
            this.compPointsLabel.Text = "0";
            // 
            // userPointsLabel
            // 
            this.userPointsLabel.AutoSize = true;
            this.userPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userPointsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userPointsLabel.Location = new System.Drawing.Point(351, 9);
            this.userPointsLabel.Name = "userPointsLabel";
            this.userPointsLabel.Size = new System.Drawing.Size(39, 42);
            this.userPointsLabel.TabIndex = 29;
            this.userPointsLabel.Text = "0";
            // 
            // player1Label
            // 
            this.player1Label.Font = new System.Drawing.Font("OCR A Extended", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.player1Label.Location = new System.Drawing.Point(5, 9);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(322, 78);
            this.player1Label.TabIndex = 28;
            this.player1Label.Text = "Player 1 (WASD)";
            this.player1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ball
            // 
            this.ball.Image = global::Senior_Project.Properties.Resources.Blue_Square;
            this.ball.Location = new System.Drawing.Point(393, 210);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(25, 25);
            this.ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ball.TabIndex = 27;
            this.ball.TabStop = false;
            // 
            // userPanel
            // 
            this.userPanel.Image = global::Senior_Project.Properties.Resources.Blue_Panel;
            this.userPanel.Location = new System.Drawing.Point(15, 168);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(25, 115);
            this.userPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPanel.TabIndex = 26;
            this.userPanel.TabStop = false;
            // 
            // compPanel
            // 
            this.compPanel.Image = global::Senior_Project.Properties.Resources.Blue_Panel;
            this.compPanel.Location = new System.Drawing.Point(770, 168);
            this.compPanel.Name = "compPanel";
            this.compPanel.Size = new System.Drawing.Size(25, 115);
            this.compPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.compPanel.TabIndex = 25;
            this.compPanel.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(393, 395);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(393, 330);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 50);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(393, 265);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(25, 50);
            this.pictureBox8.TabIndex = 22;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(393, 200);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(25, 50);
            this.pictureBox6.TabIndex = 21;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(393, 135);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(25, 50);
            this.pictureBox4.TabIndex = 20;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(393, 70);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 50);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // middleLinePB
            // 
            this.middleLinePB.Image = ((System.Drawing.Image)(resources.GetObject("middleLinePB.Image")));
            this.middleLinePB.Location = new System.Drawing.Point(393, 5);
            this.middleLinePB.Margin = new System.Windows.Forms.Padding(0);
            this.middleLinePB.Name = "middleLinePB";
            this.middleLinePB.Size = new System.Drawing.Size(25, 50);
            this.middleLinePB.TabIndex = 18;
            this.middleLinePB.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork_1);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged_1);
            // 
            // movePanelBack
            // 
            this.movePanelBack.WorkerReportsProgress = true;
            this.movePanelBack.WorkerSupportsCancellation = true;
            this.movePanelBack.DoWork += new System.ComponentModel.DoWorkEventHandler(this.movePanelBack_DoWork_1);
            this.movePanelBack.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.movePanelBack_ProgressChanged_1);
            // 
            // compPanelBack
            // 
            this.compPanelBack.WorkerReportsProgress = true;
            this.compPanelBack.WorkerSupportsCancellation = true;
            this.compPanelBack.DoWork += new System.ComponentModel.DoWorkEventHandler(this.compPanelBack_DoWork_1);
            this.compPanelBack.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.compPanelBack_ProgressChanged_1);
            // 
            // startGB
            // 
            this.startGB.Controls.Add(this.playButton);
            this.startGB.Controls.Add(this.instlabel);
            this.startGB.Controls.Add(this.twoPlayerButton);
            this.startGB.Controls.Add(this.onePlayerButton);
            this.startGB.Controls.Add(this.titleLabel);
            this.startGB.Location = new System.Drawing.Point(748, 411);
            this.startGB.Name = "startGB";
            this.startGB.Size = new System.Drawing.Size(36, 27);
            this.startGB.TabIndex = 32;
            this.startGB.TabStop = false;
            // 
            // playButton
            // 
            this.playButton.Font = new System.Drawing.Font("OCR A Extended", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(302, 369);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(204, 58);
            this.playButton.TabIndex = 38;
            this.playButton.Text = "Play";
            this.playButton.UseMnemonic = false;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // instlabel
            // 
            this.instlabel.Font = new System.Drawing.Font("OCR A Extended", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.instlabel.Location = new System.Drawing.Point(15, 94);
            this.instlabel.Name = "instlabel";
            this.instlabel.Size = new System.Drawing.Size(773, 200);
            this.instlabel.TabIndex = 37;
            this.instlabel.Text = "You control just the left panel. Use either WASD or the arrow keys to control you" +
    "r panel. Don\'t let the ball go behind your panel. Good Luck!";
            this.instlabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // twoPlayerButton
            // 
            this.twoPlayerButton.Font = new System.Drawing.Font("OCR A Extended", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoPlayerButton.Location = new System.Drawing.Point(436, 300);
            this.twoPlayerButton.Name = "twoPlayerButton";
            this.twoPlayerButton.Size = new System.Drawing.Size(329, 58);
            this.twoPlayerButton.TabIndex = 36;
            this.twoPlayerButton.Text = "Two Players";
            this.twoPlayerButton.UseVisualStyleBackColor = true;
            this.twoPlayerButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // onePlayerButton
            // 
            this.onePlayerButton.Font = new System.Drawing.Font("OCR A Extended", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onePlayerButton.Location = new System.Drawing.Point(43, 300);
            this.onePlayerButton.Name = "onePlayerButton";
            this.onePlayerButton.Size = new System.Drawing.Size(329, 58);
            this.onePlayerButton.TabIndex = 35;
            this.onePlayerButton.Text = "One Player";
            this.onePlayerButton.UseMnemonic = false;
            this.onePlayerButton.UseVisualStyleBackColor = true;
            this.onePlayerButton.Click += new System.EventHandler(this.onePlayerButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("OCR A Extended", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.titleLabel.Location = new System.Drawing.Point(291, -3);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(227, 83);
            this.titleLabel.TabIndex = 34;
            this.titleLabel.Text = "Pong";
            // 
            // player2Label
            // 
            this.player2Label.Font = new System.Drawing.Font("OCR A Extended", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.player2Label.Location = new System.Drawing.Point(474, 9);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(322, 78);
            this.player2Label.TabIndex = 33;
            this.player2Label.Text = "Player 2 (Arrow Keys)";
            this.player2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startGB);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.compPointsLabel);
            this.Controls.Add(this.userPointsLabel);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.userPanel);
            this.Controls.Add(this.compPanel);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.middleLinePB);
            this.Controls.Add(this.player2Label);
            this.Name = "Pong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pong";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Pong_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pong_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Pong_KeyUp_1);
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleLinePB)).EndInit();
            this.startGB.ResumeLayout(false);
            this.startGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Label compPointsLabel;
        private System.Windows.Forms.Label userPointsLabel;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.PictureBox userPanel;
        private System.Windows.Forms.PictureBox compPanel;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox middleLinePB;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker movePanelBack;
        private System.ComponentModel.BackgroundWorker compPanelBack;
        private System.Windows.Forms.GroupBox startGB;
        private System.Windows.Forms.Label instlabel;
        private System.Windows.Forms.Button twoPlayerButton;
        private System.Windows.Forms.Button onePlayerButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.Button playButton;
    }
}