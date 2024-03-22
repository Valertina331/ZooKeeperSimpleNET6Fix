using System;
using ZooManager;

namespace ZooKeeperSimpleNET6Fix
{
	public interface IPredator
	{
		public bool Hunt(Animal predator, int x, int y)
        {
            if (Game.Seek(x, y, Direction.up, "mouse", 1) > 0
                || Game.Seek(x, y, Direction.up, "chick", 1) > 0)
            {
                Game.Attack(predator, Direction.up);
                return true;
            }
            else if (Game.Seek(x, y, Direction.down, "mouse", 1) > 0
                || Game.Seek(x, y, Direction.down, "chick", 1) > 0)
            {
                Game.Attack(predator, Direction.down);
                return true;
            }
            else if (Game.Seek(x, y, Direction.left, "mouse", 1) > 0
                || Game.Seek(x, y, Direction.left, "chick", 1) > 0)
            {
                Game.Attack(predator, Direction.left);
                return true;
            }
            else if (Game.Seek(x, y, Direction.right, "mouse", 1) > 0
                || Game.Seek(x, y, Direction.right, "chick", 1) > 0)
            {
                Game.Attack(predator, Direction.right);
                return true;
            }
            return false;
        }
    }
}

