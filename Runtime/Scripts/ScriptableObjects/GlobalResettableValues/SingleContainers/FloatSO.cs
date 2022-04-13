using UnityEngine;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "GlobalFloatSO", menuName = "Global Values/Single/Float SO")]
    public class FloatSO : ItemSO<float>
    {
        public float Increment()
        {
            return item++;
        }

        public float Decrement()
        {
            return item--;
        }

        public float Add(float value)
        {
            return item += value;
        }

        public float Subtract(float value)
        {
            return item -= value;
        }

        public float IncrementByGameTime()
        {
            return item += Time.deltaTime;
        }

        public float GetRoundedToDecimals(int decimals)
        {
            double roundedTime = System.Math.Round(item, decimals);
            return (float)roundedTime;
        }

        public float GetRoundedToTwoDecimals()
        {
            return GetRoundedToDecimals(2);
        }
    }
}