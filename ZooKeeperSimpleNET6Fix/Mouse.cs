using System;
using ZooKeeperSimpleNET6Fix;
using static System.Net.Mime.MediaTypeNames;

namespace ZooManager
{
    public class Mouse : Animal, IPrey
    {
        public Mouse(string name)
        {
            emoji = "🐭";
            species = "mouse";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = new Random().Next(1, 4); // reaction time of 1 (fast) to 3
            /* Note that Mouse reactionTime range is smaller than Cat reactionTime,
             * so mice are more likely to react to their surroundings faster than cats!
             Mouse*/
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a mouse. Squeak.");

            if ((this as IPrey).)
            {

            }
        }

        public void TotalFlee(int x, int y, string predator)
        {
            // make sure the prey will not flee back to the original suqare
            List<Direction> possibleDirections = new List<Direction> { Direction.up, Direction.down, Direction.left, Direction.right };
            if ((this as IPrey).Flee(location.x, location.y, predator) == Direction.up)
            {
                possibleDirections.Remove(Direction.down);
            }
            else if ((this as IPrey).Flee(location.x, location.y, predator) == Direction.down)
            {
                possibleDirections.Remove(Direction.up);
            }
            else if ((this as IPrey).Flee(location.x, location.y, predator) == Direction.left)
            {
                possibleDirections.Remove(Direction.right);
            }
            else if ((this as IPrey).Flee(location.x, location.y, predator) == Direction.right)
            {
                possibleDirections.Remove(Direction.left);
            }

            Direction move = (this as IPrey).Flee(location.x, location.y, "cat");
            Game.Move(this, move, 1);
        }

        /* Note that our mouse is (so far) a teeny bit more strategic than our cat.
         * The mouse looks for cats and tries to run in the opposite direction to
         * an empty spot, but if it finds that it can't go that way, it looks around
         * some more. However, the mouse currently still has a major weakness! He
         * will ONLY run in the OPPOSITE direction from a cat! The mouse won't (yet)
         * consider running to the side to escape! However, we have laid out a better
         * foundation here for intelligence, since we actually check whether our escape
         * was succcesful -- unlike our cats, who just assume they'll get their prey!
         */
        //public void Flee()
        //{
        //    Random random = new Random();
        //    List<Direction> possibleDirections = new List<Direction> { Direction.up, Direction.down, Direction.left, Direction.right };
        //    List<Direction> secondDirections = new List<Direction> { Direction.up, Direction.down, Direction.left, Direction.right };

        //    if (Game.Seek(location.x, location.y, Direction.up, "cat", 1) > 0)
        //    {
        //        possibleDirections.Remove(Direction.up);
        //    }
        //    if (Game.Seek(location.x, location.y, Direction.down, "cat", 1) > 0)
        //    {
        //        possibleDirections.Remove(Direction.down);
        //    }
        //    if (Game.Seek(location.x, location.y, Direction.left, "cat", 1) > 0)
        //    {
        //        possibleDirections.Remove(Direction.left);
        //    }
        //    if (Game.Seek(location.x, location.y, Direction.right, "cat", 1) > 0)
        //    {
        //        possibleDirections.Remove(Direction.right);
        //    }

        //    if (possibleDirections.Count > 0 && possibleDirections.Count < 4)
        //    {
        //        Direction moveDirection = possibleDirections[random.Next(possibleDirections.Count)];
        //        Game.Move(this, moveDirection, 1);
        //        int nextX;
        //        int nextY;
        //        if (moveDirection == Direction.up)
        //        {
        //            nextX = location.x;
        //            nextY = location.y - 1;
        //            if (IsNextSafe(nextX, nextY))
        //            {
        //                Game.Move(this, moveDirection, 1);
        //            }
        //            else
        //            {
        //                secondDirections.Remove(Direction.down);
        //                if (Game.Seek(location.x, location.y, Direction.up, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.up);
        //                }
        //                if (Game.Seek(location.x, location.y, Direction.down, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.down);
        //                }
        //                if (Game.Seek(location.x, location.y, Direction.left, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.left);
        //                }
        //                if (Game.Seek(location.x, location.y, Direction.right, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.right);
        //                }

        //                if (secondDirections.Count > 0)
        //                {
        //                    Direction nextDirection = secondDirections[random.Next(secondDirections.Count)];
        //                    Game.Move(this, nextDirection, 1);
        //                }
        //            }
        //        }
        //        if (moveDirection == Direction.down)
        //        {
        //            nextX = location.x;
        //            nextY = location.y + 1;
        //            if (IsNextSafe(nextX, nextY))
        //            {
        //                Game.Move(this, moveDirection, 1);
        //            }
        //            else
        //            {
        //                secondDirections.Remove(Direction.up);
        //                if (Game.Seek(location.x, location.y, Direction.up, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.up);
        //                }
        //                if (Game.Seek(location.x, location.y, Direction.down, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.down);
        //                }
        //                if (Game.Seek(location.x, location.y, Direction.left, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.left);
        //                }
        //                if (Game.Seek(location.x, location.y, Direction.right, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.right);
        //                }

        //                if (secondDirections.Count > 0)
        //                {
        //                    Direction nextDirection = secondDirections[random.Next(secondDirections.Count)];
        //                    Game.Move(this, nextDirection, 1);
        //                }
        //            }
        //        }
        //        if (moveDirection == Direction.left)
        //        {
        //            nextX = location.x - 1;
        //            nextY = location.y;
        //            if (IsNextSafe(nextX, nextY))
        //            {
        //                Game.Move(this, moveDirection, 1);
        //            }
        //            else
        //            {
        //                secondDirections.Remove(Direction.right);
        //                if (Game.Seek(location.x, location.y, Direction.up, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.up);
        //                }
        //                if (Game.Seek(location.x, location.y, Direction.down, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.down);
        //                }
        //                if (Game.Seek(location.x, location.y, Direction.left, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.left);
        //                }
        //                if (Game.Seek(location.x, location.y, Direction.right, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.right);
        //                }

        //                if (secondDirections.Count > 0)
        //                {
        //                    Direction nextDirection = secondDirections[random.Next(secondDirections.Count)];
        //                    Game.Move(this, nextDirection, 1);
        //                }
        //            }
        //        }
        //        if (moveDirection == Direction.right)
        //        {
        //            nextX = location.x + 1;
        //            nextY = location.y;
        //            if (IsNextSafe(nextX, nextY))
        //            {
        //                Game.Move(this, moveDirection, 1);
        //            }
        //            else
        //            {
        //                secondDirections.Remove(Direction.left);
        //                if (Game.Seek(location.x, location.y, Direction.up, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.up);
        //                }
        //                if (Game.Seek(location.x, location.y, Direction.down, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.down);
        //                }
        //                if (Game.Seek(location.x, location.y, Direction.left, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.left);
        //                }
        //                if (Game.Seek(location.x, location.y, Direction.right, "cat", 1) > 0)
        //                {
        //                    secondDirections.Remove(Direction.right);
        //                }

        //                if (secondDirections.Count > 0)
        //                {
        //                    Direction nextDirection = secondDirections[random.Next(secondDirections.Count)];
        //                    Game.Move(this, nextDirection, 1);
        //                }
        //            }
        //        }
        //    }
        //}

        //private bool IsNextSafe(int x, int y)
        //{
        //    if (x < 0 || y < 0 || x >= Game.numCellsX || y >= Game.numCellsY
        //        || Game.animalZones[y][x].occupant != null || Game.animalZones[y][x].occupant.species == "cat")
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}

