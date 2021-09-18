using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject prologue_obj;
    public GameObject mainmenu_obj;
    

    public void toLoadMenu()
    {
        prologue_obj.gameObject.SetActive(false);
        mainmenu_obj.gameObject.SetActive(true);
        //SceneManager.LoadScene("SampleForLoad");

        Play.instance.StopCo();
        
        
    }

    public void toSampleScene()
    {
        prologue_obj.gameObject.SetActive(true);
        mainmenu_obj.gameObject.SetActive(false);

       // SceneManager.LoadScene("SampleScene");
        Play.instance.StartCo();
    }

    public void newGame()
    {
        Play.instance.checkNum = 0;
    }
}
