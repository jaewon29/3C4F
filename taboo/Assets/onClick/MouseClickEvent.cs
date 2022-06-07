using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseClickEvent : MonoBehaviour, IPointerClickHandler
{
   public GameObject ItemPopUp, ItemScript;

   public void OnPointerClick(PointerEventData eventData) //인벤토리가 비어있을 때 예외처리 필요
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            ItemPopUp.SetActive(true);
        }

        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            ItemScript.SetActive(true);
        }
    }
    
}
