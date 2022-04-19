using System;
using System.Collections;
using UnityEngine;

namespace Nevelson.Utils
{
    /// <summary>
    /// Util wrapper methods that reduces boiler plate for quick basic coroutine utils.
    /// Does not require unit tests because all functionality supplied by unity
    /// </summary>
    public static class UtilCoroutines
    {
        /// <summary>
        /// Waits for seconds before performing an action.  This timer slows with timescale.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="waitTime"></param>
        /// <returns></returns>
        public static IEnumerator WaitForSeconds(Action action, float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            action();
        }

        /// <summary>
        /// Waits for seconds before performing an action. This timer is not affected by timescale.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="waitTime"></param>
        /// <returns></returns>
        public static IEnumerator RealTimeWaitForSeconds(Action action, float waitTime)
        {
            yield return new WaitForSecondsRealtime(waitTime);
            action();
        }

        /// <summary>
        /// Waits for X amount of frames before executing coroutine.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="frames"></param>
        /// <returns></returns>
        public static IEnumerator WaitForFrames(Action action, int frames = 1)
        {
            for (int i = 0; i < frames; i++)
            {
                yield return null;
            }
            action();
        }
    }
}