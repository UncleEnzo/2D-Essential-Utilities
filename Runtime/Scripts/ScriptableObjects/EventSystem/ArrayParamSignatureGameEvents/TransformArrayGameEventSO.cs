using UnityEngine;
using UnityEngine.Events;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "TransformArrayGameEvent", menuName = "Events/MultiParam/Transform Array Game Event")]
    public class TransformArrayGameEventSO : ScriptableObject
    {
        public UnityAction<Transform[]> OnEventRaised;

        public void RaiseEvent(Transform[] value)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(value);
            }
        }
    }
}