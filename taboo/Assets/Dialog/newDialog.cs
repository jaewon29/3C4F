using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


[System.Serializable]
public class dialogInfo
{
    public string name;
    [TextArea(3, 10)]
    public string sentences;

}
   
[System.Serializable]
public class dialogCycle
{
    public string cycle_name;
    public List<dialogInfo> info = new List<dialogInfo>();
    public int cycle_index;
}

public class newDialog : MonoBehaviour
{
    public static newDialog instance = null;
    public List<dialogCycle> cycle = new List<dialogCycle>();
    public Queue<string> text = new Queue<string>();
    public string sentence;
    public Text nameText;
    public Text dialogText;

    IEnumerator seq_;
    IEnumerator skip_seq;

    void Awake()
    {
        if (instance == null)
            instance = this;
        
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void StartDialog(int index)
    {
        text.Clear();

        foreach (dialogInfo dialog_temp in cycle[index].info)
        {
            text.Enqueue(dialog_temp.sentences);
        }

        DisplayNextSentence(index);
    }

    public void DisplayNextSentence(int index)
    {
        if (text.Count == 0)
        {
            return;
        }
        

        for (int i = 0; i < cycle[index].info.Count; i++)
        {
            nameText.text = cycle[index].info[i].name;
            sentence = text.Dequeue();
            print(sentence);
            dialogText.text = sentence;
            StopAllCoroutines();
            seq_ = TypeSentence(sentence);
            StartCoroutine(seq_);
        }
    }

    public IEnumerator TypeSentence (string sentence)
    {
        skip_seq = touch_wait(seq_);                     //터치 스킵을 위한 터치 대기 코루틴 할당
        StartCoroutine(skip_seq);
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
        StopCoroutine(skip_seq);
        IEnumerator next = next_touch();                    //대화 지문 코루틴 해제 됬기 때문에 다음 지문으로 가는 코루틴 시작
        StartCoroutine(next);
    }

    public IEnumerator touch_wait(IEnumerator seq)//터치 대기 코루틴
    {
        yield return new WaitForSeconds(0.3f);
        yield return new WaitUntil(() => Input.GetMouseButton(0));
        StopCoroutine(seq);                                              //대화 지문 코루틴 해제
        dialogText.text = sentence;                                            //스킵시 모든 지문 한번에 출력
        IEnumerator next = next_touch();                    //대화 지문 코루틴 해제 됬기 때문에 다음 지문으로 가는 코루틴 시작
        StartCoroutine(next);
    }

    public IEnumerator next_touch()    //터치로 다음 지문 넘어가는 코루틴
    {
        StopCoroutine(seq_);
        StopCoroutine(skip_seq);
        yield return new WaitForSeconds(0.3f);
        yield return new WaitUntil(() => Input.GetMouseButton(0));
        StopCoroutine(seq_);
    }

}