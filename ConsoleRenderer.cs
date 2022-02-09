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
            // TODO Konfigurera Console-fönstret enligt världens storlek
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

        public void Render()
        {
            Console.Clear();
            


            // TODO Rendera spelvärlden (och poängräkningen) t.ex. såhär:
            Console.WriteLine(world.getPoints());
            for (int i = 1; i < GameWorld.MapHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("|");
                Console.SetCursorPosition(GameWorld.MapWidth, i);
                Console.WriteLine("|");
            }
            for (int i = 0; i < GameWorld.MapWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("-");
                Console.SetCursorPosition(i, GameWorld.MapHeight);
                Console.WriteLine("-");
            }



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
        //GameWorld.MapWidth + 3
     
    }
}
