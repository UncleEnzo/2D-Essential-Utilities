using UnityEngine;
using TMPro;
namespace Nevelson.Utils
{
    public class ExampleUIGlobalValueReceiverScript : MonoBehaviour
    {
        public IntegerSO health;
        public TextMeshProUGUI text;
        private int previousHealth;

        void Update()
        {
            if (previousHealth != health.Get())
            {
                Debug.Log($"Health Changed.  Setting player health to: {health.Get()}");
                text.text = health.Get().ToString();
                previousHealth = health.Get();
            }
        }
    }
}