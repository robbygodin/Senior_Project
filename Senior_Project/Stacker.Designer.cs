
namespace Senior_Project
{
    partial class Stacker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stacker));
            this.block1 = new System.Windows.Forms.PictureBox();
            this.block2 = new System.Windows.Forms.PictureBox();
            this.block3 = new System.Windows.Forms.PictureBox();
            this.blocksMover = new System.ComponentModel.BackgroundWorker();
            this.titleLabel = new System.Windows.Forms.Label();
            this.instLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.block1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.block2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.block3)).BeginInit();
            this.SuspendLayout();
            // 
            // block1
            // 
            this.block1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.block1.Image = ((System.Drawing.Image)(resources.GetObject("block1.Image")));
            this.block1.Location = new System.Drawing.Point(0, 751);
            this.block1.Margin = new System.Windows.Forms.Padding(0);
            this.block1.Name = "block1";
            this.block1.Size = new System.Drawing.Size(75, 75);
            this.block1.TabIndex = 0;
            this.block1.TabStop = false;
            // 
            // block2
            // 
            this.block2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.block2.Image = ((System.Drawing.Image)(resources.GetObject("block2.Image")));
            this.block2.Location = new System.Drawing.Point(75, 751);
            this.block2.Margin = new System.Windows.Forms.Padding(0);
            this.block2.Name = "block2";
            this.block2.Size = new System.Drawing.Size(75, 75);
            this.block2.TabIndex = 1;
            this.block2.TabStop = false;
            // 
            // block3
            // 
            this.block3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.block3.Image = ((System.Drawing.Image)(resources.GetObject("block3.Image")));
            this.block3.Location = new System.Drawing.Point(150, 751);
            this.block3.Margin = new System.Windows.Forms.Padding(0);
            this.block3.Name = "block3";
            this.block3.Size = new System.Drawing.Size(75, 75);
            this.block3.TabIndex = 2;
            this.block3.TabStop = false;
            // 
            // blocksMover
            // 
            this.blocksMover.WorkerReportsProgress = true;
            this.blocksMover.WorkerSupportsCancellation = true;
            this.blocksMover.DoWork += new System.ComponentModel.DoWorkEventHandler(this.blocksMover_DoWork);
            this.blocksMover.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.blocksMover_ProgressChanged);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("OCR A Extended", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.titleLabel.Location = new System.Drawing.Point(-1, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(526, 96);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Stacker";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // instLabel
            // 
            this.instLabel.Font = new System.Drawing.Font("OCR A Extended", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.instLabel.Location = new System.Drawing.Point(-1, 94);
            this.instLabel.Name = "instLabel";
            this.instLabel.Size = new System.Drawing.Size(526, 205);
            this.instLabel.TabIndex = 4;
            this.instLabel.Text = "Stack the blocks to the top to continue from where you died.\r\nPress any key to be" +
    "gin.\r\n";
            this.instLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Stacker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(156)))), ((int)(((byte)(156)))));
            this.BackgroundImage = global::Senior_Project.Properties.Resources.fdsaf;
            this.ClientSize = new System.Drawing.Size(525, 827);
            this.Controls.Add(this.instLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.block3);
            this.Controls.Add(this.block2);
            this.Controls.Add(this.block1);
            this.Name = "Stacker";
            this.Text = "Stacker";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Stacker_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.block1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.block2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.block3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox block1;
        private System.Windows.Forms.PictureBox block2;
        private System.Windows.Forms.PictureBox block3;
        private System.ComponentModel.BackgroundWorker blocksMover;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label instLabel;
    }
}