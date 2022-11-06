namespace Greed.Game.Casting
{
    /// <summary>
    /// <para>A rock.</para>
    /// <para>
    /// The responsibility of a rock is to make the player lose points.
    /// </para>
    /// </summary>
    public class Rock : FallingObject
    {
        /// <summary>
        /// Constructs a new instance of a rock and sets the score to -1
        /// </summary>
        public Rock()
        {
            SetScore(-1);
        }
    }
}