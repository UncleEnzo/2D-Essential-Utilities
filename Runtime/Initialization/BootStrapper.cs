using UnityEngine;

namespace Nevelson.Utils
{
    public static class BootStrapper
    {
        /// <summary>
        /// Methods marked [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] 
        /// are called before the scene has been loaded
        /// Note: Used for resetting ScriptableObjects that reset after each scene
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void ExecuteBeforeSceneLoad()
        {
            Debug.Log("Bootstrapper Resetting All Resettable Scriptable Objects");
            ResettableSO[] resettableSOs = Resources.LoadAll<ResettableSO>("/");
            foreach (ResettableSO resettable in resettableSOs)
            {
                resettable.Reset();
            }
        }
    }
}