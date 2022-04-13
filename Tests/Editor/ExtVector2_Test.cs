using NUnit.Framework;
using UnityEngine;
using static Nevelson.Utils.Enums;

namespace Nevelson.Utils
{
    public class ExtVector2_Test
    {
        //Use to read large floating points for exact comparison
        //Debug.Log(vector.GetRotation().ToString("F12"));
        [Test]
        public void Test_Rotate()
        {
            Vector2 vector = Vector2.right;

            Vector2 result = vector.Rotate(0);
            Assert.AreEqual(Vector2.right, vector);
            Assert.AreEqual(Vector2.right, result);

            result = vector.Rotate(180);
            Assert.AreEqual(Vector2.right, vector);
            Assert.True(Vector2.left == result);

            result = vector.Rotate(-180);
            Assert.AreEqual(Vector2.right, vector);
            Assert.True(Vector2.left == result);

            result = vector.Rotate(360);
            Assert.AreEqual(Vector2.right, vector);
            Assert.True(Vector2.right == result);

            result = vector.Rotate(-45);
            Assert.AreEqual(Vector2.right, vector);

            Assert.AreEqual(new Vector2(.7071067f, -.7071068f), result);

            result = vector.Rotate(45);
            Assert.AreEqual(Vector2.right, vector);
            Assert.AreEqual(new Vector2(.7071067f, .7071068f), result);
        }

        [Test]
        public void Test_GetAngle()
        {
            Vector2 vector = Vector2.right;
            Assert.AreEqual(0, vector.GetAngle());

            vector = Vector2.left;
            Assert.AreEqual(180, vector.GetAngle());

            vector = Vector2.zero;
            Assert.AreEqual(0, vector.GetAngle());

            vector = new Vector2(1, 1);
            Assert.AreEqual(45f, vector.GetAngle());

            vector = new Vector2(1, -1);
            Assert.AreEqual(-45f, vector.GetAngle());

            vector = new Vector2(-1, -1);
            Assert.AreEqual(-135f, vector.GetAngle());
        }

        [Test]
        public void Test_GetRotation()
        {
            Vector2 vector = Vector2.right;
            Assert.True(new Quaternion(0, 0, 0, 1f) == vector.GetRotation());

            vector = Vector2.left;
            Assert.True(new Quaternion(0, 0, 1f, 0) == vector.GetRotation());

            vector = Vector2.zero;
            Assert.True(new Quaternion(0, 0, 0, 1f) == vector.GetRotation());

            vector = new Vector2(1, 1);
            Assert.True(new Quaternion(0.000000000000f, 0.000000000000f, 0.382683500000f, 0.923879500000f) == vector.GetRotation());

            vector = new Vector2(1, -1);
            Assert.True(new Quaternion(0.000000000000f, 0.000000000000f, -0.382683500000f, 0.923879500000f) == vector.GetRotation());

            vector = new Vector2(-1, -1);
            Assert.True(new Quaternion(0.000000000000f, 0.000000000000f, -0.923879500000f, 0.382683400000f) == vector.GetRotation());
        }

        [Test]
        public void Test_TryGetCardinalDirection()
        {
            Vector2 vector = Vector2.zero;

            Vector2 directionVector = Vector2.right;
            bool success = vector.TryGetCardinalDirection(directionVector, out Direction direction);
            Assert.True(success);
            Assert.AreEqual(Direction.RIGHT, direction);

            directionVector = Vector2.up;
            success = vector.TryGetCardinalDirection(directionVector, out direction);
            Assert.True(success);
            Assert.AreEqual(Direction.UP, direction);

            directionVector = Vector2.zero;
            success = vector.TryGetCardinalDirection(directionVector, out direction);
            Assert.True(success);
            Assert.AreEqual(Direction.NONE, direction);

            directionVector = new Vector2(1, 1);
            success = vector.TryGetCardinalDirection(directionVector, out direction);
            Assert.False(success);
            Assert.AreEqual(Direction.NONE, direction);
        }

        [Test]
        public void Test_TryGetDirection()
        {
            Vector2 vector = Vector2.zero;

            Vector2 directionVector = Vector2.right;
            bool success = vector.TryGetDirection(directionVector, out Direction direction);
            Assert.True(success);
            Assert.AreEqual(Direction.RIGHT, direction);

            directionVector = Vector2.up;
            success = vector.TryGetDirection(directionVector, out direction);
            Assert.True(success);
            Assert.AreEqual(Direction.UP, direction);

            directionVector = Vector2.zero;
            success = vector.TryGetDirection(directionVector, out direction);
            Assert.True(success);
            Assert.AreEqual(Direction.NONE, direction);

            directionVector = new Vector2(1, 1);
            success = vector.TryGetDirection(directionVector, out direction);
            Assert.True(success);
            Assert.AreEqual(Direction.UP_RIGHT, direction);

            directionVector = new Vector2(.3f, .3f);
            success = vector.TryGetDirection(directionVector, out direction);
            Assert.True(success);
            Assert.AreEqual(Direction.UP_RIGHT, direction);
        }

        [Test]
        public void Test_GetDirection()
        {
            Vector2 vector = Vector2.zero;

            Vector2 directionVector = Vector2.right;
            Assert.True(Vector2.right == vector.GetDirection(directionVector));

            directionVector = Vector2.left;
            Assert.True(Vector2.left == vector.GetDirection(directionVector));

            directionVector = Vector2.zero;
            Assert.True(Vector2.zero == vector.GetDirection(directionVector));

            directionVector = new Vector2(1, 1);
            Assert.True(new Vector2(1, 1) == vector.GetDirection(directionVector));

            directionVector = new Vector2(.36f, -1.2f);
            Assert.True(new Vector2(.36f, -1.2f) == vector.GetDirection(directionVector));
        }

        [Test]
        public void Test_GetRawDirection()
        {
            Vector2 vector = Vector2.zero;

            Vector2 directionVector = Vector2.right;
            Assert.True(Vector2.right == vector.GetRawDirection(directionVector));

            directionVector = Vector2.left;
            Assert.True(Vector2.left == vector.GetRawDirection(directionVector));

            directionVector = Vector2.zero;
            Assert.True(Vector2.zero == vector.GetRawDirection(directionVector));

            directionVector = new Vector2(1, 1);
            Assert.True(new Vector2(1, 1) == vector.GetRawDirection(directionVector));

            directionVector = new Vector2(.36f, -1.2f);
            Assert.True(new Vector2(1, -1) == vector.GetRawDirection(directionVector));
        }

        [Test]
        public void Test_GetNormalizedDirection()
        {
            Vector2 vector = Vector2.zero;

            Assert.AreEqual(new Vector2(0, 0), vector.GetNormalizedDirection(Vector2.zero));
            Assert.AreEqual(new Vector2(1, 0), vector.GetNormalizedDirection(Vector2.right));
            Assert.AreEqual(new Vector2(1, 0), vector.GetNormalizedDirection(Vector2.right * 55));

            Vector2 normalizedDir = vector.GetNormalizedDirection(new Vector2(29, -13));
            Assert.AreEqual(.912509322f, normalizedDir.x);
            Assert.AreEqual(-.409055918f, normalizedDir.y);
        }

        [Test]
        public void Test_IsAbove()
        {
            Vector2 vector = Vector2.zero;
            Vector2 aboveVector = new Vector2(1, 1);
            Vector2 belowVector = new Vector2(1, -1);

            Assert.False(vector.IsAbove(Vector2.zero));
            Assert.False(vector.IsAbove(aboveVector));
            Assert.True(vector.IsAbove(belowVector));
        }

        [Test]
        public void Test_IsAboveOrOn()
        {
            Vector2 vector = Vector2.zero;
            Vector2 aboveVector = new Vector2(1, 1);
            Vector2 belowVector = new Vector2(1, -1);

            Assert.True(vector.IsAboveOrOn(Vector2.zero));
            Assert.False(vector.IsAboveOrOn(aboveVector));
            Assert.True(vector.IsAboveOrOn(belowVector));
        }

        [Test]
        public void Test_IsBelow()
        {
            Vector2 vector = Vector2.zero;
            Vector2 aboveVector = new Vector2(1, 1);
            Vector2 belowVector = new Vector2(1, -1);

            Assert.False(vector.IsBelow(Vector2.zero));
            Assert.True(vector.IsBelow(aboveVector));
            Assert.False(vector.IsBelow(belowVector));
        }

        [Test]
        public void Test_IsBelowOrOn()
        {
            Vector2 vector = Vector2.zero;
            Vector2 aboveVector = new Vector2(1, 1);
            Vector2 belowVector = new Vector2(1, -1);

            Assert.True(vector.IsBelowOrOn(Vector2.zero));
            Assert.True(vector.IsBelowOrOn(aboveVector));
            Assert.False(vector.IsBelowOrOn(belowVector));
        }

        [Test]
        public void Test_IsRightOf()
        {
            Vector2 vector = Vector2.zero;
            Vector2 rightVector = new Vector2(1, 1);
            Vector2 leftVector = new Vector2(-1, -1);

            Assert.False(vector.IsRightOf(Vector2.zero));
            Assert.False(vector.IsRightOf(rightVector));
            Assert.True(vector.IsRightOf(leftVector));
        }

        [Test]
        public void Test_IsRightOfOrOn()
        {
            Vector2 vector = Vector2.zero;
            Vector2 rightVector = new Vector2(1, 1);
            Vector2 leftVector = new Vector2(-1, -1);

            Assert.True(vector.IsRightOfOrOn(Vector2.zero));
            Assert.False(vector.IsRightOfOrOn(rightVector));
            Assert.True(vector.IsRightOfOrOn(leftVector));
        }

        [Test]
        public void Test_IsLeftOf()
        {
            Vector2 vector = Vector2.zero;
            Vector2 rightVector = new Vector2(1, 1);
            Vector2 leftVector = new Vector2(-1, -1);

            Assert.False(vector.IsLeftOf(Vector2.zero));
            Assert.True(vector.IsLeftOf(rightVector));
            Assert.False(vector.IsLeftOf(leftVector));
        }

        [Test]
        public void Test_IsLeftOfOrOn()
        {
            Vector2 vector = Vector2.zero;
            Vector2 rightVector = new Vector2(1, 1);
            Vector2 leftVector = new Vector2(-1, -1);

            Assert.True(vector.IsLeftOfOrOn(Vector2.zero));
            Assert.True(vector.IsLeftOfOrOn(rightVector));
            Assert.False(vector.IsLeftOfOrOn(leftVector));
        }
    }
}