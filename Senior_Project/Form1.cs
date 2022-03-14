using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Senior_Project
{
    public partial class Form1 : Form
    {
        // int to keep track of which panel is showing
        int panelShown = 0;

        // array to keep track of the images
        Image[] panelImages = new Image[5];

        // array for the title images for each game
        Image[] titleImages = new Image[5];


        public List<User> users = new List<User>();

        public User player;

        bool firstClick = true;

        Stopwatch lastClickTimer = new Stopwatch();

        bool closed = false;

        bool changePanelRight = false;
        bool changePanelLeft = false;


        MediaPlayer snakeSound = new MediaPlayer();
        MediaPlayer pongSound = new MediaPlayer();
        MediaPlayer tetrisSound = new MediaPlayer();
        MediaPlayer asteroidsSound = new MediaPlayer();
        MediaPlayer marioSound = new MediaPlayer();

        public Form1()
        {
            this.AllowDrop = true;

            InitializeComponent();
            updater.RunWorkerAsync();


            snakeSound.Open(new Uri(Application.StartupPath + "\\Sounds\\Bite (2).wav"));
            pongSound.Open(new Uri(Application.StartupPath + "\\Sounds\\mixkit-explainer-video-game-alert-sweep-236.wav"));
            tetrisSound.Open(new Uri(Application.StartupPath + "\\Sounds\\Video Game Beep - Sound Effect.wav"));
            asteroidsSound.Open(new Uri(Application.StartupPath + "\\Sounds\\Videogame Death Sound Effect HD  No Copyright.wav"));
            marioSound.Open(new Uri(Application.StartupPath + "\\Sounds\\MarioCoinSound.wav"));

            startGB.Location = new Point(0, 131);
            startGB.Size = new Size(1354, 545);
            startGB.BringToFront();


            // add the panel images to the array
            panelImages[0] = Properties.Resources.Snake;
            panelImages[1] = Properties.Resources.Pong_Panel_Image;
            //panelImages[2] = Properties.Resources.Pac_Man;
            panelImages[2] = Properties.Resources.Tetris_Panel_Image;
            panelImages[3] = Properties.Resources.Asteroids_Panel_Image;
            panelImages[4] = Properties.Resources.supermariothumbsup_800x400;

            titleImages[0] = Properties.Resources.Snake_Neon_Sign;
            titleImages[1] = Properties.Resources.Pong_Neon_Sign;
            //titleImages[2] = Properties.Resources.Tetris_Title_Image;
            titleImages[2] = Properties.Resources.Tetris_Neon_Sign;
            titleImages[3] = Properties.Resources.Asteroids_Neon_Sign;
            titleImages[4] = Properties.Resources.Mario_Title_Sign_Resized;

            StreamReader usersReader = new StreamReader("Users.txt");

            while (!usersReader.EndOfStream)
            {
                List<String> values = new List<string>();
                String line = usersReader.ReadLine();
                do
                {
                    values.Add(line);
                    line = usersReader.ReadLine();
                } while (line != "END");

                for (int i = values.Count; i < 8; i++)
                {
                    values.Add("0");
                }


                User user = new User(values[0], values[1], int.Parse(values[2]), int.Parse(values[3]), values[4], int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));
                users.Add(user);
            }
            usersReader.Close();
        }

        private void playSound()
        {

            // stop all previous sounds
            snakeSound.Stop();
            pongSound.Stop();
            tetrisSound.Stop();
            asteroidsSound.Stop();
            marioSound.Stop();

            if (panelShown == 1)
            {
                snakeSound.Play();
            }

            if (panelShown == 2)
            {
                pongSound.Play();
            }

            if (panelShown == 3)
            {
                tetrisSound.Play();
            }

            if (panelShown == 4)
            {
                asteroidsSound.Play();
            }

            if (panelShown == 5)
            {
                marioSound.Play();
            }
        }




        bool transitioning = false;

        private void rightArrowPB_Click(object sender, EventArgs e)
        {
            if (transitioning)
                return;
            if (firstClick)
            {
                gamesPanel.Visible = false;
                panelPB.Size = new Size(715, 414);
                panelPB.Location = new Point(321, 157);
                menuInstLabel.Visible = false;
                coinPanel.Visible = true;
                howPlayButton.Visible = true;
                nextLabel.Visible = false;
                lastLabel.Visible = false;
                leaderButton.Visible = true;
            }
            else if (lastClickTimer.ElapsedMilliseconds < 500)
                return;

            lastClickTimer.Restart();

            howPlayButton.Visible = true;
            closeButton.Visible = false;
            instructionsLabel.Visible = false;

            leaderboardLB.Visible = false;
            leaderboardTitle.Visible = false;

            // increase the counter for which panel is shown
            panelShown++;

            // if panelShown is greater than how many games there are, reset back to the first game
            if (panelShown > panelImages.Length)
                panelShown = 1;

            // show the image based on panelShown
            //panelPB.Image = panelImages[panelShown - 1];

            transitioning = true;
            panelPB.Visible = false;
            oldPanelPB.Location = panelPB.Location;
            oldPanelPB.Size = panelPB.Size;
            if (!firstClick)
                oldPanelPB.Visible = true;
            newPanelPB.Location = new Point(1321, panelPB.Location.Y);
            newPanelPB.Size = panelPB.Size;
            newPanelPB.Visible = true;

            oldPanelPB.Image = panelPB.Image;
            newPanelPB.Image = panelImages[panelShown - 1];

            changePanelRight = true;
            firstClick = false;

            playSound();
        }

        private void leftArrowPB_Click(object sender, EventArgs e)
        {
            if (transitioning)
                return;
            if (firstClick)
            {
                gamesPanel.Visible = false;
                panelPB.Size = new Size(715, 414);
                panelPB.Location = new Point(321, 157);
                menuInstLabel.Visible = false;
                coinPanel.Visible = true;
                nextLabel.Visible = false;
                lastLabel.Visible = false;
                leaderButton.Visible = true;
            }
            else if (lastClickTimer.ElapsedMilliseconds < 500)
                return;

            lastClickTimer.Restart();

            howPlayButton.Visible = true;
            closeButton.Visible = false;
            instructionsLabel.Visible = false;

            leaderboardLB.Visible = false;
            leaderboardTitle.Visible = false;

            // decrease the counter for which panel is shown
            panelShown--;

            // if panelShown is less than 1, reset back to the last game
            if (panelShown < 1)
                panelShown = panelImages.Length;

            // show the image based on panelShown
            //panelPB.Image = panelImages[panelShown - 1];

            transitioning = true;
            panelPB.Visible = false;
            oldPanelPB.Location = panelPB.Location;
            oldPanelPB.Size = panelPB.Size;
            if (!firstClick)
                oldPanelPB.Visible = true;
            newPanelPB.Location = new Point(panelPB.Location.Y - 1011, panelPB.Location.Y);
            newPanelPB.Size = panelPB.Size;
            newPanelPB.Visible = true;

            oldPanelPB.Image = panelPB.Image;
            newPanelPB.Image = panelImages[panelShown - 1];

            changePanelLeft = true;
            firstClick = false;

            playSound();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panelPB_Click(object sender, EventArgs e)
        {
            if (panelShown == 1)
            {
                Snake snake = new Snake(player); snake.Show();
            }

            if (panelShown == 2)
            {
                Pong pong = new Pong(player); pong.Show();
            }

            if (panelShown == 3)
            {
                Tetris tetris = new Tetris(player); tetris.Show();
            }

            if (panelShown == 4)
            {
                Asteroids asteroid = new Asteroids(player); asteroid.Show();
            }

            if (panelShown == 5)
            {
                Mario mario = new Mario(player); mario.Show();
            }
        }

        private void howPlayButton_Click(object sender, EventArgs e)
        {
            instructionsLabel.Visible = true;
            leaderboardLB.Visible = false;
            howPlayButton.Visible = false;
            closeButton.Visible = true;
            leaderboardTitle.Visible = false;

            instructionsLabel.Location = new Point(321, 157);
            instructionsLabel.Size = new Size(715, 414);

            switch (panelShown)
            {
                case (1): instructionsLabel.Text = "Control the snake using WASD or the arrow keys. Eat as many burgers as you can. " +
                        "Avoid hitting yourself or the walls. The more burgers you eat, the more coins you earn."; break;
                case (2): instructionsLabel.Text = "Play against a computer or another player. Hit the ball with your paddle and don't let" +
                        " it go behind you."; break;
                //case (3): instructionsLabel.Text = "pacman"; break;
                case (3): instructionsLabel.Text = "Shapes will spawn at the top of the screen. By moving them (left and right arrow keys) and " +
                        "rotating them (up arrow key), drop the shapes in the correct spots at the bottom. When a line is full , it'll break. " +
                        "Getting multiple lines at once gives you more points. Don't let the blocks reach the top of the screen or you'll lose. "; break;
                case (4): instructionsLabel.Text = "Use WASD or arrow keys to control the space ship, move forward with W or Up Arrow. Shoot (Space) the asteroids to destroy them," +
                        " but don't get hit. Be careful of the UFO, it'll appear randomly and has it's own gun. If you get in trouble, hit " +
                        "shift to teleport. Good luck."; break;
                case (5): instructionsLabel.Text = "W or up arrow to jump. A and D are used to move left and right. Squish as many enemies as possible and break the coin blocks when they appear. Have Fun."; break;

            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            leaderboardLB.Location = new Point(321, 217);
            leaderboardLB.Size = new Size(715, 354);
            leaderboardTitle.Size = new Size(715, 64);
            leaderboardTitle.Location = new Point(321, 152);
            howPlayButton.Visible = true;
            instructionsLabel.Visible = false;
            closeButton.Visible = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }


        private void clearFile(String filePath)
        {
            StreamWriter writer = new StreamWriter(filePath);
            writer.Close();
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            takenLabel.Visible = false;
            incLoginLabel.Visible = false;
            loginInstructions.Visible = false;
            enterUPErrorLabel.Visible = false;

            if (usernameTB.Text == "" || passTB.Text == "")
            {
                enterUPErrorLabel.Visible = true;
                return;
            }

            bool takenUser = false;

            // check each user already created if the username matches any of them
            foreach (User user in users)
            {
                if (user.getName() == usernameTB.Text)
                {
                    takenUser = true;
                    takenLabel.Visible = true;
                }
            }

            // if the username isn't taken
            if (!takenUser)
            {
                // make a new user with this user's info + add it to the list
                User newUser = new User(usernameTB.Text, passTB.Text);
                users.Add(newUser);

                // get the program started
                player = newUser;
                startGB.Visible = false;
                coinsLabel.Text = player.getCoins().ToString();
                coinsLabel.Visible = true;
                coinPB.Visible = true;

                // save this user to the current user file
                StreamWriter writer = new StreamWriter("CurrentUser.txt");
                writer.WriteLine(player.getName());
                writer.WriteLine(player.getPass());
                writer.WriteLine(player.getCoins());
                writer.WriteLine(player.getSnakeScore());
                writer.WriteLine(player.getPongScore());
                writer.WriteLine(player.getTetrisScore());
                writer.WriteLine(player.getAstScore());
                writer.WriteLine(player.getMarioScore());
                writer.Close();
                signedIn = true;

            }
        }
        // SIGN IN BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            // make error labels false
            loginInstructions.Visible = false;
            takenLabel.Visible = false;
            incLoginLabel.Visible = false;
            enterUPErrorLabel.Visible = false;

            if (usernameTB.Text == "" || passTB.Text == "")
            {
                enterUPErrorLabel.Visible = true;
                return;
            }

            // go to each user in the already imported list of users
            foreach (User user in users)
            {
                // if the entered username and password match an already existing account
                if (usernameTB.Text == user.getName() && passTB.Text == user.getPass() && usernameTB.Text != "Username")
                {
                    takenLabel.Visible = false;
                    incLoginLabel.Visible = false;
                    signingInLabel.Visible = true;
                    signInButton.Enabled = false;
                    newUserButton.Enabled = false;
                    this.Update();
                    player = user;

                    StreamWriter writer = new StreamWriter("CurrentUser.txt");

                    // write the user's stats to the current user file
                    writer.WriteLine(player.getName());
                    writer.WriteLine(player.getPass());
                    writer.WriteLine(player.getCoins());
                    writer.WriteLine(player.getSnakeScore());
                    writer.WriteLine(player.getPongScore());
                    writer.WriteLine(player.getTetrisScore());
                    writer.WriteLine(player.getAstScore());
                    writer.WriteLine(player.getMarioScore());
                    writer.Close();
                    // log them in and get the program started
                    startGB.Visible = false;
                    coinsLabel.Text = player.getCoins().ToString();
                    coinsLabel.Visible = true;
                    coinPB.Visible = true;
                    signedIn = true;
                }
                else
                {
                    // tell them the login was incorrect
                    incLoginLabel.Visible = true;
                }
            }
            timer.Stop();
        }

        private void passTB_TextChanged(object sender, EventArgs e)
        {

        }

        bool usernameSelected = false;
        bool passSelected = false;

        private void updater_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!closed && !updater.CancellationPending)
            {
                updater.ReportProgress(1);
                Thread.Sleep(15);
            }
            updater.CancelAsync();
        }

        bool signedIn = false;

        private void updater_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (usernameSelected && usernameLabel.Location.Y > usernameTB.Location.Y - usernameLabel.Height)
                usernameLabel.Location = new Point(usernameLabel.Location.X, usernameLabel.Location.Y - 5);
            else if (!usernameSelected && usernameTB.Text == "" && usernameLabel.Location.Y < usernameTB.Location.Y)
                usernameLabel.Location = new Point(usernameLabel.Location.X, usernameLabel.Location.Y + 5);

            if (passSelected && passLabel.Location.Y > passTB.Location.Y - passLabel.Height)
                passLabel.Location = new Point(passLabel.Location.X, passLabel.Location.Y - 5);
            else if (!passSelected && passTB.Text == "" && passLabel.Location.Y < passTB.Location.Y)
                passLabel.Location = new Point(passLabel.Location.X, passLabel.Location.Y + 5);

            if (!signedIn)
                return;
            
            coinsLabel.Text = player.getCoins().ToString();

            player.updateUser();

            // if it has to move to the next game
            if (changePanelRight)
            {
                // move the pictureboxs to the left
                oldPanelPB.Location = new Point(oldPanelPB.Location.X - 25, oldPanelPB.Location.Y);
                newPanelPB.Location = new Point(newPanelPB.Location.X - 25, newPanelPB.Location.Y);


                // if the new picturebox is in the spot where it should be
                if (newPanelPB.Location == panelPB.Location)
                {
                    transitioning = false;
                    changePanelRight = false;
                    panelPB.Image = newPanelPB.Image;
                    panelPB.Visible = true;
                    oldPanelPB.Visible = false;
                    newPanelPB.Visible = false;
                    titlePB.Image = titleImages[panelShown - 1];
                    panelPB.Visible = true;
                }
            }

            if (changePanelLeft)
            {
                // move the pictureboxs to the left
                oldPanelPB.Location = new Point(oldPanelPB.Location.X + 25, oldPanelPB.Location.Y);
                newPanelPB.Location = new Point(newPanelPB.Location.X + 25, newPanelPB.Location.Y);

                // if the new picturebox is in the spot where it should be
                if (newPanelPB.Location == panelPB.Location)
                {
                    transitioning = false;
                    changePanelLeft = false;
                    panelPB.Image = newPanelPB.Image;
                    panelPB.Visible = true;
                    oldPanelPB.Visible = false;
                    newPanelPB.Visible = false;
                    titlePB.Image = titleImages[panelShown - 1];
                    panelPB.Visible = true;
                }
            }

            this.Update();
        }

        private void leaderButton_Click(object sender, EventArgs e)
        {
            if (leaderboardLB.Visible)
            {
                leaderboardLB.Visible = false;
                leaderboardTitle.Visible = false;
            }
            else
            {
                instructionsLabel.Visible = false;
                leaderboardTitle.Visible = true;
                leaderboardLB.Items.Clear();
                if (panelShown == 1)
                {
                    List<User> usersInOrder = new List<User>();
                    bool firstuser = true;
                    foreach (User user in users)
                    {
                        if (firstuser)
                        {
                            usersInOrder.Add(user);
                            firstuser = false;
                        }
                        else
                        {
                            foreach (User checkUser in usersInOrder)
                            {
                                if (user.getSnakeScore() >= checkUser.getSnakeScore() && user != checkUser)
                                {
                                    usersInOrder.Insert(usersInOrder.IndexOf(checkUser), user);
                                    break;
                                }
                            }

                            if (!usersInOrder.Contains(user))
                                usersInOrder.Add(user);
                        }
                    }

                    foreach (User user in usersInOrder)
                    {
                        String printString;
                        printString = user.getName();
                        if (user.getName() == player.getName())
                            printString += "\u2B05";
                        int spaces = 24 - printString.Length - user.getSnakeScore().ToString().Length;
                        for (int i = 0; i < spaces; i++)
                            printString += " ";
                        printString += user.getSnakeScore();
                        leaderboardLB.Items.Add(printString);
                    }
                }

                if (panelShown == 2)
                {
                    List<User> usersInOrder = new List<User>();
                    bool firstuser = true;
                    foreach (User user in users)
                    {
                        if (firstuser)
                        {
                            usersInOrder.Add(user);
                            firstuser = false;
                        }
                        else
                        {
                            foreach (User checkUser in usersInOrder)
                            {
                                if (user.getPongScore(1) >= checkUser.getPongScore(1) && user != checkUser)
                                {
                                    usersInOrder.Insert(usersInOrder.IndexOf(checkUser), user);
                                    break;
                                }
                            }

                            if (!usersInOrder.Contains(user))
                                usersInOrder.Add(user);
                        }
                    }

                    foreach (User user in usersInOrder)
                    {
                        String printString;
                        printString = user.getName();
                        if (user.getName() == player.getName())
                            printString += "\u2B05";
                        int spaces = 24 - printString.Length - user.getPongScore().ToString().Length;
                        for (int i = 0; i < spaces; i++)
                            printString += " ";
                        printString += user.getPongScore();
                        leaderboardLB.Items.Add(printString);
                    }
                }

                if (panelShown == 3)
                {
                    List<User> usersInOrder = new List<User>();
                    bool firstuser = true;
                    foreach (User user in users)
                    {
                        if (firstuser)
                        {
                            usersInOrder.Add(user);
                            firstuser = false;
                        }
                        else
                        {
                            foreach (User checkUser in usersInOrder)
                            {
                                if (user.getTetrisScore() >= checkUser.getTetrisScore() && user != checkUser)
                                {
                                    usersInOrder.Insert(usersInOrder.IndexOf(checkUser), user);
                                    break;
                                }
                            }
                        }

                        if (!usersInOrder.Contains(user))
                            usersInOrder.Add(user);
                    }

                    foreach (User user in usersInOrder)// 32
                    {
                        String printString;
                        printString = user.getName();
                        if (user.getName() == player.getName())
                            printString += "\u2B05";
                        int spaces = 24 - printString.Length - user.getTetrisScore().ToString().Length;
                        for (int i = 0; i < spaces; i++)
                            printString += " ";
                        printString += user.getTetrisScore();
                        leaderboardLB.Items.Add(printString);
                    }
                }

                if (panelShown == 4)
                {
                    List<User> usersInOrder = new List<User>();
                    bool firstuser = true;
                    foreach (User user in users)
                    {
                        if (firstuser)
                        {
                            usersInOrder.Add(user);
                            firstuser = false;
                        }
                        else
                        {
                            foreach (User checkUser in usersInOrder)
                            {
                                if (user.getAstScore() >= checkUser.getAstScore() && user != checkUser)
                                {
                                    usersInOrder.Insert(usersInOrder.IndexOf(checkUser), user);
                                    break;
                                }
                            }

                            if (!usersInOrder.Contains(user))
                                usersInOrder.Add(user);
                        }
                    }

                    foreach (User user in usersInOrder)// 32
                    {
                        String printString;
                        printString = user.getName();
                        if (user.getName() == player.getName())
                            printString += "\u2B05";
                        int spaces = 24 - printString.Length - user.getAstScore().ToString().Length;
                        for (int i = 0; i < spaces; i++)
                            printString += " ";
                        printString += user.getAstScore();
                        leaderboardLB.Items.Add(printString);
                    }
                }

                if (panelShown == 5)
                {
                    List<User> usersInOrder = new List<User>();
                    bool firstuser = true;
                    foreach (User user in users)
                    {
                        if (firstuser)
                        {
                            usersInOrder.Add(user);
                            firstuser = false;
                        }
                        else
                        {
                            foreach (User checkUser in usersInOrder)
                            {
                                if (user.getMarioScore() >= checkUser.getMarioScore() && user != checkUser)
                                {
                                    usersInOrder.Insert(usersInOrder.IndexOf(checkUser), user);
                                    break;
                                }
                            }

                            if (!usersInOrder.Contains(user))
                                usersInOrder.Add(user);
                        }
                    }

                    foreach (User user in usersInOrder)// 32
                    {
                        String printString;
                        printString = user.getName();
                        if (user.getName() == player.getName())
                            printString += "\u2B05";
                        int spaces = 24 - printString.Length - user.getMarioScore().ToString().Length;
                        for (int i = 0; i < spaces; i++)
                            printString += " ";
                        printString += user.getMarioScore();
                        leaderboardLB.Items.Add(printString);
                    }
                }

                leaderboardLB.Visible = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            updater.CancelAsync();
            // clear the user file
            clearFile("Users.txt");

            closed = true;

            // write all the user's in the list to the file

            StreamWriter usersWrite = new StreamWriter("Users.txt");

            foreach (User user in users)
            {
                usersWrite.WriteLine(user.getName());
                usersWrite.WriteLine(user.getPass());
                usersWrite.WriteLine(user.getCoins());
                usersWrite.WriteLine(user.getSnakeScore());
                usersWrite.WriteLine(user.getPongScore());
                usersWrite.WriteLine(user.getTetrisScore());
                usersWrite.WriteLine(user.getAstScore());
                usersWrite.WriteLine(user.getMarioScore());
                usersWrite.WriteLine("END");
            }
            usersWrite.Close();
        }


        private void passTB_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void passTB_KeyUp(object sender, KeyEventArgs e)
        {
        }


        private void usernameTB_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void Form1_Enter(object sender, EventArgs e)
        {}



        MediaPlayer clickSound = new MediaPlayer();

        private void signInButton_MouseHover(object sender, EventArgs e)
        {
            clickSound.Open(new Uri(Application.StartupPath + "\\Sounds\\Click.wav"));
            clickSound.Play();
        }

        private void newUserButton_MouseHover(object sender, EventArgs e)
        {
            clickSound.Open(new Uri(Application.StartupPath + "\\Sounds\\Click.wav"));
            clickSound.Play();
        }

        private void usernameLabel_Click(object sender, EventArgs e)
        {
            usernameTB.Focus();
            usernameSelected = true;
            passSelected = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            usernameTB.Focus();
            usernameSelected = true;
            passSelected = false;
        }

        private void usernameTB_Click(object sender, EventArgs e)
        {
            usernameSelected = true;
            passSelected = false;
        }

        private void passLabel_Click(object sender, EventArgs e)
        {
            passTB.Focus();
            passSelected = true;
            usernameSelected = false;
        }

        private void usernameTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameTB_TextChanged_1(object sender, EventArgs e)
        {
            if (usernameTB.Text == "")
            {
                signInButton.Enabled = false;
                newUserButton.Enabled = false;
            }
            else if (passTB.Text == "")
            {
                signInButton.Enabled = false;
                newUserButton.Enabled = false;
            }
            else
            {
                signInButton.Enabled = true;
                newUserButton.Enabled = true;
            }
            
        }

        private void lastLabel_Click(object sender, EventArgs e)
        {

        }
    }




    public class User
    {
        int coins;
        int snakeScore;
        String pongScore;
        int tetrisScore;
        int asteroidsScore;
        int marioScore;
        String username;
        String password;


        public User(String inName, String inPass)
        {
            coins = 0;
            snakeScore = 0;
            tetrisScore = 0;
            asteroidsScore = 0;
            username = inName;
            password = inPass;
        }

        public User(String inName, String inPass, int inCoins, int inSnake, String inPong, int inTetris, int inAst, int mario)
        {
            coins = inCoins;
            snakeScore = inSnake;
            pongScore = inPong;
            tetrisScore = inTetris;
            asteroidsScore = inAst;
            marioScore = mario;
            username = inName;
            password = inPass;
        }


        public void updateUser()
        {
            StreamReader reader = new StreamReader("CurrentUser.txt");

            username = reader.ReadLine();
            password = reader.ReadLine();
            coins = int.Parse(reader.ReadLine());
            snakeScore = int.Parse(reader.ReadLine());
            pongScore = reader.ReadLine();
            tetrisScore = int.Parse(reader.ReadLine());
            asteroidsScore = int.Parse(reader.ReadLine());
            marioScore = int.Parse(reader.ReadLine());
            reader.Close();
        }


        public void updateFile()
        {
            StreamWriter writer1 = new StreamWriter("CurrentUser.txt");
            writer1.Close();

            StreamWriter writer = new StreamWriter("CurrentUser.txt");

            writer.WriteLine(username);
            writer.WriteLine(password);
            writer.WriteLine(coins);
            writer.WriteLine(snakeScore);
            writer.WriteLine(pongScore);
            writer.WriteLine(tetrisScore);
            writer.WriteLine(asteroidsScore);
            writer.WriteLine(marioScore);
            writer.Close();
        }

        public String getName()
        {
            return username;
        }

        public String getPass()
        {
            return password;
        }

        public int getCoins()
        {
            return coins;
        }
        public void setCoins(int amount)
        {
            coins = amount;
        }

        public void addCoins(int amount)
        {
            coins += amount;
        }

        public void removeCoins(int amount)
        {
            coins -= amount;
        }


        public int getSnakeScore()
        {
            return snakeScore;
        }

        public void setSnakeScore(int amount)
        {
            snakeScore = amount;
        }

        public String getPongScore()
        {

            return pongScore;
        }

        public Double getPongScore(int i)
        {
            String strScore = getPongScore();
            String userStrScore = "";
            String compStrScore = "";
            bool afterDash = false;
            foreach (Char ch in strScore)
            {
                if (ch == '-')
                    afterDash = true;
                else if (!afterDash)
                {
                    userStrScore += ch;
                }
                else
                {
                    compStrScore += ch;
                }
            }
            double score = (double)int.Parse(userStrScore) / (double)int.Parse(compStrScore);
            return score;
        }

        public void setPongScore(String amount)
        {
            pongScore = amount;
        }

        public int getTetrisScore()
        {
            return tetrisScore;
        }

        public void setTetrisScore(int amount)
        {
            tetrisScore = amount;
        }

        public int getAstScore()
        {
            return asteroidsScore;
        }

        public void setAstScore(int amount)
        {
            asteroidsScore = amount;
        }

        public int getMarioScore()
        {
            return marioScore;
        }

        public void setMarioScore(int amount)
        {
            marioScore = amount;
        }
    }
}
