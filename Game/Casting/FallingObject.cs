namespace Greed.Game.Casting
{
    /// <summary>
    /// <para>An item of cultural or historical interest.</para>
    /// <para>
    /// The responsibility of an Artifact is to provide a message about itself.
    /// </para>
    /// </summary>
    public class FallingObject : Actor
    {
        private int score = 0;
        /// <summary>
        /// Constructs a new instance of an falling object.
        /// </summary>
        public FallingObject()
        {
            Point vel = new Point(0, -1);
            SetVelocity(vel);
        }

        /// <summary>
        /// Gets the falling object's score.
        /// </summary>
        /// <returns>The message.</returns>
        public int GetScore()
        {
            return score;
        }

        /// <summary>
        /// Sets the falling object's score to the given value.
        /// </summary>
        /// <param name="score">The given score.</param>
        public void SetScore(int score)
        {
            this.score = score;
        }
    }
}