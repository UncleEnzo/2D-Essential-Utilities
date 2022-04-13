using UnityEngine;
using UnityEngine.Events;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "BoolArrayGameEvent", menuName = "Events/MultiParam/Bool Array Game Event")]
    public class BoolArrayGameEventSO : ScriptableObject
    {
        public UnityAction<bool[]> OnEventRaised;

        public void RaiseEvent(bool[] value)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(value);
            }
        }
    }
}