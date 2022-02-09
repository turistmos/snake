using System;
using System.Collections.Generic;
using System.Text;

namespace GruppInlUpp2kelett
{
    public class GameWorld
    {

        private const int MapWidth = 20;
        private const int MapHeight = 20;
        private int Points { get; set; }
        private Direction direction;

        public List<GameObject> gameObjects = new List<GameObject>();
        List<Player> players = new List<Player>();

        static Position tempPosition = new Position(MapWidth / 2, MapHeight / 2);
        
        Player player = new Player(tempPosition,Direction.Right, '☻');
        static Random rnd = new Random();
        static Position slumpPosition = new Position(rnd.Next(1,18), rnd.Next(1,18));
        Food food = new Food(slumpPosition, '*');

        /// <summary>
        /// Updates direction of player, food and player tail. Contains Point counter and the addition of tail.
        /// </summary>
        /// <param name="direction">Recives direction input.</param>
        /// <returns>Bool, false if collison with tail.</returns>
        public bool Update(Direction direction)
        {
            for (int i = 2; i < gameObjects.Count; i++)
            {
                if ((int)gameObjects[1].Position.X == (int)gameObjects[i].Position.X && (int)gameObjects[1].Position.Y == (int)gameObjects[i].Position.Y)
                {
                    return false;
                }
            }

            //Creates food and player when game starts
            if (!gameObjects.Contains(food))
            {
                
                gameObjects.Add(food);
            }
            if (!gameObjects.Contains(player))
            {
            gameObjects.Add(player);
            players.Add(player);
            }

            //Collision detector with food. Creates new tail, updates food position and add point.
            if ((int)player.Position.X == (int)food.Position.X && (int)player.Position.Y == (int)food.Position.Y)
            {

                Tail newTail = new Tail(new Position(0, 0), '■');
                food.Update();
                
                for (int i =1; i<gameObjects.Count;i++)
                {
                    //gameObject[0] is always a food object.
                    while(gameObjects[0].Position.X == gameObjects[i].Position.X && gameObjects[0].Position.Y == gameObjects[i].Position.Y)
                    {
                        food.Update();
                        
                    }
                    
                }
                Points++;
                gameObjects.Add(newTail);
            }

            Console.CursorVisible = false;
            //Updates position for tail
            for (int i = gameObjects.Count-1; i > 1; i--)
            {
               
                    if (gameObjects[i] is Tail)
                    {
                        gameObjects[i].Position.X = gameObjects[i-1].Position.X;
                        gameObjects[i].Position.Y = gameObjects[i-1].Position.Y;
                    }
            }

            //Updates position for player
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
            return true;
        }

        /// <summary>
        /// Returns all game objects.
        /// </summary>
        /// <returns>List of GameObject type.</returns>
        public List<GameObject> GetGameObjects()
        {
            return gameObjects;
        }
        
        /// <summary>
        /// Returns the score.
        /// </summary>
        /// <returns>Int points.</returns>
        public int getPoints()
        {
            return Points;
        }
        public static int getMapWidth()
        {
            return MapWidth;
        }
        public static int getMapHeight()
        {
            return MapHeight;
        }

    }
}

