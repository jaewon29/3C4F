using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{

    void Start()
    {
        soundManager.Instance.ChangeBGM("Taboo_Main", false);
    }
   
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("SampleForLoad");
        }
    }

}
