using UnityEngine;
using UnityEngine.SceneManagement;

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
            Object systems = Resources.Load("Systems");
            if(systems == null)
            {
                Debug.LogError("Could not find the systems gameobject in resources folder.  Copy the Systems Gameobject from Packages > 2D Essential Utilities > Runtime > ResourceObjects > Systems into the top level of your resources folder");
                return;
            }

            Object.DontDestroyOnLoad(Object.Instantiate(systems));
        }
    }
}