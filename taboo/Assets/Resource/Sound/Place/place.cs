using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class place : MonoBehaviour
{
    private static place _Instance = null;

    public static place Instance
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
        DontDestroyOnLoad(gameObject);
    }

    public string currentPlace; //현재 위치(이름)

    [SerializeField]
    [Header("names"), Tooltip("장소 이름들")]
    public string[] placeName = new string[2]; //장소 이름 배열 선언(크기 가변)
    public GameObject[] backgrounds = new GameObject[2]; //배경 오브젝트 배열 선언(크기 가변)
    /****(중요) 장소 이름과 배경 오브젝트 이름을 일치시켜야 한다*****/

    public void changePlace(string name) //현재 위치를 name으로 바꿈
    {
        currentPlace = null;
        for (int i = 0; i < placeName.Length; i++) //위치 이름 탐색
        {
            if (placeName[i] == name)
            {
                currentPlace = placeName[i]; //현재 위치 상태를 name으로 변경
            }
        }

        if(currentPlace == null)
        {
            return;
        }

        else //위치 이름이 있으면
        {
            for (int i = 0; i < backgrounds.Length; i++) //현재 위치와 동일한 이름의 배경 탐색
                if (backgrounds[i].name  == name)
                {
                    backgrounds[i].gameObject.SetActive(true); //해당 배경 오브젝트 활성화
                }
                else
                {
                    backgrounds[i].gameObject.SetActive(false); //이외의 모든 배경 오브젝트 비활성화
                }
        }
    }

    public bool isPlace(string name) //현재 있는 위치가 name과 같다면 true 아니면 false 반환 
    {
        if (currentPlace == name)
        {
            return true;
        }
        else
            return false;
    }
}
