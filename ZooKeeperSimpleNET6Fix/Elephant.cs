using System;
using ZooManager;

namespace ZooKeeperSimpleNET6Fix
{
	public class Elephant : Animal, IPredator, IPrey
	{
		public Elephant(string name)
		{
			emoji = "🐘";
			species = "elephant";
			this.name = name;
			reactionTime = new Random().Next(6, 10);
		}

        public override void Activate()
        {
            base.Activate();
        }

		public bool Hunt()
		{
			return false;
		}
    }
}

