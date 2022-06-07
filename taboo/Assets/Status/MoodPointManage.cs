using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoodPointManage : MonoBehaviour
{
    public static int[] MoodPointArr = new int[4] {0, 0, 0, 0};//캐릭터 호감도 리스트 (0 = 주인공 1 = 강설아 2 = 박장원 3 = 한세림)
    public static GameObject MoodPoint;
    public static Text MoodPointC1_Text;

    public static void MoodPointChange(int character, int num) //호감도 변경(캐릭터 넘버, 증감수치)
    {
        MoodPointArr[character] += num;
        if (MoodPointArr[character] > 100)
        {
            MoodPointArr[character] = 100;
        }
        else if (MoodPointArr[character] < 0)
        {
            MoodPointArr[character] = 0;
        }

        if (character == 0)
        {
            MoodPointC1_Text.text = MoodPointArr[0].ToString();
        }
        
    }

    void Awake()
    {
        MoodPoint = GameObject.Find("MoodPoint");
        MoodPointC1_Text = MoodPoint.GetComponent<ParameterM>().MoodPointC1;
    }
}
