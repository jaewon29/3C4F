using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//동일한 내용의 selection2 스크립트가 있습니다. 각각 다른 버튼 오브젝트에 적용됩니다.
//본 스크립트는 모든 선택지에서 1번 선택지를 관리합니다.

[System.Serializable]
public class selection_cycle
{
    public string cycle_name; //선택지 이름(ID)
    [TextArea(3, 5)]
    public string choice; //선택지 버튼의 텍스트에 표기될 내용
    //public bool check_cycle_read;
}


public class selection : MonoBehaviour
{
    [SerializeField]
    public static selection instance = null;
    public List<selection_cycle> selection_cycles = new List<selection_cycle>(); //choice의 내용을 담을 리스트
    //public Queue<string> content_seq = new Queue<string>();

    public Text choiceT; //선택지 텍스트 오브젝트
    public GameObject selection_obj; //선택창 오브젝트(선택지 버튼들 부모)
    public Button choice1; //본 스크립트가 관리하는 선택지 버튼
    public static int way = 0; //선택지를 선택했을때 분기의 기준이 되는 전역변수(ex. 1 -> 1번선택지 2 -> 2번선택지)

    void Awake() //싱글톤 패턴
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator selection_system_start(int index)
    {
        choiceT = selection_obj.GetComponent<parameterC>().choice_text; //parameterC 스크립트로부터 버튼 오브젝트 정보 받아옴
        selection_obj.gameObject.SetActive(true); //부모 오브젝트 활성화(기본 비활성화)
        choiceT.text = selection_cycles[index].choice; //리스트에서 내용을 뽑아 버튼 오브젝트의 텍스트에 띄웁니다.
        if (way == 1) //선택지 1번을 골랐다면(버튼 오브젝트 클릭에 있습니다)
        {
            selection_obj.gameObject.SetActive(false); //부모 오브젝트 비활성화
        }

        yield return null;


    }


}
