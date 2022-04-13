using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Nevelson.Utils
{
    public class Utils_Test
    {
        [UnityTest]
        public IEnumerator Test_LerpToDestination()
        {
            GameObject player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            player.transform.Position2D(Vector2.zero);
            Vector2 endPos = new Vector2(1, 1);


            int framesUsed = 0;
            bool isAtDest = false;
            while (!isAtDest)
            {
                framesUsed++;
                isAtDest = Utils.LerpToDestination(player.transform, endPos, 3);
                if (framesUsed >= 10000)
                {
                    Assert.Fail($"Location is: {player.transform.Position2D()}");
                }
                yield return null;
            }
            Assert.True(isAtDest);

            //test it does not exceed position after time
            player.transform.Position2D(Vector2.zero);
            framesUsed = 0;
            while (framesUsed < 500)
            {
                framesUsed++;
                isAtDest = Utils.LerpToDestination(player.transform, endPos, 100);
                yield return null;
            }
            Assert.True(isAtDest);
            GameObject.DestroyImmediate(player);
        }
    }
}