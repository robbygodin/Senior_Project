using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senior_Project
{
    public partial class Stacker : Form
    {
        // list of the main blocks, that move
        List<PictureBox> moveBlocks = new List<PictureBox>();
        List<PictureBox> frozenBoxes = new List<PictureBox>();

        // int for speed (abs value) and direction (pos or neg) of the blocks' movement
        int velocity = 75;
        int waitTime = 150;

        // bool for if this is the first key press
        bool firstKeyPress = true;

        bool gameOver = false;

        public bool stillPlaying = true;
        public bool won = true;


        public Stacker()
        {
            InitializeComponent();

            moveBlocks.Add(block1);
            moveBlocks.Add(block2);
            moveBlocks.Add(block3);
        }

        private void blocksMover_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                blocksMover.ReportProgress(1);
                Thread.Sleep(waitTime);
            }
        }

        private void blocksMover_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (endWatch.ElapsedMilliseconds >= 1500)
            {
                this.Close();
                stillPlaying = false;
            }

            // move every block in the direction they're going
            foreach (PictureBox pBox in moveBlocks)
            {
                pBox.Location = new Point(pBox.Location.X + velocity, pBox.Location.Y);
            }

            // bool for if the edge block hit the edge
            bool hitEdge = false;

            foreach (PictureBox pBox in moveBlocks)
            {
                if (pBox.Location.X >= 450 || pBox.Location.X <= 0)
                {
                    hitEdge = true;
                }
            }

            if (hitEdge)
            {
                velocity *= -1;
                moveBlocks.Reverse();
            }
        }

        Stopwatch endWatch = new Stopwatch();
        private void endGame()
        {
            gameOver = true;

            titleLabel.Visible = true;
            endWatch.Start();
        }

        private void Stacker_KeyDown(object sender, KeyEventArgs e)
        {
            if (firstKeyPress)
            {
                blocksMover.RunWorkerAsync();
                firstKeyPress = false;
                titleLabel.Visible = false;
                instLabel.Text = "Press space to stop the blocks.";
            }
            else if (e.KeyCode == Keys.Space && !gameOver)
            {
                if (instLabel.Visible)
                    instLabel.Visible = false;
                List<PictureBox> removeList = new List<PictureBox>();
                foreach (PictureBox box in moveBlocks)
                {
                    // if it's not on the ground
                    if (box.Location.Y < 751)
                    {
                        bool below = false;
                        foreach (PictureBox box2 in frozenBoxes)
                        {
                            if (box2.Location.X == box.Location.X && box2.Location.Y - 75 == box.Location.Y)
                                below = true;
                        }

                        if (!below)
                        {
                            removeList.Add(box);
                            box.Visible = false;

                        }
                    }
                }

                foreach (PictureBox q in removeList)
                {
                    moveBlocks.Remove(q);
                    q.Visible = false;
                }

                for (int i = 0; i < moveBlocks.Count; i++)
                {
                    PictureBox pbox1 = new PictureBox();
                    pbox1.BackColor = Color.FromArgb(216, 39, 39);
                    pbox1.Location = moveBlocks[i].Location;
                    pbox1.Size = new Size(75, 75);
                    this.Controls.Add(pbox1);
                    frozenBoxes.Add(pbox1);
                }

                if (moveBlocks.Count == 0)
                {
                    won = false;
                    titleLabel.Text = "Game Over";
                    endGame();
                }
                if (moveBlocks.Count > 0)
                {
                    if (moveBlocks[0].Location.Y == 1)
                    {
                        won = true;
                        titleLabel.Text = "You Won!";
                        endGame();
                    }

                    foreach (PictureBox box in moveBlocks)
                    {
                        box.Location = new Point(box.Location.X, box.Location.Y - 75);
                    }
                }

            }
        }
    }
}
