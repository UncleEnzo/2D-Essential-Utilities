using UnityEngine;

namespace Nevelson.Utils
{
    public class MockOnDestoryComponent : MonoBehaviour
    {
        private void OnDestroy()
        {
            gameObject.WhileSceneLoaded(() =>
            {
                MockMonoSingletonComponent.Instance.Reference = "I  was destroyed while scene loaded";
            });

            gameObject.WhenSceneUnloads(() =>
            {
                MockMonoSingletonComponent.Instance.Reference = "I was destroyed because the scene was unloaded";
            });
        }
    }
}