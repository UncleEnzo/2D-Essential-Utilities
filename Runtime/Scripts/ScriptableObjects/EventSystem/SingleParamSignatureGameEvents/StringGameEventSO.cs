using UnityEngine;
using UnityEngine.Events;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "StringGameEvent", menuName = "Events/SingleParam/String Game Event")]
    public class StringGameEventSO : ScriptableObject
    {
        public UnityAction<string> OnEventRaised;

        public void RaiseEvent(string value)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(value);
            }
        }
    }
}