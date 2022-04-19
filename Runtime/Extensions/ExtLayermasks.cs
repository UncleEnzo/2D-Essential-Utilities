using UnityEngine;

namespace Nevelson.Utils
{
    public static class ExtLayermasks
    {
        /// <summary>
        /// Checks if the layername is part of a layermask
        /// </summary>
        /// <param name="layerMask"></param>
        /// <param name="layerName"></param>
        /// <returns></returns>
        public static bool IsInLayerMask(this LayerMask layerMask, string layerName)
        {
            return layerMask == (layerMask | 1 << LayerMask.NameToLayer(layerName));
        }
    }
}