using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Nevelson.Utils
{
    public class ExtTransform_Test
    {
        [Test]
        public void Test_LookAt2DTransform()
        {
            GameObject player = new GameObject("Basic Object");
            GameObject lookAt = new GameObject("Look At");
            player.transform.Position2D(Vector2.zero);

            //zed affected, zed value should be ignored
            lookAt.transform.position = new Vector3(0, 1, 12.94f);
            player.transform.LookAt2D(lookAt.transform);
            Assert.AreEqual(new Vector3(0, 0, 90), player.transform.rotation.eulerAngles);

            lookAt.transform.position = Vector3.one;
            player.transform.LookAt2D(lookAt.transform);
            Vector3 roundedZed = new Vector3(player.transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, Mathf.Round(player.transform.rotation.eulerAngles.z * 100f) / 100f);
            Vector3 expected = new Vector3(0, 0, Mathf.Round(45f * 100f) / 100f);
            Assert.AreEqual(expected, roundedZed);

            lookAt.transform.position = Vector3.up;
            player.transform.LookAt2D(lookAt.transform);
            Assert.AreEqual(new Vector3(0, 0, 90), player.transform.rotation.eulerAngles);

            lookAt.transform.position = Vector3.down;
            player.transform.LookAt2D(lookAt.transform);
            Assert.AreEqual(new Vector3(0, 0, 270), player.transform.rotation.eulerAngles);

            lookAt.transform.position = Vector3.zero;
            player.transform.LookAt2D(lookAt.transform);
            Assert.AreEqual(new Vector3(0, 0, 0), player.transform.rotation.eulerAngles);

            GameObject.DestroyImmediate(player);
            GameObject.DestroyImmediate(lookAt);
        }

        [Test]
        public void Test_LookAt2DVector2()
        {
            GameObject player = new GameObject("Basic Object");
            player.transform.Position2D(Vector2.zero);

            player.transform.LookAt2D(Vector2.one);
            Vector3 roundedZed = new Vector3(player.transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, Mathf.Round(player.transform.rotation.eulerAngles.z * 100f) / 100f);
            Vector3 expected = new Vector3(0, 0, Mathf.Round(45f * 100f) / 100f);
            Assert.AreEqual(expected, roundedZed);

            player.transform.LookAt2D(Vector2.up);
            Assert.AreEqual(new Vector3(0, 0, 90), player.transform.rotation.eulerAngles);

            player.transform.LookAt2D(Vector2.down);
            Assert.AreEqual(new Vector3(0, 0, 270), player.transform.rotation.eulerAngles);

            player.transform.LookAt2D(Vector2.zero);
            Assert.AreEqual(new Vector3(0, 0, 0), player.transform.rotation.eulerAngles);

            GameObject.DestroyImmediate(player);
        }

        [Test]
        public void Test_GetDirectChildren()
        {
            GameObject oGO = new GameObject("Object");

            GameObject nsoGO = new GameObject("Normal Sub Object");
            nsoGO.transform.parent = oGO.transform;
            GameObject rsoGO = new GameObject("Random Sub Object");
            rsoGO.transform.parent = oGO.transform;


            GameObject nssoGO = new GameObject("Normaler Sub Sub Object");
            nssoGO.transform.parent = nsoGO.transform;
            GameObject rssoGO = new GameObject("Randomer Sub Sub Object");
            rssoGO.transform.parent = rsoGO.transform;
            rssoGO.tag = "Player";

            List<Transform> theChildren = oGO.transform.GetDirectChildren();
            Assert.AreEqual(2, theChildren.Count);

            GameObject.DestroyImmediate(oGO);
            GameObject.DestroyImmediate(nsoGO);
            GameObject.DestroyImmediate(rsoGO);
            GameObject.DestroyImmediate(nssoGO);
            GameObject.DestroyImmediate(rssoGO);
        }

        [Test]
        public void Test_GetAllChildren()
        {
            GameObject oGO = new GameObject("Object");

            GameObject nsoGO = new GameObject("Normal Sub Object");
            nsoGO.transform.parent = oGO.transform;
            GameObject rsoGO = new GameObject("Random Sub Object");
            rsoGO.transform.parent = oGO.transform;


            GameObject nssoGO = new GameObject("Normaler Sub Sub Object");
            nssoGO.transform.parent = nsoGO.transform;
            GameObject rssoGO = new GameObject("Randomer Sub Sub Object");
            rssoGO.transform.parent = rsoGO.transform;

            GameObject nsssoGO = new GameObject("Normaler Sub Sub Sub Object");
            nsssoGO.transform.parent = nssoGO.transform;
            GameObject rsssoGO = new GameObject("Randomer Sub Sub Sub Object");
            rsssoGO.transform.parent = rssoGO.transform;

            List<Transform> theChildren = oGO.transform.GetAllChildren();
            Assert.AreEqual(6, theChildren.Count, "If failed, make sure player tag already exists in your project");

            GameObject.DestroyImmediate(oGO);
            GameObject.DestroyImmediate(nsoGO);
            GameObject.DestroyImmediate(rsoGO);
            GameObject.DestroyImmediate(nssoGO);
            GameObject.DestroyImmediate(rssoGO);
            GameObject.DestroyImmediate(nsssoGO);
            GameObject.DestroyImmediate(rsssoGO);
        }

        [Test]
        public void Test_DestroyAllChildren()
        {
            GameObject oGO = new GameObject("Object");

            GameObject nsoGO = new GameObject("Normal Sub Object");
            nsoGO.transform.parent = oGO.transform;
            GameObject rsoGO = new GameObject("Random Sub Object");
            rsoGO.transform.parent = oGO.transform;


            GameObject nssoGO = new GameObject("Normaler Sub Sub Object");
            nssoGO.transform.parent = nsoGO.transform;
            GameObject rssoGO = new GameObject("Randomer Sub Sub Object");
            rssoGO.transform.parent = rsoGO.transform;

            GameObject nsssoGO = new GameObject("Normaler Sub Sub Sub Object");
            nsssoGO.transform.parent = nssoGO.transform;
            GameObject rsssoGO = new GameObject("Randomer Sub Sub Sub Object");
            rsssoGO.transform.parent = rssoGO.transform;

            //https://answers.unity.com/questions/865405/nunit-notnull-assert-strangeness.html
            //can't use isNull or null checks for gameobjects
            oGO.transform.DestroyAllChildren(true);
            Assert.False(oGO == null);
            Assert.True(nsoGO == null);
            Assert.True(nssoGO == null);
            Assert.True(nsssoGO == null);
            Assert.True(rsoGO == null);
            Assert.True(rssoGO == null);
            Assert.True(rsssoGO == null);
        }

        [Test]
        public void Test_SetLocalScale2D()
        {
            GameObject go = new GameObject("Object");
            go.transform.localScale = new Vector3(99, 8172, 3);
            go.transform.LocalScale2D(Vector2.up);
            Assert.AreEqual(new Vector3(0, 1, 1), go.transform.localScale);
            GameObject.DestroyImmediate(go);
        }

        [Test]
        public void Test_GetLocalScale2D()
        {
            GameObject go = new GameObject("Object");
            go.transform.localScale = Vector3.up;
            Assert.AreEqual(new Vector2(0, 1), go.transform.LocalScale2D());
            GameObject.DestroyImmediate(go);
        }

        [Test]
        public void Test_SetPosition2D()
        {
            GameObject go = new GameObject("Object");
            go.transform.position = new Vector3(99, 8172, 3);
            go.transform.Position2D(Vector2.up);
            Assert.AreEqual(new Vector3(0, 1, 0), go.transform.position);
            GameObject.DestroyImmediate(go);
        }

        [Test]
        public void Test_GetPosition2D()
        {
            GameObject go = new GameObject("Object");
            go.transform.position = new Vector3(0, 1, 29);
            Assert.AreEqual(new Vector2(0, 1), go.transform.Position2D());
            GameObject.DestroyImmediate(go);
        }

        [Test]
        public void Test_SetLocalPosition2D()
        {
            GameObject go = new GameObject("Object");
            GameObject subGO = new GameObject("Sub Object");
            go.transform.position = new Vector3(100, 100, 50);
            subGO.transform.parent = go.transform;
            subGO.transform.localPosition = new Vector3(99, 8172, 3);

            subGO.transform.LocalPosition2D(Vector2.up);
            Assert.AreEqual(new Vector3(100, 101, 50), subGO.transform.position);
            Assert.AreEqual(new Vector3(0, 1, 0), subGO.transform.localPosition);

            GameObject.DestroyImmediate(go);
            GameObject.DestroyImmediate(subGO);
        }

        [Test]
        public void Test_GetLocalPosition2D()
        {
            GameObject go = new GameObject("Object");
            GameObject subGO = new GameObject("Sub Object");
            go.transform.position = new Vector3(100, 100, 50);
            subGO.transform.parent = go.transform;
            subGO.transform.localPosition = new Vector3(99, 8172, 3);
            Assert.AreEqual(new Vector3(199, 8272, 53), subGO.transform.position);
            Assert.AreEqual(new Vector2(99, 8172), subGO.transform.LocalPosition2D());

            GameObject.DestroyImmediate(go);
            GameObject.DestroyImmediate(subGO);
        }

        [Test]
        public void Test_NormalizedDirectionVector()
        {
            GameObject go = new GameObject("Object");
            go.transform.position = Vector3.zero;

            Assert.AreEqual(new Vector2(0, 0), go.transform.GetNormalizedDirection(Vector2.zero));
            Assert.AreEqual(new Vector2(1, 0), go.transform.GetNormalizedDirection(Vector2.right));
            Assert.AreEqual(new Vector2(1, 0), go.transform.GetNormalizedDirection(Vector2.right * 55));

            Vector2 normalizedDir = go.transform.GetNormalizedDirection(new Vector2(29, -13));
            Assert.AreEqual(.912509322f, normalizedDir.x);
            Assert.AreEqual(-.409055918f, normalizedDir.y);
            GameObject.DestroyImmediate(go);
        }

        [Test]
        public void Test_NormalizedDirectionTransform()
        {
            GameObject go = new GameObject("Object");
            GameObject otherGo = new GameObject("Other Object");
            go.transform.position = Vector3.zero;

            otherGo.transform.position = Vector3.zero;
            Assert.AreEqual(new Vector2(0, 0), go.transform.GetNormalizedDirection(otherGo.transform));

            otherGo.transform.position = Vector3.right;
            Assert.AreEqual(new Vector2(1, 0), go.transform.GetNormalizedDirection(otherGo.transform));

            otherGo.transform.position = Vector3.right * 55;
            Assert.AreEqual(new Vector2(1, 0), go.transform.GetNormalizedDirection(otherGo.transform));

            otherGo.transform.position = new Vector3(29, -13, 69);
            Vector2 normalizedDir = go.transform.GetNormalizedDirection(otherGo.transform);
            Assert.AreEqual(.912509322f, normalizedDir.x);
            Assert.AreEqual(-.409055918f, normalizedDir.y);

            GameObject.DestroyImmediate(go);
            GameObject.DestroyImmediate(otherGo);
        }

    }
}