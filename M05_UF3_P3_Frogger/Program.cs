using System;
using System.Collections.Generic;
using System.Threading;

namespace M05_UF3_P3_Frogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WindowWidth = Utils.MAP_WIDTH;
            Console.WindowHeight = Utils.MAP_HEIGHT;

            Player player = new Player();

            List<Lane> lanes = new List<Lane>();

            lanes.Add(new Lane(1, true, ConsoleColor.Blue, true, false, 0.3f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(3, false, ConsoleColor.Green, false, false, 0.4f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(5, true, ConsoleColor.Yellow, true, true, 0.5f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(7, false, ConsoleColor.Cyan, false, true, 0.6f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(9, true, ConsoleColor.Magenta, true, false, 0.7f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(11, false, ConsoleColor.Red, false, false, 0.8f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));

            bool running = true;
            Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;

            while (running)
            {
                // Dibujar elementos
                Console.Clear();
                player.Draw(lanes);
                foreach (Lane lane in lanes)
                {
                    lane.Draw();
                }

                // Actualizar elementos
                player.Update(Utils.Input());
                foreach (Lane lane in lanes)
                {
                    lane.Update();
                }

                // Comprobar estado del juego
                gameState = player.Update(Utils.Input(), lanes);
                if (gameState == Utils.GAME_STATE.WIN)
                {
                    Console.Clear();
                    Console.WriteLine("¡Felicidades! Has ganado el juego.");
                    break;
                }
                else if (gameState == Utils.GAME_STATE.LOOSE)
                {
                    Console.Clear();
                    Console.WriteLine("Lo siento, has perdido el juego.");
                    break;
                }

                // Esperar un tiempo antes de la siguiente actualización
                Thread.Sleep(100);
            }

            Console.CursorVisible = true;
        }
    }
}
