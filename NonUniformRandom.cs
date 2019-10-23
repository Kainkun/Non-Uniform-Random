using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NonUniformRandom<T>
{
    /// <summary>
    /// Randomly returns data from an array based on the inputted probabilities
    /// </summary>
    /// <param name="array">Input an array of any datatype</param>
    /// <param name="chances">Input an array of probabilities. If they add up to 100, it is identical to percent chance. Otherwise they are proportional to each other. (Ex. if 5,10,20 is inputted, there is a 5/35 chance of returning the first data, 10/35 for the second, 20/35 for the third)</param>
    /// <returns></returns>
    public static T RandomFromArray(T[] array, params float[] chances)
    {
        if (array.Length < chances.Length)
        {
            Debug.LogError("Cannot have more probablities than array length");
        }

        return array[NonUniformRandom.RandomInt(chances)];
    }

}


public static class NonUniformRandom
{
    /// <summary>
    /// Randomly returns an index from an array based on the inputted probabilities
    /// </summary>
    /// <param name="chances">Input an array of probabilities. If they add up to 100, it is identical to percent chance. Otherwise they are proportional to each other. (Ex. if 5,10,20 is inputted, there is a 5/35 chance of returning a 0, 10/35 for 1, 20/35 for 2)</param>
    /// <returns></returns>
    public static int RandomInt(params float[] chances)
    {
        float[] percentPositions = new float[chances.Length];

        percentPositions[0] = chances[0];
        for (int i = 1; i < chances.Length; i++)
        {
            percentPositions[i] = percentPositions[i-1] + chances[i];
        }

        float randPosition = Random.Range(0f, percentPositions[percentPositions.Length - 1]);

        return searchLessthan(randPosition, percentPositions);
    }


    static int searchLessthan(float lookFor, float[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (lookFor < array[i])
                return i;
        }

        return -1;
    }

}
