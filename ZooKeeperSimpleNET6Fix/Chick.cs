using System;
namespace ZooManager
{
	public class Chick : Bird
	{
		public Chick(string name)
		{
            emoji = "🐥";
            species = "chick";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = new Random().Next(6, 10);
        }

        public override void Activate()
        {
            base.Activate();
            Flee();
        }

        public void Flee()
        {
            if (Game.Seek(location.x, location.y, Direction.up, "cat", 1) > 0)
            {
                if (Game.Retreat(this, Direction.down)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.down, "cat", 1) > 0)
            {
                if (Game.Retreat(this, Direction.up)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.left, "cat", 1) > 0)
            {
                if (Game.Retreat(this, Direction.right)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.right, "cat", 1) > 0)
            {
                if (Game.Retreat(this, Direction.left)) return;
            }
        }
    }
}

