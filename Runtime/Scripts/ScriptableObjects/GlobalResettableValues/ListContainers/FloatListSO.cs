using System.Linq;
using UnityEngine;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "GlobalFloatListSO", menuName = "Global Values/Collections/FloatListSO")]
    public class FloatListSO : CollectionSO<float>
    {
        public int[] GetInts()
        {
            return items.Select(x => (int)x).ToArray();
        }

        public double[] GetDoubles()
        {
            return items.Select(x => (double)x).ToArray();
        }
    }
}