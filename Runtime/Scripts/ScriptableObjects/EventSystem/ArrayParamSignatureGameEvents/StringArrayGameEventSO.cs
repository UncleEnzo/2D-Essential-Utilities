using UnityEngine;
using UnityEngine.Events;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "StringArrayGameEvent", menuName = "Events/MultiParam/String Array Game Event")]
    public class StringArrayGameEventSO : ScriptableObject
    {
        public UnityAction<string[]> OnEventRaised;

        public void RaiseEvent(string[] value)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(value);
            }
        }
    }
}