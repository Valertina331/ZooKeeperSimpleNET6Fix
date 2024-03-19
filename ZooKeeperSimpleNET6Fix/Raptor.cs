using System;
namespace ZooManager
{
	public class Raptor : Bird
	{
		public Raptor(string name)
		{
            emoji = "🦅";
            species = "raptor";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = 1;
        }

        public override void Activate()
        {
            base.Activate();
            Hunt();
        }

        public void Hunt()
        {
            if (Game.Seek(location.x, location.y, Direction.up, "cat", 1) > 0
                || Game.Seek(location.x, location.y, Direction.up, "mouse", 1) > 0)
            {
                Game.Attack(this, Direction.up);
            }
            else if (Game.Seek(location.x, location.y, Direction.down, "cat", 1) > 0
                || Game.Seek(location.x, location.y, Direction.down, "mouse", 1) > 0)
            {
                Game.Attack(this, Direction.down);
            }
            else if (Game.Seek(location.x, location.y, Direction.left, "cat", 1) > 0
                || Game.Seek(location.x, location.y, Direction.left, "mouse", 1) > 0)
            {
                Game.Attack(this, Direction.left);
            }
            else if (Game.Seek(location.x, location.y, Direction.right, "cat", 1) > 0
                || Game.Seek(location.x, location.y, Direction.right, "mouse", 1) > 0)
            {
                Game.Attack(this, Direction.right);
            }
        }
    }
}

