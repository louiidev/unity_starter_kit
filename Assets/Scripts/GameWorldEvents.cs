using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameWorldEvents
{

    public delegate void ExampleEventAction();
    public static event ExampleEventAction OnExampleEvent;
    // OnExampleEvent?.Invoke();

    public static void ExampleEvent()
    {
       OnExampleEvent?.Invoke();
    }
}
