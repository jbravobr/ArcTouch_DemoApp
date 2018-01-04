using Humanizer;

namespace ArcTouch.TestApp
{
    public class StringOperations : IStringOperations
    {
        /// <summary>
        /// Truncate the specified text and length.
        /// </summary>
        /// <returns>The truncate.</returns>
        /// <param name="text">Text.</param>
        /// <param name="length">Length.</param>
        public string Truncate(string text, int length)
        {
            return text.Truncate(length);
        }
    }
}