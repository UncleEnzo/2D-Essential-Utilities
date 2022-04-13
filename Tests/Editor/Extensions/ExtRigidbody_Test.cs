using NUnit.Framework;
using UnityEngine;

namespace Nevelson.Utils
{
    public class ExtRigidbody_Test
    {
        [Test]
        public void Test_PredictFuturePos()
        {
            GameObject go = new GameObject("Object");
            Rigidbody2D rb = go.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            go.transform.Position2D(Vector2.zero);

            rb.velocity = new Vector2(-5, 3);
            Assert.AreEqual(Vector2.zero, rb.PredictFuturePos(0));
            go.transform.Position2D(Vector2.zero);

            rb.velocity = new Vector2(-5, 3);
            Assert.AreEqual(Vector2.zero, rb.PredictFuturePos(-5));
            go.transform.Position2D(Vector2.zero);

            rb.velocity = Vector2.zero;
            Assert.AreEqual(Vector2.zero, rb.PredictFuturePos(10));
            go.transform.Position2D(Vector2.zero);

            rb.velocity = Vector2.one;
            Vector2 futurePos = rb.PredictFuturePos(15);
            Assert.AreEqual(.299999982f, futurePos.x);
            Assert.AreEqual(.299999982f, futurePos.y);
            go.transform.Position2D(Vector2.zero);

            rb.velocity = new Vector2(-5, 3);
            futurePos = rb.PredictFuturePos(5);
            Assert.AreEqual(-.49999997f, futurePos.x);
            Assert.AreEqual(.299999982f, futurePos.y);
            go.transform.Position2D(Vector2.zero);

            GameObject.DestroyImmediate(go);
        }

        [Test]
        public void Test_PredictFuturePosFromChildPos()
        {
            GameObject go = new GameObject("Object");
            GameObject goSub = new GameObject("Object Child");
            Rigidbody2D rb = go.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            go.transform.Position2D(Vector2.zero);
            goSub.transform.LocalPosition2D(new Vector2(0, -5));

            rb.velocity = new Vector2(-5, 3);
            Assert.AreEqual(new Vector2(0, -5), rb.PredictFuturePosFromChildPos(goSub.transform.Position2D(), 0));
            go.transform.Position2D(Vector2.zero);

            rb.velocity = new Vector2(-5, 3);
            Assert.AreEqual(Vector2.zero, rb.PredictFuturePosFromChildPos(goSub.transform.Position2D(), -5));
            go.transform.Position2D(Vector2.zero);

            rb.velocity = Vector2.zero;
            Assert.AreEqual(new Vector2(0, -5), rb.PredictFuturePosFromChildPos(goSub.transform.Position2D(), 10));
            go.transform.Position2D(Vector2.zero);

            rb.velocity = Vector2.one;
            Vector2 futurePos = rb.PredictFuturePosFromChildPos(goSub.transform.Position2D(), 15);
            Assert.AreEqual(.299999982f, futurePos.x);
            Assert.AreEqual(-4.69999981f, futurePos.y);
            go.transform.Position2D(Vector2.zero);

            rb.velocity = new Vector2(-5, 3);
            futurePos = rb.PredictFuturePosFromChildPos(goSub.transform.Position2D(), 5);
            Assert.AreEqual(-.49999997f, futurePos.x);
            Assert.AreEqual(-4.69999981f, futurePos.y);
            go.transform.Position2D(Vector2.zero);

            GameObject.DestroyImmediate(go);
            GameObject.DestroyImmediate(goSub);
        }
    }
}