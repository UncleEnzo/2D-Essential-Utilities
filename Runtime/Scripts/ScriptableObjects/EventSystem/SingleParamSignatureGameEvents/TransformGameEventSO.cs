using UnityEngine;
using UnityEngine.Events;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "TransformGameEvent", menuName = "Events/SingleParam/Transform Game Event")]
    public class TransformGameEventSO : ScriptableObject
    {
        public UnityAction<Transform> OnEventRaised;

        public void RaiseEvent(Transform value)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(value);
            }
        }
    }
}