using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Nevelson.Utils
{
    public static class ExtGameObject
    {
        /// <summary>
        /// Call from the gameobject you want to add the component too.  Supply the component you want to copy.
        /// Example usage:
        ///  Health myHealth = gameObject.AddComponent<Health>(enemy.health);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="go"></param>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        public static T AddCopiedComponent<T>(this GameObject go, T toAdd) where T : Component
        {
            return go.AddComponent<T>().GetCopyOf(toAdd);
        }

        /// <summary>
        /// Call this method in the Update, OnDisable, or OnDestroy function to ensure that the
        /// action you provide is only called while the scene is loaded.
        /// 
        /// This method prevents the action from happening while a scene is unloading.  
        /// Useful for avoiding calling runtime specific OnDestory functions 
        /// while the scene is being cleaned.
        /// 
        /// Ex. OnDestroy if you call a function like: SetUIScore++, you do not want this happening
        /// when the scene is being cleaned up and destroying all objects.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="action"></param>
        public static void WhileSceneLoaded(this GameObject gameObject, Action action)
        {
            if (gameObject.scene.isLoaded)
            {
                action();
            }
        }

        /// <summary>
        /// Call this method in the OnDisable, or OnDestroy function if you only want the action
        /// to run while the scene is being cleaned up and unloaded, but not when the component 
        /// is destroyed by other means.
        /// 
        /// Ex. OnDestroy if you call a function like: ResetPlayerScore(), 
        /// you do not want this happening if the player dies and respawns without gameover,
        /// but you do want to reset the score when the move to the next level.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="action"></param>
        public static void WhenSceneUnloads(this GameObject gameObject, Action action)
        {
            if (!gameObject.scene.isLoaded)
            {
                action();
            }
        }

        /// <summary>
        /// Takes a list of gameobjects and returns the one that's closest to this gameobject.
        /// Will return first on the list if there are multiple values at the same distance.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="transforms"></param>
        /// <returns></returns>
        public static GameObject GetClosest(this GameObject g, List<GameObject> gameObjects)
        {
            if (gameObjects.Count <= 0)
            {
                Debug.LogWarning("No GameObjects supplied");
                return null;
            }

            GameObject closest = gameObjects[0];
            foreach (var gameObject in gameObjects)
            {
                if (Vector2.Distance(gameObject.transform.Position2D(), g.transform.Position2D()) <
                    Vector2.Distance(closest.transform.Position2D(), g.transform.Position2D()))
                {
                    closest = gameObject;
                }
            }
            return closest;
        }

        /// <summary>
        /// Takes a list of transforms and returns the one that's closest to this gameobject.
        /// Will return first on the list if there are multiple values at the same distance.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="transforms"></param>
        /// <returns></returns>
        public static Transform GetClosest(this GameObject g, List<Transform> transforms)
        {
            if (transforms.Count <= 0)
            {
                Debug.LogWarning("No Transforms supplied");
                return null;
            }

            Transform closest = transforms[0];
            foreach (var trans in transforms)
            {
                if (Vector2.Distance(trans.Position2D(), g.transform.Position2D()) <
                    Vector2.Distance(closest.Position2D(), g.transform.Position2D()))
                {
                    closest = trans;
                }
            }
            return closest;
        }

        /// <summary>
        /// Takes a list of Vectors and returns the one closest to this gameobject.
        /// Will return first on the list if there are multiple values at the same distance.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="vectors"></param>
        /// <returns></returns>
        public static Vector2 GetClosest(this GameObject g, List<Vector2> vectors)
        {
            if (vectors.Count <= 0)
            {
                Debug.LogWarning("No Vectors supplied");
                return Vector2.zero;
            }

            Vector2 closest = vectors[0];
            foreach (var vector in vectors)
            {
                if (Vector2.Distance(vector, g.transform.Position2D()) <
                    Vector2.Distance(closest, g.transform.Position2D()))
                {
                    closest = vector;
                }
            }
            return closest;
        }

        private static T GetCopyOf<T>(this Component comp, T other) where T : Component
        {
            Type type = comp.GetType();
            if (type != other.GetType())
            {
                return null; // type mis-match
            }
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
            PropertyInfo[] pinfos = type.GetProperties(flags);
            foreach (var pinfo in pinfos)
            {
                if (pinfo.CanWrite)
                {
                    try
                    {
                        pinfo.SetValue(comp, pinfo.GetValue(other, null), null);
                    }
                    catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
                }
            }
            FieldInfo[] finfos = type.GetFields(flags);
            foreach (var finfo in finfos)
            {
                finfo.SetValue(comp, finfo.GetValue(other));
            }
            return comp as T;
        }
    }
}