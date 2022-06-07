using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void toLoadMenu()
    {
        SceneManager.LoadScene("SampleForLoad");
    }

    public static void toSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void toOptionScene()
    {
        SceneManager.LoadScene("Option");
    }

}
