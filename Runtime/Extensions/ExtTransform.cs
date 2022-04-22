using System.Collections.Generic;
using UnityEngine;

namespace Nevelson.Utils
{
    public static class ExtTransform
    {
        /// <summary>
        /// Takes a list of transforms and returns the one that's closest to this transform.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="transforms"></param>
        /// <returns></returns>
        public static Transform GetClosest(this Transform t, List<Transform> transforms)
        {
            if (transforms.Count <= 0)
            {
                Debug.LogWarning("No Transforms supplied");
                return null;
            }

            Transform closest = transforms[0];
            foreach (var trans in transforms)
            {
                if (Vector2.Distance(trans.Position2D(), t.Position2D()) <
                    Vector2.Distance(closest.Position2D(), t.Position2D()))
                {
                    closest = trans;
                }
            }
            return closest;
        }

        /// <summary>
        /// Takes a list of Vectors and returns the one closest to this transform.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="vectors"></param>
        /// <returns></returns>
        public static Vector2 GetClosest(this Transform t, List<Vector2> vectors)
        {
            if (vectors.Count <= 0)
            {
                Debug.LogWarning("No Transforms supplied");
                return Vector2.zero;
            }

            Vector2 closest = vectors[0];
            foreach (var vector in vectors)
            {
                if (Vector2.Distance(vector, t.Position2D()) <
                    Vector2.Distance(closest, t.Position2D()))
                {
                    closest = vector;
                }
            }
            return closest;
        }

        /// <summary>
        /// Rotates the transform to look at the target world position
        /// </summary>
        /// <param name="t"></param>
        /// <param name="target">What the transform should look at</param>
        public static void LookAt2D(this Transform t, Transform target)
        {
            Vector3 dir = target.Position2D() - t.Position2D();
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            t.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        /// <summary>
        /// Rotates the transform to look at the target world position
        /// </summary>
        /// <param name="t"></param>
        /// <param name="worldPos">Where the transform should look</param>
        public static void LookAt2D(this Transform t, Vector2 worldPos)
        {
            Vector3 dir = worldPos - t.Position2D();
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            t.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


        /// <summary>
        /// Returns all child transforms for the gameobject
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Returns list of children</returns>
        public static List<Transform> GetDirectChildren(this Transform t)
        {
            List<Transform> children = new List<Transform>();
            foreach (Transform tran in t)
            {
                children.Add(tran);
            }
            return children;
        }

        /// <summary>
        /// Returns all child transforms for the gameobject
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Returns list of children</returns>
        public static List<Transform> GetAllChildren(this Transform t)
        {
            List<Transform> children = new List<Transform>();
            foreach (Transform tran in t)
            {
                children.Add(tran);
                List<Transform> subChildren = tran.GetAllChildren();
                foreach (var subChild in subChildren)
                {
                    children.Add(subChild);
                }
            }
            return children;
        }

        /// <summary>
        /// Destroys all children of supplied GO transform, by default destroys after 1 frame delay
        /// </summary>
        /// <param name="t"></param>
        /// <param name="destroyImmediately">if set to true, the children are destroyed same frame.
        ///  This is considered a bad Unity practice</param>
        public static void DestroyAllChildren(this Transform t, bool destroyImmediately = false)
        {
            //When marking for immediate delete, performing a foreach loop will cause the length of the loop to
            //update as you destroy the gameobjects and will always neglect to delete the last few objects
            if (destroyImmediately)
            {
                Transform[] children = t.GetDirectChildren().ToArray();
                for (int i = 0; i < children.Length; i++)
                {
                    MonoBehaviour.DestroyImmediate(children[i].gameObject);
                }
            }
            else
            {
                foreach (Transform child in t)
                {
                    MonoBehaviour.Destroy(child.gameObject);
                }
            }
        }

        /// <summary>
        /// Gets the local scale of the gameobject in 2D.  The Zed axis is assumed to be 1.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector2 LocalScale2D(this Transform t)
        {
            return new Vector3(t.localScale.x, t.localScale.y, 1);
        }

        /// <summary>
        /// Sets the local scale of the gameobject in 2D.  The Zed axis is assumed to be 1.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="localScale2D"></param>
        public static void LocalScale2D(this Transform t, Vector2 localScale2D)
        {
            t.localScale = new Vector3(localScale2D.x, localScale2D.y, 1);
        }

        /// <summary>
        /// Gets the direction from object to target transform.
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Not normalized Vector2</returns>
        public static Vector2 GetNormalizedDirection(this Transform t, Vector2 target)
        {
            return (target - new Vector2(t.position.x, t.position.y)).normalized;
        }

        /// <summary>
        /// Gets the normalized direction from object to target transform.
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Normalized Vector2</returns>
        public static Vector2 GetNormalizedDirection(this Transform t, Transform target)
        {
            return GetNormalizedDirection(t, target.Position2D()).normalized;
        }

        /// <summary>
        /// Gets the world position of the gameobject in 2D.  The Zed axis is assumed to be 0.
        /// </summary>
        /// <param name="t"></param>
        /// <returns>The world position of the gameobject as Vector2</returns>
        public static Vector2 Position2D(this Transform t)
        {
            return t.position;
        }

        /// <summary>
        /// Sets the world position of the gameobject in 2D.  The Zed axis is assumed to be 0.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="position2D">Vector2 position you'd like to place the object</param>
        public static void Position2D(this Transform t, Vector2 position2D)
        {
            t.position = new Vector3(position2D.x, position2D.y, 0);
        }

        /// <summary>
        /// Gets the local position of the gameobject in 2D.  The Zed axis is assumed to be 0.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector2 LocalPosition2D(this Transform t)
        {
            return t.localPosition;
        }

        /// <summary>
        /// Sets the local POSITION of the gameobject in 2D.  The Zed axis is assumed to be 0.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="localPosition2D">Vector2 local position you'd like to place the object</param>
        public static void LocalPosition2D(this Transform t, Vector2 localPosition2D)
        {
            t.localPosition = new Vector3(localPosition2D.x, localPosition2D.y, 0);
        }
    }
}