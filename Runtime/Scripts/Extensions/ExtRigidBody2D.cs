using UnityEngine;

namespace Nevelson.Utils
{
    public static class ExtRigidbody2D
    {
        /// <summary>
        /// Predicts future position of the object based on it's current velocity
        /// </summary>
        /// <param name="rb"></param>
        /// <param name="fixedFramesAhead"></param>
        /// <returns>Future position X frames ahead</returns>
        public static Vector2 PredictFuturePos(this Rigidbody2D rb, int fixedFramesAhead)
        {
            if (fixedFramesAhead < 0)
            {
                Debug.LogWarning("Frames supplied is less than 0");
                return rb.transform.Position2D();
            }
            return rb.transform.Position2D() + rb.velocity * (Time.fixedDeltaTime * fixedFramesAhead);
        }

        /// <summary>
        /// Predicts future position of the object based on it's current velocity
        /// Used when the position is derived from a child object than the rigidbody itself.
        /// Ex: Want to use a subchild's position 
        /// </summary>
        /// <param name="rb"></param>
        /// <param name="position"></param>
        /// <param name="fixedFramesAhead"></param>
        /// <returns></returns>
        public static Vector2 PredictFuturePosFromChildPos(this Rigidbody2D rb, Vector2 position, int fixedFramesAhead)
        {
            if (fixedFramesAhead < 0)
            {
                Debug.LogWarning("Frames supplied is less than 0");
                return rb.transform.Position2D();
            }
            return position + rb.velocity * (Time.fixedDeltaTime * fixedFramesAhead);
        }
    }
}