using UnityEngine;

namespace Nevelson.Utils
{
    public class ExampleListeningScript : MonoBehaviour
    {
        [Header("Void Game Event Channels")]
        [SerializeField] private GameEventSO pressWChannel;
        [SerializeField] private GameEventSO pressAChannel;
        [SerializeField] private GameEventSO pressSChannel;
        [SerializeField] private GameEventSO pressDChannel;

        [Header("Value Game Event Channels")]
        [SerializeField] private GameObjectGameEventSO sendGOChannel;
        [SerializeField] private BoolGameEventSO sendBoolChannel;
        [SerializeField] private StringGameEventSO sendStringChannel;
        [SerializeField] private TransformGameEventSO sendTransformChannel;

        private void OnEnable()
        {
            pressWChannel.OnEventRaised += MoveUp;
            pressAChannel.OnEventRaised += MoveLeft;
            pressSChannel.OnEventRaised += MoveDown;
            pressDChannel.OnEventRaised += MoveRight;

            sendGOChannel.OnEventRaised += RecieveGO;
            sendBoolChannel.OnEventRaised += RecieveBool;
            sendStringChannel.OnEventRaised += RecieveString;
            sendTransformChannel.OnEventRaised += RecieveTransform;
        }

        private void OnDisable()
        {
            pressWChannel.OnEventRaised -= MoveUp;
            pressAChannel.OnEventRaised -= MoveLeft;
            pressSChannel.OnEventRaised -= MoveDown;
            pressDChannel.OnEventRaised -= MoveRight;

            sendGOChannel.OnEventRaised -= RecieveGO;
            sendBoolChannel.OnEventRaised -= RecieveBool;
            sendStringChannel.OnEventRaised -= RecieveString;
            sendTransformChannel.OnEventRaised -= RecieveTransform;
        }

        private void MoveUp()
        {
            Debug.Log("Heard W, Moving up!");
            transform.Position2D(transform.Position2D() + Vector2.up);
        }

        private void MoveLeft()
        {
            Debug.Log("Heard A, Moving Left!");
            transform.Position2D(transform.Position2D() + Vector2.left);
        }

        private void MoveDown()
        {
            Debug.Log("Heard S, Moving Down!");
            transform.Position2D(transform.Position2D() + Vector2.down);
        }

        private void MoveRight()
        {
            Debug.Log("Heard D, Moving Right!");
            transform.Position2D(transform.Position2D() + Vector2.right);
        }

        private void RecieveGO(GameObject value)
        {
            Debug.Log($"Recieved GO: {value.name}");
        }

        private void RecieveBool(bool value)
        {
            Debug.Log($"Recieved bool: {value}");
        }

        private void RecieveString(string value)
        {
            Debug.Log($"Recieved string: {value}");
        }

        private void RecieveTransform(Transform value)
        {
            Debug.Log($"Recieved transform: {value.name}");
        }
    }
}