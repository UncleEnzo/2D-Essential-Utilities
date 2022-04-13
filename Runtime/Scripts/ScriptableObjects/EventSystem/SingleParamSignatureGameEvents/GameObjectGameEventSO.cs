using UnityEngine;
using UnityEngine.Events;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "GOGameEvent", menuName = "Events/SingleParam/GO Game Event")]
    public class GameObjectGameEventSO : ScriptableObject
    {
        public UnityAction<GameObject> OnEventRaised;

        public void RaiseEvent(GameObject value)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(value);
            }
        }
    }
}