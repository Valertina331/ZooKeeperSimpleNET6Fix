using System;
using ZooManager;

namespace ZooKeeperSimpleNET6Fix
{
	public interface IPrey
	{
        public Direction Flee1(int x, int y, string predator)
        {
            Random random = new Random();
            List<Direction> possibleDirections = new List<Direction> { Direction.up, Direction.down, Direction.left, Direction.right };
            int predators = 0;

            if (Game.Seek(x, y, Direction.up, predator, 1) > 0)
            {
                possibleDirections.Remove(Direction.up);
                predators++;
            }
            if (Game.Seek(x, y, Direction.down, predator, 1) > 0)
            {
                possibleDirections.Remove(Direction.down);
                predators++;
            }
            if (Game.Seek(x, y, Direction.left, predator, 1) > 0)
            {
                possibleDirections.Remove(Direction.left);
                predators++;
            }
            if (Game.Seek(x, y, Direction.right, predator, 1) > 0)
            {
                possibleDirections.Remove(Direction.right);
                predators++;
            }

            if (possibleDirections.Count > 0 && predators > 0)
            {
                Direction moveDirection = possibleDirections[random.Next(possibleDirections.Count)];
                return moveDirection;
            }
            else
            {
                return Direction.stay;
            }
        }

        public void TotalFlee(Animal prey, int x, int y, string predator)
        {
            // make the first move
            Random random = new Random();
            Direction move = Flee1(x, y, predator);
            if (Game.Seek(x, y, move, predator, 1) == 0)
            {
                Game.Move(prey, move, 1);
            }

            // make sure the prey will not flee back to the original suqare
            List<Direction> possibleDirections = new List<Direction> { Direction.up, Direction.down, Direction.left, Direction.right };
            if (move == Direction.up)
            {
                possibleDirections.Remove(Direction.down);
            }
            else if (move == Direction.down)
            {
                possibleDirections.Remove(Direction.up);
            }
            else if (move == Direction.left)
            {
                possibleDirections.Remove(Direction.right);
            }
            else if (move == Direction.right)
            {
                possibleDirections.Remove(Direction.left);
            }

            // if the mouse can countinue moving, the direction will not change,
            // if cannot, it will choose a possible direction randomly.
            if (Game.Seek(x, y, move, predator, 2) == 0)
            {
                Game.Move(prey, move, 1);
            }
            else if (possibleDirections.Count > 0)
            {
                Direction moveDirection = possibleDirections[random.Next(possibleDirections.Count)];
                Game.Move(prey, moveDirection, 1);
            }
        }

        // will not use in mouse
        public bool Flee(Animal prey, int x, int y, string predator)
        {
            if (Game.Seek(x, y, Direction.up, predator, 1) > 0)
            {
                if (Game.Retreat(prey, Direction.down))
                {
                    return true;
                }
            }
            if (Game.Seek(x, y, Direction.down, predator, 1) > 0)
            {
                if (Game.Retreat(prey, Direction.up))
                {
                    return true;
                }
            }
            if (Game.Seek(x, y, Direction.left, predator, 1) > 0)
            {
                if (Game.Retreat(prey, Direction.right))
                {
                    return true;
                }
            }
            if (Game.Seek(x, y, Direction.right, predator, 1) > 0)
            {
                if (Game.Retreat(prey, Direction.left))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

