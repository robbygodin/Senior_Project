using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;

namespace Senior_Project
{
    public partial class Tetris : Form
    {
        bool alreadyShift = false;

        // landing sound
        MediaPlayer music = new MediaPlayer();

        bool closedForm = false;


        // array to hold all the purple blocks' picture boxes
        PictureBox[] purpleBlocks;
        PictureBox[] blueBlocks;
        PictureBox[] orangeBlocks;
        PictureBox[] yellowBlocks;
        PictureBox[] pinkBlocks;
        PictureBox[] redBlocks;
        PictureBox[] greenBlocks;
        PictureBox[] futureBoxes;

        // list for the hard blocks being removed
        List<PictureBox> removingHards = new List<PictureBox>();

        // Array to hold the blocks that are currently being dropped
        PictureBox[] currentBlocks;

        // The pivot point of the shape
        Point pivotPoint;

        // int for the speed at which the blocks fall
        int fallSpeed = 40;

        // int for how long the background worker waits before moving the blocks again
        int waitSpeed = 800;

        // boolean for if the user is still holding the key he pressed down
        bool keyStillDown = false;

        // ints for the traits of the shape currently falling
        int shapeColor;
        int shapeShape;

        // the key being held
        Keys keyHeld;

        bool lost = false;

        // int for which hard block is going to be placed next
        int nextHard = 0;

        // array to hold all the hard blocks
        PictureBox[] hardBlocks;

        // array to hold all the active hard blocks
        List<PictureBox> activeHard = new List<PictureBox>();

        // ints for the next and held shapes
        int nextShape = 100;
        int heldShape = 100;

        Stopwatch stopwatch = new Stopwatch();

        bool firstKeyPressed = false;

        bool blue = false;


        int level = 0;
        int score = 0;
        int scoreSinceLast = 0;

        int totalLinesBroken = 0;

        bool spaceDown = false;

        Stopwatch songwatch = new Stopwatch();

        User player;

        bool paused = false;
    
        public Tetris(User user)
        {
            InitializeComponent();
            player = user;
            startPB.Location = new Point(-46, 216);
            startPB.Size = new Size(831, 545);
            startPB.BringToFront();

            music.Volume /= 2;
            music.MediaEnded += new EventHandler(musicEnded);

            music.Open(new Uri(Application.StartupPath + "\\Sounds\\Original Tetris theme (Tetris Soundtrack).wav"));
            music.Play();
            songwatch.Start();

            controlsButton.Enabled = false;

            music.MediaEnded += new EventHandler(musicStopped);

            // create a temporary array to assign the purple blocks
            PictureBox[] tempPurpBlocks = { purple1, purple2, purple3, purple4 };
            PictureBox[] tempBlueBlocks = { blue1, blue2, blue3, blue4 };
            PictureBox[] tempOrangeBlocks = { orange1, orange2, orange3, orange4 };
            PictureBox[] tempYellowBlocks = { yellow1, yellow2, yellow3, yellow4 };
            PictureBox[] tempPinkBlocks = { pink1, pink2, pink3, pink4 };
            PictureBox[] tempRedBlocks = { red1, red2, red3, red4 };
            PictureBox[] tempGreenBlocks = { green1, green2, green3, green4 };
            PictureBox[] tempGreenBlocks2 = { exPB1, exPB2, exPB3, exPB4 };


            nextLabel.Visible = false;
            futureBoxes = tempGreenBlocks2;

            foreach (PictureBox box in futureBoxes)
                box.Image = Properties.Resources.Future_Block;

            // assign the purple blocks to the real array
            purpleBlocks = tempPurpBlocks;
            blueBlocks = tempBlueBlocks;
            orangeBlocks = tempOrangeBlocks;
            yellowBlocks = tempYellowBlocks;
            pinkBlocks = tempPinkBlocks;
            redBlocks = tempRedBlocks;
            greenBlocks = tempGreenBlocks;

            if (blue)
            {
                foreach (PictureBox box in purpleBlocks)
                {
                    box.Image = null;
                    box.BackColor = System.Drawing.Color.LightGray;
                }

                foreach (PictureBox box in blueBlocks)
                {
                    box.Image = null;
                    box.BackColor = System.Drawing.Color.FromArgb(19, 80, 130);
                }

                foreach (PictureBox box in orangeBlocks)
                {
                    box.Image = null;
                    box.BackColor = System.Drawing.Color.FromArgb(0, 168, 243);
                }

                foreach (PictureBox box in yellowBlocks)
                {
                    box.Image = null;
                    box.BackColor = System.Drawing.Color.FromArgb(79, 213, 236);
                }

                foreach (PictureBox box in pinkBlocks)
                {
                    box.Image = null;
                    box.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
                }

                foreach (PictureBox box in redBlocks)
                {
                    box.Image = null;
                    box.BackColor = System.Drawing.Color.LightGray;
                }

                foreach (PictureBox box in greenBlocks)
                {
                    box.Image = null;
                    box.BackColor = System.Drawing.Color.FromArgb(19, 80, 130);
                }
            }

            // create a temporary array to assign the hardblocks
            PictureBox[] tempHard = { hard1, hard2, hard3, hard4, hard5, hard6, hard7, hard8, hard9, hard10, hard11, hard12, hard13, hard14, hard15, hard16, hard17, hard18, hard19, hard20, hard21, hard22, hard23, hard24, hard25,
            hard26, hard27, hard28, hard29, hard30, hard31, hard32, hard33, hard34, hard35, hard36, hard37, hard38, hard39, hard40, hard41, hard42, hard43, hard44, hard45, hard46, hard47, hard48, hard49, hard50,
            hard51, hard52, hard53, hard54, hard55, hard56, hard57, hard58, hard59, hard60, hard61, hard62, hard63, hard64, hard65, hard66, hard67, hard68, hard69, hard70, hard71, hard72, hard73, hard74, hard75,
            hard76, hard77, hard78, hard79, hard80, hard81, hard82, hard83, hard84, hard85, hard86, hard87, hard88, hard89, hard90, hard91, hard92, hard93, hard94, hard95, hard96, hard97, hard98, hard99, hard100,
            hard101, hard102, hard103, hard104, hard105, hard106, hard107, hard108, hard109, hard110, hard111, hard112, hard113, hard114, hard115, hard116, hard117, hard118, hard119, hard120, hard121, hard122, hard123, hard124, hard125,
            hard126, hard127, hard128, hard129, hard130, hard131, hard132, hard133, hard134, hard135, hard136, hard137, hard138, hard139, hard140, hard141, hard142, hard143, hard144, hard145, hard146, hard147, hard148, hard149, hard150,
            hard151, hard152, hard153, hard154, hard155 };

            // assign the hard blocks to the real array
            hardBlocks = tempHard;

        }

        private void musicEnded(object sender, EventArgs e)
        {
            music.Open(new Uri(Application.StartupPath + "\\Sounds\\Original Tetris theme  Tetris Soundtrack .wav"));
            music.Play();
        }

        private void musicStopped(object sender, EventArgs e)
        {
            music.Open(new Uri(Application.StartupPath + "\\Sounds\\Original Tetris theme  Tetris Soundtrack .wav"));
            music.Play();
        }

        private void changeMessage(String message)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
                messageLabel.Visible = true;
                messageLabel.Text = message;
            }
        }







        private void moveBlocksDown_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!closedForm)
            {
                while (!lost && !paused)
                {
                    // add a delay before moving the blocks
                    Thread.Sleep(waitSpeed);

                    // report progress
                    moveBlocksDown.ReportProgress(1);
                }
            }
        }









        private void moveBlocksDown_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (songwatch.ElapsedMilliseconds > 75000)
            {
                music.Open(new Uri(Application.StartupPath + "\\Sounds\\Original Tetris theme  Tetris Soundtrack .wav"));

                music.Play();
                songwatch.Restart();
            }

            if (stopwatch.ElapsedMilliseconds >= 4000)
            {
                stopwatch.Stop();
                messageLabel.Visible = false;
            }
            // if the blocks hit other blocks or the ground, solidify them
            foreach (PictureBox block in currentBlocks)
            {
                // boolean for if the block hit a hard block
                bool hitBarrier = false;

                foreach (PictureBox barrier in activeHard)
                {
                    if (block.Location.Y + block.Height == barrier.Location.Y && block.Location.X == barrier.Location.X)
                    {
                        hitBarrier = true;
                        break;
                    }
                }

                // if a block hit the ground or a hard block
                if (block.Location.Y >= 720 || hitBarrier)
                {
                    MediaPlayer click = new MediaPlayer();
                    click.Open(new Uri(Application.StartupPath + "\\Sounds\\Click.wav"));
                    click.Play();
                    // if the user is still holding  a key, move it in the direction they want before locking it in
                    if (keyStillDown)
                    {
                        if (keyHeld == Keys.Left)
                        {
                            bool can = true;
                            foreach (PictureBox curr in currentBlocks)
                            {
                                Point point = new Point(curr.Location.X - 40, curr.Location.Y);

                                foreach (PictureBox hard in activeHard)
                                {
                                    Point hardPoint = hard.Location;
                                    if ((getDistance(point, hardPoint) < 30 && point.Y > hardPoint.Y) || (getDistance(point, hardPoint) < currentBlocks[1].Width))
                                    {
                                        can = false;
                                    }
                                }
                            }

                            if (can)
                            {
                                foreach (PictureBox box in currentBlocks)
                                    box.Location = new Point(box.Location.X - 40, box.Location.Y);
                            }
                        }
                        if (keyHeld == Keys.Right)
                        {
                            bool can = true;
                            foreach (PictureBox curr in currentBlocks)
                            {
                                Point point = new Point(curr.Location.X + 40, curr.Location.Y);

                                foreach (PictureBox hard in activeHard)
                                {
                                    Point hardPoint = hard.Location;
                                    if ((getDistance(point, hardPoint) < 30 && point.Y > hardPoint.Y) || (getDistance(point, hardPoint) < currentBlocks[1].Width))
                                    {
                                        can = false;
                                    }
                                }
                            }

                            if (can)
                            {
                                foreach (PictureBox box in currentBlocks)
                                    box.Location = new Point(box.Location.X + 40, box.Location.Y);
                            }
                        }
                    }

                    // if the block is above where it should be and it hit a barrier
                    if (block.Location.Y <= 80)
                        lose();

                    // replace all the currently being dropped blocks with hard blocks
                    foreach (PictureBox block2 in currentBlocks)
                    {
                        try
                        {
                            while (activeHard.Contains(hardBlocks[nextHard]))
                            {
                                nextHard++;

                                // if it went through all the hard blocks, go back to the first one
                                if (nextHard >= hardBlocks.Count())
                                    nextHard = 0;
                            }
                        }
                        catch
                        {
                            nextHard = 0;

                            while (activeHard.Contains(hardBlocks[nextHard]))
                            {
                                nextHard++;

                                // if it went through all the hard blocks, go back to the first one
                                if (nextHard >= hardBlocks.Count())
                                    nextHard = 0;
                            }
                        }


                        // set the hard block's location to the location of this current block
                        hardBlocks[nextHard].Location = block2.Location;

                        // make this hard block visible
                        hardBlocks[nextHard].Visible = true;

                        // set the hardBlocks image to be the same as the block it's replacing
                        if (blue)
                        {
                            hardBlocks[nextHard].Image = null;
                            hardBlocks[nextHard].BackColor = block2.BackColor;
                        }
                        else
                            hardBlocks[nextHard].Image = block2.Image;

                        // add the hard block that was just placed to the active hard blocks list
                        activeHard.Add(hardBlocks[nextHard]);

                        // increment the next hard variable
                        nextHard++;
                    }

                    changeVisible(currentBlocks);

                    // make a new shape
                    makeShape();

                    // exit this for loop
                    break;
                }
            }

            // move the blocks down
            moveBlocks(0, fallSpeed);

            pivotPoint = new Point(pivotPoint.X, pivotPoint.Y + fallSpeed);
        }





        private void lose()
        {
            if (!lossGP.Visible)
            {
                lost = true;
                //music.Stop();
                MediaPlayer lossSound = new MediaPlayer();

                lossSound.Open(new Uri(Application.StartupPath + "\\Sounds\\Videogame Lose Sound Effect HD _ No Copyright.wav"));
                lossSound.Play();

                // stop the background workers
                moveBlocksUser.CancelAsync();
                hardBlockRemover.CancelAsync();
                moveHardDown.CancelAsync();

                // put all the values into the lose menu
                lossPointsLabel.Text = score.ToString();
                lossLevelLabel.Text = level.ToString();
                linesBrokenLabel.Text = totalLinesBroken.ToString();

                // make the loss menu visible
                lossGP.Visible = true;
                lossGP.Size = new Size(471, 680);
                lossGP.Location = new Point(40, 40);
                lossGP.BringToFront();
            }

        }



        // method that moves the blocks down
        private void moveBlocks(int xChange, int yChange)
        {
            // if none of the blocks are going to go out of the sides
            if (!outside(currentBlocks[0], xChange, yChange) && !outside(currentBlocks[1], xChange, yChange) &&
                !outside(currentBlocks[2], xChange, yChange) && !outside(currentBlocks[3], xChange, yChange))
            {
                // go to each block in the current blocks array
                foreach (PictureBox block in currentBlocks)
                {
                    block.Location = new Point(block.Location.X + xChange, block.Location.Y + yChange);
                }
            }
        }

        private bool canMoveBlocks(int xChange, int yChange)
        {
            bool canDoIt = true;
            // if none of the blocks are going to go out of the sides
            if (!outside(currentBlocks[0], xChange, yChange) && !outside(currentBlocks[1], xChange, yChange) &&
                !outside(currentBlocks[2], xChange, yChange) && !outside(currentBlocks[3], xChange, yChange))
            {
                foreach (PictureBox curr in currentBlocks)
                {
                    Point point = new Point(curr.Location.X + xChange, curr.Location.Y + yChange);

                    foreach (PictureBox hard in activeHard)
                    {
                        Point hardPoint = hard.Location;
                        if ((getDistance(point, hardPoint) < 30 && point.Y > hardPoint.Y) || (getDistance(point, hardPoint) < currentBlocks[1].Width))
                        {
                            canDoIt = false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }

            if (canDoIt)
            {
                // go to each block in the current blocks array
                foreach (PictureBox block in currentBlocks)
                {
                    block.Location = new Point(block.Location.X + xChange, block.Location.Y + yChange);
                }
                return true;
            }
            else
                return false;
        }




        private void dropToBottom()
        {
            bool canGoDown = true;

            while (canGoDown)
            {

                // if none of the blocks are going to go out of the sides
                if (!outside(currentBlocks[0], 0, 40) && !outside(currentBlocks[1], 0, 40) &&
                    !outside(currentBlocks[2], 0, 40) && !outside(currentBlocks[3], 0, 40))
                {
                    foreach (PictureBox curr in currentBlocks)
                    {
                        Point point = new Point(curr.Location.X, curr.Location.Y + 40);

                        foreach (PictureBox hard in activeHard)
                        {
                            Point hardPoint = hard.Location;
                            
                            if (getDistance(point, hardPoint) <= 40 && point.X == hardPoint.X)
                            {
                                canGoDown = false;
                            }
                        }
                    }
                }
                else
                    canGoDown = false;

                if (canGoDown)
                    moveBlocks(0, 40);
                Thread.Sleep(10);
            }
        }




        private int getDistance(Point point1, Point point2)
        {
            return Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y);
        }




        private bool outside(PictureBox block, int xChange, int yChange)
        {
            if (block.Location.X + xChange <= 360 && block.Location.X + xChange >= 0 && block.Location.Y < 720)
                return false;
            return true;
        }







        private void changeVisible(PictureBox[] array)
        {
            foreach (PictureBox box in array)
            {
                box.Visible = !box.Visible;
            }
        }







        // method that makes the shape
        private void makeShape()
        {               
            // make a new random variable
            Random rand = new Random();

            alreadyShift = false;

            // int to decide the shape
            if (nextShape != 100)
            {
                shapeShape = nextShape;
                nextShape = rand.Next(0, 7);
            }
            else
            {
                shapeShape = rand.Next(0, 7);
                nextShape = rand.Next(0, 7);
            }

            // int to decide the color of the shape
            shapeColor = shapeShape;

            // update the next shape picture box
            switch (nextShape)
            {
                case (0): nextPB.Image = Properties.Resources.nextSquare; break;
                case (1): nextPB.Image = Properties.Resources.nextBlueL; break;
                case (2): nextPB.Image = Properties.Resources.nextOrangeL; break;
                case (3): nextPB.Image = Properties.Resources.nextM; break;
                case (4): nextPB.Image = Properties.Resources.nextLine; break;
                case (5): nextPB.Image = Properties.Resources.leftZ; break;
                case (6): nextPB.Image = Properties.Resources.rightZ; break;
            }

            // add the boxes that are going to be used to the boxes array
            switch (shapeColor)
            {
                case (0): currentBlocks = purpleBlocks; break;
                case (1): currentBlocks = blueBlocks; break;
                case (2): currentBlocks = orangeBlocks; break;
                case (3): currentBlocks = yellowBlocks; break;
                case (4): currentBlocks = pinkBlocks; break;
                case (5): currentBlocks = redBlocks; break;
                case (6): currentBlocks = greenBlocks; break;
            }

            // if the shape is the square (0)
            if (shapeShape == 0)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(160, 0);
                currentBlocks[1].Location = new Point(200, 0);
                currentBlocks[2].Location = new Point(160, 40);
                currentBlocks[3].Location = new Point(200, 40);

                // set the pivot point to be in the middle of the four squares
                pivotPoint = currentBlocks[3].Location;
            }

            // if the shape is the blue L (1)
            if (shapeShape == 1)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(160, 0);
                currentBlocks[1].Location = new Point(160, 40);
                currentBlocks[2].Location = new Point(200, 40);
                currentBlocks[3].Location = new Point(240, 40);

                // set the pivot point to be in the middle of the middle square
                pivotPoint = new Point(currentBlocks[2].Location.X + currentBlocks[2].Width / 2, currentBlocks[2].Location.Y + currentBlocks[2].Width / 2);
            }

            // if the shape is the orange L (2)
            if (shapeShape == 2)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(240, 0);
                currentBlocks[1].Location = new Point(240, 40);
                currentBlocks[2].Location = new Point(200, 40);
                currentBlocks[3].Location = new Point(160, 40);

                // set the pivot point to be in the middle of the middle square
                pivotPoint = new Point(currentBlocks[2].Location.X + currentBlocks[2].Width / 2, currentBlocks[2].Location.Y + currentBlocks[2].Width / 2);
            }

            // if the shape is the _|_ (3)
            if (shapeShape == 3)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(200, 0);
                currentBlocks[1].Location = new Point(200, 40);
                currentBlocks[2].Location = new Point(160, 40);
                currentBlocks[3].Location = new Point(240, 40);

                // set the pivot point to be in the middle of the middle block
                pivotPoint = new Point(currentBlocks[1].Location.X + currentBlocks[1].Width / 2, currentBlocks[1].Location.Y + currentBlocks[1].Width / 2);
            }

            // if the shape is the stick (4)
            if (shapeShape == 4)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(160, 0);
                currentBlocks[1].Location = new Point(200, 0);
                currentBlocks[2].Location = new Point(240, 0);
                currentBlocks[3].Location = new Point(280, 0);

                // set the pivot point to be in the middle of one of the two middle squares
                pivotPoint = new Point(currentBlocks[2].Location.X + currentBlocks[2].Width / 2, currentBlocks[2].Location.Y + currentBlocks[2].Width / 2);
            }

            // if the shape is the left z (5)
            if (shapeShape == 5)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(160, 0);
                currentBlocks[1].Location = new Point(200, 0);
                currentBlocks[2].Location = new Point(200, 40);
                currentBlocks[3].Location = new Point(240, 40);

                // set the pivot point to be in the middle of one of the two middle squares
                pivotPoint = new Point(currentBlocks[2].Location.X + currentBlocks[2].Width / 2, currentBlocks[2].Location.Y + currentBlocks[2].Width / 2);
            }

            // if the shape is the right z (6)
            if (shapeShape == 6)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(240, 0);
                currentBlocks[1].Location = new Point(200, 0);
                currentBlocks[2].Location = new Point(200, 40);
                currentBlocks[3].Location = new Point(160, 40);

                // set the pivot point to be in the middle of one of the two middle squares
                pivotPoint = new Point(currentBlocks[2].Location.X + currentBlocks[2].Width / 2, currentBlocks[2].Location.Y + currentBlocks[2].Width / 2);
            }

            if (!currentBlocks[1].Visible)
                changeVisible(currentBlocks);
        }





        bool fastkey = false;


        private void Tetris_KeyDown(object sender, KeyEventArgs e)
        {
            Tetris.ActiveForm.Focus();

            if (!firstKeyPressed)
            {
                pressKeyLabel.Visible = false;
                titleLabel1.Visible = false;
                titleLabel2.Visible = false;
                titleLabel3.Visible = false;
                titleLabel4.Visible = false;
                titleLabel5.Visible = false;
                titleLabel6.Visible = false;
                label1.Visible = true;
                controlsButton.Enabled = true;

                music.Pause();
                for (int i = 0; i < 6; i++)
                {
                    Thread.Sleep(500);
                    startPB.Location = new Point(startPB.Location.X, startPB.Location.Y + 50);
                    SoundPlayer beep = new SoundPlayer(Properties.Resources.Video_Game_Beep___Sound_Effect);
                    beep.Play();
                }
                Thread.Sleep(500);
                music.Play();

                nextLabel.Visible = true;

                // start the background worker that moves the blocks down
                futureWorker.RunWorkerAsync();
                moveBlocksDown.RunWorkerAsync();
                gridPB.Visible = true;
                firstKeyPressed = true;

                startPB.Visible = false;
                pictureBox1.Visible = true;
                nextLabel.Visible = true;
                makeShape();
                moveBlocksUser.RunWorkerAsync();
                hardBlockRemover.RunWorkerAsync();
                moveHardDown.RunWorkerAsync();
            }
            else
            {
                // indicate that a key is being held down
                keyStillDown = true;

                // save the key being held
                keyHeld = e.KeyCode;

                if (keyHeld == Keys.Up || keyHeld == Keys.W)
                {
                    rotateShape();
                    keyStillDown = false;
                }

                if (keyHeld == Keys.ShiftKey && !alreadyShift)
                {
                    alreadyShift = true;
                    holdShape();
                    keyStillDown = false;
                }

                if (keyHeld == Keys.Space && !spaceDown)
                {
                    spaceDown = true;
                    dropToBottom();
                    keyStillDown = false;
                }

                if (keyHeld == Keys.Down && !fastkey)
                {
                    fastkey = true;
                    waitSpeed /= 15;
                    keyStillDown = false;
                }
            }

        }







        private void Tetris_KeyUp(object sender, KeyEventArgs e)
        {
            // indicate the user lifted the key
            keyStillDown = false;

            spaceDown = false;
            fastkey = false;
        }







        private void moveBlocksUser_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!closedForm)
            {
                // while the user is holding the key down
                while (!lost && !paused)
                {
                    if (keyStillDown && !lost)
                    {
                        // move the blocks in the direction the user wants them to move
                        moveBlocksUser.ReportProgress(1);

                        // sleep for a tiny bit
                        Thread.Sleep(100);
                    }
                }
            }

        }








        private void moveBlocksUser_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // move the blocks in the direction the user wants them to go


            if (keyHeld == Keys.Left || keyHeld == Keys.A)
            {
                if (canMoveBlocks(-40, 0))
                    pivotPoint = new Point(pivotPoint.X - 40, pivotPoint.Y);
            }

            if (keyHeld == Keys.Right || keyHeld == Keys.D)
            {
                if (canMoveBlocks(40, 0))
                    pivotPoint = new Point(pivotPoint.X + 40, pivotPoint.Y);
            }
        }



        private void holdShape()
        {
            Random rand = new Random();

            // move the current blocks out of the way and make them invisible
            foreach (PictureBox box in currentBlocks)
            {
                box.Location = new Point(676, 702);
                box.Visible = false;
            }

            if (heldShape == 100)
            {
                heldShape = shapeShape;
                shapeShape = nextShape;
                nextShape = rand.Next(0, 7);
            }
            else
            {
                int tempShape = heldShape;
                heldShape = shapeShape;
                shapeShape = tempShape;
            }


            shapeColor = shapeShape;

            // update the next shape picture box
            switch (nextShape)
            {
                case (0): nextPB.Image = Properties.Resources.nextSquare; break;
                case (1): nextPB.Image = Properties.Resources.nextBlueL; break;
                case (2): nextPB.Image = Properties.Resources.nextOrangeL; break;
                case (3): nextPB.Image = Properties.Resources.nextM; break;
                case (4): nextPB.Image = Properties.Resources.nextLine; break;
                case (5): nextPB.Image = Properties.Resources.leftZ; break;
                case (6): nextPB.Image = Properties.Resources.rightZ; break;
            }

            // add the boxes that are going to be used to the boxes array
            switch (shapeColor)
            {
                case (0): currentBlocks = purpleBlocks; break;
                case (1): currentBlocks = blueBlocks; break;
                case (2): currentBlocks = orangeBlocks; break;
                case (3): currentBlocks = yellowBlocks; break;
                case (4): currentBlocks = pinkBlocks; break;
                case (5): currentBlocks = redBlocks; break;
                case (6): currentBlocks = greenBlocks; break;
            }

            // update the held shape picture box
            switch (heldShape)
            {
                case (0): heldPB.Image = Properties.Resources.nextSquare; break;
                case (1): heldPB.Image = Properties.Resources.nextBlueL; break;
                case (2): heldPB.Image = Properties.Resources.nextOrangeL; break;
                case (3): heldPB.Image = Properties.Resources.nextM; break;
                case (4): heldPB.Image = Properties.Resources.nextLine; break;
                case (5): heldPB.Image = Properties.Resources.leftZ; break;
                case (6): heldPB.Image = Properties.Resources.rightZ; break;
            }

            // if the shape is the square (0)
            if (shapeShape == 0)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(160, 0);
                currentBlocks[1].Location = new Point(200, 0);
                currentBlocks[2].Location = new Point(160, 40);
                currentBlocks[3].Location = new Point(200, 40);

                // set the pivot point to be in the middle of the four squares
                pivotPoint = currentBlocks[3].Location;
            }

            // if the shape is the blue L (1)
            if (shapeShape == 1)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(160, 0);
                currentBlocks[1].Location = new Point(160, 40);
                currentBlocks[2].Location = new Point(200, 40);
                currentBlocks[3].Location = new Point(240, 40);

                // set the pivot point to be in the middle of the middle square
                pivotPoint = new Point(currentBlocks[2].Location.X + currentBlocks[2].Width / 2, currentBlocks[2].Location.Y + currentBlocks[2].Width / 2);
            }

            // if the shape is the orange L (2)
            if (shapeShape == 2)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(240, 0);
                currentBlocks[1].Location = new Point(240, 40);
                currentBlocks[2].Location = new Point(200, 40);
                currentBlocks[3].Location = new Point(160, 40);

                // set the pivot point to be in the middle of the middle square
                pivotPoint = new Point(currentBlocks[2].Location.X + currentBlocks[2].Width / 2, currentBlocks[2].Location.Y + currentBlocks[2].Width / 2);
            }

            // if the shape is the _|_ (3)
            if (shapeShape == 3)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(200, 0);
                currentBlocks[1].Location = new Point(200, 40);
                currentBlocks[2].Location = new Point(160, 40);
                currentBlocks[3].Location = new Point(240, 40);

                // set the pivot point to be in the middle of the middle block
                pivotPoint = new Point(currentBlocks[1].Location.X + currentBlocks[1].Width / 2, currentBlocks[1].Location.Y + currentBlocks[1].Width / 2);
            }

            // if the shape is the stick (4)
            if (shapeShape == 4)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(160, 0);
                currentBlocks[1].Location = new Point(200, 0);
                currentBlocks[2].Location = new Point(240, 0);
                currentBlocks[3].Location = new Point(280, 0);

                // set the pivot point to be in the middle of one of the two middle squares
                pivotPoint = new Point(currentBlocks[2].Location.X + currentBlocks[2].Width / 2, currentBlocks[2].Location.Y + currentBlocks[2].Width / 2);
            }

            // if the shape is the left z (5)
            if (shapeShape == 5)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(160, 0);
                currentBlocks[1].Location = new Point(200, 0);
                currentBlocks[2].Location = new Point(200, 40);
                currentBlocks[3].Location = new Point(240, 40);

                // set the pivot point to be in the middle of one of the two middle squares
                pivotPoint = new Point(currentBlocks[2].Location.X + currentBlocks[2].Width / 2, currentBlocks[2].Location.Y + currentBlocks[2].Width / 2);
            }

            // if the shape is the right z (6)
            if (shapeShape == 6)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(240, 0);
                currentBlocks[1].Location = new Point(200, 0);
                currentBlocks[2].Location = new Point(200, 40);
                currentBlocks[3].Location = new Point(160, 40);

                // set the pivot point to be in the middle of one of the two middle squares
                pivotPoint = new Point(currentBlocks[2].Location.X + currentBlocks[2].Width / 2, currentBlocks[2].Location.Y + currentBlocks[2].Width / 2);
            }// if the shape is the square (0)
            if (shapeShape == 0)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(160, 0);
                currentBlocks[1].Location = new Point(200, 0);
                currentBlocks[2].Location = new Point(160, 40);
                currentBlocks[3].Location = new Point(200, 40);

                // set the pivot point to be in the middle of the four squares
                pivotPoint = currentBlocks[3].Location;
            }

            // if the shape is the blue L (1)
            if (shapeShape == 1)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(160, 0);
                currentBlocks[1].Location = new Point(160, 40);
                currentBlocks[2].Location = new Point(200, 40);
                currentBlocks[3].Location = new Point(240, 40);

                // set the pivot point to be in the middle of the middle square
                pivotPoint = new Point(currentBlocks[2].Location.X + currentBlocks[2].Width / 2, currentBlocks[2].Location.Y + currentBlocks[2].Width / 2);
            }

            // if the shape is the orange L (2)
            if (shapeShape == 2)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(240, 0);
                currentBlocks[1].Location = new Point(240, 40);
                currentBlocks[2].Location = new Point(200, 40);
                currentBlocks[3].Location = new Point(160, 40);

                // set the pivot point to be in the middle of the middle square
                pivotPoint = new Point(currentBlocks[2].Location.X + currentBlocks[2].Width / 2, currentBlocks[2].Location.Y + currentBlocks[2].Width / 2);
            }

            // if the shape is the _|_ (3)
            if (shapeShape == 3)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(200, 0);
                currentBlocks[1].Location = new Point(200, 40);
                currentBlocks[2].Location = new Point(160, 40);
                currentBlocks[3].Location = new Point(240, 40);

                // set the pivot point to be in the middle of the middle block
                pivotPoint = new Point(currentBlocks[1].Location.X + currentBlocks[1].Width / 2, currentBlocks[1].Location.Y + currentBlocks[1].Width / 2);
            }

            // if the shape is the stick (4)
            if (shapeShape == 4)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(160, 0);
                currentBlocks[1].Location = new Point(200, 0);
                currentBlocks[2].Location = new Point(240, 0);
                currentBlocks[3].Location = new Point(280, 0);

                // set the pivot point to be in the middle of one of the two middle squares
                pivotPoint = new Point(currentBlocks[2].Location.X + currentBlocks[2].Width / 2, currentBlocks[2].Location.Y + currentBlocks[2].Width / 2);
            }

            // if the shape is the left z (5)
            if (shapeShape == 5)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(160, 0);
                currentBlocks[1].Location = new Point(200, 0);
                currentBlocks[2].Location = new Point(200, 40);
                currentBlocks[3].Location = new Point(240, 40);

                // set the pivot point to be in the middle of one of the two middle squares
                pivotPoint = new Point(currentBlocks[2].Location.X + currentBlocks[2].Width / 2, currentBlocks[2].Location.Y + currentBlocks[2].Width / 2);
            }

            // if the shape is the right z (6)
            if (shapeShape == 6)
            {
                // set the location of the four squares
                currentBlocks[0].Location = new Point(240, 0);
                currentBlocks[1].Location = new Point(200, 0);
                currentBlocks[2].Location = new Point(200, 40);
                currentBlocks[3].Location = new Point(160, 40);

                // set the pivot point to be in the middle of one of the two middle squares
                pivotPoint = new Point(currentBlocks[2].Location.X + currentBlocks[2].Width / 2, currentBlocks[2].Location.Y + currentBlocks[2].Width / 2);
            }

            // make the current blocks visible
            foreach (PictureBox box in currentBlocks)
                box.Visible = true;
        }
























        private void rotateShape()
        {
            // boolean for if the shape has room to rotate
            bool canRotate = true;

            // go to each square in the shape
            foreach (PictureBox square in currentBlocks)
            {
                // get the distance for x and y from the pivot point
                int xDist = square.Location.X - pivotPoint.X;
                int yDist = square.Location.Y - pivotPoint.Y;

                // ints for new distance from the center
                int newX = yDist * -1;
                int newY = xDist;

                // the new point
                Point newPoint = new Point(pivotPoint.X + newX, pivotPoint.Y + newY);

                // if the new points would be outside of the play area
                if (newPoint.X > 360 || newPoint.X < 0)
                    canRotate = false;

                Point point = new Point(newPoint.X, newPoint.Y);
                foreach (PictureBox hard in activeHard)
                {
                    Point hardPoint = hard.Location;
                    if (getDistance(point, hardPoint) < 40)
                        canRotate = false;
                }

            }

            // actually rotate if the shape can
            if (canRotate)
            {
                // go to each square in the shape
                foreach (PictureBox square in currentBlocks)
                {
                    // get the distance for x and y from the pivot point
                    int xDist = square.Location.X - pivotPoint.X;
                    int yDist = square.Location.Y - pivotPoint.Y;

                    // ints for new distance from the center
                    int newX = yDist * -1;
                    int newY = xDist;

                    square.Location = new Point(pivotPoint.X + newX, pivotPoint.Y + newY);
                }
            }
        }











        private void breakRows()
        {
            // int for how many lines are being broken
            int linesBroken = 0;

            // go to each x row
            for (int y = 720; y > 0; y -= 40)
            {
                // go to each active hardblock
                foreach (PictureBox hard in activeHard)
                {
                    // if there is a hard block in the first column of this row
                    if (hard.Location == new Point(0, y))
                    {
                        // boolean for if this line is full
                        bool lineFull = true;

                        // list for the hard blocks in this row
                        List<PictureBox> hardBlocksRow = new List<PictureBox>();
                        hardBlocksRow.Add(hard);

                        // go to each block in the row
                        for (int x = currentBlocks[1].Width; x <= 360; x += currentBlocks[1].Width)
                        {
                            // boolean for if it found a hard block for this locaiton
                            bool foundHard = false;

                            // if there isn't a hardblock here, the line isn't full
                            foreach (PictureBox lineHard in activeHard)
                            {
                                if (lineHard.Location == new Point(x, y))
                                {
                                    hardBlocksRow.Add(lineHard);
                                    foundHard = true;
                                }
                            }

                            // if it didn't find a hard block for this position in the row, the row isn't full
                            if (!foundHard)
                                lineFull = false;
                        }
                        // if the line is full, add the hard blocks in this row to the list of the ones being removed
                        if (lineFull)
                        {
                            linesBroken++;
                            totalLinesBroken++;
                            removingHards.AddRange(hardBlocksRow);

                            MediaPlayer clearSound = new MediaPlayer();
                            clearSound.Open(new Uri(Application.StartupPath + "\\Sounds\\NES Tetris Sound Effect - Tetris Clear.wav"));
                            clearSound.Play();

                            foreach (PictureBox box in hardBlocksRow)
                                box.Image = Properties.Resources.Hard_Square;
                        }
                    }
                }
            }

            removeRow();

            Random rand = new Random();

            // display a somewhat random message based on how many lines were broken
            if (linesBroken == 1)
            {
                score += 40 * (level + 1);
                scoreSinceLast += 300 * (level + 1);

                int messageInt = rand.Next(0, 2);

                switch (messageInt)
                {
                    case (0): changeMessage("Nice!"); break;
                    case (1): changeMessage("Wow!"); break;
                }
            }

            if (linesBroken == 2)
            {
                score += 100 * (level + 1);
                scoreSinceLast += 300 * (level + 1);

                int messageInt = rand.Next(0, 2);

                switch (messageInt)
                {
                    case (0): changeMessage("Nice Job!"); break;
                    case (1): changeMessage("Good Job!"); break;
                }
            }

            if (linesBroken == 3)
            {
                score += 300 * (level + 1);
                scoreSinceLast += 300 * (level + 1);

                int messageInt = rand.Next(0, 2);

                switch (messageInt)
                {
                    case (0): changeMessage("Amazing!"); break;
                    case (1): changeMessage("You Rock!"); break;
                }
            }

            if (linesBroken == 4)
            {
                score += 1200 * (level + 1);
                scoreSinceLast += 1200 * (level + 1);
                changeMessage("Tetris!");
            }


            if (level <= 9)
            {
                if (scoreSinceLast >= (level * 10) + 10)
                {
                    level++;
                    scoreSinceLast = 0;
                }
            }
            else if (level <= 15)
            {
                if (scoreSinceLast >= 100)
                {
                    level++;
                    scoreSinceLast = 0;
                }
                else if (level <= 40)
                {
                    if (scoreSinceLast >= 100 + (level - 15))
                    {
                        level++;
                        scoreSinceLast = 0;
                    }
                }
            }
            else
            {
                if (scoreSinceLast >= 200)
                {
                    level++;
                    scoreSinceLast = 0;
                }
            }

            scoreLabel.Text = score.ToString();
            levelLabel.Text = level.ToString();

            if (!fastkey)
            {
                waitSpeed = 1030 - (level * 50);
                if (waitSpeed < 250)
                    waitSpeed = 250;
            }

        }

        private void removeRow()
        {
            // go to each hard block in the remove hard blocks list
            for (int i = 0; i < removingHards.Count; i++)
            {
                PictureBox hardBlock = removingHards[i];

                // move the hard block down
                hardBlock.Location = new Point(hardBlock.Location.X, hardBlock.Location.Y + 7);

                // if the hard block is off the screen
                if (hardBlock.Location.Y > 900)
                {
                    removingHards.Remove(hardBlock);
                    activeHard.Remove(hardBlock);
                    hardBlock.Visible = false;
                }
            }
        }




        private void hardBlockRemover_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                while (!lost && !paused)
                {
                    hardBlockRemover.ReportProgress(1);
                    Thread.Sleep(20);
                }
            }

        }





        private void hardBlockRemover_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!lost)
                breakRows();


        }

        // boolean for if the loop is still moving squares down
        bool stillWorking = false;

        private void moveHardDown_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                while (!lost && !paused)
                {
                    if (!stillWorking && !lost)
                    {
                        Thread.Sleep(20);
                        moveHardDown.ReportProgress(1);
                    }
                }
            }
        }

        private void moveHardDown_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!lost)
            {
                stillWorking = true;
                // go to each row
                for (int i = 680; i > 0; i -= 40)
                {
                    bool canMove = true;

                    // go to each picture box
                    foreach (PictureBox firstHard in activeHard)
                    {
                        // if this block is in this row
                        if (firstHard.Location.Y == i)
                        {
                            // if there's a block below this one, indicate that this row can't move down
                            foreach (PictureBox belowBlock in activeHard)
                            {
                                if (belowBlock.Location.X == firstHard.Location.X && belowBlock.Location.Y - 40 == firstHard.Location.Y)
                                    canMove = false;
                            }
                        }
                    }

                    // if this row can move, move it
                    if (canMove)
                    {
                        foreach (PictureBox picBox in activeHard)
                        {
                            if (picBox.Location.Y == i)
                                picBox.Location = new Point(picBox.Location.X, picBox.Location.Y + 40);
                        }
                    }
                }
                stillWorking = false;
            }
        }

        private void titleLabel1_Click(object sender, EventArgs e)
        {

        }

        private void titleLabel2_Click(object sender, EventArgs e)
        {

        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            if (score > player.getTetrisScore())
                player.setTetrisScore(score);

            player.addCoins(level);
            music.Open(new Uri(Application.StartupPath + "\\Sounds\\Original Tetris theme  Tetris Soundtrack .wav"));

            music.Play();
            heldPB.Image = null;
            heldShape = 100;
            Tetris.ActiveForm.Focus();
            lost = false;

            lossGP.Visible = false;

            // reset the score
            score = 0;
            totalLinesBroken = 0;
            level = 0;

            nextShape = 100;
            heldShape = 100;

            // move all the active hard blocks off the screen and deactivate them
            foreach (PictureBox box in activeHard)
            {
                box.Location = new Point(1000, 1000);
            }

            activeHard.Clear();

            removingHards.Clear();

            fallSpeed = 40;
            waitSpeed = 1000;

            // move the currentBlocks off the screen
            foreach (PictureBox box in currentBlocks)
                box.Location = new Point(1000, 1000);

            // make the next shape
            makeShape();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (score > player.getTetrisScore())
                player.setTetrisScore(score);

            this.Close();
        }



        private void futureWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (currentBlocks == null) {}

            Point[] currentLoc = { currentBlocks[0].Location, currentBlocks[1].Location, currentBlocks[2].Location, currentBlocks[3].Location };
            while (!closedForm)
            {
                while (!paused)
                {
                    int i = 0;
                    foreach (Point point in currentLoc)
                    {
                        // if the saved x of the first current block has changed, move the ghost blocks
                        if (point.X != currentBlocks[i].Location.X)
                        {
                            futureWorker.ReportProgress(1);
                            currentLoc[0] = currentBlocks[0].Location;
                            currentLoc[1] = currentBlocks[1].Location;
                            currentLoc[2] = currentBlocks[2].Location;
                            currentLoc[3] = currentBlocks[3].Location;
                            Thread.Sleep(30);
                            break;
                        }
                        i++;
                    }
                }
            }
        }


        private void futureWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            foreach (PictureBox box in futureBoxes)
                box.Visible = false;

            // go to each future box
            for (int i = 0; i < 4; i++)
            {
                // set the location equal to the corresponding current block
                futureBoxes[i].Location = currentBlocks[i].Location;
            }

            // boolean for if the block hit a hard block
            bool hitBarrier = false;
            while (!hitBarrier)
            {
                // move the boxes down like the space key does to the real blocks
                foreach (PictureBox block in futureBoxes)
                {
                    if (block.Location.Y >= 720)
                    {
                        hitBarrier = true;
                        break;
                    }
                    foreach (PictureBox barrier in activeHard)
                    {
                        if (block.Location.Y + block.Height == barrier.Location.Y && block.Location.X == barrier.Location.X)
                        {
                            hitBarrier = true;
                            break;
                        }
                    }
                }

                // if none of the blocks hit a hard block or the bottom, move them all down
                if (!hitBarrier)
                {
                    foreach (PictureBox block in futureBoxes)
                        block.Location = new Point(block.Location.X, block.Location.Y + 40);
                }
                else
                    break;
            }

            // if the box isn't on a line, back it up to the closest line
            foreach (PictureBox box in futureBoxes)
            {
                box.Location = new Point(box.Location.X, box.Location.Y - box.Location.Y % 40);
            }

            foreach (PictureBox box in futureBoxes)
                box.Visible = true;

        }

        private void Tetris_FormClosed(object sender, FormClosedEventArgs e)
        {
            music.Stop();
            player.addCoins(level);
            player.updateFile();
            closedForm = true;
        }

        // CONTROLS PANEL CLOSE BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            paused = false;
            controlsPanel.Visible = false;
        }

        private void controlsButton_Click_1(object sender, EventArgs e)
        {
            paused = true;
            controlsPanel.Visible = true;
            controlsPanel.Location = new Point(0, 0);
            controlsPanel.Size = new Size(551, 762);
            controlsPanel.BringToFront();
        }
    }
}
