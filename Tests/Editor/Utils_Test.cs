using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static Nevelson.Utils.Enums;

namespace Nevelson.Utils
{
    public class Utils_Test
    {
        [Test]
        public void Test_ConvertVolumeToLogarithmic()
        {
            List<TestCase<float, float>> tc = new List<TestCase<float, float>>()
            {
                new TestCase<float, float> {
                    name = "Below No Volume",
                    input = -.5f,
                    expected = -Mathf.Infinity,
                },
                new TestCase<float, float> {
                    name = "No Volume",
                    input = 0,
                    expected = -Mathf.Infinity,
                },
                new TestCase<float, float> {
                    name = "Low Volume",
                    input = .25f,
                    expected = -12.0412006f,
                },
                new TestCase<float, float> {
                    name = "Mid Volume",
                    input = .5f,
                    expected = -6.02060032f,
                },
                new TestCase<float, float> {
                    name = "Max volume",
                    input = 1,
                    expected = 0.0f,
                },
                new TestCase<float, float> {
                    name = "Above Max Volume",
                    input = -.5f,
                    expected = -Mathf.Infinity,
                },
            };

            foreach (var test in tc)
            {
                float volume = Utils.ConvertVolumeToLogarithmic(test.input);
                Assert.AreEqual(test.expected, volume, test.name);
            }
        }

        [Test]
        public void Test_GetCardinalDirection()
        {
            List<TestCase<Vector2, Vector2, Direction>> tc = new List<TestCase<Vector2, Vector2, Direction>>()
            {
                new TestCase<Vector2, Vector2, Direction> {
                    name = "Up",
                    input = Vector2.zero,
                    input2 = Vector2.up,
                    expected = Direction.UP,
                },
                new TestCase<Vector2, Vector2, Direction> {
                    name = "Down",
                    input = Vector2.zero,
                    input2 = Vector2.down,
                    expected = Direction.DOWN,
                },
                new TestCase<Vector2, Vector2, Direction> {
                    name = "Left",
                    input = Vector2.zero,
                    input2 = Vector2.left,
                    expected = Direction.LEFT,
                },
                new TestCase<Vector2, Vector2, Direction> {
                    name = "Right",
                    input = Vector2.zero,
                    input2 = Vector2.right,
                    expected = Direction.RIGHT,
                },
                new TestCase<Vector2, Vector2, Direction> {
                    name = "No Direction",
                    input = Vector2.zero,
                    input2 = Vector2.zero,
                    expected = Direction.NONE,
                },
                new TestCase<Vector2, Vector2, Direction> {
                    name = "Diagonal Up left",
                    input = Vector2.zero,
                    input2 = new Vector2(-.3f, .3f),
                    expected = Direction.NONE,
                },
                new TestCase<Vector2, Vector2, Direction> {
                    name = "Diagonal Up right",
                    input = Vector2.zero,
                    input2 = new Vector2(.3f, .3f),
                    expected = Direction.NONE,
                },
                new TestCase<Vector2, Vector2, Direction> {
                    name = "Diagonal Down left",
                    input = Vector2.zero,
                    input2 = new Vector2(-.3f, -.3f),
                    expected = Direction.NONE,
                },
                new TestCase<Vector2, Vector2, Direction> {
                    name = "Diagonal down right",
                    input = Vector2.zero,
                    input2 = new Vector2(.3f, -.3f),
                    expected = Direction.NONE,
                },
            };

            foreach (var test in tc)
            {
                Direction dir = Utils.GetCardinalDirection(test.input, test.input2);
                Assert.AreEqual(test.expected, dir, test.name);
            }
        }

        [Test]
        public void Test_FormatTime()
        {
            List<TestCase<float, string>> tc = new List<TestCase<float, string>>()
            {
                new TestCase<float, string> {
                    name = "Negative time",
                    input = -100,
                    expected = "-01:40.00",
                },
                new TestCase<float, string> {
                    name = "No Time",
                    input = 0,
                    expected = "00:00.00",
                },
                new TestCase<float, string> {
                    name = "milli seconds",
                    input = .24f,
                    expected = "00:00.24",
                },
                new TestCase<float, string> {
                    name = "seconds and milli seconds",
                    input = 1.24f,
                    expected = "00:01.24",
                },
                new TestCase<float, string> {
                    name = "minutes, seconds and milli seconds",
                    input = 100.24f,
                    expected = "01:40.24",
                },
                new TestCase<float, string> {
                    name = "Long float",
                    input = 100.243423423455f,
                    expected = "01:40.24",
                },
            };

            foreach (var test in tc)
            {
                string timeFormatted = Utils.FormatTime(test.input);
                Assert.AreEqual(test.expected, timeFormatted, test.name);
            }
        }

        [Test]
        public void Test_StripPunctuation()
        {
            List<TestCase<string, string>> tc = new List<TestCase<string, string>>()
            {
                new TestCase<string, string> {
                    name = "null string",
                    input = null,
                    expected = "",
                },
                new TestCase<string, string> {
                    name = "empty string",
                    input = "",
                    expected = "",
                },
                new TestCase<string, string> {
                    name = "dirty dirty string",
                    input = ",./1234 5680-=!@#$%^&*)_+ABCabc",
                    expected = "1234 5680=$^+ABCabc",
                },
            };

            foreach (var test in tc)
            {
                string punctuationlessString = Utils.StripPunctuation(test.input);
                Assert.AreEqual(test.expected, punctuationlessString, test.name);
            }
        }

        [Test]
        public void Test_CopyComponent()
        {
            string expectedStr = "New String";
            GameObject sourceGO = new GameObject("Source");
            GameObject targetGO = new GameObject("Target");
            MockComponent sourceMock = sourceGO.AddComponent<MockComponent>();

            sourceMock.MockStringField = expectedStr;
            sourceMock.MockStringGetterSetter = expectedStr;
            sourceMock.MockStringGetterSetterWithRef = expectedStr;
            Assert.AreEqual(expectedStr, sourceMock.MockStringField);
            Assert.AreEqual(expectedStr, sourceMock.MockStringGetterSetter);
            Assert.AreEqual(expectedStr, sourceMock.MockStringGetterSetterWithRef);

            MockComponent copy = Utils.CopyComponent(sourceMock, targetGO);
            Assert.NotNull(copy);
            Assert.NotNull(targetGO.GetComponent<MockComponent>());

            Assert.AreEqual(expectedStr, targetGO.GetComponent<MockComponent>().MockStringField);
            Assert.AreEqual(expectedStr, copy.MockStringField);

            //does not work with compiled getter/setter
            Assert.AreNotEqual(expectedStr, targetGO.GetComponent<MockComponent>().MockStringGetterSetterWithRef);
            Assert.AreNotEqual(expectedStr, copy.MockStringGetterSetterWithRef);

            //does not work with compiled getter/setter
            Assert.AreNotEqual(expectedStr, targetGO.GetComponent<MockComponent>().MockStringGetterSetter);
            Assert.AreNotEqual(expectedStr, copy.MockStringGetterSetter);

            GameObject.DestroyImmediate(sourceGO);
            GameObject.DestroyImmediate(targetGO);
        }

        [Test]
        public void Test_FindComponentsOfType()
        {
            GameObject roGO = new GameObject("Random Object");
            roGO.AddComponent<MockComponent>();

            GameObject rsoGO = new GameObject("Random Sub Object");
            rsoGO.AddComponent<MockComponent>();
            rsoGO.transform.parent = roGO.transform;

            GameObject oroGO = new GameObject("Other Random Object");
            oroGO.AddComponent<MockComponent>();


            List<MockComponent> mockComponents = Utils.FindComponentsOfType<MockComponent>();
            Assert.IsTrue(3 == mockComponents.Count, $"Mock component length = {mockComponents.Count}");

            GameObject.DestroyImmediate(roGO);
            GameObject.DestroyImmediate(rsoGO);
            GameObject.DestroyImmediate(oroGO);
        }

        [Test]
        public void Test_FindChildWithTagGO()
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

            GameObject child = Utils.FindChildWithTag(oGO, "Player");
            Assert.AreEqual(rssoGO, child, "If failed, make sure player tag already exists in your project");

            GameObject.DestroyImmediate(oGO);
            GameObject.DestroyImmediate(nsoGO);
            GameObject.DestroyImmediate(rsoGO);
            GameObject.DestroyImmediate(nssoGO);
            GameObject.DestroyImmediate(rssoGO);
        }

        [Test]
        public void Test_FindChildWithTagTransform()
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

            Transform child = Utils.FindChildWithTag(oGO.transform, "Player");
            Assert.AreEqual(rssoGO.transform, child, "If failed, make sure player tag already exists in your project");

            GameObject.DestroyImmediate(oGO);
            GameObject.DestroyImmediate(nsoGO);
            GameObject.DestroyImmediate(rsoGO);
            GameObject.DestroyImmediate(nssoGO);
            GameObject.DestroyImmediate(rssoGO);
        }
    }
}