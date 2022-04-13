using UnityEngine;
using UnityEngine.Events;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "VoidGameEvent", menuName = "Events/Game Event")]
    public class GameEventSO : ScriptableObject
    {
        public UnityAction OnEventRaised;

        public void RaiseEvent()
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke();
            }
        }
    }
}