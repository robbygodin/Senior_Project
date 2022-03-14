namespace Senior_Project
{
    partial class Splash
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
            this.robbyPB = new System.Windows.Forms.PictureBox();
            this.toPB = new System.Windows.Forms.PictureBox();
            this.welcomePB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.robbyPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.welcomePB)).BeginInit();
            this.SuspendLayout();
            // 
            // robbyPB
            // 
            this.robbyPB.Image = global::Senior_Project.Properties.Resources.Untitled;
            this.robbyPB.Location = new System.Drawing.Point(12, 279);
            this.robbyPB.Name = "robbyPB";
            this.robbyPB.Size = new System.Drawing.Size(1090, 122);
            this.robbyPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.robbyPB.TabIndex = 2;
            this.robbyPB.TabStop = false;
            this.robbyPB.Visible = false;
            // 
            // toPB
            // 
            this.toPB.Image = global::Senior_Project.Properties.Resources.To;
            this.toPB.Location = new System.Drawing.Point(221, 151);
            this.toPB.Name = "toPB";
            this.toPB.Size = new System.Drawing.Size(681, 122);
            this.toPB.TabIndex = 1;
            this.toPB.TabStop = false;
            this.toPB.Visible = false;
            // 
            // welcomePB
            // 
            this.welcomePB.Image = global::Senior_Project.Properties.Resources.Welcome;
            this.welcomePB.Location = new System.Drawing.Point(221, 23);
            this.welcomePB.Name = "welcomePB";
            this.welcomePB.Size = new System.Drawing.Size(681, 122);
            this.welcomePB.TabIndex = 0;
            this.welcomePB.TabStop = false;
            this.welcomePB.Visible = false;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1114, 600);
            this.Controls.Add(this.robbyPB);
            this.Controls.Add(this.toPB);
            this.Controls.Add(this.welcomePB);
            this.Name = "Splash";
            this.Text = "Splash";
            ((System.ComponentModel.ISupportInitialize)(this.robbyPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.welcomePB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox welcomePB;
        private System.Windows.Forms.PictureBox toPB;
        private System.Windows.Forms.PictureBox robbyPB;
    }
}