using System;
using ZooKeeperSimpleNET6Fix;

namespace ZooManager
{
    public class Cat : Animal, IPredator, IPrey
    {
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
            if ((this as IPrey).Flee(this, location.x, location.y, "rapter"))
            {
                Direction move = (this as IPrey).Flee1(location.x, location.y, "rapter");
                Game.Move(this, move, 1);
            }
            else if ((this as IPredator).Hunt(this, location.x, location.y))
            {
                // hunt prey
            }
        }

        /* Note that our cat is currently not very clever about its hunting.
         * It will always try to attack "up" and will only seek "down" if there
         * is no mouse above it. This does not affect the cat's effectiveness
         * very much, since the overall logic here is "look around for a mouse and
         * attack the first one you see." This logic might be less sound once the
         * cat also has a predator to avoid, since the cat may not want to run in
         * to a square that sets it up to be attacked!
         */
    }
}

