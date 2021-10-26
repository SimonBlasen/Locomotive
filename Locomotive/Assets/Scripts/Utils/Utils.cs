using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Sappph
{
    public class Utils
    {
        public static float NormalDistribution(float mean, float stdDev)
        {
            float rand0 = UnityEngine.Random.Range(0f, 1f);
            float rand1 = UnityEngine.Random.Range(0f, 1f);
            float u1 = 1.0f - rand0; //uniform(0,1] random doubles
            float u2 = 1.0f - rand1;
            float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) *
                         Mathf.Sin(2.0f * Mathf.PI * u2); //random normal(0,1)
            float randNormal =
                         mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)

            return randNormal;
        }

        public static bool IsInIntArray(int[] array, int element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

    }

}