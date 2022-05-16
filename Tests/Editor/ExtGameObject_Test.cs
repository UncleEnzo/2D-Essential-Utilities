using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Nevelson.Utils
{
    public class ExtGameObject_Test
    {
        [Test]
        public void Test_AddCopiedComponent()
        {
            GameObject go = new GameObject();
            Rigidbody2D rb = go.AddComponent<Rigidbody2D>();
            rb.gravityScale = -12;
            rb.sleepMode = RigidbodySleepMode2D.NeverSleep;
            rb.velocity = new Vector2(345, 913);

            GameObject destinationGO = new GameObject();

            //Test returned component
            Rigidbody2D myDestinationRB = destinationGO.AddCopiedComponent(go.GetComponent<Rigidbody2D>());
            Assert.AreEqual(-12, myDestinationRB.gravityScale);
            Assert.AreEqual(RigidbodySleepMode2D.NeverSleep, myDestinationRB.sleepMode);
            Assert.AreEqual(new Vector2(345, 913), myDestinationRB.velocity);

            //Test attached component
            Rigidbody2D attachedRB = destinationGO.GetComponent<Rigidbody2D>();
            Assert.AreEqual(-12, attachedRB.gravityScale);
            Assert.AreEqual(RigidbodySleepMode2D.NeverSleep, attachedRB.sleepMode);
            Assert.AreEqual(new Vector2(345, 913), attachedRB.velocity);

            GameObject.DestroyImmediate(go);
            GameObject.DestroyImmediate(destinationGO);
        }

        [Test]
        public void Test_GetClosest_GameObject()
        {
            GameObject go = new GameObject();
            go.transform.Position2D(Vector2.zero);

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
            GameObject closest = go.GetClosest(GameObjects);
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
            closest = go.GetClosest(GameObjects);
            Assert.AreEqual(goEqual1, closest);

            //returns null if list empty
            GameObjects.Clear();
            closest = go.GetClosest(GameObjects);
            Assert.Null(closest);
        }

        [Test]
        public void Test_GetClosest_Transform()
        {
            GameObject go = new GameObject();
            go.transform.Position2D(Vector2.zero);

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
            Transform closest = go.GetClosest(Transforms);
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
            closest = go.GetClosest(Transforms);
            Assert.AreEqual(transEqual1.transform, closest);

            //returns null if list empty
            Transforms.Clear();
            closest = go.GetClosest(Transforms);
            Assert.Null(closest);
        }

        [Test]
        public void Test_GetClosest_Vector()
        {
            GameObject go = new GameObject();
            go.transform.Position2D(Vector2.zero);

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
            Vector2 closest = go.GetClosest(Vectors);
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
            closest = go.GetClosest(Vectors);
            Assert.AreEqual(vEqual1, closest);

            //returns Vector2.zero if list empty
            Vectors.Clear();
            closest = go.GetClosest(Vectors);
            Assert.AreEqual(Vector2.zero, closest);
        }
    }
}