using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Media;
using System.IO;
using System.Windows.Media;

namespace Senior_Project
{
    public partial class Asteroids : Form
    {
        int direction = 0;

        List<Keys> keysDown = new List<Keys>();

        // alive asteroids
        List<Asteroid> asteroids = new List<Asteroid>();

        // alive bullets
        List<Bullet> bullets = new List<Bullet>();

        // enemy bullets
        List<Bullet> enemyBullets = new List<Bullet>();

        // timer for the time since the last shot, used to delay time between shots
        Stopwatch stopSinceLastSpace = new Stopwatch();

        // stopwatch for spawning the ufp
        Stopwatch ufoWatch = new Stopwatch();

        int ufoDirection = 80;

        bool closedForm = false;

        Image currentShipImage = Properties.Resources.Transparent_Ship;
        int points = 0;
        int lives = 3;
        Stopwatch death = new Stopwatch();
        bool dead = false;

        List<int> directions = new List<int>();
        List<int> directionSpeeds = new List<int>();
        Random rand = new Random();

        bool firstKeyPressed = false;
        bool paused = false;
        public bool gameDone = false;

        public User player;

        bool getCoins = false;

        public Asteroids(User user)
        {
            InitializeComponent();


            player = user;
        }





        private void Asteroids_KeyDown(object sender, KeyEventArgs e)
        {
            if (!firstKeyPressed)
            {
                titleLabel.Visible = false;
                instructionsLabel.Visible = false;
                playLabel.Visible = false;

                firstKeyPressed = true;

                ufoWatch.Start();

                for (int i = 0; i < 4; i++)
                {
                    asteroids.Add(new Asteroid(2, 3));
                    this.Controls.Add(asteroids[i].picturebox);
                }


                // spawn the asteroids - spawn on left if direction is right, spawn up if direction is down
                foreach (Asteroid asteroid in asteroids)
                {
                    while (getDistance(asteroid.picturebox.Location, new Point(560, 246)) < 300)
                    {
                        for (int i = 0; i < rand.Next(5, 15); i++)
                            asteroid.picturebox.Location = new Point(rand.Next(0, 1000), rand.Next(0, 550));
                    }
                    asteroid.direction = rand.Next(0, 160);
                }

                stopSinceLastSpace.Start();

                moveSpaceShip.RunWorkerAsync();
                whileKey.RunWorkerAsync();
                moveAsteroids.RunWorkerAsync();
                checkCollision.RunWorkerAsync();
                moveBullets.RunWorkerAsync();
                spawnShip.RunWorkerAsync();
                ufoWorker.RunWorkerAsync();

            }
            else if (e.KeyCode == Keys.Escape)
            {
                paused = true;
                beforePause = shipPB.Location;
                pauseMenu.Width = 480;
                pauseMenu.Height = 414;
                pauseMenu.Location = new Point(349, 120);
                shipPB.Location = new Point(2000, 2000);
                titleLabel.Visible = true;
                pauseMenu.Visible = true;
            }
            // user can't input if they're dead
            else if (!dead)
            {
                if (e.KeyCode == Keys.ShiftKey)
                    shipPB.Location = new Point(rand.Next(0, 1100), rand.Next(0, 500));
                else if (!keysDown.Contains(e.KeyCode))
                    keysDown.Add(e.KeyCode);
            }
        }

        Point beforePause;








        private Image rotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }











        private void Asteroids_Paint(object sender, PaintEventArgs e)
        {
        }


        private void Asteroids_KeyPress(object sender, KeyPressEventArgs e)
        {
        }






        private void moveSpaceShip_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!closedForm)
            {
                while (!paused)
                {
                    moveSpaceShip.ReportProgress(1);
                    Thread.Sleep(50);
                }
            }
            moveSpaceShip.CancelAsync();
        }









        private void moveSpaceShip_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!dead)
                moveForward();
        }





        private void moveForward()
        {
            Point point = shipPB.Location;
            for (int i = 0; i < directions.Count(); i++)
            {
                // y = cos of the angle, x = sin of the angle                                                                                                                                            
                double xMove = Math.Cos(directions[i] * Math.PI / 80);
                double yMove = Math.Sin(directions[i] * Math.PI / 80);

                point = new Point(point.X + (int)(xMove * directionSpeeds[i]), point.Y + (int)(yMove * directionSpeeds[i]));

                if (!keysDown.Contains(Keys.Up) && !keysDown.Contains(Keys.W))
                    directionSpeeds[i] -= 1;

                if (directionSpeeds[i] <= 0)
                {
                    directions.Remove(directions[i]);
                    directionSpeeds.Remove(directionSpeeds[i]);
                }
            }

            shipPB.Location = point;

            if (shipPB.Location.Y < -25)
                shipPB.Location = new Point(shipPB.Location.X, 570);
            if (shipPB.Location.Y > 570)
                shipPB.Location = new Point(shipPB.Location.X, -25);
            if (shipPB.Location.X < -25)
                shipPB.Location = new Point(1190, shipPB.Location.Y);
            if (shipPB.Location.X > 1190)
                shipPB.Location = new Point(-25, shipPB.Location.Y);
        }

        private void moveForward(PictureBox pBox, int dir, int speed)
        {
            Point point = pBox.Location;

            // y = cos of the angle, x = sin of the angle                                                                                                                                            
            double xMove = Math.Cos(dir * Math.PI / 80);
            double yMove = Math.Sin(dir * Math.PI / 80);

            point = new Point(point.X + (int)(xMove * speed), point.Y + (int)(yMove * speed));

            pBox.Location = point;

            if (pBox.Location.Y < -25)
                pBox.Location = new Point(pBox.Location.X, 570);
            if (pBox.Location.Y > 570)
                pBox.Location = new Point(pBox.Location.X, -25);
            if (pBox.Location.X < -25)
                pBox.Location = new Point(1190, pBox.Location.Y);
            if (pBox.Location.X > 1190)
                pBox.Location = new Point(-25, pBox.Location.Y);
        }









        private void Asteroids_KeyUp(object sender, KeyEventArgs e)
        {
            keysDown.Remove(e.KeyCode);
        }


        Stopwatch ufoLife = new Stopwatch();


        private void whileKey_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!ufo.Visible)
            {
                if (ufoWatch.ElapsedMilliseconds > 60000)
                {
                    // make the ufo alive
                    ufo.Visible = true;
                    ufoDirection = rand.Next(0, 160);

                    // randomly get where its going to spawn of the screen
                    // if going to spawn of screen on the x
                    if (rand.Next(0, 2) == 0)
                    {
                        // if going to spawn off to the left
                        if (rand.Next(0, 2) == 0)
                            ufo.Location = new Point(0, rand.Next(0, 500));
                        else
                            ufo.Location = new Point(1130, rand.Next(0, 500));
                    }
                    else
                    {
                        // if going to spawn up top
                        if (rand.Next(0, 2) == 0)
                            ufo.Location = new Point(rand.Next(0, 1130), 0);
                        else
                            ufo.Location = new Point(rand.Next(0, 1130), 530);
                    }
                        

                    ufoLife.Start();
                }

            }

            if (!dead)
            {
                if (keysDown.Contains(Keys.W) || keysDown.Contains(Keys.Up))
                {

                    // if the ship isn't already going this direction, add this one to the list
                    if (!directions.Contains(direction))
                    {
                        directions.Add(direction);
                        directionSpeeds.Add(1);
                    }
                    // if the ship has this direction, just add speed to it as long as it's not maxed
                    else if (directionSpeeds[directions.IndexOf(direction)] < 35)
                        directionSpeeds[directions.IndexOf(direction)]++;
                }


                if (keysDown.Contains(Keys.Left) || keysDown.Contains(Keys.A))
                {
                    direction -= 4; shipPB.Image = rotateImage(currentShipImage, (float)(direction * 2.25));
                }

                if (keysDown.Contains(Keys.Right) || keysDown.Contains(Keys.D))
                {
                    direction += 4; shipPB.Image = rotateImage(currentShipImage, (float)(direction * 2.25));
                }
                if (direction == -160 || direction == 160)
                    direction = 0;

                if (keysDown.Contains(Keys.Space))
                    shoot();
            }
        }








        private void shoot()
        {
            if (stopSinceLastSpace.ElapsedMilliseconds > 300)
            {
                //SoundPlayer shoot = new SoundPlayer(Properties.Resources.Pew_Sound_Effect);
                //shoot.Play();
                Bullet bullet = new Bullet(direction, new Point(shipPB.Location.X + (shipPB.Width / 2), shipPB.Location.Y + (shipPB.Height / 2)));
                bullets.Add(bullet);
                this.Controls.Add(bullet.picturebox);
                stopSinceLastSpace.Restart();
            }

        }







        private void whileKey_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!closedForm)
            {
                while (!paused)
                {
                    if (keysDown.Count > 0)
                        whileKey.ReportProgress(1);

                    Thread.Sleep(30);
                }
            }
            whileKey.CancelAsync();
        }





        private void moveAsteroids_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!closedForm)
            {
                while (!paused)
                {
                    moveAsteroids.ReportProgress(1);
                    Thread.Sleep(20);
                }
            }
            moveAsteroids.CancelAsync();
        }





        private void moveAsteroids_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            for (int i = 0; i < asteroids.Count(); i++)
            {
                asteroids[i].moveForward();
            }
        }




        private void checkCollision_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!closedForm)
            {
                while (!paused)
                {
                    checkCollision.ReportProgress(1);
                    Thread.Sleep(100);
                }
            }
            checkCollision.CancelAsync();
        }




        int i = 0;

        private void checkCollision_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!dead)
            {
                List<Asteroid> removeAst = new List<Asteroid>();
                foreach (Asteroid asteroid in asteroids)
                {
                    Point astLoc = asteroid.picturebox.Location;
                    Point shipLoc = shipPB.Location;

                    // if the top left corner if the ship is inside the asteroid
                    if (shipLoc.X > astLoc.X && shipLoc.X < astLoc.X + asteroid.picturebox.Width && shipLoc.Y > astLoc.Y && shipLoc.Y < astLoc.Y + asteroid.picturebox.Height)
                    {
                        collided();
                        removeAst.Add(asteroid);
                    }


                    // change the point to the top right
                    shipLoc = new Point(shipPB.Location.X + shipPB.Width, shipPB.Location.Y);
                    if (shipLoc.X > astLoc.X && shipLoc.X < astLoc.X + asteroid.picturebox.Width && shipLoc.Y > astLoc.Y && shipLoc.Y < astLoc.Y + asteroid.picturebox.Height)
                    {
                        collided();
                        removeAst.Add(asteroid);
                    }

                    // change the point to the bottom left
                    shipLoc = new Point(shipPB.Location.X, shipPB.Location.Y + shipPB.Height);
                    if (shipLoc.X > astLoc.X && shipLoc.X < astLoc.X + asteroid.picturebox.Width && shipLoc.Y > astLoc.Y && shipLoc.Y < astLoc.Y + asteroid.picturebox.Height)
                    {
                        collided();
                        removeAst.Add(asteroid);
                    }
                    // change the point to the bottom right
                    shipLoc = new Point(shipPB.Location.X + shipPB.Width, shipPB.Location.Y + shipPB.Height);
                    if (shipLoc.X > astLoc.X && shipLoc.X < astLoc.X + asteroid.picturebox.Width && shipLoc.Y > astLoc.Y && shipLoc.Y < astLoc.Y + asteroid.picturebox.Height)
                    {
                        collided();
                        removeAst.Add(asteroid);
                    }

                    // check if collided with the ufo
                    shipLoc = new Point(ufo.Location.X + ufo.Width, ufo.Location.Y + ufo.Height);
                    if (shipLoc.X > astLoc.X && shipLoc.X < astLoc.X + asteroid.picturebox.Width && shipLoc.Y > astLoc.Y && shipLoc.Y < astLoc.Y + asteroid.picturebox.Height)
                    {
                        ufo.Visible = false;
                        removeAst.Add(asteroid);
                    }

                    if (astLoc.X > shipLoc.X && astLoc.X < shipLoc.X + shipPB.Width && astLoc.Y > shipLoc.Y && astLoc.Y < shipLoc.Y + shipPB.Height)
                    {
                        ufo.Visible = false;
                        removeAst.Add(asteroid);
                    }
                }

                foreach (Asteroid asteroid in removeAst)
                {
                    breakAst(asteroid);
                }
            }
        }


        MediaPlayer deadSound = new MediaPlayer();
        //SoundPlayer deadSound = new SoundPlayer(Properties.Resources.Videogame_Death_Sound_Effect_HD__No_Copyright);

        private void collided()
        {
            if (!dead)
            {
                directions.Clear();
                directionSpeeds.Clear();
                enemyBullets.Clear();
                // indicate that the ship's currently dead
                dead = true;

                if (!closedForm)
                {
                    deadSound.Open(new Uri(Application.StartupPath + "\\Sounds\\Videogame Death Sound Effect HD  No Copyright.wav"));
                    deadSound.Play();
                }

                // reset and start the timer for how long the ship's been dead
                death.Restart();

                // change the ship
                shipPB.Image = Properties.Resources.Transparent_Ship;
                currentShipImage = Properties.Resources.Transparent_Ship;

                // remove the lives from the screen depending on how many the user has left, start from the right
                switch (lives)
                {
                    case (3): life3.Visible = false; break;
                    case (2): life2.Visible = false; break;
                    case (1): life1.Visible = false; break;
                }

                // subtract the amount of lives left
                lives--;
            }
            if (lives < 0)
            {
                deadPointsLabel.Text = points.ToString();
                deadGB.Visible = true;
                deadGB.Location = new Point(0, -5);
                deadGB.Width = 1180;
                deadGB.Height = 549;
                deadGB.BringToFront();

                if (player.getCoins() >= 50)
                    minigameButton.Enabled = true;
                else
                    minigameButton.Enabled = false;
            }

        }



        private int getDistance(PictureBox pbox1, PictureBox pbox2)
        {
            int distance = 0;

            // distance = |x1-x2| + |y1-y2|
            distance = Math.Abs(pbox1.Location.X - pbox2.Location.X) + Math.Abs(pbox1.Location.Y - pbox2.Location.Y);

            return distance;
        }


        private int getDistance(Point point1, Point point2)
        {
            int distance = 0;

            // distance = |x1-x2| + |y1-y2|
            distance = Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y);

            return distance;
        }





        private void moveBullets_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!closedForm)
            {
                while (!paused)
                {
                    moveBullets.ReportProgress(1);
                    Thread.Sleep(20);
                }
            }
            moveBullets.CancelAsync();
        }





        private void moveBullets_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // list of bullets that need to be removed
            // used to remove bullets after the loop, can't change bullet list during loop
            List<Bullet> removeBullets = new List<Bullet>();

            foreach (Bullet bullet in bullets)
            {
                // move the bullet forward
                bullet.moveForward();

                // checks if the bullet hit an asteroid, breaks the asteroid if true
                if (hitAsteroid(bullet))
                {
                    removeBullets.Add(bullet);
                }

                // if the bullets been alive for more than a second, remove it from the array
                if (bullet.life.ElapsedMilliseconds > 1500)
                    removeBullets.Add(bullet);
            }

            foreach (Bullet bullet in removeBullets)
            {
                // remove the bullet from the list of alive bullets and make it invisible
                bullets.Remove(bullet);
                bullet.picturebox.Visible = false;
            }

            removeBullets.Clear();

            foreach (Bullet bullet in enemyBullets)
            {
                // move the bullet forward
                bullet.moveForward();

                // checks if the bullet hit the ship
                if (hitShip(bullet))
                {
                    collided();
                    break;
                }

                if (bullet.life.ElapsedMilliseconds > 1500)
                    removeBullets.Add(bullet);
            }

            foreach (Bullet bullet in removeBullets)
            {
                // remove the bullet from the list of alive bullets and make it invisible
                enemyBullets.Remove(bullet);
                bullet.picturebox.Visible = false;
            }
        }


        private bool hitShip(Bullet bullet)
        {
            Point bulletLoc = bullet.picturebox.Location;
            Point shipLoc = shipPB.Location;

            if (bulletLoc.X >= shipLoc.X && bulletLoc.X <= shipLoc.X + shipPB.Width &&
                    bulletLoc.Y >= shipLoc.Y && bulletLoc.Y <= shipLoc.Y + shipPB.Height)
                return true;
            return false;

        }


        private bool hitAsteroid(Bullet bullet)
        {
            // get the location of the picturebox of the bullet
            Point bulletLoc = bullet.picturebox.Location;

            // list for the asteroids that have to be broken
            List<Asteroid> toBreak = new List<Asteroid>();

            // go to each asteroid
            foreach (Asteroid asteroid in asteroids)
            {
                // get the location of the picturebox of the asteroid
                Point astLoc = asteroid.picturebox.Location;

                // if the bullet's inside of the asteroid, add it to the list to be broken
                if (bulletLoc.X >= astLoc.X && bulletLoc.X <= astLoc.X + asteroid.picturebox.Width &&
                    bulletLoc.Y >= astLoc.Y && bulletLoc.Y <= astLoc.Y + asteroid.picturebox.Height)
                    toBreak.Add(asteroid);
            }

            // bool for if there was an asteroid hit
            bool retBool = false;

            // if there's at least one asteroid in the list to break, change the variable to true
            if (toBreak.Count > 0)
                retBool = true;

            // break all the asteroids in the break list
            foreach (Asteroid asteroid in toBreak)
                breakAst(asteroid);

            // return the bool of if an asteroid was hit
            return retBool;
        }

        private void increaseScore(int increase)
        {
            for (int i = 0; i < increase; i++)
            {
                points++;

                if (points % 10000 == 0)
                {
                    if (lives < 3)
                        lives++;
                    if (lives == 1)
                        life1.Visible = true;
                    if (lives == 2)
                        life2.Visible = true;
                    if (lives == 3)
                        life3.Visible = true;
                }
            }
        }
        
        Stopwatch timeSinceLastBreak = new Stopwatch();
        bool firstBreak = true;
        private void breakAst(Asteroid asteroid)
        {
            if ((!dead && !closedForm) || firstBreak)
            {
                MediaPlayer lossSound = new MediaPlayer();
                lossSound.Open(new Uri(Application.StartupPath + "\\Sounds\\mixkit-explainer-video-game-alert-sweep-236.wav"));
                lossSound.Play();
                timeSinceLastBreak.Restart();
            }

            if (firstBreak)
            {
                firstBreak = false;
                timeSinceLastBreak.Start();
            }


            // subtract the health
            asteroid.health -= 1;

            // increase speed of the asteroid since it got smaller
            asteroid.speed+= rand.Next(0, 3);

            // if the asteroid hit is now a medium asteroid
            if (asteroid.health == 2)
            {
                // increase the user's score by 20
                increaseScore(20);
                pointsLabel.Text = points.ToString();

                // make this asteroid smaller
                asteroid.picturebox.Width = 70;
                asteroid.picturebox.Height = 70;

                // change the image
                asteroid.picturebox.Image = Properties.Resources.Medium_Asteroid;
            }

            // if the asteroid hit is now a small asteroid
            if (asteroid.health == 1)
            {
                // increase the points by 50
                increaseScore(50);
                pointsLabel.Text = points.ToString();

                // make this asteroid smaller
                asteroid.picturebox.Width = 35;
                asteroid.picturebox.Height = 35;

                // change the image
                asteroid.picturebox.Image = Properties.Resources.Small_Asteroid;
            }

            // if the asteroid hit is dead now
            if (asteroid.health == 0)
            {
                // increase the points by 100
                increaseScore(100);
                pointsLabel.Text = points.ToString();

                // this asteroid is dead, so remove it from the list of living ones
                asteroids.Remove(asteroid);

                // make this asteroid invisible
                asteroid.picturebox.Visible = false;
            }
            else
            {
                // make a new asteroid, same as this one
                Asteroid asteroid2 = new Asteroid(asteroid.speed, asteroid.health);
                asteroid2.picturebox.Location = new Point(asteroid.picturebox.Location.X + 10, asteroid.picturebox.Location.Y + 10);

                // add the new asteroid to the array
                asteroids.Add(asteroid2);


                // set random directions for the existing and new asteroid
                asteroid.direction = rand.Next(0, 160);

                // loop until the two asteroids have different directions
                for (int i = 0; i < 5; i++)
                {
                    asteroid2.direction = rand.Next(0, 160);
                }

                // add the second asteroid to the screen
                this.Controls.Add(asteroid2.picturebox);
            }

            // if there are no asteroids left
            if (asteroids.Count < 1)
            {
                round++;
                // spawn in new asteroids
                for (int i = 0; i < 4 + round / 5; i++)
                {
                    asteroids.Add(new Asteroid(2, 3));
                    this.Controls.Add(asteroids[i].picturebox);
                }


                // spawn the asteroids - spawn on left if direction is right, spawn up if direction is down
                foreach (Asteroid newAst in asteroids)
                {
                    while (getDistance(newAst.picturebox.Location, shipPB.Location) < 300)
                    {
                        for (int i = 0; i < rand.Next(5, 15); i++)
                            newAst.picturebox.Location = new Point(rand.Next(0, 1000), rand.Next(0, 550));
                    }
                    newAst.direction = rand.Next(0, 160);
                }
            }

        }
        int round = 0;

        bool tryingToSpawn = false;

        private void spawnShip_DoWork(object sender, DoWorkEventArgs e)
        {


            while (!closedForm)
            {
                while (lives >= 0)
                {
                    if (dead && death.ElapsedMilliseconds > 1500)
                    {
                        // bool for if it's safe for the ship to spawn
                        bool canSpawn = false;

                        while (!canSpawn)
                        {
                            canSpawn = true;
                            // go to each living asteroid
                            foreach (Asteroid asteroid in asteroids)
                            {
                                // if the asteroid is within 250 of the ship, it's not safe for the ship to spawn
                                if (getDistance(asteroid.picturebox.Location, new Point(560, 246)) < 150)
                                    canSpawn = false;
                            }
                        }
                        spawnShip.ReportProgress(1);
                    }
                    Thread.Sleep(30);
                }
            }
            spawnShip.CancelAsync();
        }


        private void spawnShip_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            shipPB.Location = new Point(560, 246);
            dead = false;
            direction = 0;
            currentShipImage = Properties.Resources.Transparent_Ship;
            shipPB.Image = Properties.Resources.Transparent_Ship;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (points > player.getAstScore())
                player.setAstScore(points);

            player.updateFile();

            player.addCoins(points / 1000);
            getCoins = true;
            gameDone = true;
            this.Close();
            return;
        }

        private void againButton_Click(object sender, EventArgs e)
        {
            if (points > player.getAstScore())
                player.setAstScore(points);

            player.addCoins(points / 1000);
            getCoins = false;

            restart();
        }

        private void restart()
        {
            ufoWatch.Restart();
            direction = 0;
            paused = false;

            keysDown.Clear();
            shipPB.Location = new Point(561, 253);

            foreach (Asteroid asteroid in asteroids)
                asteroid.picturebox.Visible = false;
            asteroids.Clear();



            life1.Visible = true;
            life2.Visible = true;
            life3.Visible = true;
            lives = 3;

            bullets.Clear();
            currentShipImage = Properties.Resources.Transparent_Ship;
            shipPB.Image = Properties.Resources.Transparent_Ship;
            points = 0;

            dead = false;

            directions.Clear();
            directionSpeeds.Clear();

            for (int i = 0; i < 5; i++)
            {
                asteroids.Add(new Asteroid(2, 3));
                this.Controls.Add(asteroids[i].picturebox);
            }


            // spawn the asteroids - spawn on left if direction is right, spawn up if direction is down
            foreach (Asteroid asteroid in asteroids)
            {
                while (getDistance(asteroid.picturebox.Location, new Point(560, 246)) < 150)
                    asteroid.picturebox.Location = new Point(rand.Next(0, 1000), rand.Next(0, 550));
                asteroid.direction = rand.Next(0, 160);
            }

            stopSinceLastSpace.Start();

            deadGB.Visible = false;
            pauseMenu.Visible = false;
            Asteroids.ActiveForm.Focus();
        }

        private void ufoWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            lastShot.Start();
            while (!closedForm)
            {
                while (!paused)
                {
                    ufoWorker.ReportProgress(1);
                    Thread.Sleep(15);
                }
            }
            ufoWorker.CancelAsync();
        }
        Stopwatch lastShot = new Stopwatch();
        private void ufoWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // if the ufo is visible, it's alive
            if (ufo.Visible)
            {
                if (ufoLife.ElapsedMilliseconds > 10000)
                {
                    ufo.Visible = false;
                    ufoWatch.Restart();
                }
                else
                {
                    // move the ship
                    moveForward(ufo, ufoDirection, 5);

                    // shoot at the ship
                    if (lastShot.ElapsedMilliseconds > 1000)
                    {
                        Bullet bullet = new Bullet(123456789, ((shipPB.Location.X + (shipPB.Width / 2)) - ufo.Location.X),
                            ((shipPB.Location.Y + (shipPB.Height / 2)) - ufo.Location.Y),
                            new Point(ufo.Location.X + (ufo.Width / 2), ufo.Location.Y + (ufo.Height / 2)), round);

                        enemyBullets.Add(bullet);
                        this.Controls.Add(bullet.picturebox);
                        lastShot.Restart();
                    }
                }
                
            }
        }

        private void pausePlayButton_Click(object sender, EventArgs e)
        {
            paused = false;
            pauseMenu.Visible = false;
            shipPB.Location = beforePause;
            titleLabel.Visible = false;
            Asteroids.ActiveForm.Focus();
        }

        private void pauseExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            restart();
        }

        private void controlsButton_Click(object sender, EventArgs e)
        {
            instLabel.Visible = true;
            closeButton.Visible = true;
            instLabel.BringToFront();
            closeButton.BringToFront();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            instLabel.Visible = false;
            htpLabel.Visible = false;
            closeButton.Visible = false;
        }

        private void howPlayButton_Click(object sender, EventArgs e)
        {
            htpLabel.Visible = true;
            closeButton.Visible = true;
            htpLabel.BringToFront();
            closeButton.BringToFront();
        }

        private void minigameButton_Click(object sender, EventArgs e)
        {
            player.removeCoins(50);

            Stacker stacker = new Stacker();
            stacker.ShowDialog();

            while (stacker.stillPlaying)
            { 
            
            }

            if (stacker.won)
            {
                deadGB.Visible = false;

                ufoWatch.Restart();
                direction = 0;
                paused = false;

                keysDown.Clear();
                shipPB.Location = new Point(561, 253);

                foreach (Asteroid asteroid in asteroids)
                    asteroid.picturebox.Visible = false;

                life1.Visible = true;
                life2.Visible = true;
                life3.Visible = true;

                asteroids.Clear();

                bullets.Clear();
                currentShipImage = Properties.Resources.Transparent_Ship;
                shipPB.Image = Properties.Resources.Transparent_Ship;
                lives = 3;
                dead = false;

                directions.Clear();
                directionSpeeds.Clear();

                for (int i = 0; i < 5; i++)
                {
                    asteroids.Add(new Asteroid(2, 3));
                    this.Controls.Add(asteroids[i].picturebox);
                }


                // spawn the asteroids - spawn on left if direction is right, spawn up if direction is down
                foreach (Asteroid asteroid in asteroids)
                {
                    while (getDistance(asteroid.picturebox.Location, new Point(560, 246)) < 150)
                        asteroid.picturebox.Location = new Point(rand.Next(0, 1000), rand.Next(0, 550));
                    asteroid.direction = rand.Next(0, 160);
                }

                stopSinceLastSpace.Start();

                deadGB.Visible = false;
                pauseMenu.Visible = false;
                Asteroids.ActiveForm.Focus();

            }
            else
            {
                minigameButton.Enabled = false;
            }
        }

        private void Asteroids_FormClosed(object sender, FormClosedEventArgs e)
        {
            // update the file that keeps track of the current user
            player.updateFile();


            // update the user's stats to that file
            player.updateUser();

            Dispose();
        }

        private void minigameButton_MouseHover(object sender, EventArgs e)
        {
            continueLabel.Visible = true;
        }

        private void againButton_MouseHover(object sender, EventArgs e)
        {
            playAgainLabel.Visible = true;
        }

        private void minigameButton_MouseLeave(object sender, EventArgs e)
        {
            continueLabel.Visible = false;
        }

        private void againButton_MouseLeave(object sender, EventArgs e)
        {
            playAgainLabel.Visible = false;
        }

        private void colorPickerPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void colorSelectorButton_Click(object sender, EventArgs e)
        {
            if (colorDia.ShowDialog() != DialogResult.OK)
                return;

            exampleShipPB.BackColor = colorDia.Color;

        }

        private void exitSaveButton_Click(object sender, EventArgs e)
        {
            shipPB.BackColor = colorDia.Color;
            colorPickerPanel.Visible = false;
            Asteroids.ActiveForm.Focus();
        }

        // EXIT WITHOUT SAVING BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            colorPickerPanel.Visible = false;
            Asteroids.ActiveForm.Focus();
        }

        private void changeShipColorButton_Click_1(object sender, EventArgs e)
        {
            colorPickerPanel.Size = new Size(1179, 546);
            colorPickerPanel.Location = new Point(0, 0);
            colorPickerPanel.Visible = true;

        }
    }




    public class Asteroid
    {
        public PictureBox picturebox;
        public int direction;
        public int speed;
        public int health;
        Random rand = new Random();

        public Asteroid()
        {
        }

        public Asteroid(int inSpeed, int inHealth)
        {
            
            // 3 = full, 2 = medium, 1 = small, 0 = dead
            health = inHealth;
            speed = inSpeed;
            picturebox = new PictureBox();

            int size = 0;

            switch (health)
            {
                case (3): size = 120;break;
                case (2): size = 70; break;
                case (1): size = 35; break;
            }
            picturebox.Width = size;
            picturebox.Height = size;
            picturebox.Visible = true;
            picturebox.Image = Properties.Resources.Big_Asteroid;
            picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            for (int i = 0; i < rand.Next(5, 15); i++)
                picturebox.Location = new Point(rand.Next(0, 585), rand.Next(0, 1195));

            direction = 40;
            while (direction % 40 <= 5)
            {
                direction = rand.Next(0, 160);
            }

            // if the asteroid hit is now a medium asteroid
            if (health == 2)
            {
                // make this asteroid smaller
                picturebox.Width = 70;
                picturebox.Height = 70;

                // change the image
                picturebox.Image = Properties.Resources.Medium_Asteroid;
            }

            // if the asteroid hit is now a small asteroid
            if (health == 1)
            {
                // make this asteroid smaller
                picturebox.Width = 35;
                picturebox.Height = 35;

                // change the image
                picturebox.Image = Properties.Resources.Small_Asteroid;
            }
            picturebox.BringToFront();
        }

        public void moveForward()
        {
            // y = cos of the angle, x = sin of the angle                                                                                                                                            
            double xMove = Math.Cos(direction * Math.PI / 80);
            double yMove = Math.Sin(direction * Math.PI / 80);

            picturebox.Location = new Point(picturebox.Location.X + (int)(xMove * speed), picturebox.Location.Y + (int)(yMove * speed));

            if (picturebox.Location.Y < -25)
                picturebox.Location = new Point(picturebox.Location.X, 500);
            if (picturebox.Location.Y > 500)
                picturebox.Location = new Point(picturebox.Location.X, -25);
            if (picturebox.Location.X < -25)
                picturebox.Location = new Point(1150, picturebox.Location.Y);
            if (picturebox.Location.X > 1150)
                picturebox.Location = new Point(-25, picturebox.Location.Y);
        }
    }






    public class Bullet
    {
        public int direction;
        public PictureBox picturebox = new PictureBox();
        public Stopwatch life = new Stopwatch();
        int xDif;
        int yDif;
        Random rand = new Random();


        public Bullet(int dir, Point location)
        {
            direction = dir;
            xDif = 123456789;
            yDif = 123456789;
            picturebox.Width = 5;
            picturebox.Height = 5;
            picturebox.Image = Properties.Resources.Bullet;
            picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            picturebox.Location = location;
            picturebox.Visible = true;
            life.Start();
        }

        public Bullet(int dir, int inXDif, int inYDif, Point location, int round)
        {
            if (rand.Next(0, 2) == 0)
                xDif = inXDif + rand.Next(0, 100) - round * 2;
            else
                xDif = inXDif - rand.Next(0, 100) - round * 2;

            if (rand.Next(0, 2) == 0)
                yDif = inYDif + rand.Next(0, 100) - round * 2;
            else
                yDif = inYDif - rand.Next(0, 100) - round * 2;            

            direction = 123456789;
            picturebox.Width = 5;
            picturebox.Height = 5;
            picturebox.Image = Properties.Resources.Bullet;
            picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            picturebox.Location = location;
            picturebox.Visible = true;
            life.Start();
        }


        public void moveForward()
        {
            if (life.ElapsedMilliseconds < 1000)
            {
                if (direction == 123456789)
                {
                    picturebox.Location = new Point(picturebox.Location.X + (xDif / 25), picturebox.Location.Y + (yDif / 25));
                }
                else
                {
                    // y = cos of the angle, x = sin of the angle                                                                                                                                            
                    double xMove = Math.Cos(direction * Math.PI / 80);
                    double yMove = Math.Sin(direction * Math.PI / 80);

                    picturebox.Location = new Point(picturebox.Location.X + (int)(xMove * 20), picturebox.Location.Y + (int)(yMove * 20));
                }


                if (picturebox.Location.Y < -25)
                    picturebox.Location = new Point(picturebox.Location.X, 500);
                if (picturebox.Location.Y > 500)
                    picturebox.Location = new Point(picturebox.Location.X, -25);
                if (picturebox.Location.X < -25)
                    picturebox.Location = new Point(1190, picturebox.Location.Y);
                if (picturebox.Location.X > 1190)
                    picturebox.Location = new Point(-25, picturebox.Location.Y);

            }
            else
                picturebox.Visible = false;
        }

    }
}
