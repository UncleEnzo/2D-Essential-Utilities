using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nevelson.Utils
{
    public class SceneResettableSystem : MonoSingleton<SceneResettableSystem>
    {
        ResettableSO[] resettableSOs = null;

        private void Awake()
        {
            SceneManager.sceneLoaded += CleanUp;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= CleanUp;
        }

        private void CleanUp(Scene scene, LoadSceneMode loadMode)
        {
            if (loadMode == LoadSceneMode.Additive)
            {
                return;
            }

            Debug.Log("Resetting All Resettable Scriptable Objects");
            if(resettableSOs == null)
            {
                resettableSOs = Resources.LoadAll<ResettableSO>("/");
            }

            foreach (ResettableSO resettable in resettableSOs)
            {
                resettable.Reset();
            }
        }
    }
}