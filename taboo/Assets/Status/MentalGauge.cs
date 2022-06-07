using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentalGauge : MonoBehaviour
{
    /* 본 게임에서는 이름을 나눠서(아마 별도의 스테이터스 스크립트에서 관리 할 예정) 함수에서 이름을 받아서 조절
    public string player1, player2, player3, player4;
    public int P1Gaouge, P2Gaouge, P3Gaouge, P4Gaouge;
    */
    
    private static MentalGauge _Instance = null;

    public static MentalGauge Instance
    {
        get
        {
            if (_Instance == null)
            {
                Debug.Log("instance is null");
            }
            return _Instance;
        }
    }

    void Awake()
    {
        _Instance = this;
    }

    public float playerGauge = 100f; //플레이어 현재 멘탈 게이지

    public void MentalGaugeChange(float num) //멘탈게이지를 num만큼 변경
    {
        playerGauge += num;
        print(playerGauge);
        /**
        if (playerGauge > 100f) //100 이상일땐 100으로 고정
        {
            playerGauge = 100f;
        }
        **/
        if (playerGauge < 0f) //0 이하일땐 0으로 고정
        {
            playerGauge = 0f;
        }

    }

}
