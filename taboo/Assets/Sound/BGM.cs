using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    void Start()
    {
        soundManager.Instance.ChangeBGM("BGM", false);
    }
}
