using UnityEngine;

namespace Nevelson.Utils
{
    public static class ExtRenderer
    {
        /// <summary>
        /// Checks if the renderer component is visible from the camera
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
        }
    }
}