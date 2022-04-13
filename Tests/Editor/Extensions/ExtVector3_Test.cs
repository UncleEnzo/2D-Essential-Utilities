using NUnit.Framework;
using UnityEngine;

namespace Nevelson.Utils
{
    public class ExtVector3_Test
    {
        [Test]
        public void Test_Get2D()
        {
            Vector3 v3Test = new Vector3(12, 19, 5);
            Vector2 v2Test = v3Test.Get2D();
            Assert.AreEqual(new Vector2(12, 19), v2Test);
        }
    }
}