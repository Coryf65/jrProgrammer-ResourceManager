using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a subclass of the Building class. It doesn’t change the behavior of that class, but it does
/// store a singleton reference to it in its Awake function. This means that you can query the base from
/// anywhere. This is used by Units when they return to the base
/// </summary>
public class Base : Building
{ 
    public static Base Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}