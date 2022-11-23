using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //sourcehttps://answers.unity.com/questions/984389/how-to-limit-the-rotation-of-transformrotate.html
    public static float ConvertToAngle180(float input)
    {
        while (input > 360)
        {
            input = input - 360;
        }
        while (input < -360)
        {
            input = input + 360;
        }
        if (input > 180)
        {
            input = input - 360;
        }
        if (input < -180)
            input = 360 + input;
        return input;
    }

    //sourcehttps://gamedev.stackexchange.com/questions/139003/calculate-vector3-global-point-projecting-it-in-local-space-using-unity-and-c
    public static T[] CoorinateTransform<T>(T[] vector, T[][] currentCoordinateMatrix, T[][] newCoordinateMatrix)
    {
        return vector;
    }

    //sourcehttps://nerdhut.de/2020/05/09/unity-arcball-camera-spherical-coordinates/
    public static Vector3 getSphericalCoordinates(Vector3 cartesian)
    {
        float r = Mathf.Sqrt(
            Mathf.Pow(cartesian.x, 2) +
            Mathf.Pow(cartesian.y, 2) +
            Mathf.Pow(cartesian.z, 2)
        );

        // use atan2 for built-in checks
        float phi = Mathf.Atan2(cartesian.z / cartesian.x, cartesian.x);
        float theta = Mathf.Acos(cartesian.y / r);

        return new Vector3(r, phi, theta);
    }

    //sourcehttps://nerdhut.de/2020/05/09/unity-arcball-camera-spherical-coordinates/
    public static Vector3 getCartesianCoordinates(Vector3 spherical)
    {
        Vector3 ret = new Vector3();

        ret.x = spherical.x * Mathf.Cos(spherical.z) * Mathf.Cos(spherical.y);
        ret.y = spherical.x * Mathf.Sin(spherical.z);
        ret.z = spherical.x * Mathf.Cos(spherical.z) * Mathf.Sin(spherical.y);

        return ret;
    }
}
