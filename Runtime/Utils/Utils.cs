using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Nevelson.Utils.Enums;

namespace Nevelson.Utils
{
    public static class Utils
    {
        /// <summary>
        /// converts a float from range 0 to 1 to logarithmic scaling, which is what the mixer group uses
        /// </summary>
        /// <param name="volume"></param>
        /// <returns></returns>
        public static float ConvertVolumeToLogarithmic(float volume)
        {
            if (volume < 0)
            {
                Debug.LogWarning("Passing in value less than 0, defaulting to 0");
                volume = 0;
            }
            if (volume > 1)
            {
                Debug.LogWarning("Passing in value greater than 1, defaulting to 1");
                volume = 1;
            }
            return Mathf.Log10(volume) * 20;
        }

        /// <summary>
        /// Returns a cardinal direction based on start and end point.
        /// Returns NONE if there is no difference between start and endpoint
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        public static Direction GetCardinalDirection(Vector2 startPoint, Vector2 endPoint)
        {
            Vector2 direction = endPoint - startPoint;
            if (direction.x != 0 && direction.y != 0)
            {
                Debug.LogWarning($"direct is not cardinal, return NONE | direction: {direction} start point: {startPoint} end point: {endPoint}");
                return Direction.NONE;
            }

            if (direction == Vector2.zero)
            {
                return Direction.NONE;
            }
            if (direction.x == 0)
            {
                return direction.y > 0 ? Direction.UP : Direction.DOWN;
            }
            if (direction.y == 0)
            {
                return direction.x > 0 ? Direction.RIGHT : Direction.LEFT;
            }

            Debug.LogWarning($"direct is not cardinal, return NONE | direction: {direction} start point: {startPoint} end point: {endPoint}");
            return Direction.NONE;
        }

        /// <summary>
        /// Formats seconds to a readable time string: minutes : seconds : milliseconds
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string FormatTime(float time)
        {
            if (time < 0)
            {
                return "-" + TimeSpan.FromSeconds(time).ToString(@"mm\:ss\.ff");
            }
            return TimeSpan.FromSeconds(time).ToString(@"mm\:ss\.ff");
        }

        /// <summary>
        /// Strip all punctuation out of a string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string StripPunctuation(string s)
        {
            if (s == null)
            {
                Debug.LogWarning("Supplied string was null, returning empty");
                return "";
            }
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (!char.IsPunctuation(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Improved find components of type that permits finding of interfaces as well
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> FindComponentsOfType<T>()
        {
            List<T> components = new List<T>();
            GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var rootGameObject in rootGameObjects)
            {
                T[] childComponents = rootGameObject.GetComponentsInChildren<T>();
                foreach (var childComponent in childComponents)
                {
                    components.Add(childComponent);
                }
            }
            return components;
        }

        /// <summary>
        /// A continuous lerp to destination.  
        /// Keeps moving until it reaches the exact point.  
        /// Does not go beyond.
        /// </summary>
        /// <param name="lerpTarget"></param>
        /// <param name="endPos"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public static bool LerpToDestination(Transform lerpTarget, Vector2 endPos, float speed)
        {
            float step = speed * Time.deltaTime;
            lerpTarget.Position2D(Vector2.MoveTowards(lerpTarget.Position2D(), endPos, step));
            if (lerpTarget.Position2D() == endPos) return true;
            return false;
        }

        /// <summary>
        /// Finds first child with specified tag using depth first search
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="tag"></param>
        /// <returns>Transform</returns>
        public static Transform FindChildWithTag(Transform parent, string tag)
        {
            foreach (Transform child in parent)
            {
                Transform taggedChild = FindChildWithTag(child, tag);
                if (taggedChild != null) return taggedChild;
                if (child.CompareTag(tag)) return child;
            }
            return null;
        }

        /// <summary>
        /// Finds first child with specified tag using depth first search
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="tag"></param>
        /// <returns>Gameobject</returns>
        public static GameObject FindChildWithTag(GameObject parent, string tag)
        {
            foreach (Transform child in parent.transform)
            {
                Transform taggedChild = FindChildWithTag(child, tag);
                if (taggedChild != null) return taggedChild.gameObject;
                if (child.CompareTag(tag)) return child.gameObject;
            }
            return null;
        }
    }
}
