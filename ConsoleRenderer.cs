using System;
using System.Collections.Generic;
using System.Text;

namespace GruppInlUpp2kelett
{
    class ConsoleRenderer
    {
        private GameWorld world;

        public ConsoleRenderer(GameWorld gameWorld)
        {
            // Try Catch to work on Mac.
            try
            {
                Console.SetWindowSize(GameWorld.getMapWidth(), GameWorld.getMapHeight());
                Console.SetBufferSize(GameWorld.getMapWidth(), GameWorld.getMapHeight());
            }
            catch (PlatformNotSupportedException)
            {
                //notsupportedonsomeplatforms
            }

            world = gameWorld;
        }
        /// <summary>
        /// Clears the screen then writes ponits and all objects.
        /// </summary>
        public void Render()
        {
            Console.Clear();

            Console.WriteLine(world.getPoints());
            //displays all objects to create the snake and food in the terminal
            foreach (var obj in world.gameObjects)
            {
                if (obj is Tail)
                {
                    Console.ForegroundColor = GetRandomConsoleColor();
                    Console.SetCursorPosition((int)obj.Position.X, (int)obj.Position.Y);
                    
                    Console.Write(obj.Appearance);
                    Console.ForegroundColor = ConsoleColor.White;
                    
                }
                else
                {
                    Console.SetCursorPosition((int)obj.Position.X, (int)obj.Position.Y);

                    Console.Write(obj.Appearance);
                }
            }
            Console.SetCursorPosition(0, 0);
        }
        private static Random rng = new Random();
        /// <summary>
        /// returns a random color for the tail objects
        /// </summary>
        /// <returns></returns>
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(rng.Next(consoleColors.Length));
        }
    }
}
