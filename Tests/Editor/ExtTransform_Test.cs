using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Nevelson.Utils
{
    public class ExtTransform_Test
    {
        [Test]
        public void Test_GetClosest_GameObject()
        {
            GameObject go = new GameObject();
            go.transform.Position2D(Vector2.zero);
            Transform trans = go.GetComponent<Transform>();

            //Selects closest disregarding Zed
            GameObject go1 = new GameObject();
            go1.transform.Position2D(Vector2.left);
            GameObject go2 = new GameObject();
            go2.transform.Position2D(Vector2.right);
            GameObject go3 = new GameObject();
            go3.transform.Position2D(Vector2.left * 2);
            GameObject go4 = new GameObject();
            go4.transform.Position2D(Vector2.left * 3);
            GameObject go5 = new GameObject();
            go5.transform.Position2D(new Vector3(.5f, .2f, 10000f));
            List<GameObject> GameObjects = new List<GameObject>()
            {
               go1,
               go2,
               go3,
               go4,
               go5,
            };
            GameObject closest = trans.GetClosest(GameObjects);
            Assert.AreEqual(go5, closest);

            //Selects first on list if all equal
            GameObject goEqual1 = new GameObject();
            goEqual1.transform.Position2D(Vector2.left);
            GameObject goEqual2 = new GameObject();
            goEqual2.transform.Position2D(Vector2.left);
            GameObjects.Clear();
            GameObjects = new List<GameObject>()
            {
               goEqual1,
               goEqual2,
            };
            closest = trans.GetClosest(GameObjects);
            Assert.AreEqual(goEqual1, closest);

            //returns null if list empty
            GameObjects.Clear();
            closest = trans.GetClosest(GameObjects);
            Assert.Null(closest);
        }

        [Test]
        public void Test_GetClosest_Transform()
        {
            GameObject go = new GameObject();
            go.transform.Position2D(Vector2.zero);
            Transform trans = go.GetComponent<Transform>();

            //Selects closest disregarding Zed
            GameObject go1 = new GameObject();
            go1.transform.Position2D(Vector2.left);
            GameObject go2 = new GameObject();
            go2.transform.Position2D(Vector2.right);
            GameObject go3 = new GameObject();
            go3.transform.Position2D(Vector2.left * 2);
            GameObject go4 = new GameObject();
            go4.transform.Position2D(Vector2.left * 3);
            GameObject go5 = new GameObject();
            go5.transform.Position2D(new Vector3(.5f, .2f, 10000f));
            List<Transform> Transforms = new List<Transform>()
            {
               go1.transform,
               go2.transform,
               go3.transform,
               go4.transform,
               go5.transform,
            };
            Transform closest = trans.GetClosest(Transforms);
            Assert.AreEqual(go5.transform, closest);

            //Selects first on list if all equal
            GameObject transEqual1 = new GameObject();
            transEqual1.transform.Position2D(Vector2.left);
            GameObject transEqual2 = new GameObject();
            transEqual2.transform.Position2D(Vector2.left);
            Transforms.Clear();
            Transforms = new List<Transform>()
            {
               transEqual1.transform,
               transEqual2.transform,
            };
            closest = trans.GetClosest(Transforms);
            Assert.AreEqual(transEqual1.transform, closest);

            //returns null if list empty
            Transforms.Clear();
            closest = trans.GetClosest(Transforms);
            Assert.Null(closest);
        }

        [Test]
        public void Test_GetClosest_Vector()
        {
            GameObject go = new GameObject();
            go.transform.Position2D(Vector2.zero);
            Transform trans = go.GetComponent<Transform>();

            //Selects closest disregarding Zed
            Vector2 v1 = Vector2.left;
            Vector2 v2 = Vector2.right;
            Vector2 v3 = Vector2.left * 2;
            Vector2 v4 = Vector2.left * 3;
            Vector2 v5 = new Vector3(.5f, .2f, 10000f);
            List<Vector2> Vectors = new List<Vector2>()
            {
               v1,
               v2,
               v3,
               v4,
               v5,
            };
            Vector2 closest = trans.GetClosest(Vectors);
            Assert.AreEqual(v5, closest);

            //Selects first on list if all equal
            Vector2 vEqual1 = Vector2.left;
            Vector2 vEqual2 = Vector2.left;
            Vectors.Clear();
            Vectors = new List<Vector2>()
            {
               vEqual1,
               vEqual2,
            };
            closest = trans.GetClosest(Vectors);
            Assert.AreEqual(vEqual1, closest);

            //returns Vector2.zero if list empty
            Vectors.Clear();
            closest = trans.GetClosest(Vectors);
            Assert.AreEqual(Vector2.zero, closest);
        }

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