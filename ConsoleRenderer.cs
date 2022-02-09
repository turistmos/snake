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
                Console.SetWindowSize(GameWorld.ScreenWidth, GameWorld.ScreenHeigth);
                Console.SetBufferSize(GameWorld.ScreenWidth, GameWorld.ScreenHeigth);
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

            foreach (var obj in world.gameObjects)
            {
                if (obj is Tail)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
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
     
    }
}
