using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class selection_cycle2
{
    public string cycle_name;
    [TextArea(3, 5)]
    public string choice;
    public bool check_cycle_read;
}

public class selection2 : MonoBehaviour
{
    [SerializeField]
    public static selection2 instance = null;
    public List<selection_cycle2> selection_cycles = new List<selection_cycle2>();
    public Queue<string> content_seq = new Queue<string>();

    public Text choiceT; //선택지 텍스트 오브젝트
    public GameObject selection_obj; //선택창 오브젝트


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
        choiceT = selection_obj.GetComponent<parameter2>().choice_text;
  
        choiceT.text = selection_cycles[index].choice;

        if (selection.way == 2)
        {
            selection_obj.gameObject.SetActive(false);
        }

        yield return null;


    }
/*
    public bool isSelected()
    {
        if (Input.GetMouseButton(0))
        {
            return true;
        }

        return false;
    }
*/
}
