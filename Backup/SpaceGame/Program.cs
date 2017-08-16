using System;

namespace SpaceGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (SpaceGame game = new SpaceGame())
            {
                game.Run();
            }
        }
    }
}

