using UnityEngine;
using static Nevelson.Utils.Enums;

namespace Nevelson.Utils
{
    public abstract class ResettableSO : ScriptableObject, IResetBeforeScene
    {
        [SerializeField] protected OnSceneLoad onSceneLoad = OnSceneLoad.PERSIST;

        protected abstract void ResetValue();

        public void Reset()
        {
            if (onSceneLoad == OnSceneLoad.RESET)
            {
                ResetValue();
            }
        }
    }
}