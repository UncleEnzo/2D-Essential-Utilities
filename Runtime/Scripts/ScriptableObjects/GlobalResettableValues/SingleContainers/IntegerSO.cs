using UnityEngine;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "GlobalIntegerSO", menuName = "Global Values/Single/Integer SO")]
    public class IntegerSO : ItemSO<int>
    {
        public int Increment()
        {
            return item++;
        }

        public int Decrement()
        {
            return item--;
        }

        public int Add(int value)
        {
            return item += value;
        }

        public int Subtract(int value)
        {
            return item -= value;
        }
    }
}