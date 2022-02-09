using System;

namespace GruppInlUpp2kelett
{
    public enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }
    public class Player : GameObject
    {
        public Direction Direction;

        public Player(Position position, Direction direction ,Char appearance) 
        {
            this.Position = position;
            this.Direction = direction;
            this.Appearance = appearance;
        }

        /// <summary>
        /// Updates position depending on direction. Changes position to other side of map if wall is struck.
        /// </summary>
        /// <param name="direction"></param>
        public void Update(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    Position.X++;
                    break;
                case Direction.Left:
                    Position.X--;
                    break;
                case Direction.Up:
                    Position.Y--;
                    break;
                case Direction.Down:
                    Position.Y++;
                    break;
            }
            //if the snakes runs into a border it gets to continue on the opposite side
            if(Position.X < 1)
            {
                Position.X = (GameWorld.getMapWidth()-1);
            }
            else if(Position.X > (GameWorld.getMapWidth() -1))
            {
                Position.X = 1;
            }
            else if(Position.Y > (GameWorld.getMapHeight()-1))
            {
                Position.Y = 1;
            }
            else if(Position.Y < 1)
            {
                Position.Y = (GameWorld.getMapHeight()-1 );
            }
        }
       
        
        public override void Update()
        {
            throw new NotImplementedException();    
        }
    }
}