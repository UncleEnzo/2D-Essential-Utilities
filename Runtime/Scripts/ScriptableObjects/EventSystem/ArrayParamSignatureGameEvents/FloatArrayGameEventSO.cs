using UnityEngine;
using UnityEngine.Events;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "FloatArrayGameEvent", menuName = "Events/MultiParam/Float Array Game Event")]
    public class FloatArrayGameEventSO : ScriptableObject
    {
        public UnityAction<float[]> OnEventRaised;

        public void RaiseEvent(float[] value)
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke(value);
            }
        }
    }
}