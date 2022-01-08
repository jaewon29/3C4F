using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MoveMenu : MonoBehaviour
{
    public GameObject NewGame;
    public GameObject Load;
    public GameObject Setting;
    public GameObject Gallery;
    public GameObject Credits;

    public void MoveLeft()
    {
        if (NewGame.activeSelf == true)
        {
            NewGame.SetActive(false);
            Credits.SetActive(true);
        }

        else if (Load.activeSelf == true)
        {
            Load.SetActive(false);
            NewGame.SetActive(true);
        }

        else if (Setting.activeSelf == true)
        {
            Setting.SetActive(false);
            Load.SetActive(true);
        }

        else if (Gallery.activeSelf == true)
        {
            Gallery.SetActive(false);
            Setting.SetActive(true);
        }

        else if (Credits.activeSelf == true)
        {
            Credits.SetActive(false);
            Gallery.SetActive(true);
        }
    }

    public void MoveRight()
    {
        if (NewGame.activeSelf == true)
        {
            NewGame.SetActive(false);
            Load.SetActive(true);
        }

        else if (Load.activeSelf == true)
        {
            Load.SetActive(false);
            Setting.SetActive(true);
        }

        else if (Setting.activeSelf == true)
        {
            Setting.SetActive(false);
            Gallery.SetActive(true);
        }

        else if (Gallery.activeSelf == true)
        {
            Gallery.SetActive(false);
            Credits.SetActive(true);
        }

        else if (Credits.activeSelf == true)
        {
            Credits.SetActive(false);
            NewGame.SetActive(true);
        }

    }

}
