using NUnit.Framework;
using UnityEngine;

namespace Nevelson.Utils
{
    public class ExtRectTransform_Test
    {
        [Test]
        public void Test_SetLeft()
        {
            GameObject go = new GameObject("Object");
            RectTransform getRect = go.AddComponent<RectTransform>();

            //Set offsets from anchor (should be 100 by 100 square now)
            getRect.offsetMin = new Vector2(100, 100);
            getRect.offsetMax = new Vector2(100, 100);

            getRect.SetLeft(50);
            Assert.AreEqual(new Vector2(50, 100), getRect.offsetMin);
            Assert.AreEqual(new Vector2(100, 100), getRect.offsetMax);

            getRect.SetLeft(150);
            Assert.AreEqual(new Vector2(150, 100), getRect.offsetMin);
            Assert.AreEqual(new Vector2(100, 100), getRect.offsetMax);

            getRect.SetLeft(-70);
            Assert.AreEqual(new Vector2(-70, 100), getRect.offsetMin);
            Assert.AreEqual(new Vector2(100, 100), getRect.offsetMax);

            GameObject.DestroyImmediate(go);
        }

        [Test]
        public void Test_SetRight()
        {
            GameObject go = new GameObject("Object");
            RectTransform getRect = go.AddComponent<RectTransform>();

            //Set offsets from anchor (should be 100 by 100 square now)
            getRect.offsetMin = new Vector2(100, 100);
            getRect.offsetMax = new Vector2(100, 100);

            getRect.SetRight(50);
            Assert.AreEqual(new Vector2(100, 100), getRect.offsetMin);
            Assert.AreEqual(new Vector2(-50, 100), getRect.offsetMax);

            getRect.SetRight(150);
            Assert.AreEqual(new Vector2(100, 100), getRect.offsetMin);
            Assert.AreEqual(new Vector2(-150, 100), getRect.offsetMax);

            getRect.SetRight(-70);
            Assert.AreEqual(new Vector2(100, 100), getRect.offsetMin);
            Assert.AreEqual(new Vector2(70, 100), getRect.offsetMax);

            GameObject.DestroyImmediate(go);

        }

        [Test]
        public void Test_SetTop()
        {
            GameObject go = new GameObject("Object");
            RectTransform getRect = go.AddComponent<RectTransform>();

            //Set offsets from anchor (should be 100 by 100 square now)
            getRect.offsetMin = new Vector2(100, 100);
            getRect.offsetMax = new Vector2(100, 100);

            getRect.SetTop(50);
            Assert.AreEqual(new Vector2(100, 100), getRect.offsetMin);
            Assert.AreEqual(new Vector2(100, -50), getRect.offsetMax);

            getRect.SetTop(150);
            Assert.AreEqual(new Vector2(100, 100), getRect.offsetMin);
            Assert.AreEqual(new Vector2(100, -150), getRect.offsetMax);

            getRect.SetTop(-70);
            Assert.AreEqual(new Vector2(100, 100), getRect.offsetMin);
            Assert.AreEqual(new Vector2(100, 70), getRect.offsetMax);

            GameObject.DestroyImmediate(go);

        }

        [Test]
        public void Test_SetBottom()
        {
            GameObject go = new GameObject("Object");
            RectTransform getRect = go.AddComponent<RectTransform>();

            //Set offsets from anchor (should be 100 by 100 square now)
            getRect.offsetMin = new Vector2(100, 100);
            getRect.offsetMax = new Vector2(100, 100);

            getRect.SetBottom(50);
            Assert.AreEqual(new Vector2(100, 50), getRect.offsetMin);
            Assert.AreEqual(new Vector2(100, 100), getRect.offsetMax);

            getRect.SetBottom(150);
            Assert.AreEqual(new Vector2(100, 150), getRect.offsetMin);
            Assert.AreEqual(new Vector2(100, 100), getRect.offsetMax);

            getRect.SetBottom(-70);
            Assert.AreEqual(new Vector2(100, -70), getRect.offsetMin);
            Assert.AreEqual(new Vector2(100, 100), getRect.offsetMax);

            GameObject.DestroyImmediate(go);

        }
    }
}