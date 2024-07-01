using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentNullChecker
{
    private static ComponentNullChecker _instance = null;
    public static ComponentNullChecker Instance { 
        get {
            if (_instance == null)
                _instance = new ComponentNullChecker();

            return _instance;
        } }

    public bool CheckComponentNull<T>(T value, string className) where T : Component
    {
        if(value == null)
        {
            Debug.LogError(string.Format("{0} : {1} is null", className, nameof(value)));
            return true;
        }

        return false;
    }
}
