using UnityEngine;
using UnityEngine.Events;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "GOArrayGameEvent", menuName = "Events/MultiParam/GO Array Game Event")]
    public class GOArrayGameEventSO : ScriptableObject
    {
        public UnityAction<GameObject[]> OnEventRaised;

        public void RaiseEvent(GameObject[] value)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(value);
            }
        }
    }
}