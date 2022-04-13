using System.Linq;
using UnityEngine;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "GlobalTransformListSO", menuName = "Global Values/Collections/TransformListSO")]
    public class TransformListSO : CollectionSO<Transform>
    {
        public Vector2[] GetPositions2D()
        {
            return items.Select(x => x.Position2D()).ToArray();
        }
    }
}