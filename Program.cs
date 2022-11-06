using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Greed.Game.Casting;
using Greed.Game.Directing;
using Greed.Game.Services;


namespace Greed
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static string CAPTION = "Greed";
        private static Color WHITE = new Color(255, 255, 255);


        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            // create the banner
            Actor banner = new Actor();
            banner.SetText("");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            // create the player
            Actor player = new Actor();
            player.SetText("#");
            player.SetFontSize(FONT_SIZE);
            player.SetColor(WHITE);
            player.SetPosition(new Point(MAX_X / 2, 585));
            cast.AddActor("player", player);



            // create the artifacts
            Random random = new Random();
            //**CHANGE THE FOR STATEMENT TO A LOOP THAT
            //**WILL BE INFINITE, CHANGE SPEED BASED ON POINTS,
            //**AND END WHEN POINTS ARE TOO LOW
            for (int i = 0; i < 15; i++)
            {
                //REPLACE LINE WITH SPRITE/SYMBOL FOR ROCK OR GEM
                string text = ((char)(42)).ToString();

                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                FallingObject fallingObject = new FallingObject();
                fallingObject.SetText(text);
                fallingObject.SetFontSize(FONT_SIZE);
                fallingObject.SetColor(color);
                fallingObject.SetPosition(position);
                fallingObject.SetScore(1);
                cast.AddActor("fallingObject", fallingObject);
            }
            for (int i = 0; i < 15; i++)
            {
                //REPLACE LINE WITH SPRITE/SYMBOL FOR ROCK OR GEM
                string text = ((char)(111)).ToString();

                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                FallingObject fallingObject = new FallingObject();
                fallingObject.SetText(text);
                fallingObject.SetFontSize(FONT_SIZE);
                fallingObject.SetColor(color);
                fallingObject.SetPosition(position);
                fallingObject.SetScore(-1);
                cast.AddActor("fallingObject", fallingObject);
            }

            // start the game
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(cast);
        }
    }
}