using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnClick : MonoBehaviour
{
    public GameObject menu, dialog, inventory, inventoryCloseBtn, ItemPopUp, ItemScript, shop, book, job, commu, youtube;
    //메인 스토리 페이즈에서 사용되는 함수

    public void openMenuPopUp()
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
        dialog.SetActive(false);
    }

    public void closeMenuPopup()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
        dialog.SetActive(true);
    }

    public void openInventory()
    {
        Time.timeScale = 0f;
        inventory.SetActive(true);
        inventoryCloseBtn.SetActive(true);
    }

    public void closeInventory()
    {
        Time.timeScale = 1f;
        inventory.SetActive(false);
        inventoryCloseBtn.SetActive(false);
    }

    public void closeItemPopUp()
    {
        ItemPopUp.SetActive(false);
    }

    public void closeItemScript()
    {
        ItemScript.SetActive(false);
    }

    //자유행동 페이즈에서 사용되는 함수

    public void openShop()
    {
        shop.SetActive(true);
    }

    public void closeShop()
    {
        shop.SetActive(false);
    }

    public void buyItem()
    {
        freeAction.TurnChange(-1);
        freeAction.MoneyChange(-10000);
        Inventory.Instance.AddItem(parameterData.ItemArr[0]);
    }

    public void openBook()
    {
        book.SetActive(true);
    }

    public void closeBook()
    {
        book.SetActive(false);
    }

    public void readBook()
    {
        freeAction.TurnChange(-1);
        freeAction.MoneyChange(-10000);
        parameterData.mentalGauge += 10f;
    }

    public void openJob()
    {
        job.SetActive(true);
    }

    public void closeJob()
    {
        job.SetActive(false);
    }

    public void DoJob()
    {
        freeAction.TurnChange(-1);
        freeAction.MoneyChange(10000);
        job.SetActive(false);
    }

    public void openCommu()
    {
        commu.SetActive(true);
    }

    public void closeCommu()
    {
        commu.SetActive(false);
    }

    public void openYoutube()
    {
        youtube.SetActive(true);
    }

    public void closeYoutube()
    {
        youtube.SetActive(false);
    }
}
