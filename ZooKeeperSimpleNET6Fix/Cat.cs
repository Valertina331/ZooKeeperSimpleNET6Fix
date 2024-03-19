using System;

namespace ZooManager
{
    public class Cat : Animal
    {
        private bool move;
        public Cat(string name)
        {
            emoji = "🐱";
            species = "cat";
            this.name = name;
            reactionTime = new Random().Next(1, 6); // reaction time 1 (fast) to 5 (medium)Cat
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a cat. Meow.");
            move = false;
            Flee();
            Hunt();
        }

        /* Note that our cat is currently not very clever about its hunting.
         * It will always try to attack "up" and will only seek "down" if there
         * is no mouse above it. This does not affect the cat's effectiveness
         * very much, since the overall logic here is "look around for a mouse and
         * attack the first one you see." This logic might be less sound once the
         * cat also has a predator to avoid, since the cat may not want to run in
         * to a square that sets it up to be attacked!
         */
        public void Flee()
        {
            if (Game.Seek(location.x, location.y, Direction.up, "raptor", 1) > 0)
            {
                if (Game.Retreat(this, Direction.down))
                {
                    move = true;
                    return;
                }
            }
            if (Game.Seek(location.x, location.y, Direction.down, "raptor", 1) > 0)
            {
                if (Game.Retreat(this, Direction.up))
                {
                    move = true;
                    return;
                }
            }
            if (Game.Seek(location.x, location.y, Direction.left, "raptor", 1) > 0)
            {
                if (Game.Retreat(this, Direction.right))
                {
                    move = true;
                    return;
                }
            }
            if (Game.Seek(location.x, location.y, Direction.right, "raptor", 1) > 0)
            {
                if (Game.Retreat(this, Direction.left))
                {
                    move = true;
                    return;
                }
            }
        }

        public void Hunt()
        {
            if (Game.Seek(location.x, location.y, Direction.up, "mouse", 1) > 0
                || Game.Seek(location.x, location.y, Direction.up, "chick", 1) > 0)
            {
                Game.Attack(this, Direction.up);
            }
            else if (Game.Seek(location.x, location.y, Direction.down, "mouse", 1) > 0
                || Game.Seek(location.x, location.y, Direction.down, "chick", 1) > 0)
            {
                Game.Attack(this, Direction.down);
            }
            else if (Game.Seek(location.x, location.y, Direction.left, "mouse", 1) > 0
                || Game.Seek(location.x, location.y, Direction.left, "chick", 1) > 0)
            {
                Game.Attack(this, Direction.left);
            }
            else if (Game.Seek(location.x, location.y, Direction.right, "mouse", 1) > 0
                || Game.Seek(location.x, location.y, Direction.right, "chick", 1) > 0)
            {
                Game.Attack(this, Direction.right);
            }
        }
    }
}

