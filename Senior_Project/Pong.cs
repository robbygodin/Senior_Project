using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Media;

namespace Senior_Project
{
    public partial class Pong : Form
    {
        bool onePlayer = true;
        // ints to keep track of the slope that the ball is following (0 - 5)
        int ballChangeY = 0;
        int ballChangeX = -3;

        int coinsToAdd = 0;


        // bool for if the game is over
        bool gameOver = false;

        // var to hold which key is being pressed
        List<Keys> keyHeld = new List<Keys>();

        // location of where the panel should be for when the ball reaches it
        Point futureCompLocation;

        // int to keep track of the adjustment of the location of the panel
        int panelAdj = 0;

        // boolean for if it's the first key press
        bool firstKeyPress = true;

        // ints to keep track of the points
        int userPoints = 0;
        int compPoints = 0;

        // string to keep track of who gets the serve (user and computer)
        String whoServe = "user";

        // timer for adding a reaction time to the computer
        Stopwatch stopwatch = new Stopwatch();

        // int to keep track of the amount of hits in a rally
        int hits = 0;

        // keys
        Keys[] p1Up = new Keys[2];
        Keys[] p1Down = new Keys[2];
        Keys[] p2Up = new Keys[2];
        Keys[] p2Down = new Keys[2];

        User player;

        public Pong(User user)
        {
            InitializeComponent();
            player = user;

            // start the background worker that moves the panel
            movePanelBack.RunWorkerAsync();
            startGB.BringToFront();
            startGB.Size = new Size(809, 455);
            startGB.Location = new Point(0, 0);

            Pong.ActiveForm.Focus();

        }

        private void startGame()
        {
            backgroundWorker1.RunWorkerAsync();
            compPanelBack.RunWorkerAsync();
            player1Label.Visible = false;
            player2Label.Visible = false;
            instructionsLabel.Visible = false;
            Pong.ActiveForm.Focus();

        }


        private void setServe()
        {
            ballChangeY = 0;
            // if it's the user's serve
            if (whoServe.Equals("user"))
            {
                // set the x so the ball goes to the user
                ballChangeX = -3;

                // set it so the computer gets the next serve
                whoServe = "computer";

                // reset the ball and the y direction of the ball
                ball.Location = new Point(734, 210);

            }
            else
            {
                // set the x so it goes to the computer
                ballChangeX = 3;

                // set it so the user gets the next serve
                whoServe = "user";

                // reset the ball and the y direction of the ball
                ball.Location = new Point(41, 210);
            }
        }



        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            while (!gameOver)
            {
                // report progress, which triggers the ball to move again
                backgroundWorker1.ReportProgress(1);

                // sleep for a tiny amount of time
                Thread.Sleep(15);
            }
        }

        private void backgroundWorker1_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            // change the location of the ball
            ball.Location = new Point(ball.Location.X + ballChangeX, ball.Location.Y + ballChangeY);

            // if the ball collided with computer panel, go in the opposite direction
            if (ball.Location.X + 25 >= compPanel.Location.X && ball.Location.X + 25 <= compPanel.Location.X + 25 &&
                ball.Location.Y + 25 >= compPanel.Location.Y && ball.Location.Y <= compPanel.Location.Y + 115)
            {
                ball.Location = new Point(compPanel.Location.X - ball.Width, ball.Location.Y);
                SoundPlayer hit = new SoundPlayer(Properties.Resources.mixkit_explainer_video_game_alert_sweep_236);
                hit.Play();
                hits++;

                if (hits > 5)
                    ball.Image = Properties.Resources._5_Ball;
                if (hits > 10)
                    ball.Image = Properties.Resources._10_Ball;
                if (hits > 15)
                    ball.Image = Properties.Resources._15_Ball;
                if (hits > 20)
                    ball.Image = Properties.Resources._20_Ball;
                if (hits > 25)
                    ball.Image = Properties.Resources._25_Ball;
                if (hits > 30)
                    ball.Image = Properties.Resources._30_Ball;
                if (hits > 35)
                    ball.Image = Properties.Resources.Max_Ball;


                stopwatch.Stop();
                stopwatch.Start();
                ballChangeX *= -1;

                if (ballChangeX < 0)
                    ballChangeX--;
                else
                    ballChangeX++;

                // if it hit the panel at the top part, make the ball go down, opposite for if it hit the bottom side
                if (ball.Location.Y <= compPanel.Location.Y + 20)
                {
                    ballChangeY = 3;
                }
                else if (ball.Location.Y <= compPanel.Location.Y + 40)
                {
                    ballChangeY = 2;
                }
                else if (ball.Location.Y <= compPanel.Location.Y + 55)
                {
                    ballChangeY = 1;
                }
                else if (ball.Location.Y <= compPanel.Location.Y + 70)
                {
                    ballChangeY = -1;
                }
                else if (ball.Location.Y <= compPanel.Location.Y + 85)
                {
                    ballChangeY = -2;
                }
                else
                {
                    ballChangeY = -3;
                }
            }

            // if the ball hit the player panel
            if (ball.Location.X <= 35 && ball.Location.X >= userPanel.Location.X &&
                ball.Location.Y + 25 >= userPanel.Location.Y && ball.Location.Y <= userPanel.Location.Y + 115)
            {
                ball.Location = new Point(userPanel.Location.X + userPanel.Width, ball.Location.Y);
                SoundPlayer hit = new SoundPlayer(Properties.Resources.mixkit_explainer_video_game_alert_sweep_236);
                hit.Play();
                hits++;

                if (hits > 5)
                    ball.Image = Properties.Resources._5_Ball;
                if (hits > 10)
                    ball.Image = Properties.Resources._10_Ball;
                if (hits > 15)
                    ball.Image = Properties.Resources._15_Ball;
                if (hits > 20)
                    ball.Image = Properties.Resources._20_Ball;
                if (hits > 25)
                    ball.Image = Properties.Resources._25_Ball;
                if (hits > 30)
                    ball.Image = Properties.Resources._30_Ball;
                if (hits > 35)
                    ball.Image = Properties.Resources.Max_Ball;


                ballChangeX *= -1;

                stopwatch.Stop();
                stopwatch.Start();
                // if it hit the panel at the top part, make the ball go down, opposite for if it hit the bottom side
                // if it hit the panel at the top part, make the ball go down, opposite for if it hit the bottom side
                if (ball.Location.Y <= userPanel.Location.Y + 20)
                {
                    ballChangeY = 3;
                }
                else if (ball.Location.Y <= userPanel.Location.Y + 40)
                {
                    ballChangeY = 2;
                }
                else if (ball.Location.Y <= userPanel.Location.Y + 55)
                {
                    ballChangeY = 1;
                }
                else if (ball.Location.Y <= userPanel.Location.Y + 70)
                {
                    ballChangeY = -1;
                }
                else if (ball.Location.Y <= userPanel.Location.Y + 85)
                {
                    ballChangeY = -2;
                }
                else
                {
                    ballChangeY = -3;
                }
            }

            // if the ball is coming towards the computer && the computer isn't controlled by a player
            if (ballChangeX > 0 && onePlayer)
            {
                // predict where the ball's going to be when it reaches the computer panel
                // subtract the x of the ball from the x of the panel (horizontal distance the ball has to travel)
                int futureY = compPanel.Location.X - ball.Location.X;

                // divide the distance the ball has to travel by the distance it goes each movement(amount of moves left)
                futureY /= ballChangeX;

                // multiply the amount of moves left by the distance the ball goes on each move (the distance the
                //ball will travel on the y before reaching the panel)
                futureY *= ballChangeY;

                // add the distance the ball will travel on the y to the current y of the ball
                futureY += ball.Location.Y;

                // if the user's panel is high up
                if (userPanel.Location.Y <= 240)
                {
                    // set the panel adustment so the panel goes a little higher and hits the ball with the lower part
                    panelAdj = 0;
                }
                else
                    panelAdj = -100;

                // set the computer's desired location to be in front of the ball
                futureCompLocation = new Point(compPanel.Location.X, futureY);
            }

            // if the ball hit the top or bottom, reverse they y
            if (ball.Location.Y <= 0 || ball.Location.Y >= 440)
            {
                ballChangeY *= -1;
                SoundPlayer hit = new SoundPlayer(Properties.Resources.mixkit_explainer_video_game_alert_sweep_236);
                hit.Play();
            }

            // if the ball went behind the user's panel
            if (ball.Location.X <= 0)
            {
                SoundPlayer goal = new SoundPlayer(Properties.Resources.audiomass_output__2_);
                goal.Play();

                // give a point to the computer
                compPoints++;
                coinsToAdd--;
                compPointsLabel.Text = compPoints.ToString();

                // reset the square's image
                ball.Image = Properties.Resources.Blue_Square;
                hits = 0;

                setServe();

            }

            // if the ball when behind the computer's panel
            if (ball.Location.X > compPanel.Location.X + 30)
            {
                SoundPlayer goal = new SoundPlayer(Properties.Resources.audiomass_output__2_);
                goal.Play();

                // give points to the user
                userPoints++;
                coinsToAdd++;
                userPointsLabel.Text = userPoints.ToString();

                // reset the square's image
                ball.Image = Properties.Resources.Blue_Square;
                hits = 0;

                setServe();
            }
        }

        private void movePanelBack_DoWork_1(object sender, DoWorkEventArgs e)
        {
            // keep moving the board until the key is released
            while (!gameOver)
            {
                movePanelBack.ReportProgress(1);



                // wait a little bit of time before moving the panel again
                Thread.Sleep(15);
            }
        }

        private void movePanelBack_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            if (keyHeld.Count > 0)
            {
                // if it's one player
                if (onePlayer)
                {
                    int userChangeY = 0;

                    // go to each key curently being held
                    foreach (Keys key in keyHeld)
                    {
                        // if the user pressed w or the up arrow key
                        if (p1Up.Contains(key) && userPanel.Location.Y >= 0)
                        {
                            // move the user's panel up
                            userChangeY = -6;
                        }

                        // if the user pressed s or the down arrow key
                        if (p1Down.Contains(key) && userPanel.Location.Y + 115 <= 450)
                        {
                            // move the user's panel up
                            userChangeY = 6;
                        }
                    }

                    // move the user panel
                    userPanel.Location = new Point(userPanel.Location.X, userPanel.Location.Y + userChangeY);
                }
                // if it's two player
                else
                {
                    int userChangeY = 0;
                    int compChangeY = 0;
                    // go to each key curently being held
                    foreach (Keys key in keyHeld)
                    {
                        // if the left user pressed w
                        if (p1Up.Contains(key) && userPanel.Location.Y >= 0)
                        {
                            // move the user's panel up
                            userChangeY = -5;
                        }

                        // if the user pressed s or the down arrow key
                        if (p1Down.Contains(key) && userPanel.Location.Y + 115 <= 450)
                        {
                            // move the user's panel up
                            userChangeY = 5;
                        }

                        // if the right user pressed up
                        if (p2Up.Contains(key) && compPanel.Location.Y >= 0)
                        {
                            // move the user's panel up
                            compChangeY = -5;
                        }

                        // if the user pressed s or the down arrow key
                        if (p2Down.Contains(key) && compPanel.Location.Y + 115 <= 450)
                        {
                            // move the user's panel up
                            compChangeY = 5;
                        }
                    }
                    // move the user panel
                    userPanel.Location = new Point(userPanel.Location.X, userPanel.Location.Y + userChangeY);

                    // move the computer panel
                    compPanel.Location = new Point(compPanel.Location.X, compPanel.Location.Y + compChangeY);
                }
            }

            
        }

        private void compPanelBack_DoWork_1(object sender, DoWorkEventArgs e)
        {
            // loop until the game is over
            while (!gameOver)
            {
                compPanelBack.ReportProgress(1);

                // wait before moving the panel again
                Thread.Sleep(15);
            }
        }

        private void compPanelBack_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            if (stopwatch.ElapsedMilliseconds >= 300 && onePlayer)
            {
                // if the y is higher than the panel currently is, move the panel up
                if (futureCompLocation.Y - 10 + panelAdj > compPanel.Location.Y && compPanel.Location.Y + 115 < 450)
                    compPanel.Location = new Point(compPanel.Location.X, compPanel.Location.Y + 5);

                // // if the y is lower than the panel currently is, move the panel down
                if (futureCompLocation.Y + 10 + panelAdj < compPanel.Location.Y && compPanel.Location.Y > 0)
                    compPanel.Location = new Point(compPanel.Location.X, compPanel.Location.Y - 3);
            }
        }

        private void Pong_KeyUp_1(object sender, KeyEventArgs e)
        {
            keyHeld.Remove(e.KeyCode);
        }


        private void Pong_KeyDown(object sender, KeyEventArgs e)
        {
           

            if (firstKeyPress)
            {
                startGame();
                firstKeyPress = false;
            }
            else if (!keyHeld.Contains(e.KeyCode))
            {
                // save what key is being held down
                keyHeld.Add(e.KeyCode);
            }
        }

        // TWO PLAYER BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            // set the bool that keeps track of type of play to two player
            onePlayer = false;

            player1Label.Text = "Player 1 (WASD)";
            player2Label.Text = "Player 2 (Arrow Keys)";

            // tell the user the instructions for two player mode
            instlabel.Text = "Player One controls just the left panel with WASD. " +
                "Player Two controls the right panel with the arrow keys. " +
                "Don't let the ball go behind your panel. Good Luck!";

            // disable this button, enable the other one
            twoPlayerButton.Enabled = false;
            onePlayerButton.Enabled = true;
        }

        private void onePlayerButton_Click(object sender, EventArgs e)
        {
            // set the bool that keeps track of type of play to one player
            onePlayer = true;

            player1Label.Text = "You";
            player2Label.Text = "Computer";

            // tell the user the instructions for the one player mode
            instlabel.Text = "You control just the left panel. " +
                "Use either WASD or the arrow keys to control your panel. " +
                "Don't let the ball go behind your panel. Good Luck!";

            // disable this button, enable the other one
            onePlayerButton.Enabled = false;
            twoPlayerButton.Enabled = true; 
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            // close this menu
            startGB.Visible = false;
            onePlayerButton.Enabled = false;
            twoPlayerButton.Enabled = false;
            Pong.ActiveForm.Focus();


            if (onePlayer)
            {
                p1Up[0] = Keys.Up;
                p1Up[1] = Keys.W;
                p1Down[0] = Keys.Down;
                p1Down[1] = Keys.S;
            }
            else
            {
                p1Up[0] = Keys.W;
                p1Down[0] = Keys.S;
                p2Up[0] = Keys.Up;
                p2Down[0] = Keys.Down;
            }
        }

        private void settingsGB_Enter(object sender, EventArgs e)
        {

        }

        private void onePControls_Enter(object sender, EventArgs e)
        {

        }

    

        private void Pong_FormClosed(object sender, FormClosedEventArgs e)
        {
            gameOver = true;
            player.addCoins(coinsToAdd);
            if (((double)userPoints / (double)compPoints) > player.getPongScore(1))
                player.setPongScore(userPoints.ToString() + "-" + compPoints.ToString());
            player.updateFile();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
