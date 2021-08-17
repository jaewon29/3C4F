using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public void clickSFX()
    {
        //버튼효과음
        soundManager.Instance.PlaySFX("Click2", false);
    }
}
