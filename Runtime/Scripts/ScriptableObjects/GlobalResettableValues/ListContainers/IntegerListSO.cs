using System.Linq;
using UnityEngine;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "GlobalIntegerListSO", menuName = "Global Values/Collections/IntegerListSO")]
    public class IntegerListSO : CollectionSO<int>
    {
        public float[] GetFloatss()
        {
            return items.Select(x => (float)x).ToArray();
        }

        public double[] GetDoubles()
        {
            return items.Select(x => (double)x).ToArray();
        }
    }
}