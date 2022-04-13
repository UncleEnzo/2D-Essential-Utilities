using UnityEngine;

namespace Nevelson.Utils
{
    public class ExampleParameterEventInvokeScript : MonoBehaviour
    {
        [SerializeField] private GameObjectGameEventSO goChannel;
        [SerializeField] private BoolGameEventSO boolChannel;
        [SerializeField] private StringGameEventSO stringChannel;
        [SerializeField] private TransformGameEventSO transformChannel;

        public void OnClick_SendGameObject()
        {
            Debug.Log("Sending GO");
            goChannel.RaiseEvent(gameObject);
        }

        public void OnClick_SendBool()
        {
            Debug.Log("Sending Bool");
            boolChannel.RaiseEvent(true);
        }

        public void OnClick_SendString()
        {
            Debug.Log("Sending String");
            stringChannel.RaiseEvent("Hello!");
        }

        public void OnClick_SendTransform()
        {
            Debug.Log("Sending Transform");
            transformChannel.RaiseEvent(gameObject.transform);
        }
    }
}