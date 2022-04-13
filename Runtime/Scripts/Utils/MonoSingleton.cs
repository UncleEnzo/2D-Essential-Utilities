using UnityEngine;

namespace Nevelson.Utils
{
    /// <summary>
    /// Inherit from this base class to create a singleton.
    /// e.g. public class MyClassName : Singleton<MyClassName> {}

    /// Taken from Unity3d wiki: http://wiki.unity3d.com/index.php?title=Singleton
    /// Creative commons license; will have to give credit
    /// </summary>
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {

        // Check to see if we're about to be destroyed.
        private static bool m_ShuttingDown = false;

        private static object m_Lock = new object();
        private static T m_Instance;
        public static bool IsInitialized { get; set; }

        protected void CreateSingletonOnAwake(T singletonScript)
        {
            if (m_Instance != null && m_Instance != singletonScript)
            {
                Destroy(gameObject);
            }
            else
            {
                m_Instance = singletonScript;
                DontDestroyOnLoad(gameObject);
            }
        }

        /// <summary>
        /// Access singleton instance through this property.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (m_ShuttingDown)
                {
                    Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                        "' already destroyed. Returning null.");
                    return null;
                }

                lock (m_Lock)
                {
                    if (m_Instance == null)
                    {
                        // Search for existing instance.
                        m_Instance = (T)FindObjectOfType(typeof(T));

                        // Create new instance if one doesn't already exist.
                        if (m_Instance == null)
                        {
                            // Need to create a new GameObject to attach the singleton to.
                            var singletonObject = new GameObject();
                            m_Instance = singletonObject.AddComponent<T>();
                            singletonObject.name = typeof(T).ToString() + " (Singleton)";

                            // Make instance persistent.
                            DontDestroyOnLoad(singletonObject);
                        }
                    }
                    return m_Instance;
                }
            }
        }

        private void OnApplicationQuit()
        {
            m_ShuttingDown = true;
        }

        private void OnDestroy()
        {
            m_ShuttingDown = true;
        }
    }
}