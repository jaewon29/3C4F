using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    public void BGMvolumeUP()
    {
        soundManager.Instance.changeBGMVolume(0.1f);
    }

    public void BGMvolumeDowm()
    {
        soundManager.Instance.changeBGMVolume(-0.1f);
    }

    public void SFXvolumeUP()
    {
        soundManager.Instance.changeBGMVolume(0.1f);
    }

    public void SFXvolumeDown()
    {
        soundManager.Instance.changeBGMVolume(-0.1f);
    }
}
