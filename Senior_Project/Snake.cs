using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Media;

namespace Senior_Project
{
    public partial class Snake : Form
    {
        // boolean for if the snake is dead
        private bool dead = false;

        // int for amount of food the snake's eaten
        int points = 0;

        // String for the direction of the snake (right, up, left, down)
        private String direction = "right";

        // String for the direction the user wants the snake to go, the snake can't move that direction until it hits the next box in the "grid"
        // none is when the user hasn't hit a key, at the start, or since last move
        private String tempDirect = "none";

        // int for keeping track of the amount of bodies the snake has
        private int bodyCount = 2;

        List<PictureBox> activeBody = new List<PictureBox>();

        // array of strings to save the direction of each picture box
        List<String> directionsList = new List<String>();

        // array to save the locations where the head moved, when a body part hits a location, its direction changes
        List<Point> headMoves = new List<Point>();

        // array to save the direction the head went at each location where it moved
        List<String> headMovesDir = new List<String>();

        // List to keep track of the active food picture boxes
        List<PictureBox> activeFood = new List<PictureBox>();

        // boolean for if the first key has been pressed
        bool firstKeyPress = true;

        // boolean for if the worker should keep flashing
        bool keepFlashing = true;

        // int for the amount the snake moves every time
        int snakeSpeed = 10;

        int waitSpeed = 40;
        SoundPlayer deathSound = new SoundPlayer(Properties.Resources.WallHit);

        User player;

        public Snake(User user)
        {
            InitializeComponent();

            // get the user playing
            player = user;

            bite.Load();


            // make the background worker able to report progress
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            // start backgtround worker that flashes instructions
            backgroundWorker2.RunWorkerAsync();
            backgroundWorker2.WorkerSupportsCancellation = true;


            // set the direction of the first two picture boxes
            directionsList.Add("right");
            directionsList.Add("right");

            activeBody.Add(snakeBodyPB1);
            activeBody.Add(snakeBodyPB2);

            activeFood.Add(foodPB1);

            // make the background
            int x = 0;
            int y = 0;

            Color darkBack = Color.FromArgb(106, 176, 76);
            Color lightBack = Color.FromArgb(120, 181, 94);

            while (x < 16 && y < 9)
            {
                // make the picturebox
                PictureBox box = new PictureBox();
                box.Size = new Size(50, 50);
                box.Location = new Point(50 * x, 50 * y);

                // set the color of the picturebox
                if (x % 2 == 0)
                {
                    if (y % 2 == 0)
                    {
                        box.BackColor = darkBack;
                    }
                    else
                        box.BackColor = lightBack;
                }
                else
                {
                    if (y % 2 == 0)
                    {
                        box.BackColor = lightBack;
                    }
                    else
                        box.BackColor = darkBack;
                }

                // add the picturebox to the form
                this.Controls.Add(box);
                box.SendToBack();

                x++;

                if (x >= 16)
                {
                    x = 0;
                    y++;
                }
            }
        }


        private void snakeDied()
        {
            backgroundWorker1.CancelAsync();

            // set the title visible again
            titleLabel.Visible = true;

            // make the dead group box visible
            deadGroup.Visible = true;
            deadGroup.Location = new Point(237, 77);
            deadGroup.Size = new Size(322, 296);
            deadGroup.BringToFront();

            deadPointsLabel.Text = points.ToString();
        }


        // method for starting the game after the first key is pressed
        private void startGame()
        {
            // run the background worker
            backgroundWorker1.RunWorkerAsync();

            // end the worker that flashes instructions
            backgroundWorker2.CancelAsync();
            keepFlashing = false;

            changeFoodButton.Visible = false;

            // make the title and subtitle invisible
            titleLabel.Visible = false;
            instructionsLabel.Visible = false;
        }

        SoundPlayer bite = new SoundPlayer(Properties.Resources.Bite__2_);

        // method to check if the snake collided with some food
        private void ateFood()
        {

            // go through each food picture box
            for (int i = 0; i < activeFood.Count(); i++)
            {
                // get the location of the current food box
                Point foodLoc = activeFood[i].Location;

                // get the current location of the snake head
                Point snakeLoc = snakeHeadPB.Location;

                // if the snake location is greater than the x of the food box, but less than the x + the size of the box
                if (snakeLoc.X >= foodLoc.X && snakeLoc.X < foodLoc.X + activeFood[i].Width)
                {
                    // if the snake location is greater than the y of the food box, but less than y + height of food box
                    if (snakeLoc.Y >= foodLoc.Y && snakeLoc.Y < foodLoc.Y + activeFood[i].Height)
                    {
                        bite.Play();

                        // give the snake a point
                        points++;

                        // update the points textbox
                        pointsLabel.Text = points.ToString();

                        // make a random variable
                        Random rand = new Random();

                        // move the food picture box
                        // new point, new location for the food
                        // loop while the x and y arent both divisible by 75 and isn't on the snake
                        bool onSnake = false;
                        Point newFoodLoc = new Point(1, 1);
                        while (newFoodLoc.X % 50 != 0 || newFoodLoc.Y % 50 != 0 || onSnake)
                        {
                            onSnake = false;

                            newFoodLoc = new Point(rand.Next(0, 675), rand.Next(0, 425));

                            // loop through each body part
                            for (int j = 0; j < bodyCount - 1; j++)
                            {
                                // get the location of the current body part
                                Point curBodLoc = activeBody[j].Location;

                                // if the new food location is on the location of the body part
                                if (newFoodLoc.X + 50 >= curBodLoc.X && newFoodLoc.X <= curBodLoc.X + 50)
                                {
                                    // if the new location for the food is on the location of the head
                                    if (newFoodLoc.Y + 50 >= curBodLoc.Y && newFoodLoc.Y <= curBodLoc.Y + 50)
                                        onSnake = true;

                                }
                            }
                        }
                        activeFood[i].Location = newFoodLoc;

                        // get the direction of the last body part
                        String direct = directionsList[bodyCount - 1];

                        // save the location of the old last body part
                        Point oldLast = activeBody[bodyCount - 1].Location;

                        // add the next body part depending on the direciton of the body part it's attatching to
                        switch (direct)
                        {
                            case ("right"): oldLast.X -= 50; break;
                            case ("left"): oldLast.X += 50; break;
                            case ("up"): oldLast.Y += 50; break;
                            case ("down"): oldLast.Y -= 50; break;
                        }

                        // set the direction of the new body part to match the one it's attatching to
                        directionsList.Add(directionsList[bodyCount - 1]);

                        // make a new body part
                        PictureBox body = new PictureBox();
                        body.Image = snakeBodyPB1.Image;
                        body.SizeMode = snakeBodyPB1.SizeMode;
                        body.Size = snakeBodyPB1.Size;
                        body.Location = oldLast;
                        activeBody.Add(body);
                        this.Controls.Add(body);
                        body.BringToFront();

                        // increase the body count
                        bodyCount++; 

                    }
                }
            }
        }



        // method to check if the snake is dead
        private void setDead()
        {
            // if the snake hit the border
            if (snakeHeadPB.Location.X > 750 || snakeHeadPB.Location.X < 0 || snakeHeadPB.Location.Y < 0 || snakeHeadPB.Location.Y > 400)
            {
                dead = true;
                deathSound.Play();

                // if this is a new highscore for this player, save that
                if (points > player.getSnakeScore())
                    player.setSnakeScore(points);
            }

            // if the snake hit itself
            // go to each body part of the snake
            foreach (PictureBox box in activeBody)
            {
                // save the location of this body part in a variable
                Point currBodLoc = box.Location;

                // if the head is in the picture box's location
                if (getDistance(snakeHeadPB, box) < snakeHeadPB.Width - 1)
                {
                    dead = true;
                    deathSound.Play();

                    // if this is a new highscore for this player, save that
                    if (points > player.getSnakeScore())
                        player.setSnakeScore(points);
                }
            }
        }


        private int getDistance(PictureBox box1, PictureBox box2)
        {
            int distance = Math.Abs(box1.Location.X - box2.Location.X) + Math.Abs(box1.Location.Y - box2.Location.Y);
            return distance;
        }


        // loop that keeps the snake moving
        private void moveSnake()
        {
            // check if the snake ate food
            ateFood();

            // if the head of the snake is waiting to change direction and it's able to, change the direction, clear the temp direction, and
            // change the head
            if (tempDirect.Equals("right") && snakeHeadPB.Location.Y % 50 == 0 && snakeHeadPB.Location.X % 50 == 0)
            {
                direction = "right"; tempDirect = "none"; snakeHeadPB.Image = Properties.Resources.Right_Snake_Head;

                // add the direction change to the lists
                headMoves.Add(snakeHeadPB.Location);
                headMovesDir.Add("right");
            }
            if (tempDirect.Equals("up") && snakeHeadPB.Location.X % 50 == 0 && snakeHeadPB.Location.X % 50 == 0)
            {
                direction = "up"; tempDirect = "none"; snakeHeadPB.Image = Properties.Resources.Up_Snake_Head;

                // add the direction change to the lists
                headMoves.Add(snakeHeadPB.Location);
                headMovesDir.Add("up");
            }
            if (tempDirect.Equals("left") && snakeHeadPB.Location.Y % 50 == 0 && snakeHeadPB.Location.X % 50 == 0)
            {
                direction = "left"; tempDirect = "none"; snakeHeadPB.Image = Properties.Resources.Left_Snake_Head;

                // add the direction change to the lists
                headMoves.Add(snakeHeadPB.Location);
                headMovesDir.Add("left");
            }
            if (tempDirect.Equals("down") && snakeHeadPB.Location.X % 50 == 0 && snakeHeadPB.Location.X % 50 == 0)
            {
                direction = "down"; tempDirect = "none"; snakeHeadPB.Image = Properties.Resources.Down_Snake_Head;

                // add the direction change to the lists
                headMoves.Add(snakeHeadPB.Location);
                headMovesDir.Add("down");
            }
            // change the location of head of the snake depending on which way it' facing
            switch (direction)
            {
                case ("right"):
                    Point newRightLocation = new Point(snakeHeadPB.Location.X + snakeSpeed, snakeHeadPB.Location.Y); snakeHeadPB.Location = newRightLocation; break;
                case ("up"):
                    Point newUpLocation = new Point(snakeHeadPB.Location.X, snakeHeadPB.Location.Y - snakeSpeed); snakeHeadPB.Location = newUpLocation; break;
                case ("left"):
                    Point newLeftLocation = new Point(snakeHeadPB.Location.X - snakeSpeed, snakeHeadPB.Location.Y); snakeHeadPB.Location = newLeftLocation; break;
                case ("down"):
                    Point newDownLocation = new Point(snakeHeadPB.Location.X, snakeHeadPB.Location.Y + snakeSpeed); snakeHeadPB.Location = newDownLocation; break;
            }

            // change the rest of the body that the snake has grown so far
            foreach (PictureBox box in activeBody)
            {
                // save the location of this body picture box
                Point thisBodLoc = box.Location;

                // check if it's at any of the locations that the head has changed direction at
                for (int i = 0; i < headMoves.Count(); i++)
                {
                    // if the current location of this body part is equal to one of the locations thee head changed directions at
                    if (thisBodLoc == headMoves[i])
                    {
                        // change this picture box's direction to the direction the head switched to at this location
                        directionsList[activeBody.IndexOf(box)] = headMovesDir[i];

                        // if this is the last body part on the snake, remove this direction change from the list bc every body's done it now
                        if (activeBody.IndexOf(box) == bodyCount - 1)
                        {
                            headMoves.RemoveAt(i);
                            headMovesDir.RemoveAt(i);
                        }
                    }
                }
            }

            // go to each body part that the snake has
            foreach (PictureBox box in activeBody)
            {
                // variable for the location of the current picture box
                Point pbLocation = box.Location;

                // move the location variablie 5 in the direction the picture box is going
                switch (directionsList[activeBody.IndexOf(box)])
                {
                    case ("right"): pbLocation.X += snakeSpeed; break;
                    case ("up"): pbLocation.Y -= snakeSpeed; break;
                    case ("left"): pbLocation.X -= snakeSpeed; break;
                    case ("down"): pbLocation.Y += snakeSpeed; break;
                }

                // set the actual picture box location to the location variable
                box.Location = pbLocation;
            }
        }

        bool formClosed = false;

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!dead)
            {
                // move the snake
                backgroundWorker1.ReportProgress(3);

                // add a delay before moving the snake again
                Thread.Sleep(waitSpeed);
            }

            if (dead)
                backgroundWorker1.ReportProgress(1);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ateFood();

            if (dead)
            {
                // call the method for when the snake dies
                snakeDied();
            }
            else
            {
                // move the snake forward
                moveSnake();

                // check if its new location kills it
                setDead();
            }
        }

        private void backgroundWorker2_DoWork_1(object sender, DoWorkEventArgs e)
        {
            while (keepFlashing)
            {
                backgroundWorker2.ReportProgress(3);
                Thread.Sleep(1000);
            }
            backgroundWorker2.CancelAsync();
        }

        private void backgroundWorker2_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            if (instructionsLabel.Visible == false)
                instructionsLabel.Visible = true;
            else
                instructionsLabel.Visible = false;
        }

        private void playAgainNo_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Snake_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Snake_KeyDown(object sender, KeyEventArgs e)
        {
            if (firstKeyPress)
            {
                startGame();
                firstKeyPress = false;
            }

            if ((e.KeyCode == Keys.W || e.KeyCode == Keys.Up) && !direction.Equals("down"))
            {
                tempDirect = "up";
            }

            if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && !direction.Equals("left"))
            {
                tempDirect = "right";
            }

            if ((e.KeyCode == Keys.S || e.KeyCode == Keys.Down) && !direction.Equals("up"))
            {
                tempDirect = "down";
            }

            if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && !direction.Equals("right"))
            {
                tempDirect = "left";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void playAgainYes_Click(object sender, EventArgs e)
        {
            player.addCoins(points);
            deadGroup.Visible = false;

            Snake.ActiveForm.Focus();


            // make all the body parts invisible and in the corner again
            foreach (PictureBox box in activeBody)
            {
                box.Visible = false;
                box.Location = new Point(701, 382);
            }
            activeBody.Clear();
            firstKeyPress = true;
            if (!backgroundWorker2.IsBusy)
                backgroundWorker2.RunWorkerAsync();
            keepFlashing = true;
            direction = "right";

            // set the head and first two body parts to the correct location
            activeBody.Add(snakeBodyPB1);
            activeBody.Add(snakeBodyPB2);
            snakeHeadPB.Location = new Point(150, 200);
            snakeBodyPB1.Location = new Point(100, 200);
            snakeBodyPB2.Location = new Point(50, 200);
            snakeBodyPB1.Visible = true;
            snakeBodyPB2.Visible = true;
            directionsList.Clear();
            directionsList.Add("right");
            directionsList.Add("right");

            snakeHeadPB.Image = Properties.Resources.Right_Snake_Head;
            deadGroup.Visible = false;

            // reset the score
            points = 0;

            bodyCount = 2;
            dead = false;

            headMovesDir.Clear();
            headMoves.Clear();
        }

        private void Snake_FormClosed(object sender, FormClosedEventArgs e)
        {
            player.addCoins(points);
            // update the file that keeps track of the current user
            player.updateFile();

            // update the user's stats to that file
            player.updateUser();
        }

        private void changeFoodButton_Click(object sender, EventArgs e)
        {
            foodSelectPanel.Location = new Point(0, 0);
            foodSelectPanel.Size = new Size(800, 451);
            foodSelectPanel.Visible = true;
        }


        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            PictureBox[] foodSelectBoxes = { pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8,
            pictureBox9, pictureBox10, pictureBox11 };

            foreach (PictureBox box in foodSelectBoxes)
                box.BackColor = Color.FromArgb(106, 176, 76);


            foodPB1.Image = ((PictureBox)sender).Image;
            ((PictureBox)sender).BackColor = Color.FromArgb(255, 255, 255);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foodSelectPanel.Visible = false;
            Snake.ActiveForm.Focus();
        }
    }
}
