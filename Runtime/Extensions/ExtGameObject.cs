using System;
using UnityEngine;

namespace Nevelson.Utils
{
    public static class ExtGameObject
    {
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
    }
}