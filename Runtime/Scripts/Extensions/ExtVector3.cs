using UnityEngine;

namespace Nevelson.Utils
{
    public static class ExtVector3
    {
        /// <summary>
        /// Gets the X,Y Vector2 of this Vector3.
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Returns Vector2 conversion of the Vector3</returns>
        public static Vector2 Get2D(this Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }
    }
}