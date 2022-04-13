using UnityEngine;

namespace Nevelson.Utils
{
    [CreateAssetMenu(fileName = "GlobalGameObjectSO", menuName = "Global Values/Single/GameObject SO")]
    public class GameObjectSO : ItemSO<GameObject>
    {
        public T GetObjectComponent<T>()
        {
            if (item == null)
            {
                return default(T);
            }
            return item.GetComponent<T>();
        }
    }
}