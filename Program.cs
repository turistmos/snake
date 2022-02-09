using System.Threading;
using GruppInlUpp2kelett;

namespace GruppInlUpp2kelett
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            // Hjälpfunktion för att läsa knapptryckningar
            // utan att bromsa upp spelet, som Console.ReadLine() gör
            ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

            // Initialisera spelet
            const int frameRate = 5;
            GameWorld world = new GameWorld();
            ConsoleRenderer renderer = new ConsoleRenderer(world);

            // Huvudloopen
            bool running = true;
            Direction direction = Direction.Left;
            while (running)
            {


                // Kom ihåg vad klockan var i början
                DateTime before = DateTime.Now;

                // Hantera knapptryckningar från användaren

                ConsoleKey key = ReadKeyIfExists();
               
                    switch (key)
                    {
                        case ConsoleKey.Q:
                            running = false;
                            //Quit
                            break;
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            if (direction == Direction.Down)
                            {
                            }
                            else
                            direction = Direction.Up;

                            break;
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            if (direction == Direction.Right)
                            {
                            }
                            else
                            direction = Direction.Left;
                        break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            if (direction == Direction.Up)
                            {
                            }
                            else
                            direction = Direction.Down;
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            if(direction==Direction.Left)
                            {
                            }
                            else
                            direction = Direction.Right;
                            break;
                    }

                

                // Uppdatera världen och rendera om
                // renderer.RenderBlank();
                
                running =world.Update(direction);
                renderer.Render();
                

                // Mät hur lång tid det tog
                double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
                if (frameTime > 0)
                {
                    // Vänta rätt antal millisekunder innan loopens nästa varv
                    Thread.Sleep((int)frameTime);
                }

            }

            Console.WriteLine($"Poäng: {world.getPoints()}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du förlorade!");
            Console.ReadLine();
            
        }
    }
    
   
}
