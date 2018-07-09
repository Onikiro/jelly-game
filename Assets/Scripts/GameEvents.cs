using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{

    public static void Send(Action action)
    {
        if (action != null)
            action();
    }

    public static void Send<T>(Action<T> action, T value)
    {
        if (action != null)
            action(value);
    }
    public static void Send<T1, T2>(Action<T1, T2> action, T1 value1, T2 value2)
    {
        if (action != null)
            action(value1, value2);
    }
    public static void Send<T1, T2, T3>(Action<T1, T2, T3> action, T1 value1, T2 value2, T3 value3)
    {
        if (action != null)
            action(value1, value2, value3);
	}
	public static void Send<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, T1 value1, T2 value2, T3 value3, T4 value4)
	{
		if (action != null)
			action(value1, value2, value3, value4);
	}
}

