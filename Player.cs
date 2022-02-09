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

        public void Update(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:

                    Position.X++;
                    //this.Position.X = this.Position.X+1;
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
            if(Position.X <= 1)
            {
                Position.X = (GameWorld.MapWidth-1);
            }
            else if(Position.X > (GameWorld.MapWidth -1))
            {
                Position.X = 1;
            }
            else if(Position.Y >= (GameWorld.MapHeight-1))
            {
                Position.Y = 1;
            }
            else if(Position.Y <= 1)
            {
                Position.Y = (GameWorld.MapHeight - 2);
            }
        }
        public Direction getDirection()
        {
            return Direction;
        }
        public Position getPosition()
        {
            return Position;
        }
        public override void Update()
        {
            
        }
    }
}