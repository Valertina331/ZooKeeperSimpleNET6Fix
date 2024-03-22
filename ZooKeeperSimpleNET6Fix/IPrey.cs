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

