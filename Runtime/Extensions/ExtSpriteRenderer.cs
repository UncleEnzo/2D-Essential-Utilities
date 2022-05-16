using UnityEngine;

namespace Nevelson.Utils
{
    public static class ExtSpriteRenderer
    {
        /// <summary>
        /// Flips the sprite if the look at point is to the left of the sprite renderer. If they are equal on the horizontal axis, it will prefer to stay unflipped flip 
        /// </summary>
        /// <param name="spriteRenderer"></param>
        /// <param name="lookAtPoint"></param>
        public static bool OrientZeroPreferDir(this SpriteRenderer spriteRenderer, Vector2 lookAtPoint, bool isDefaultRight = true)
        {
            if (lookAtPoint == null)
            {
                Debug.LogWarning("Look at point is null");
                return spriteRenderer.flipX;
            }
            float dirX = lookAtPoint.x - spriteRenderer.transform.Position2D().x;
            if (dirX >= 0)
            {
                return spriteRenderer.flipX = !isDefaultRight;
            }
            else
            {
                return spriteRenderer.flipX = isDefaultRight;
            }
        }

        /// <summary>
        /// Flips the sprite if the look at point is to the left of the sprite renderer. If they are equal on the horizontal axis, it will remain in the state that it's currently in.
        /// </summary>
        /// <param name="spriteRenderer"></param>
        /// <param name="lookAtPoint"></param>
        public static bool OrientNoDirZeroPreference(this SpriteRenderer spriteRenderer, Vector2 lookAtPoint, bool isDefaultRight = true)
        {
            if (lookAtPoint == null)
            {
                Debug.LogWarning("Look at point is null");
                return spriteRenderer.flipX;
            }
            float dirX = lookAtPoint.x - spriteRenderer.transform.Position2D().x;
            if (dirX > 0)
            {
                return spriteRenderer.flipX = !isDefaultRight;
            }
            else if (dirX < 0)
            {
                return spriteRenderer.flipX = isDefaultRight;
            }
            else
            {
                return spriteRenderer.flipX;
            }
        }
    }
}