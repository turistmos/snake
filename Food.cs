using System;

namespace GruppInlUpp2kelett 
{
    public class Food : GameObject
    {
        public Food(Position position, char appearence)
        {
            this.Position = position;
            this.Appearance = appearence;
        }
        public override void Update()
        {
            Random rnd = new Random();
            this.Position.X = rnd.Next(2, 18);
            this.Position.Y = rnd.Next(2, 18);
        }
    }
}