namespace Senior_Project
{
    partial class NewSplash
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
            this.robby = new System.Windows.Forms.PictureBox();
            this.obby = new System.Windows.Forms.PictureBox();
            this.flasher = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.robby)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obby)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // robby
            // 
            this.robby.BackColor = System.Drawing.Color.Transparent;
            this.robby.Image = global::Senior_Project.Properties.Resources.coollogo_com_18025511;
            this.robby.Location = new System.Drawing.Point(53, 36);
            this.robby.Margin = new System.Windows.Forms.Padding(0);
            this.robby.Name = "robby";
            this.robby.Size = new System.Drawing.Size(992, 128);
            this.robby.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.robby.TabIndex = 1;
            this.robby.TabStop = false;
            // 
            // obby
            // 
            this.obby.BackColor = System.Drawing.Color.Transparent;
            this.obby.Image = global::Senior_Project.Properties.Resources.coollogo_com_2280627241;
            this.obby.Location = new System.Drawing.Point(87, 36);
            this.obby.Margin = new System.Windows.Forms.Padding(0);
            this.obby.Name = "obby";
            this.obby.Size = new System.Drawing.Size(992, 128);
            this.obby.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.obby.TabIndex = 2;
            this.obby.TabStop = false;
            // 
            // flasher
            // 
            this.flasher.WorkerReportsProgress = true;
            this.flasher.WorkerSupportsCancellation = true;
            this.flasher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.flasher_DoWork);
            this.flasher.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.flasher_ProgressChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Senior_Project.Properties.Resources.Steel_Door;
            this.pictureBox1.Location = new System.Drawing.Point(462, 198);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 402);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // NewSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.BackgroundImage = global::Senior_Project.Properties.Resources._96d85c7ab7e8eb0a61c84be58c363660;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1114, 600);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.robby);
            this.Controls.Add(this.obby);
            this.Name = "NewSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewSplash";
            this.Shown += new System.EventHandler(this.NewSplash_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.robby)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obby)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox robby;
        private System.Windows.Forms.PictureBox obby;
        private System.ComponentModel.BackgroundWorker flasher;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}