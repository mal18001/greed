using System.Collections.Generic;
using Greed.Game.Casting;
using Greed.Game.Services;
using System;


namespace Greed.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        public int score = 0;
        private KeyboardService _keyboardService = null;
        private VideoService _videoService = null;

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this._keyboardService = keyboardService;
            this._videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            _videoService.OpenWindow();
            while (_videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            _videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>

        private void GetInputs(Cast cast)
        {
            List<Actor> falling_object = cast.GetActors("falling_object");
            foreach (Actor actor in falling_object)
            {
                Point objvelocity = _keyboardService.MoveFalling_objects();
                actor.SetVelocity(objvelocity);
                int maxX = _videoService.GetWidth();
                int maxY = _videoService.GetHeight();
                actor.MoveNext(maxX, maxY);
            }
            Actor robot = cast.GetFirstActor("robot");
            Point velocity = _keyboardService.GetDirection();
            robot.SetVelocity(velocity);
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {

            Actor banner = cast.GetFirstActor("banner");
            Actor robot = cast.GetFirstActor("robot");
            List<Actor> falling_object = cast.GetActors("falling_object");

            banner.SetText($"Score: {score.ToString()}");
            int maxX = _videoService.GetWidth();
            int maxY = _videoService.GetHeight();
            robot.MoveNext(maxX, maxY);

            Random random = new Random();
            foreach (Actor actor in falling_object)
            {

                if (robot.GetPosition().Equals(actor.GetPosition()))
                {
                    Falling_objects falling_objects = (Falling_objects)actor;
                    score += falling_objects.GetScore();
                    banner.SetText($"Score: {score.ToString()}");

                    int x = random.Next(1, 60);
                    int y = 0;
                    Point position = new Point(x, y);
                    position = position.Scale(15);

                    falling_objects.SetPosition(position);
                }
            }
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>

        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            _videoService.ClearBuffer();
            _videoService.DrawActors(actors);
            _videoService.FlushBuffer();
        }

    }
}