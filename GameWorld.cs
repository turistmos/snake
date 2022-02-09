using System;
using System.Collections.Generic;
using System.Text;

namespace GruppInlUpp2kelett
{
    public class GameWorld
    {
        // TODO
        private const ConsoleColor BorderColor = ConsoleColor.Gray;
        public const int MapWidth = 20;
        public const int MapHeight = 20;
        public const int ScreenWidth = MapWidth ;
        public const int ScreenHeigth = MapHeight;
        public int Points { get; set; }
        public Direction direction;

        public List<GameObject> gameObjects = new List<GameObject>();
        List<Player> players = new List<Player>();

        static Position tempPosition = new Position(MapWidth / 2, MapHeight / 2);
        
        Player player = new Player(tempPosition,Direction.Right, '☻');
        static Random rnd = new Random();
        static Position slumpPosition = new Position(rnd.Next(1,19), rnd.Next(1,19));
        Food food = new Food(slumpPosition, '*');

        public bool Update(Direction direction)
        {
            for (int i = 2; i < gameObjects.Count; i++)
            {
                if ((int)gameObjects[1].Position.X == (int)gameObjects[i].Position.X && (int)gameObjects[1].Position.Y == (int)gameObjects[i].Position.Y)
                {
                    return false;
                }
            }



            if (!gameObjects.Contains(food))
            {
                gameObjects.Add(food);
            }
            if (!gameObjects.Contains(player))
            {
            gameObjects.Add(player);
            players.Add(player);
                                    
            }
            if ((int)player.Position.X==(int)food.Position.X && (int)player.Position.Y == (int)food.Position.Y)
            {
                
                Tail newTail = new Tail(new Position(0,0), '■');
                food.Update();
                Points++;
                gameObjects.Add(newTail);
            }
            

            // TODO
            Console.CursorVisible = false;

            
            //DrawBorder();
            //oldPosx.Add(posx);
            //oldPosy.Add(posy);

            for (int i = gameObjects.Count-1; i > 1; i--)
            {
               
                    if (gameObjects[i] is Tail)
                    {
                    
                        gameObjects[i].Position.X = gameObjects[i-1].Position.X;
                        gameObjects[i].Position.Y = gameObjects[i-1].Position.Y;

                    }

                   
                

            }


            int numberOfPlayers = gameObjects.OfType<Player>().Count();
            foreach (var gameObject in gameObjects)
            {
                if (gameObject is Player)
                {

                    Player temp = (Player)gameObject;
                    temp.Update(direction);
                    break;
                }

            }
            //bool running = IfCollide(gameObjects);
            return true;

        }
        public List<GameObject> GetGameObjects()
        {
            return gameObjects;
        }
        
        static void DrawBorder()
        {
            for (int i = 0; i < MapWidth; i++)
            {
                new Pixel(i, 0, BorderColor).Draw();
                new Pixel(i, MapHeight - 1, BorderColor).Draw();
            }
            
            for (int i = 0; i < MapHeight; i++)
            {
                new Pixel(0, i, BorderColor).Draw();
                new Pixel(MapWidth - 1, i, BorderColor).Draw();
            }
        }
        public int getPoints()
        {
            return Points;
        }

        //public bool IfCollide(List<GameObject>gameObject)
        //{

        //    Player player = gameObjects[1];
        //    for (int i = 2; i < gameObjects.Count; i++)
        //    {
        //        if ((int)player.Position.X == (int)gameObjects[i].Position.X && (int)player.Position.Y == (int)gameObjects[i].Position.Y)
        //        {

        //            return true;
        //        }
        //    }

        //    return false;
                

            
        //}
    }
}

