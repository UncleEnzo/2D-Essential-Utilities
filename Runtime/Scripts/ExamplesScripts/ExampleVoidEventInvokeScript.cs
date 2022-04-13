using UnityEngine;

namespace Nevelson.Utils
{
    public class ExampleVoidEventInvokeScript : MonoBehaviour
    {
        [SerializeField] private GameEventSO pressWChannel;
        [SerializeField] private GameEventSO pressAChannel;
        [SerializeField] private GameEventSO pressSChannel;
        [SerializeField] private GameEventSO pressDChannel;
        [SerializeField] private IntGameEventSO dealDamageChannel;


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Pressing W");
                pressWChannel.RaiseEvent();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Pressing A");
                pressAChannel.RaiseEvent();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Pressing S");
                pressSChannel.RaiseEvent();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Pressing D");
                pressDChannel.RaiseEvent();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Pressing F");
                dealDamageChannel.RaiseEvent(1);
            }
        }
    }
}