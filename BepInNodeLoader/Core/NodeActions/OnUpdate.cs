using System;
using System.Collections.Generic;
using UnityEngine;

namespace BepInNodeLoader.Core.NodeActions;

public class OnUpdate : MonoBehaviour
{
    private static List<Action> _actions = new();

    public void Update()
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
