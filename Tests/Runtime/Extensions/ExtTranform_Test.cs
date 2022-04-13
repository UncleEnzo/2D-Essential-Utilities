using System.Collections;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Nevelson.Utils
{
    public class ExtTranform_Test
    {
        [UnityTest]
        public IEnumerator Test_DestroyAllChildren()
        {
            //Wait a frame option
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
            oGO.transform.DestroyAllChildren();
            Assert.False(oGO == null);
            Assert.False(nsoGO == null);
            Assert.False(rsoGO == null);
            Assert.False(nssoGO == null);
            Assert.False(rssoGO == null);
            Assert.False(nsssoGO == null);
            Assert.False(rsssoGO == null);
            yield return null;
            Assert.False(oGO == null);
            Assert.True(nsoGO == null);
            Assert.True(rsoGO == null);
            Assert.True(nssoGO == null);
            Assert.True(rssoGO == null);
            Assert.True(nsssoGO == null);
            Assert.True(rsssoGO == null);
        }
    }
}