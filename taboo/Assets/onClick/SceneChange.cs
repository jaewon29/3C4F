using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject menu;
    public GameObject dialog;
    //public GameObject prologue_obj;
    //public GameObject mainmenu_obj;


    public void toLoadMenu()
    {
        //prologue_obj.gameObject.SetActive(false);
        //mainmenu_obj.gameObject.SetActive(true);
        SceneManager.LoadScene("SampleForLoad");
        
    }

    public void toSampleScene()
    {
        // prologue_obj.gameObject.SetActive(true);
        //mainmenu_obj.gameObject.SetActive(false);

        // newDialog.instance.StartDialog(0);
        SceneManager.LoadScene("SampleScene");
    }

    public void toOptionScene()
    {
        SceneManager.LoadScene("Option");
    }

    public void openPopUp()
    { 
        Time.timeScale = 0f;
        menu.SetActive(true);
        dialog.SetActive(false);
    }

    public void closePopup()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
        dialog.SetActive(true);
    }
}
