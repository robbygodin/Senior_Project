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

namespace Senior_Project
{
    public partial class PacMan : Form
    {
        // string to hold the direction of pac man
        String pacDirection = "right";

        // boolean for if the game is over
        bool gameOver = false;

        // array to keep track of the barrier picture boxes
        PictureBox[] barriers;

        // array to keep track of ghosts
        PictureBox[] ghostsArray;
        Boolean[] blueGhosts = { false, false, false, false };

        // array for ghosts directions (red, pink, yellow, blue)
        String[] ghostDirects = { "up", "up", "up", "up" };

        // array for if each ghost is out of the box yet
        Boolean[] ghostOut = { false, false, false, false };

        // array to hold the turning picture boxes
        PictureBox[] turnBoxes;

        // array to hold the intersection picture boxes
        PictureBox[] interBoxes;

        public PacMan()
        {
            InitializeComponent();
            movePacMan.RunWorkerAsync();
            moveGhostsBack.RunWorkerAsync();

            // temporary border array
            PictureBox[] tempBarriers = { border1, border2, border3, border4, border5, border6, border7, border8 , border9, border10, border11,
                border12 , border13, border14, border15, border16, border17, border18, border19, border20, border21, border22, border23,
                border24, border25, border26, border27, border28, border29, border29, border30};
            barriers = tempBarriers;

            // temp ghost array
            PictureBox[] tempGhosts = { redGhost, pinkGhost, yellowGhost, blueGhost };
            ghostsArray = tempGhosts;

            // temp turn box array
            PictureBox[] tempTurn = {turnPB1};
            turnBoxes = tempTurn;

            PictureBox[] tempInter = {};
            interBoxes = tempInter;
        }



        private String onGhost()
        {
            // go to each ghost
            for (int i = 0; i < 4; i++)
            {
                // save the current ghost
                PictureBox ghost = ghostsArray[i];

                // save pacmans location
                Point pacLoc = pacManPB.Location;

                if (((pacLoc.X >= ghost.Location.X && pacLoc.X <= ghost.Location.X + ghostsArray[i].Width) ||
                     (pacLoc.X + pacManPB.Width >= ghost.Location.X && pacLoc.X + pacManPB.Width <= ghost.Location.X + ghostsArray[i].Width))
                     && ((pacLoc.Y <= ghost.Location.Y + ghostsArray[i].Height && pacLoc.Y >= ghost.Location.Y) || (pacLoc.Y +
                     pacManPB.Height <= ghost.Location.Y + ghostsArray[i].Height && pacLoc.Y + pacManPB.Height >= ghost.Location.Y)))
                {
                    if (blueGhosts[i])
                        return "blue";
                    else
                        return ("true");
                }
            }
            return "false";
        }



        private bool onBarrier(PictureBox picBox, String direction)
        {
            // point to hold the test location of pac man
            Point point = new Point();

            // get the test location of the pac man based on which direction it's going
            switch (direction)
            {
                case ("up"): point = new Point(picBox.Location.X, picBox.Location.Y - 3); ; break;
                case ("down"): point = new Point(picBox.Location.X, picBox.Location.Y + 3); break;
                case ("left"): point = new Point(picBox.Location.X - 3, picBox.Location.Y); break;
                case ("right"): point = new Point(picBox.Location.X + 3, picBox.Location.Y); break;
            }

            // go to each barrier
            for (int i = 0; i < barriers.Count(); i++)
            {
                // save the location of the barrier
                Point barrierLocation = new Point(barriers[i].Location.X, barriers[i].Location.Y);

                // if the point is on the current barrier
                if (point.X + picBox.Width >= barrierLocation.X && point.X + picBox.Width <= barrierLocation.X + barriers[i].Width &&
                    point.Y + picBox.Width >= barrierLocation.Y && point.Y <= barrierLocation.Y + barriers[i].Height)
                    return true;
            }

            return false;
        }

        private bool onBarrier(Point point)
        {
            // go to each barrier
            for (int i = 0; i < barriers.Count(); i++)
            {
                // save the location of the barrier
                Point barrierLocation = new Point(barriers[i].Location.X, barriers[i].Location.Y);

                // if the point is on the current barrier
                if (point.X + 45 >= barrierLocation.X && point.X + 45 <= barrierLocation.X + barriers[i].Width &&
                    point.Y + 45 >= barrierLocation.Y && point.Y <= barrierLocation.Y + barriers[i].Height)
                    return true;
            }

            return false;
        }






        // method to turn the ghost when they hit a turn box
        private void turnGhost(int i)
        {
            // check which directions it can go
            //bools for if the ghost can go in each direction and counter for the number of directions
            bool canUp = false;
            bool canRight = false;
            bool canDown = false;
            bool canLeft = false;

            if (true/*!onBarrier(new Point(ghostsArray[i].Location.X, ghostsArray[i].Location.Y - 3)) && ghostDirects[i] != "down"*/)
            {
                canUp = true;
            }

            if (true/*!onBarrier(new Point(ghostsArray[i].Location.X + 3, ghostsArray[i].Location.Y)) && ghostDirects[i] != "left"*/)
            {
                canRight = true;
            }

            if (true/*!onBarrier(new Point(ghostsArray[i].Location.X, ghostsArray[i].Location.Y + 3)) && ghostDirects[i] != "up"*/)
            {
                canDown = true;
            }

            if (true/*!onBarrier(new Point(ghostsArray[i].Location.X - 3, ghostsArray[i].Location.Y)) && ghostDirects[i] != "right"*/)
            {
                canLeft = true;
            }

            // int for the shortest distance and string for which direction has that shortest distance
            int shortestDist = 1000000;
            String shortestDir = "";

            // if it can go this direction, get the distance it would be from pac man after
            if (canUp)
            {
                // get the distance the ghost would be if it went up
                int distance = getDistance(new Point(ghostsArray[i].Location.X, ghostsArray[i].Location.Y - 3), pacManPB.Location);

                // if this distance is shorter than the shortest distance, save that
                if (distance < shortestDist)
                {
                    shortestDist = distance;
                    shortestDir = "up";
                }
            }

            if (canRight)
            {
                // get the distance the ghost would be to pac man if it went right
                int distance = getDistance(new Point(ghostsArray[i].Location.X + 3, ghostsArray[i].Location.Y), pacManPB.Location);

                // if this distance is shorter than the shortest distance, save that
                if (distance < shortestDist)
                {
                    shortestDist = distance;
                    shortestDir = "right";
                }
            }

            if (canDown)
            {
                // get the distance the ghost would be to pac man if it went down
                int distance = getDistance(new Point(ghostsArray[i].Location.X, ghostsArray[i].Location.Y + 3), pacManPB.Location);

                // if this distance is shorter than the shortest distance, save that
                if (distance < shortestDist)
                {
                    shortestDist = distance;
                    shortestDir = "down";
                }
            }

            if (canLeft)
            {
                // get the distance the ghost would be to pac man if it went left
                int distance = getDistance(new Point(ghostsArray[i].Location.X - 3, ghostsArray[i].Location.Y), pacManPB.Location);

                // if this distance is shorter than the shortest distance, save that
                if (distance < shortestDist)
                {
                    shortestDist = distance;
                    shortestDir = "left";
                }
            }

            // move the ghost in the direction with the shortest distance
            switch (shortestDir)
            {
                case ("up"): ghostsArray[i].Location = new Point(ghostsArray[i].Location.X, ghostsArray[i].Location.Y - 3); break;
                case ("right"): ghostsArray[i].Location = new Point(ghostsArray[i].Location.X + 3, ghostsArray[i].Location.Y); break;
                case ("down"): ghostsArray[i].Location = new Point(ghostsArray[i].Location.X, ghostsArray[i].Location.Y + 3); break;
                case ("left"): ghostsArray[i].Location = new Point(ghostsArray[i].Location.X - 3, ghostsArray[i].Location.Y); break;
            }
        }




        // method to get the distance from one thing to another
        private int getDistance(PictureBox pb1, PictureBox pb2)
        {
            // variable to hold the distance
            int distance = 0;

            // add the x distance to the variable
            distance += Math.Abs(pb2.Location.X - pb1.Location.X);

            // add the y distance to the variable
            distance += Math.Abs(pb2.Location.Y - pb1.Location.Y);

            // return the x distance + the y distance
            return distance;
        }

        // method to get the distance from one point to another
        private int getDistance(Point point1, Point point2)
        {
            // return the x distance + the y distance
            return Math.Abs(point2.X - point1.X) + Math.Abs(point2.Y - point1.Y);
        }

        private void movePacMan_DoWork_1(object sender, DoWorkEventArgs e)
        {
            while (!gameOver)
            {
                movePacMan.ReportProgress(1);
                Thread.Sleep(25);
            }
        }

        private void movePacMan_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!onBarrier(pacManPB, pacDirection))
            {
                switch (pacDirection)
                {
                    case ("left"): pacManPB.Location = new Point(pacManPB.Location.X - 3, pacManPB.Location.Y); break;
                    case ("up"): pacManPB.Location = new Point(pacManPB.Location.X, pacManPB.Location.Y - 3); break;
                    case ("down"): pacManPB.Location = new Point(pacManPB.Location.X, pacManPB.Location.Y + 3); break;
                    case ("right"): pacManPB.Location = new Point(pacManPB.Location.X + 3, pacManPB.Location.Y); break;
                }
            }

            // if pacman went off the edge, teleport him to the opposite side
            if (pacManPB.Location.X > 1079)
            {
                pacManPB.Location = new Point(-30, pacManPB.Location.Y);
                pacDirection = "right";
            }

            if (pacManPB.Location.X < -30)
            {
                pacManPB.Location = new Point(1079, pacManPB.Location.Y);
                pacDirection = "left";
            }

            if (pacManPB.Location.Y < -30)
            {
                pacManPB.Location = new Point(pacManPB.Location.X, 595);
                pacDirection = "up";
            }

            if (pacManPB.Location.Y > 595)
            {
                pacManPB.Location = new Point(pacManPB.Location.X, -30);
                pacDirection = "down";
            }

            // if pacman collided with a ghost
            if (onGhost().Equals("true"))
            {
                Console.WriteLine("true");
            }
            // if pacman ate a ghost
            if (onGhost().Equals("blue"))
            {

            }
        }

        private void PacMan_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keyPressed = e.KeyCode;

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                pacDirection = "up";
            }
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                pacDirection = "down";
            }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                pacDirection = "left";
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                pacDirection = "right";
            }
        }

        private void moveGhostsBack_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!gameOver)
            {
                moveGhostsBack.ReportProgress(1);
                Thread.Sleep(25);
            }
        }

        private void moveGhostsBack_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // boolean for if all the ghosts are out
            bool allGhostsOut = false;
            // go to each ghost
            for (int i = 0; i < 4; i++)
            {
                // get the location of pac man
                Point pacLoc = pacManPB.Location;

                // get the location of the ghost
                Point ghostLoc = ghostsArray[i].Location;

                // boolean for if the ghost turned
                bool ghostTurned = false;

                if (!ghostOut[i])
                {
                    if (ghostLoc.Y <= 113)
                    {
                        ghostOut[i] = true;
                    }
                    else if (ghostLoc.X < 312)
                    {
                        ghostsArray[i].Location = new Point(ghostLoc.X + 3, ghostLoc.Y);
                    }
                    else if (ghostLoc.X > 427)
                    {
                        ghostsArray[i].Location = new Point(ghostLoc.X - 3, ghostLoc.Y);
                    }
                    else
                    {
                        ghostsArray[i].Location = new Point(ghostLoc.X, ghostLoc.Y - 3);
                    }
                }
                else
                {
                    // go to each square where the ghost can turn (blue boxes) to check if the ghost is on it
                    for (int j = 0; j < turnBoxes.Length; j++)
                    {
                        // get the location of this turn box
                        Point boxLoc = new Point(turnBoxes[j].Location.X, turnBoxes[j].Location.Y);

                        // get the height and width of the turn box
                        int height = turnBoxes[j].Height;
                        int width = turnBoxes[j].Width;

                        // if the ghost is on this square
                        if (ghostLoc.X <= boxLoc.X + width && ghostLoc.X >= boxLoc.X && ghostLoc.Y <= boxLoc.Y + height && ghostLoc.Y >= boxLoc.Y)
                        {
                            turnGhost(i);
                            ghostTurned = true;
                        }
                    }


                    // check if the ghost is at an intersection
                    // go to each intersection square
                    for (int j = 0; j < interBoxes.Length; j++)
                    {
                        // get the location of this intersection
                        Point boxLoc = new Point(interBoxes[j].Location.X, interBoxes[j].Location.Y);

                        // get the height and width of this intersection box
                        int height = interBoxes[j].Height;
                        int width = interBoxes[j].Width;

                        // if the ghost is on this square
                        if (ghostLoc.X <= boxLoc.X + width && ghostLoc.X >= boxLoc.X && ghostLoc.Y <= boxLoc.Y + height && ghostLoc.Y >= boxLoc.Y)
                        {
                            turnGhost(i);
                            ghostTurned = true;
                        }
                    }


                    // if the ghost didn't turn, move it in the direction it was already going
                    if (!ghostTurned)
                    {
                        Console.WriteLine("ghost not turned");
                        switch (ghostDirects[i])
                        {
                            case ("right"): ghostsArray[i].Location = new Point(ghostsArray[i].Location.X + 3, ghostsArray[i].Location.Y); break;
                            case ("down"): ghostsArray[i].Location = new Point(ghostsArray[i].Location.X, ghostsArray[i].Location.Y + 3); break;
                            case ("left"): ghostsArray[i].Location = new Point(ghostsArray[i].Location.X - 3, ghostsArray[i].Location.Y); break;
                            case ("up"): ghostsArray[i].Location = new Point(ghostsArray[i].Location.X, ghostsArray[i].Location.Y - 3); break;
                        }
                    }
                }


            }

            if (allGhostsOut)
                barriers[29] = spawnBorder;
        }
    }
}
