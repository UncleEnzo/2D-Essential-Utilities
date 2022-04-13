using UnityEngine;
using static Nevelson.Utils.Enums;
using static Nevelson.Utils.RODicts;

namespace Nevelson.Utils
{
    public static class ExtVector2
    {
        /// <summary>
        /// Rotates the vector2 by the supplied amount of degrees.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="degrees"> Accepts positive and negative rotations.</param>
        /// <returns>Vector2 rotated by degrees.</returns>
        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            return Quaternion.Euler(0, 0, degrees) * v;
        }

        /// <summary>
        /// Returns the rotation of a direction.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>Quaternion rotation of a direction</returns>
        public static float GetAngle(this Vector2 direction)
        {
            return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }

        /// <summary>
        /// Returns the rotation of a direction.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>Quaternion rotation of a direction</returns>
        public static Quaternion GetRotation(this Vector2 direction)
        {
            return Quaternion.Euler(new Vector3(0, 0, GetAngle(direction)));
        }

        /// <summary>
        /// Gets the cardinal direction of 2 vectors if they evaluate to an exact cardinal direction.
        /// Vector2.Zero returns true with a direction of none.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static bool TryGetCardinalDirection(this Vector2 start, Vector2 end, out Direction direction)
        {
            Vector2 rawDirection = GetRawDirection(start, end);
            if (rawDirection == Vector2.zero)
            {
                direction = Direction.NONE;
                return true;
            }
            else if (rawDirection == DirectionVector[Direction.UP])
            {
                direction = Direction.UP;
                return true;
            }
            else if (rawDirection == DirectionVector[Direction.DOWN])
            {
                direction = Direction.DOWN;
                return true;
            }
            else if (rawDirection == DirectionVector[Direction.LEFT])
            {
                direction = Direction.LEFT;
                return true;
            }
            else if (rawDirection == DirectionVector[Direction.RIGHT])
            {
                direction = Direction.RIGHT;
                return true;
            }

            direction = Direction.NONE;
            return false;
        }

        /// <summary>
        /// Gets the direction of 2 vectors if they evaluate to an exact direction.
        /// Vector2.Zero returns true with a direction of NONE.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end">end position location of the vector</param>
        /// <param name="direction"></param>
        /// <returns>Returns whether the try get operation was successful.</returns>
        public static bool TryGetDirection(this Vector2 start, Vector2 end, out Direction direction)
        {
            bool isCardinal = TryGetCardinalDirection(start, end, out Direction cardinalDirection);
            if (isCardinal)
            {
                direction = cardinalDirection;
                return isCardinal;
            }

            Vector2 rawDirection = GetRawDirection(start, end);
            if (rawDirection == DirectionVector[Direction.UP_LEFT])
            {
                direction = Direction.UP_LEFT;
                return true;
            }
            else if (rawDirection == DirectionVector[Direction.UP_RIGHT])
            {
                direction = Direction.UP_RIGHT;
                return true;
            }
            else if (rawDirection == DirectionVector[Direction.DOWN_RIGHT])
            {
                direction = Direction.DOWN_RIGHT;
                return true;
            }
            else if (rawDirection == DirectionVector[Direction.DOWN_RIGHT])
            {
                direction = Direction.DOWN_RIGHT;
                return true;
            }

            direction = Direction.NONE;
            return false;
        }

        /// <summary>
        /// Gets the direction from the vector2 to the end position
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static Vector2 GetDirection(this Vector2 start, Vector2 end)
        {
            return end - start;
        }

        /// <summary>
        /// Gets the raw direction from the vector2 to the end position
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static Vector2 GetRawDirection(this Vector2 start, Vector2 end)
        {
            Vector2 direction = GetDirection(start, end);
            //rounding required to avoid absurdly small scientific notation
            //values so small code doesn't even detect it's not 0
            float roundedX = Mathf.Round(direction.x * 100f) / 100f;
            float roundedY = Mathf.Round(direction.y * 100f) / 100f;
            if (direction == Vector2.zero) return direction;

            if (roundedX > 0f)
            {
                direction.x = 1;
            }
            else if (roundedX < 0f)
            {
                direction.x = -1;
            }

            if (roundedY > 0f)
            {
                direction.y = 1;
            }
            else if (roundedY < 0f)
            {
                direction.y = -1;
            }

            return direction;
        }

        /// <summary>
        /// Gets the normalized direction from the vector2 to end position.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static Vector2 GetNormalizedDirection(this Vector2 start, Vector2 end)
        {
            return (end - start).normalized;
        }

        /// <summary>
        /// Checks if this vector 2 is above the worldPos on the vertical axis.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="worldPos"></param>
        /// <returns>True if above.  False if equal or below</returns>
        public static bool IsAbove(this Vector2 v, Vector2 worldPos)
        {
            return worldPos.y - v.y < 0;
        }

        /// <summary>
        /// Checks if this vector 2 is above or exactly on the same point of the vertical axis as the world position
        /// </summary>
        /// <param name="v"></param>
        /// <param name="worldPos"></param>
        /// <returns>True if above or equal. False below position</returns>
        public static bool IsAboveOrOn(this Vector2 v, Vector2 worldPos)
        {
            return worldPos.y - v.y <= 0;
        }

        /// <summary>
        /// Checks if this vector 2 is below the world position on the vertical axis.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="worldPos"></param>
        /// <returns>True if above.  False if equal or above</returns>
        public static bool IsBelow(this Vector2 v, Vector2 worldPos)
        {
            return worldPos.y - v.y > 0;
        }

        /// <summary>
        /// Checks if this vector 2 is below or exactly on the same point of the vertical axis as the world position
        /// </summary>
        /// <param name="v"></param>
        /// <param name="worldPos"></param>
        /// <returns>True if above or equal. False below position</returns>
        public static bool IsBelowOrOn(this Vector2 v, Vector2 worldPos)
        {
            return worldPos.y - v.y >= 0;
        }

        /// <summary>
        /// Checks if this vector 2 is on the right side on the horizontal axis of the world position.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="worldPos"></param>
        /// <returns>True if right.  False if equal or to the left</returns>
        public static bool IsRightOf(this Vector2 v, Vector2 worldPos)
        {
            return worldPos.x - v.x < 0;
        }

        /// <summary>
        /// Checks if this vector 2 is on the right side or exactly on the same point of the horizontal axis as the world position
        /// </summary>
        /// <param name="v"></param>
        /// <param name="worldPos"></param>
        /// <returns>true if right or equal position</returns>
        public static bool IsRightOfOrOn(this Vector2 v, Vector2 worldPos)
        {
            return worldPos.x - v.x <= 0;
        }

        /// <summary>
        /// Checks if this vector 2 is on the left side on the horizontal axis of the world position.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="worldPos"></param>
        /// <returns>True if left.  False if equal or to the right</returns>
        public static bool IsLeftOf(this Vector2 v, Vector2 worldPos)
        {
            return worldPos.x - v.x > 0;
        }

        /// <summary>
        /// Checks if this vector 2 is on the left side or 
        /// exactly on the same point of the horizontal axis as the world position
        /// </summary>
        /// <param name="v"></param>
        /// <param name="worldPos"></param>
        /// <returns>true if left or equal position</returns>
        public static bool IsLeftOfOrOn(this Vector2 v, Vector2 worldPos)
        {
            return worldPos.x - v.x >= 0;
        }
    }
}
