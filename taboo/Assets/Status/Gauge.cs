using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public Image mgbar; //멘탈게이지 바 오브젝트

    void Update()
    {
        float MG = MentalGauge.Instance.playerGauge; //멘탈게이지 수치를 인스턴스로 받아옴
        mgbar.fillAmount = MG / 100f; //멘탈게이지 바와 멘탈게이지 수치간 연동
    }
}
