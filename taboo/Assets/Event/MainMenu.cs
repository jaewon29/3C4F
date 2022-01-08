using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject NewGame;
    public GameObject Load;
    public GameObject Setting;
    public GameObject Gallery;
    public GameObject Credits;
    public GameObject Buttons;

    void Start()
    {
        soundManager.Instance.ChangeBGM("bgm_main-1.2", false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (NewGame.activeSelf == true)
            {
                SceneManager.LoadScene("SampleScene");
            }

            else if (Load.activeSelf == true)
            {
                GameObject.Find("SLManager").GetComponent<SLManager>()._load();
                SceneManager.LoadScene("SampleScene");
            }

            else if (Setting.activeSelf == true)
            {
                SceneManager.LoadScene("Option");
            }

            else if (Gallery.activeSelf == true)
            {

            }

            else if (Credits.activeSelf == true)
            {

            }
        }
    }
}
