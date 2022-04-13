using UnityEngine;

namespace Nevelson.Utils
{
    public static class ExtRectTransform
    {
        /// <summary>
        /// Sets the rect transform X pixels left of anchor
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="left"></param>
        public static void SetLeft(this RectTransform rt, float left)
        {
            rt.offsetMin = new Vector2(left, rt.offsetMin.y);
        }

        /// <summary>
        /// Sets the rect transform X pixels right of anchor
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="left"></param>
        public static void SetRight(this RectTransform rt, float right)
        {
            rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
        }

        /// <summary>
        /// Sets the rect transform X pixels up of anchor
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="left"></param>
        public static void SetTop(this RectTransform rt, float top)
        {
            rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
        }

        /// <summary>
        /// Sets the rect transform X pixels bottom of anchor
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="left"></param>
        public static void SetBottom(this RectTransform rt, float bottom)
        {
            rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
        }
    }
}