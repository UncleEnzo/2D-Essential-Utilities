using NUnit.Framework;
using UnityEngine;

namespace Nevelson.Utils
{
    public class ExtLayermasks_Test
    {
        [Test]
        public void Test_IsInLayerMask()
        {
            LayerMask layerMask = new LayerMask();
            layerMask |= (1 << LayerMask.NameToLayer("Default"));
            Assert.False(layerMask.IsInLayerMask("Non-Existant"));
            Assert.True(layerMask.IsInLayerMask("Default"));
        }
    }
}