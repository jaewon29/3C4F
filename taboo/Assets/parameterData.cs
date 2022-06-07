using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parameterData : MonoBehaviour
{
    public static Item[] ItemArr;
    public static float mentalGauge = 100f;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
