using UnityEngine;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "GlobalBooleanSO", menuName = "Global Values/Single/Boolean SO")]
    public class BooleanSO : ItemSO<bool>
    {
        public bool SetIfOpposite(bool item)
        {
            if (base.item != item) base.item = !item;
            return base.item;
        }

        public bool FlipValue()
        {
            return item = !item;
        }
    }
}