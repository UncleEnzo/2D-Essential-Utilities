using UnityEngine;
using UnityEngine.Events;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "BoolGameEvent", menuName = "Events/SingleParam/Bool Game Event")]
    public class BoolGameEventSO : ScriptableObject
    {
        public UnityAction<bool> OnEventRaised;

        public void RaiseEvent(bool value)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(value);
            }
        }
    }
}