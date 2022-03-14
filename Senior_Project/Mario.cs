using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Senior_Project
{
    public partial class Mario : Form
    {
        // list of the currently held keys
        List<Keys> heldKeys = new List<Keys>();

        // array of the barriers
        PictureBox[] barriers = new PictureBox[10];

        // mario's vertical velocity
        double marioVelocity = 0;

        // boolean for if the player has landed after their jump yet
        bool sameJump = false;

        // bool for if it hit max vertical velocity
        bool maxVel = false;

        Random rand = new Random();

        // list of the goombas currently on the screen
        List<Goomba> goombas = new List<Goomba>();

        // List of the koopa troopas currently on the screen
        List<KoopaTroopa> koopas = new List<KoopaTroopa>();

        // list of the shells currently on the screen
        List<Shell> shells = new List<Shell>();

        // list of the enemies falling down
        List<Enemy> fallingEnemies = new List<Enemy>();

        // bool for if mario's holding a shell
        bool holdingShell = false;

        bool keepGoing = true;

        bool closedForm = false;

        String direction = "right";

        bool characterSelected = false;

        // int for the amount of enemies mario's killed
        int kills = 0;

        int formHeight = Mario.ActiveForm.Height;

        bool firstKey = true;

        MediaPlayer song = new MediaPlayer();//(Properties.Resources.Super_Mario_Bros__Theme_Song);
        MediaPlayer coinSound = new MediaPlayer();

        // list of the current coins being shown
        List<PictureBox> coinPBs = new List<PictureBox>();

        bool dead = false;

        int coins = 0;

        User player;

        bool thrownAlr = false;

        bool muted = false;

        Size formSize;

        // images for the character
        Image rightChar = Properties.Resources._223_2238299_mario_sprite_by_flamingdragon5000_mario_8_bit_png1;
        Image leftChar = Properties.Resources.Left_Mario;
        Image rightShellChar = Properties.Resources.Mario_with_shell;
        Image leftShellChar = Properties.Resources.Left_Mario_Shell;

        // Colors for the character selecter
        System.Drawing.Color hoverColor = System.Drawing.Color.FromArgb(253, 230, 136);
        System.Drawing.Color selectColor = System.Drawing.Color.FromArgb(251, 208, 40);

        public Mario(User player1)
        {
            InitializeComponent();
            formSize = Mario.ActiveForm.Size;

            song.Open(new Uri(Application.StartupPath + "\\Sounds\\Super Mario Bros. Theme Song.wav"));
            coinSound.Open(new Uri(Application.StartupPath + "\\Sounds\\MarioCoinSound.wav"));

            song.MediaEnded += new EventHandler(mediaEnded);

            player = player1;

            if (!muted)
                song.Play();

            // start the background worker that moves the objects
            movement.RunWorkerAsync();
            remover.RunWorkerAsync();

            // add the barriers to the barriers array
            barriers[0] = barrier1;
            barriers[1] = barrier2;
            barriers[2] = barrier3;
            barriers[3] = barrier3;
            barriers[4] = barrier4;
            barriers[5] = barrier4;
            barriers[6] = barrier4;
            barriers[7] = barrier4;
            barriers[8] = barrier5;
            barriers[9] = barrier6;

            for (int i = 0; i < 2; i++)
            {
                int box = 2;
                while (box == 2 || box == 3)
                    box = rand.Next(0, 8);

                Goomba goomba = new Goomba(barriers[i], Properties.Resources.d9nyjkq_6df1b499_1c92_4bd2_adce_78055faf40e01);
                int cntr = 0;
                while (distance(goomba.box, marioPB) < 100 || cntr > 5)
                {
                    goomba.box.Location = new Point(rand.Next(goomba.barrierBlock.Location.X + 1, goomba.barrierBlock.Location.X + goomba.barrierBlock.Width - goomba.box.Width - 1), goomba.barrierBlock.Location.Y - goomba.box.Height);
                    cntr++;
                }
                this.Controls.Add(goomba.box);
                goombas.Add(goomba);
                goomba.box.BringToFront();
            }

            for (int i = 0; i < 1; i++)
            {
                int box = 2;
                while (box == 2 || box == 3)
                    box = rand.Next(0, 8);

                KoopaTroopa koopa = new KoopaTroopa(barriers[5], Properties.Resources.Koopa);
                int cntr = 0;
                while (distance(koopa.box, marioPB) < 100 || cntr > 5)
                {
                    koopa.box.Location = new Point(rand.Next(koopa.barrierBlock.Location.X + 1, koopa.barrierBlock.Location.X + koopa.barrierBlock.Width - koopa.box.Width - 1), koopa.barrierBlock.Location.Y - koopa.box.Height);
                    cntr++;
                }
                    this.Controls.Add(koopa.box);
                koopas.Add(koopa);

                koopa.box.BringToFront();
            }
            marioPB.BringToFront();

        }

        private void mediaEnded(object sender, EventArgs e)
        {
            song.Open(new Uri(Application.StartupPath + "\\Super Mario Bros. Theme Song.wav"));
            song.Play();
        }

        private void makeCoin()
        {
            // make the picture box for the coin
            PictureBox coinBox = new PictureBox();
            coinBox.Size = new Size(75, 75);
            coinBox.SizeMode = PictureBoxSizeMode.AutoSize;
            coinBox.Image = Properties.Resources.CoinBlock;

            // randomly choose a barrier, can't be bottom one
            PictureBox barrierBox = barriers[rand.Next(0, 4)];

            // choose a random spot on the barrier to put the coin
            coinBox.Location = new Point(barrierBox.Location.X + rand.Next(0, barrierBox.Width / 75), barrierBox.Location.Y);

            // add this coin to the list
            coinPBs.Add(coinBox);

            // show the coin
            this.Controls.Add(coinBox);
            coinBox.BringToFront();
        }

        private void start()
        {
            charSelectPanel.Visible = false;
            firstKey = false;
            timer.Start();
            titlePB.Visible = false;
            instructionsPB.Visible = false;
            beginning.RunWorkerAsync();
            timerLabel.Visible = true;
        }


        private void Mario_KeyDown(object sender, KeyEventArgs e)
        {
            if (!characterSelected)
                return;

            if (firstKey)
                start();
            else
            {
                // if the key is space, w, or up arrow (jump), start the jump timer
                if (e.KeyCode == Keys.W || e.KeyCode == Keys.Space || e.KeyCode == Keys.Up)
                {
                    if (!sameJump)
                    {
                        marioVelocity = -20;
                        sameJump = true;
                    }
                    else if (!maxVel)
                    {
                        marioVelocity -= 5;
                    }

                    if (marioVelocity < -20)
                    {
                        maxVel = true;
                    }
                }

                if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                {
                    if (holdingShell)
                        marioPB.Image = leftShellChar;
                    else
                        marioPB.Image = leftChar;

                    direction = "left";
                }

                if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                {
                    if (holdingShell)
                        marioPB.Image = rightShellChar;
                    else
                        marioPB.Image = rightChar;

                    direction = "right";
                }


                if ((e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.E) && holdingShell)
                {
                    throwLabel.Visible = false;
                    throwShell();
                }
                else if (!heldKeys.Contains(e.KeyCode))
                    heldKeys.Add(e.KeyCode);
            }
        }

        private void Mario_KeyUp(object sender, KeyEventArgs e)
        {
            // when they key is lifted up, remove it from the held keys
            heldKeys.Remove(e.KeyCode);

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Space || e.KeyCode == Keys.Up)
                sameJump = true;
        }




        private void throwShell()
        {
            if (direction == "left")
            {
                Shell shell = new Shell(new Point(marioPB.Location.X - Properties.Resources.Koopa_Shell.Width - 1, marioPB.Location.Y + marioPB.Height - Properties.Resources.Koopa_Shell.Height), barriers);
                shell.direction = -10;
                shells.Add(shell);
                this.Controls.Add(shell.box);
                marioPB.Image = leftChar;
            }
            else
            {
                Shell shell = new Shell(new Point(marioPB.Location.X + marioPB.Width, marioPB.Location.Y + marioPB.Height - Properties.Resources.Koopa_Shell.Height), barriers);
                shell.direction = 10;
                shells.Add(shell);
                this.Controls.Add(shell.box);
                marioPB.Image = rightChar;
            }

            holdingShell = false;
        }

        private int distance(PictureBox box1, PictureBox box2)
        {
            return (Math.Abs(box1.Location.X - box2.Location.X)) + (Math.Abs(box1.Location.Y - box2.Location.Y));
        }


        private void increasedKills()
        {
            if (kills < 30)
            {
                if (kills % 10 == 0)
                {
                    KoopaTroopa koopa = new KoopaTroopa(barriers[rand.Next(0, 8)], Properties.Resources.Koopa);
                    int cntr = 0;
                    while (distance(koopa.box, marioPB) < 100 || cntr > 5)
                    {
                        koopa.box.Location = new Point(rand.Next(koopa.barrierBlock.Location.X + 1, koopa.barrierBlock.Location.X + koopa.barrierBlock.Width - koopa.box.Width - 1), koopa.barrierBlock.Location.Y - koopa.box.Height);
                        cntr++;
                    }
                    this.Controls.Add(koopa.box);
                    koopas.Add(koopa);
                }
                else if (kills % 5 == 0)
                {
                    Goomba goomba = new Goomba(barriers[rand.Next(0, 8)], Properties.Resources.d9nyjkq_6df1b499_1c92_4bd2_adce_78055faf40e01);

                    int cntr = 0;
                    while (distance(goomba.box, marioPB) < 100 || cntr < 5)
                    {
                        goomba.box.Location = new Point(rand.Next(goomba.barrierBlock.Location.X + 1, goomba.barrierBlock.Location.X + goomba.barrierBlock.Width - goomba.box.Width - 1), goomba.barrierBlock.Location.Y - goomba.box.Height);
                        cntr++;
                    }
                        this.Controls.Add(goomba.box);
                    goombas.Add(goomba);
                }
            }


            if (kills % 5 == 0)
                makeCoin();

        }
        private void movement_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!closedForm)
            {

                while (keepGoing)
                {

                    movement.ReportProgress(1);
                    Thread.Sleep(17);

                }


                while (!keepEnding)
                {
                    movement.ReportProgress(1);
                    Thread.Sleep(17);
                }
            }

            movement.CancelAsync();
        }

        private void movement_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!keepEnding && !keepGoing)
            {
                endMoveMario();
                return;
            }
            // move mario if the user is prssing a key that moves him
            if (!firstKey)
                moveMario();

            // move all the goombas
            foreach (Goomba goomba in goombas)
                goomba.move();

            // move all the koopa troopas
            foreach (KoopaTroopa koopa in koopas)
                koopa.move();

            foreach (Shell shell in shells)
            {
                shell.move();

                if (Math.Abs(shell.direction) > 0)
                    checkCollisions(shell);
            }

            // check if mario collided with the enemy
            checkCollisions();
        }



        private void checkCollisions(Shell shell)
        {
            List<Goomba> removeGoombas = new List<Goomba>();
            List<KoopaTroopa> removeKoopas = new List<KoopaTroopa>();
            bool incKills = false;

            foreach (Goomba goomba in goombas)
            {
                if (collided(shell.box, goomba.box))
                {
                    kills++;
                    removeGoombas.Add(goomba);

                    if (fallingEnemies.Count < 3)
                        fallingEnemies.Add(goomba);
                    else
                        this.Controls.Remove(goomba.box);
                    incKills = true;
                }
            }

            foreach (KoopaTroopa koopa in koopas)
            {
                if (collided(shell.box, koopa.box))
                {
                    kills++;
                    removeKoopas.Add(koopa);
                    if (fallingEnemies.Count < 3)
                        fallingEnemies.Add(koopa);
                    else
                        this.Controls.Remove(koopa.box);
                    incKills = true;
                }
            }

            if (incKills)
                increasedKills();

            foreach (Goomba goomba in removeGoombas)
            {
                goombas.Remove(goomba);

                Goomba newGoomba = new Goomba(barriers[rand.Next(0, 8)], Properties.Resources.d9nyjkq_6df1b499_1c92_4bd2_adce_78055faf40e01);
                int cntr = 0;
                while (distance(newGoomba.box, marioPB) < 100 || cntr > 5)
                {
                    newGoomba.box.Location = new Point(rand.Next(newGoomba.barrierBlock.Location.X + 1, newGoomba.barrierBlock.Location.X + newGoomba.barrierBlock.Width - newGoomba.box.Width - 1), newGoomba.barrierBlock.Location.Y - newGoomba.box.Height);
                    cntr++;
                }

                this.Controls.Add(newGoomba.box);
                goombas.Add(newGoomba);
            }

            foreach (KoopaTroopa koopa in removeKoopas)
            {
                koopas.Remove(koopa);
                
                KoopaTroopa newKoopa = new KoopaTroopa(barriers[rand.Next(0, 8)], Properties.Resources.Koopa);
                int cntr = 0;
                while (distance(newKoopa.box, marioPB) < 100 || cntr > 5)
                {
                    newKoopa.box.Location = new Point(rand.Next(newKoopa.barrierBlock.Location.X + 1, newKoopa.barrierBlock.Location.X + newKoopa.barrierBlock.Width - newKoopa.box.Width - 1), newKoopa.barrierBlock.Location.Y - newKoopa.box.Height);
                    cntr++;
                }
                    this.Controls.Add(newKoopa.box);
                koopas.Add(newKoopa);
            }
        }




        private bool collided(PictureBox box1, PictureBox box2)
        {
            Point box1Loc = box1.Location;
            Point box2Loc = box2.Location;
            if ((box1Loc.X > box2Loc.X && box1Loc.X < box2Loc.X + box2.Width)
                    || (box1Loc.X + box1.Width > box2Loc.X && box1Loc.X + box1.Width < box2Loc.X + box2.Width))
            {
                if ((box1Loc.Y < box2Loc.Y + box2.Height && box1Loc.Y > box2Loc.Y) ||
                    (box1Loc.Y + box1.Height < box2Loc.Y + box2.Height && box1Loc.Y + box1.Height> box2Loc.Y))
                {
                    return true;
                }

            }

            return false;
        }

        private void checkCollisions()
        {
            List<Goomba> removeGoombas = new List<Goomba>();
            // check the goombas
            foreach (Goomba goomba in goombas)
            {
                Point goombaLoc = goomba.box.Location;
                Point marioLoc = marioPB.Location;

                if ((marioLoc.X > goombaLoc.X && marioLoc.X < goombaLoc.X + goomba.box.Width)
                    || (marioLoc.X + marioPB.Width > goombaLoc.X && marioLoc.X + marioPB.Width < goombaLoc.X + goomba.box.Width))
                {
                    if (marioLoc.Y < goombaLoc.Y + goomba.box.Height && marioLoc.Y + marioPB.Height > goombaLoc.Y)
                    {
                        if (marioLoc.Y + marioPB.Height - marioVelocity <= goombaLoc.Y && marioVelocity > 0)
                            removeGoombas.Add(goomba);
                        else if (!removeGoombas.Contains(goomba) && goomba.life.ElapsedMilliseconds > 750)
                        {
                            kill();
                        }
                    }

                }

                
                if (!removeGoombas.Contains(goomba))
                {
                    if ((goombaLoc.X > marioLoc.X && goombaLoc.X < marioLoc.X + marioPB.Width)
                        || (goombaLoc.X + goomba.box.Width > marioLoc.X && goombaLoc.X + goomba.box.Width < marioLoc.X + marioPB.Width))
                    {
                        if (goombaLoc.Y < marioLoc.Y + marioPB.Height && goombaLoc.Y + goomba.box.Height > marioLoc.Y)
                        {
                            if (marioLoc.Y + marioPB.Height - marioVelocity <= goombaLoc.Y && marioVelocity > 0)
                                removeGoombas.Add(goomba);
                            else if (!removeGoombas.Contains(goomba) && goomba.life.ElapsedMilliseconds > 750)
                            {
                                kill();
                            }
                        }
                    }
                } 
            }

            bool incKills = false;
            foreach (Goomba goomba in removeGoombas)
            {
                squish(goomba);
                kills++;
                incKills = true;
            }



            List<KoopaTroopa> removeKoopas = new List<KoopaTroopa>();
            // check the goombas
            foreach (KoopaTroopa koopa in koopas)
            {
                Point koopaLoc = koopa.box.Location;
                Point marioLoc = marioPB.Location;

                if ((marioLoc.X > koopaLoc.X && marioLoc.X < koopaLoc.X + koopa.box.Width)
                    || (marioLoc.X + marioPB.Width > koopaLoc.X && marioLoc.X + marioPB.Width < koopaLoc.X + koopa.box.Width))
                {
                    if (marioLoc.Y < koopaLoc.Y + koopa.box.Height && marioLoc.Y + marioPB.Height > koopaLoc.Y)
                    {
                        if (marioLoc.Y + marioPB.Height - marioVelocity <= koopaLoc.Y && marioVelocity > 0)
                            removeKoopas.Add(koopa);
                        else if (!removeKoopas.Contains(koopa) && koopa.life.ElapsedMilliseconds > 500)
                            kill();
                    }

                }

                if (!removeKoopas.Contains(koopa))
                {
                    if ((koopaLoc.X > marioLoc.X && koopaLoc.X < marioLoc.X + marioPB.Width)
                        || (koopaLoc.X + koopa.box.Width > marioLoc.X && koopaLoc.X + koopa.box.Width < marioLoc.X + marioPB.Width))
                    {
                        if (koopaLoc.Y < marioLoc.Y + marioPB.Height && koopaLoc.Y + koopa.box.Height > marioLoc.Y)
                        {
                            if (marioLoc.Y + marioPB.Height - marioVelocity <= koopaLoc.Y && marioVelocity > 0)
                                removeKoopas.Add(koopa);
                            else if (!removeKoopas.Contains(koopa) && koopa.life.ElapsedMilliseconds > 500)
                                kill();
                        }
                    }
                }
            }

            foreach (KoopaTroopa koopa in removeKoopas)
            {
                squish(koopa);
                kills++;
                incKills = true;
            }

            List<Shell> removeShells = new List<Shell>();

            foreach (Shell shell in shells)
            {
                Point shellLoc = shell.box.Location;
                Point marioLoc = marioPB.Location;
                bool collided = false;

                if ((marioLoc.X > shellLoc.X && marioLoc.X < shellLoc.X + shell.box.Width)
                    || (marioLoc.X + marioPB.Width > shellLoc.X && marioLoc.X + marioPB.Width < shellLoc.X + shell.box.Width))
                {
                    if (marioLoc.Y < shellLoc.Y + shell.box.Height && marioLoc.Y + marioPB.Height > shellLoc.Y)
                    {
                        collided = true;
                        bool pickedUp = false;

                        foreach (PictureBox barrier in barriers)
                        {
                            if (Math.Abs(barrier.Location.Y - (marioLoc.Y + marioPB.Height)) < 5)
                            {
                                if (Math.Abs(shell.direction) < 5)
                                    pickedUp = true;
                            }
                        }

                        if (pickedUp)
                        {
                            pickup(shell);
                            removeShells.Add(shell);

                            if (!thrownAlr)
                            {
                                thrownAlr = true;
                                throwLabel.Visible = true;
                            }
                        }
                        else if (marioLoc.X < shellLoc.X)
                            shell.direction = 10;
                        else
                            shell.direction = -10;
                    }

                }

                if (!collided)
                {
                    if ((shellLoc.X > marioLoc.X && shellLoc.X < marioLoc.X + marioPB.Width)
                        || (shellLoc.X + shell.box.Width > marioLoc.X && shellLoc.X + shell.box.Width < marioLoc.X + marioPB.Width))
                    {
                        if (shellLoc.Y < marioLoc.Y + marioPB.Height && shellLoc.Y + shell.box.Height > marioLoc.Y)
                        {
                            bool pickedUp = false;

                            foreach (PictureBox barrier in barriers)
                            {
                                if (Math.Abs(barrier.Location.Y - (marioLoc.Y + marioPB.Height)) < 5)
                                {
                                    if (Math.Abs(shell.direction) < 5)
                                        pickedUp = true;
                                    else
                                        kill();
                                }
                            }

                            if (pickedUp)
                            {
                                pickup(shell);
                                removeShells.Add(shell);
                            }
                            else if (marioLoc.X < shellLoc.X)
                                shell.direction = 3;
                            else
                                shell.direction = -3;
                        }
                    }
                }
            }
            foreach (Shell shell2 in removeShells)
            {
                shells.Remove(shell2);
                this.Controls.Remove(shell2.box);
            }

            if (incKills)
                increasedKills();
        }


        private void pickup(Shell shell)
        {
            
            shell.box.Visible = false;

            if (marioPB.Image == leftChar)
                marioPB.Image = leftShellChar;
            else
                marioPB.Image = rightShellChar;
            holdingShell = true;

            marioPB.Location = new Point(marioPB.Location.X, marioPB.Location.Y - 2);
        }

        private void squish(Goomba goomba)
        {
            goombas.Remove(goomba);
            goomba.box.Visible = false;

            this.Controls.Remove(goomba.box);
            
            Goomba newGoomba = new Goomba(barriers[rand.Next(0, 8)], Properties.Resources.d9nyjkq_6df1b499_1c92_4bd2_adce_78055faf40e01);
            int cntr = 0;
            while (distance(newGoomba.box, marioPB) < 100 || cntr > 5)
            {
                newGoomba.box.Location = new Point(rand.Next(newGoomba.barrierBlock.Location.X + 1, newGoomba.barrierBlock.Location.X + newGoomba.barrierBlock.Width - newGoomba.box.Width - 1), newGoomba.barrierBlock.Location.Y - newGoomba.box.Height);
                cntr++;
            }
            this.Controls.Add(newGoomba.box);
            goombas.Add(newGoomba);
        }


        private void squish(KoopaTroopa koopa)
        {
            koopas.Remove(koopa);
            koopa.box.Visible = false;
            this.Controls.Remove(koopa.box);

            KoopaTroopa newKoopa = new KoopaTroopa(barriers[rand.Next(0, 8)], Properties.Resources.Koopa);
            int cntr = 0;
            while (distance(newKoopa.box, marioPB) < 100 || cntr > 5)
            {
                newKoopa.box.Location = new Point(rand.Next(newKoopa.barrierBlock.Location.X + 1, newKoopa.barrierBlock.Location.X + newKoopa.barrierBlock.Width - newKoopa.box.Width - 1), newKoopa.barrierBlock.Location.Y - newKoopa.box.Height);
                cntr++;
            }
            this.Controls.Add(newKoopa.box);
            koopas.Add(newKoopa);

            Shell shell = new Shell(koopa.barrierBlock, Properties.Resources.Koopa_Shell, koopa.box.Location, barriers);
            this.Controls.Add(shell.box);
            shells.Add(shell);
        }


        private void kill()
        {
            if (!dead)
            {
                marioPB.Location = new Point(532, -71);
                dead = true;

                if (throwLabel.Visible)
                {
                    throwLabel.Visible = false;
                    thrownAlr = false;
                }

                coins -= 10;

                coinsLabel.Text = coins.ToString();
                coinsLabel.Location = new Point(3, coinsLabel.Location.Y);
                coinPB.Location = new Point(coinsLabel.Width + 3, coinPB.Location.Y);
                holdingShell = false;

                marioPB.Image = rightChar;

                List<PictureBox> removeCoins = new List<PictureBox>();

                foreach (PictureBox box in coinPBs)
                {
                    removeCoins.Add(box);
                }

                foreach (PictureBox box in removeCoins)
                {
                    coinPBs.Remove(box);
                    this.Controls.Remove(box);
                }
            }

        }

        private void moveMario()
        {
            //VERTICAL MOVEMENT
            move(marioPB, 0, (int) marioVelocity);

            List<PictureBox> removeCoins = new List<PictureBox>();
            foreach (PictureBox coinBox in coinPBs)
            {
                if (marioPB.Location.X > coinBox.Location.X && marioPB.Location.X < coinBox.Location.X + coinBox.Width)
                {
                    if (Math.Abs(marioPB.Location.Y - (coinBox.Location.Y + coinBox.Height)) < 5)
                    {
                        if (kills < 10)
                            coins++;
                        else if (kills < 20)
                            coins += 2;
                        else
                            coins += 5;

                        coinSound.Open(new Uri(Application.StartupPath + "\\Sounds\\MarioCoinSound.wav"));
                        coinSound.Play();
                        coinsLabel.Text = coins.ToString();
                        coinsLabel.Location = new Point(3, coinsLabel.Location.Y);
                        coinPB.Location = new Point(coinsLabel.Width + 3, coinPB.Location.Y);
                        this.Controls.Remove(coinBox);
                        removeCoins.Add(coinBox);
                    }

                }
            }

            foreach (PictureBox box in removeCoins)
            {
                coinPBs.Remove(box);
            }

            if (heldKeys.Contains(Keys.W) || heldKeys.Contains(Keys.Space) || heldKeys.Contains(Keys.Up))
            {
                if (maxVel)
                    marioVelocity += 4;
            }
            else
                marioVelocity += 4;

            if (marioVelocity > 0 && !canMove(marioPB, 0, (int) marioVelocity))
            {
                marioVelocity = 2;
                sameJump = false;
                maxVel = false;
            }

            if (marioVelocity > 20)
                marioVelocity = 20;

            //HORIZONTAL MOVEMENT
            // if the user is holding a left key, move mario left ten pixels
            if ((heldKeys.Contains(Keys.A) || heldKeys.Contains(Keys.Left)) && marioPB.Location.X > 0 - (marioPB.Width - 10))
            {
                move(marioPB, -10, 0);
            }

            // if the user is holding a right key, move mario right ten pixels
            if ((heldKeys.Contains(Keys.D) || heldKeys.Contains(Keys.Right)) && marioPB.Location.X < 1140 - marioPB.Width)
            {
                move(marioPB, 10, 0);
            }

            
        }

        private void move(PictureBox box, int xChange, int yChange)
        {
            // location of where the box would be
            Point futureLoc = new Point(box.Location.X + xChange, box.Location.Y + yChange);

            // bool for if the box can go where it wants to
            bool canGo = true;

            // check if the future locaiton would hit a barrier
            foreach (PictureBox barrier in barriers)
            {
                // variable for the barrier's location
                Point barrierLoc = barrier.Location;

                // if the character is about to hit a border, it can't move
                if ((futureLoc.X > barrierLoc.X && futureLoc.X < barrierLoc.X + barrier.Width)
                    || (futureLoc.X + box.Width > barrierLoc.X && futureLoc.X + box.Width < barrierLoc.X + barrier.Width))
                {
                    if (futureLoc.Y < barrierLoc.Y + barrier.Height && futureLoc.Y + box.Height > barrierLoc.Y)
                        canGo = false;

                }

                if ((barrierLoc.X > futureLoc.X && barrierLoc.X < futureLoc.X + box.Width)
                    || (barrierLoc.X + barrier.Width > futureLoc.X && barrierLoc.X + barrier.Width < futureLoc.X + box.Width))
                {
                    if (barrierLoc.Y < futureLoc.Y + box.Height && barrierLoc.Y + barrier.Height > futureLoc.Y)
                        canGo = false;
                }
            }

            if (canGo)
                box.Location = new Point(box.Location.X + xChange, box.Location.Y + yChange);

        }

        private bool canMove(PictureBox box, int xChange, int yChange)
        {
            // location of where the box would be
            Point futureLoc = new Point(box.Location.X + xChange, box.Location.Y + yChange);

            // check if the future locaiton would hit a barrier
            foreach (PictureBox barrier in barriers)
            {
                // variable for the barrier's location
                Point barrierLoc = barrier.Location;

                // if the character is about to hit a border, it can't move
                if ((futureLoc.X > barrierLoc.X && futureLoc.X < barrierLoc.X + barrier.Width)
                    || (futureLoc.X + box.Width > barrierLoc.X && futureLoc.X + box.Width < barrierLoc.X + barrier.Width))
                {
                    if (futureLoc.Y < barrierLoc.Y + barrier.Height && futureLoc.Y + box.Height > barrierLoc.Y - 5)
                        return false;

                }

                if ((barrierLoc.X > futureLoc.X && barrierLoc.X < futureLoc.X + box.Width)
                    || (barrierLoc.X + barrier.Width > futureLoc.X && barrierLoc.X + barrier.Width < futureLoc.X + box.Width))
                {
                    if (barrierLoc.Y < futureLoc.Y + box.Height && barrierLoc.Y + barrier.Height > futureLoc.Y - 5)
                        return false;

                }
            }

            return true;
        }

        private void Mario_Load(object sender, EventArgs e)
        {

        }

        private void remover_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!closedForm)
            {
                while (keepGoing)
                {
                    remover.ReportProgress(1);
                    Thread.Sleep(10);
                }
            }

            remover.CancelAsync();
        }

        private void remover_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            List<Enemy> removeEnemies = new List<Enemy>();
            foreach (Enemy enemy in fallingEnemies)
            {
                enemy.box.BringToFront();
                enemy.box.Location = new Point(enemy.box.Location.X + 3, enemy.box.Location.Y + 15);

                if (enemy.box.Location.Y > formHeight)
                {
                    this.Controls.Remove(enemy.box);
                    removeEnemies.Add(enemy);
                }
            }

            foreach (Enemy enemy1 in removeEnemies)
                fallingEnemies.Remove(enemy1);


        }

        private void beginning_DoWork(object sender, DoWorkEventArgs e)
        {
            while (marioPB.Location.Y < 299)
            {
                beginning.ReportProgress(1); Thread.Sleep(50);
            }

            while (!closedForm)
            {
                while (dead)
                {
                    while (marioPB.Location.Y < 299)
                    {
                        beginning.ReportProgress(1); Thread.Sleep(50);
                    }
                }
            }
        }

        private void beginning_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            marioPB.Location = new Point(marioPB.Location.X, marioPB.Location.Y + 4);

            if (marioPB.Location.Y >= 299)
            {
                dead = false;
                // marioPB.Location = new Point(marioPB.Location.X, 298);
            }
        }

        private void Mario_FormClosed(object sender, FormClosedEventArgs e)
        {
            formClosed = true;
            closedForm = true;
            song.Stop();

            player.addCoins(coins);

            if (kills > player.getMarioScore())
                player.setMarioScore(kills);

            player.updateFile();
        }


        private void endGame()
        {
            keepGoing = false;
            ending.RunWorkerAsync();
        }


        private void showEndScreen()
        {
            keepEnding = false;

            foreach (Enemy enemy in fallingEnemies)
                enemy.box.Visible = false;

            panel1.Visible = true;
            marioPB.BringToFront();
            timerLabel.Visible = false;
            foreach (PictureBox box in coinPBs)
                box.Visible = false;
            marioPB.Location = new Point(rand.Next(0, barrier4.Width), barrier4.Location.Y - marioPB.Height);
            panel1.Location = new Point(0, 0);
            panel1.Size = new Size(1125, 725);
            endCoinsLabel.Text = coins.ToString();
            endKillsLabel.Text = kills.ToString();
        }

        bool formClosed = false;
        bool keepEnding = true;


        Stopwatch timer = new Stopwatch();
        bool alrEnded = false;
        private void gameTimer_Tick(object sender, EventArgs e)
        {

            String outputString = "";

            int secondsLeft = 120;

            secondsLeft -= (int)timer.Elapsed.TotalSeconds;

            if (secondsLeft < 0)
            {
                if (!alrEnded)
                {
                    alrEnded = true;
                    endGame();
                }
                return;
            }

            if (secondsLeft > 60)
            {
                outputString += secondsLeft / 60;
                secondsLeft -= 60 * (secondsLeft / 60);
            }

            outputString += ":";

            if (secondsLeft < 10)
                outputString += "0";

            outputString += secondsLeft;

            timerLabel.Text = outputString;

        }

        int endDirection = 5;

        private void endMoveMario()
        {
            marioPB.Location = new Point(marioPB.Location.X + endDirection, marioPB.Location.Y);

            if (marioPB.Location.X < 5 && endDirection < 0)
            {
                endDirection *= -1;
                marioPB.Image = rightChar;
            }

            if (marioPB.Location.X > 1070 && endDirection > 0)
            {
                endDirection *= -1;
                marioPB.Image = leftChar;
            }
        }

        private void ending_DoWork(object sender, DoWorkEventArgs e)
        {
            while (keepEnding)
            {
                ending.ReportProgress(1);
                Thread.Sleep(15);
            }
        }

        private void ending_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            marioPB.Location = new Point(marioPB.Location.X, marioPB.Location.Y - 5);

            if (marioPB.Location.Y < 0 - marioPB.Height)
                showEndScreen();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void marioCharPB_Click(object sender, EventArgs e)
        {
            // change the instructions
            selectCharPB.Visible = false;
            instructionsPB.Visible = true;

            // change the images of the pictureboxes
            marioCharPB.Image = Properties.Resources.Celebrating_Mario;
            luigiCharPB.Image = Properties.Resources.Luigi_Standing_Awkwardly;
            yoshiCharPB.Image = Properties.Resources.Yoshi_Running;
            toadCharPB.Image = Properties.Resources.Toad_Standing;
            peachCharPB.Image = Properties.Resources.Peach_Standing;

            // set the character images
            rightChar = Properties.Resources._223_2238299_mario_sprite_by_flamingdragon5000_mario_8_bit_png1;
            leftChar = Properties.Resources.Left_Mario;
            rightShellChar = Properties.Resources.Mario_with_shell;
            leftShellChar = Properties.Resources.Left_Mario_Shell;
            marioPB.Image = rightChar;

            // set the backcolor
            ((PictureBox)sender).BackColor = System.Drawing.Color.FromArgb(251, 208, 40);

            // indicate that the user has selected a character
            characterSelected = true;

            // reset the backcolors of the rest of the character pb's
            luigiCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
            yoshiCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
            toadCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
            peachCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
        }

        private void luigiCharPB_Click(object sender, EventArgs e)
        {
            // change the instructions
            selectCharPB.Visible = false;
            instructionsPB.Visible = true;

            // change the images of the pictureboxes
            marioCharPB.Image = Properties.Resources.Mario_Standing_Awkwardly1;
            luigiCharPB.Image = Properties.Resources.Sexy_Luigi;
            yoshiCharPB.Image = Properties.Resources.Yoshi_Running;
            toadCharPB.Image = Properties.Resources.Toad_Standing;
            peachCharPB.Image = Properties.Resources.Peach_Standing;

            // set the character images
            rightChar = Properties.Resources.Luigi_Right;
            leftChar = Properties.Resources.Luigi_Left;
            rightShellChar = Properties.Resources.Luigi_Right_Shell_2;
            leftShellChar = Properties.Resources.Luigi_Left_Shell_2;
            marioPB.Image = rightChar;

            // set the backcolor
            ((PictureBox)sender).BackColor = System.Drawing.Color.FromArgb(251, 208, 40);

            // indicate that the user has selected a character
            characterSelected = true;

            // reset the backcolors of the rest of the character pb's
            marioCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
            yoshiCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
            toadCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
            peachCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
        }

        private void yoshiCharPB_Click(object sender, EventArgs e)
        {
            // change the instructions
            selectCharPB.Visible = false;
            instructionsPB.Visible = true;

            // change the images of the pictureboxes
            marioCharPB.Image = Properties.Resources.Mario_Standing_Awkwardly1;
            luigiCharPB.Image = Properties.Resources.Luigi_Standing_Awkwardly;
            yoshiCharPB.Image = Properties.Resources.Yoshi_Celebrating;
            toadCharPB.Image = Properties.Resources.Toad_Standing;
            peachCharPB.Image = Properties.Resources.Peach_Standing;

            // set the character images
            rightChar = Properties.Resources.Yoshi_Right;
            leftChar = Properties.Resources.Yoshi_Left;
            rightShellChar = Properties.Resources.Yoshi_Right_Shell;
            leftShellChar = Properties.Resources.Yoshi_Left_Shell;
            marioPB.Image = rightChar;

            // set the backcolor
            ((PictureBox)sender).BackColor = System.Drawing.Color.FromArgb(251, 208, 40);

            // indicate that the user has selected a character
            characterSelected = true;

            // reset the backcolors of the rest of the character pb's
            luigiCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
            marioCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
            toadCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
            peachCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
        }

        private void toadCharPB_Click(object sender, EventArgs e)
        {
            // change the instructions
            selectCharPB.Visible = false;
            instructionsPB.Visible = true;

            // change the images of the pictureboxes
            marioCharPB.Image = Properties.Resources.Mario_Standing_Awkwardly1;
            luigiCharPB.Image = Properties.Resources.Luigi_Standing_Awkwardly;
            yoshiCharPB.Image = Properties.Resources.Yoshi_Running;
            toadCharPB.Image = Properties.Resources.Toad_Celebrating;
            peachCharPB.Image = Properties.Resources.Peach_Standing;

            // set the character images
            rightChar = Properties.Resources.Toad_Right;
            leftChar = Properties.Resources.Toad_Left_2;
            rightShellChar = Properties.Resources.Toad_Right_Shell;
            leftShellChar = Properties.Resources.Toad_Left_Shell;
            marioPB.Image = rightChar;

            // set the backcolor
            ((PictureBox)sender).BackColor = System.Drawing.Color.FromArgb(251, 208, 40);

            // indicate that the user has selected a character
            characterSelected = true;

            // reset the backcolors of the rest of the character pb's
            luigiCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
            yoshiCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
            marioCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
            peachCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
        }

        private void peachCharPB_Click(object sender, EventArgs e)
        {
            // change the instructions
            selectCharPB.Visible = false;
            instructionsPB.Visible = true;

            // change the images of the pictureboxes
            marioCharPB.Image = Properties.Resources.Mario_Standing_Awkwardly1;
            luigiCharPB.Image = Properties.Resources.Luigi_Standing_Awkwardly;
            yoshiCharPB.Image = Properties.Resources.Yoshi_Running;
            toadCharPB.Image = Properties.Resources.Toad_Standing;
            peachCharPB.Image = Properties.Resources.Peach_Celebrating;

            // set the character images
            rightChar = Properties.Resources.Peach_Right;
            leftChar = Properties.Resources.Peach_Left;
            rightShellChar = Properties.Resources.Peach_Right_Shell;
            leftShellChar = Properties.Resources.Peach_Left_Shell;
            marioPB.Image = rightChar;

            // set the backcolor
            ((PictureBox)sender).BackColor = System.Drawing.Color.FromArgb(251, 208, 40);

            // indicate that the user has selected a character
            characterSelected = true;

            // reset the backcolors of the rest of the character pb's
            luigiCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
            yoshiCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
            toadCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
            marioCharPB.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
        }

        private void marioCharPB_MouseHover(object sender, EventArgs e)
        {
            //PictureBox box = (PictureBox)sender;
            //if (box.BackColor != selectColor)
            //    box.BackColor = hoverColor;
        }

        private void marioCharPB_MouseLeave(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            if (box.BackColor != selectColor)
                box.BackColor = System.Drawing.Color.FromArgb(155, 222, 236);
        }

        private void marioCharPB_MouseEnter(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            if (box.BackColor != selectColor)
                box.BackColor = hoverColor;
        }
    }


    public class Enemy
    {
        public int direction;
        public PictureBox box = new PictureBox();
        public Random rand = new Random();
        public  PictureBox barrierBlock;
        public Image image;
        public Stopwatch life = new Stopwatch();
        
        /*
        public Enemy(PictureBox spawnBarrier, Image image)
        {
            // randomly decide their direction
            if (rand.Next(0, 2) == 1)
                direction = 3;
            else
                direction = -3;

            barrierBlock = spawnBarrier;

            // set the picturebox settings
            box.SizeMode = PictureBoxSizeMode.AutoSize;
            box.Image = image;
            box.Location = new Point(rand.Next(barrierBlock.Location.X + 1, barrierBlock.Location.X + barrierBlock.Width - box.Width - 1), barrierBlock.Location.Y - box.Height);
            box.BorderStyle = BorderStyle.FixedSingle;
        } */

            public void move()
        {
            bool canGo = true;

            Point futureLoc = new Point(box.Location.X + direction, box.Location.Y);

            if (futureLoc.X + box.Width > barrierBlock.Location.X + barrierBlock.Width)
                canGo = false;

            if (futureLoc.X < barrierBlock.Location.X)
                canGo = false;

            if (canGo)
                box.Location = futureLoc;
            else
            {
                direction *= -1;
            }
        }
    }
    public class Goomba : Enemy
    {

        public Goomba(PictureBox spawnBarrier, Image image)
        {
            life.Start();
            // randomly decide their direction
            if (rand.Next(0, 2) == 1)
                direction = 3;
            else
                direction = -3;

            barrierBlock = spawnBarrier;

            // set the picturebox settings
            box.SizeMode = PictureBoxSizeMode.AutoSize;
            box.Image = image;
            box.Location = new Point(rand.Next(barrierBlock.Location.X + 1, barrierBlock.Location.X + barrierBlock.Width - box.Width - 1), barrierBlock.Location.Y - box.Height);
        }



    }


    public class KoopaTroopa : Enemy
    {
        public KoopaTroopa(PictureBox spawnBarrier, Image image)
        {
            life.Start();
            // randomly decide their direction
            if (rand.Next(0, 2) == 1)
                direction = 3;
            else
                direction = -3;

            barrierBlock = spawnBarrier;

            // set the picturebox settings
            box.SizeMode = PictureBoxSizeMode.AutoSize;
            box.Image = image;
            box.Location = new Point(rand.Next(barrierBlock.Location.X + 1, barrierBlock.Location.X + barrierBlock.Width - box.Width - 1), barrierBlock.Location.Y - box.Height);
        }
    }




    public class Shell : Enemy
    {
        PictureBox currentBox;
        Point location;
        PictureBox[] barriers;

        public Shell(PictureBox spawnBarrier, Image image, Point point, PictureBox[] inBarriers)
        {
            // randomly decide their direction
            direction = 0;

            currentBox = spawnBarrier;

            barriers = inBarriers;

            // set the picturebox settings
            box.SizeMode = PictureBoxSizeMode.AutoSize;
            box.Image = image;
            location = new Point(point.X, currentBox.Location.Y - box.Height);
            box.Location = location;
        }

        public Shell(Point point, PictureBox[] inBarriers)
        {
            // randomly decide their direction
            direction = 0;

            barriers = inBarriers;

            // set the picturebox settings
            box.SizeMode = PictureBoxSizeMode.AutoSize;
            box.Image = Properties.Resources.Koopa_Shell;
            location = point;
            box.Location = location;
        }


        public void move()
        {
            Point futureLoc = new Point(box.Location.X, box.Location.Y + 15);

            bool canGo = true;

            // check if the future locaiton would hit a barrier
            foreach (PictureBox barrier in barriers)
            {
                // variable for the barrier's location
                Point barrierLoc = barrier.Location;

                // if the character is about to hit a border, it can't move
                if ((futureLoc.X > barrierLoc.X && futureLoc.X < barrierLoc.X + barrier.Width)
                    || (futureLoc.X + box.Width > barrierLoc.X && futureLoc.X + box.Width < barrierLoc.X + barrier.Width))
                {
                    if (futureLoc.Y < barrierLoc.Y + barrier.Height && futureLoc.Y + box.Height > barrierLoc.Y)
                        canGo = false;

                }

                if ((barrierLoc.X > futureLoc.X && barrierLoc.X < futureLoc.X + box.Width)
                    || (barrierLoc.X + barrier.Width > futureLoc.X && barrierLoc.X + barrier.Width < futureLoc.X + box.Width))
                {
                    if (barrierLoc.Y < futureLoc.Y + box.Height && barrierLoc.Y + barrier.Height > futureLoc.Y)
                        canGo = false;
                }
            }



            if (canGo)
                box.Location = futureLoc;
            else
            {
                int closest = 1000;
                foreach (PictureBox barrier in barriers)
                {
                    if (barrier.Location.Y - (box.Location.Y + box.Height) < closest && barrier.Location.Y > box.Location.Y)
                        closest = barrier.Location.Y - (box.Location.Y + box.Height);
                }

                if (closest <= 5)
                    box.Location = new Point(box.Location.X, box.Location.Y + closest);
                /*else if (closest < 15)
                    box.Location = new Point(box.Location.X, box.Location.Y + 5);*/
            }

            box.Location = new Point(box.Location.X + direction, box.Location.Y);
        }
    }
}
