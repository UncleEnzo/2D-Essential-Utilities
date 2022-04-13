using UnityEngine;
using UnityEngine.Events;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "IntArrayGameEvent", menuName = "Events/MultiParam/Int Array Game Event")]
    public class IntArrayGameEventSO : ScriptableObject
    {
        public UnityAction<int[]> OnEventRaised;

        public void RaiseEvent(int[] value)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(value);
            }
        }
    }
}