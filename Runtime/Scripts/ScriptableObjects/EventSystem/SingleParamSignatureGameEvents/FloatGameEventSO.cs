using UnityEngine;
using UnityEngine.Events;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "FloatGameEvent", menuName = "Events/SingleParam/Float Game Event")]
    public class FloatGameEventSO : ScriptableObject
    {
        public UnityAction<float> OnEventRaised;

        public void RaiseEvent(float value)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(value);
            }
        }
    }
}