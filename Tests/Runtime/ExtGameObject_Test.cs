using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Nevelson.Utils
{
    public class ExtGameObject_Test
    {
        [UnityTest]
        public IEnumerator Test_WhileSceneLoaded()
        {
            GameObject player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            player.AddComponent<MockOnDestoryComponent>();
            GameObject.Destroy(player);
            yield return null;
            Assert.AreEqual("I  was destroyed while scene loaded", MockMonoSingletonComponent.Instance.Reference);
            yield return null;

            GameObject player2 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            player2.AddComponent<MockOnDestoryComponent>();
            yield return null;
            SceneManager.LoadScene("UnitTestScene");

            yield return null;
            Assert.AreNotEqual("I  was destroyed while scene loaded", MockMonoSingletonComponent.Instance.Reference);

            MockMonoSingletonComponent.Instance.Reference = "Default";
        }

        [UnityTest]
        public IEnumerator Test_WhileSceneUnloads()
        {
            GameObject player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            player.AddComponent<MockOnDestoryComponent>();
            GameObject.Destroy(player);
            yield return null;
            Assert.AreNotEqual("I was destroyed because the scene was unloaded", MockMonoSingletonComponent.Instance.Reference);
            yield return null;

            GameObject player2 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            player2.AddComponent<MockOnDestoryComponent>();
            yield return null;
            SceneManager.LoadScene("UnitTestScene");

            yield return null;
            Assert.AreEqual("I was destroyed because the scene was unloaded", MockMonoSingletonComponent.Instance.Reference);

            MockMonoSingletonComponent.Instance.Reference = "Default";
        }
    }
}