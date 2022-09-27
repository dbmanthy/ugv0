using System.Collections;
using System.Collections.Generic;

public static class Utility
{
    public static T[] FisherYatesArrayShuffle<T>(T[] array, int seed = -1)
    {
        //psuedo random number generator
        System.Random prng = seed == -1 ? new System.Random() : new System.Random(seed);

        for(int i = 0; i < array.Length - 1; i ++)
        {
            int randomIndex = prng.Next(i, array.Length);
            T tempItem = array[randomIndex];
            array[randomIndex] = array[i];
            array[i] = tempItem;
        }
        return array;
    }
}
