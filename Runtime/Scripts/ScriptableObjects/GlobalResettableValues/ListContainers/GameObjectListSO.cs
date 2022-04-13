using System.Linq;
using UnityEngine;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "GlobalGameObjectListSO", menuName = "Global Values/Collections/GameObjectListSO")]
    public class GameObjectListSO : CollectionSO<GameObject>
    {
        public Transform[] GetTransforms()
        {
            return items.Select(x => x.gameObject.transform).ToArray();
        }
    }
}