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

    public static float Height(this Camera camera)
    {
        return camera.orthographicSize * 2;
    }

    public static float Width(this Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        return camera.Height() * screenAspect;
    }

    public static Vector2 Size(this Camera camera)
    {
        return new Vector2(camera.Width(), camera.Height());
    }

    public static Vector2 HalfSize(this Camera camera)
    {
        var size = camera.Size();

        return new Vector2(size.x / 2, size.y / 2);
    }

    public static Bounds OrthographicBounds(this Camera camera)
    {
        var size = camera.Size();

        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(size.x, size.y, 0));
        return bounds;
    }
}
