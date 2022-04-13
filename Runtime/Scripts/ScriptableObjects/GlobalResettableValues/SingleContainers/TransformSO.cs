using UnityEngine;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "GlobalTransformSO", menuName = "Global Values/Single/Transform SO")]
    public class TransformSO : ItemSO<Transform>
    {
        public Vector2 GetPosition2D()
        {
            if (item == null)
            {
                return Vector2.zero;
            }
            return item.Position2D();
        }
    }
}