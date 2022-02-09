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
        /// <summary>
        /// Updates the position of food to random coord within playingfield.
        /// </summary>
        public override void Update()
        {
            Random rnd = new Random();
            this.Position.X = rnd.Next(2, GameWorld.getMapWidth()-2);
            this.Position.Y = rnd.Next(2, GameWorld.getMapHeight()-2);
        }
    }
}