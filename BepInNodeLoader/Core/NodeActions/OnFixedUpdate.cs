using System;
using System.Collections.Generic;
using UnityEngine;

namespace BepInNodeLoader.Core.NodeActions;

public class OnFixedUpdate : MonoBehaviour
{
    private static List<Action> _actions = new();

    public void FixedUpdate()
    {
        _actions.ForEach(action => action.Invoke());
    }

    public static void Subscribe(Action action)
    {
        _actions.Add(action);
    }

    public static void Unsubscribe(Action action)
    {
        _actions.Remove(action);
    }
}
