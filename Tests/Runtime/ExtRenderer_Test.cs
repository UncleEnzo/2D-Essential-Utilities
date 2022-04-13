using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Nevelson.Utils
{
    public class ExtRenderer_Test
    {
        [UnityTest]
        public IEnumerator Test_IsVisibleFrom()
        {
            GameObject cameraGO = new GameObject("camera");
            Camera camera = cameraGO.AddComponent<Camera>();
            camera.transform.position = new Vector3(0, 0, -10);

            GameObject player = new GameObject("Basic Object");
            SpriteRenderer spriteRenderer = player.AddComponent<SpriteRenderer>();
            player.transform.Position2D(Vector2.zero);

            bool isVisible = spriteRenderer.IsVisibleFrom(camera);
            Assert.True(isVisible);

            //move camera away from object
            camera.transform.position = new Vector3(1000, 0, -10);
            isVisible = spriteRenderer.IsVisibleFrom(camera);
            Assert.False(isVisible);

            //rotate camera away from object
            camera.transform.position = new Vector3(0, 0, -10);
            Quaternion rotationOfCamera = new Quaternion();
            rotationOfCamera.eulerAngles = new Vector3(0, 180, 0);
            camera.transform.rotation = rotationOfCamera;
            isVisible = spriteRenderer.IsVisibleFrom(camera);
            Assert.False(isVisible);


            GameObject.Destroy(player);
            GameObject.Destroy(cameraGO);
            yield return null;
        }
    }
}