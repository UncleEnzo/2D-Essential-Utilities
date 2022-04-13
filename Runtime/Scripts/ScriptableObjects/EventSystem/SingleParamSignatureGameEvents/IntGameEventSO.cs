using UnityEngine;
using UnityEngine.Events;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "IntGameEvent", menuName = "Events/SingleParam/Int Game Event")]
    public class IntGameEventSO : ScriptableObject
    {
        public UnityAction<int> OnEventRaised;

        public void RaiseEvent(int value)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(value);
            }
        }
    }
}