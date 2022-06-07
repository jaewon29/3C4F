using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class freeAction : MonoBehaviour
{
    public static int Turn, Money;
    public static GameObject TM;
    public static Text TurnNum_Text, MoneyNum_Text;
    

    public static void TurnChange(int num)
    {
        Turn += num;
        TurnNum_Text.text = Turn.ToString();
        if (Turn == 0)
        {
            SceneChange.toSampleScene();
        }
    }

    public static void MoneyChange(int num)
    {
        Money += num;
        MoneyNum_Text.text = Money.ToString();
    }

    void Start()
    {
        Turn = 10;
        Money = 0;
    }
    
    void Awake()
    {
        TM = GameObject.Find("TM");
        TurnNum_Text = TM.GetComponent<parameterF>().TurnNum;
        MoneyNum_Text = TM.GetComponent<parameterF>().MoneyNum;
    }
}
