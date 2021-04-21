using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionsHandy
{
    /// <summary>
    /// Return a random item from the list.
    /// Sampling with replacement.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static T RandomItem<T>(this IList<T> list)
    {
        if (list.Count == 0) throw new System.IndexOutOfRangeException("Cannot select a random item from an empty list");
        return list[UnityEngine.Random.Range(0, list.Count)];
    }

    public static Vector2 GetRandomDirection(this Vector2 v)
    {
        List<Vector2> list = new List<Vector2> { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
        return list.RandomItem<Vector2>();
    }
}
