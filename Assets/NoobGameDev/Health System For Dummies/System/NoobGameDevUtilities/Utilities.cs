using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    static Utilities _instance = new Utilities();
    public static Utilities Instance { 
        get
        {
            return _instance;
        }
        private set { }
    }

    public PrefabUtilities Prefab { get; private set; }

    public Utilities()
    {
        Prefab = new PrefabUtilities();
    }

}
