using UnityEngine;

namespace Nevelson.Utils
{
    public class ExampleGOVariableReferenceScript : MonoBehaviour
    {
        public IntGameEventSO dealDamageChannel;
        public IntegerSO health;

        private void OnEnable()
        {
            dealDamageChannel.OnEventRaised += TakeDamage;
        }

        private void OnDisable()
        {
            dealDamageChannel.OnEventRaised -= TakeDamage;
        }

        private void TakeDamage(int damage)
        {
            Debug.Log("Recieved take damage event, updating health global value");
            health.Subtract(damage);
        }
    }
}