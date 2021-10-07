﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
[System.Serializable]
public class dialog_info
{
    public string name;
    [TextArea(3, 5)]
    public string content;
    public bool check_read;
}

[System.Serializable]
public class Dialog_cycle
{
    public string cycle_name;
    public List<dialog_info> info = new List<dialog_info>();
    public int cycle_index;
    public bool check_cycle_read;
}


public class dialog : MonoBehaviour
{
    [SerializeField]
    public static dialog instance = null;
    public List<Dialog_cycle> dialog_cycles = new List<Dialog_cycle>(); //대화 지문 그룹
    public Queue<string> text_seq = new Queue<string>();                //대화 지문들의 내용을 큐로 저장한다.(끝점을 쉽게 판단하기 위해)
    public string name_;                                                //임시로 저장할 대화 지문의 이름
    public string text_;                                                //임시로 저장할 대화 지문의 내용

    public Text nameing;                                                //대화 지문 오브젝트에 있는 것을 표시할 오브젝트
    public Text DialogT;                                                //대화 지문 내용 오브젝트
                                             //다음 버튼
    public GameObject dialog_obj;                                       //대화 지문 오브젝트

    IEnumerator seq_;
    IEnumerator skip_seq;

    public float delay;
    public bool running = false;
    void Awake()    //싱글톤 패턴
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

       // DontDestroyOnLoad(gameObject); //코루틴을 적게 사용해보자, 싱글톤패턴도 나중에 디버깅할때 힘드니까 다시 고려해보자, scriptableObject
        dialog_obj = GameObject.Find("Dialog");
    }
    public IEnumerator dialog_system_start(int index)//다이얼로그 출력 시작
    {
        
        nameing = dialog_obj.GetComponent<parameter>().name_text;   //다이얼로그 오브젝트에서 각 변수 받아오기
        DialogT = dialog_obj.GetComponent<parameter>().content;
        
        running = true;
        text_seq.Clear();

        foreach (dialog_info dialog_temp in dialog_cycles[index].info)  //대화 단위를 큐로 관리하기 위해 넣는다.
        {
            text_seq.Enqueue(dialog_temp.content);
        }

        dialog_obj.gameObject.SetActive(true);
        for (int i = 0; i < dialog_cycles[index].info.Count; i++) //대화 단위를 순서대로 출력
        {

            nameing.text = dialog_cycles[index].info[i].name;

            text_ = text_seq.Dequeue();                                  //대화 지문을 pop

            seq_ = seq_sentence(index, i);                               //대화 지문 출력 코루틴
            StartCoroutine(seq_);
            //코루틴 실행
            if (gameObject == null)
            {
                StopCoroutine(seq_);
            }


            yield return new WaitUntil(() =>
            {
                if (dialog_cycles[index].info[i].check_read)            //현재 대화를 읽었는지 아닌지
                {
                    return true;                                        //읽었다면 진행
                }
                else
                {
                    return false;                                       //읽지 않았다면 다시 검사
                }
            });
        }

        dialog_cycles[index].check_cycle_read = true;                   //해당 대화 그룹 읽음
        running = false;

    }

    public void DisplayNext(int index, int number)                      //다음 지문으로 넘어가기
    {


        if (text_seq.Count == 0)                                        //다음 지문이 없다면
        {
            dialog_obj.gameObject.SetActive(false);                     //다이얼로그 끄기
        }
        StopCoroutine(seq_);                                            //실행중인 코루틴 종료

        dialog_cycles[index].info[number].check_read = true;            //현재 지문 읽음으로 표시
    }

    public IEnumerator seq_sentence(int index, int number)              //지문 텍스트 한글자식 연속 출력
    {

        skip_seq = touch_wait(seq_, index, number);                     //터치 스킵을 위한 터치 대기 코루틴 할당
        StartCoroutine(skip_seq);
        //터치 대기 코루틴 시작
        if (DialogT != null)
        {
            DialogT.text = "";                                              //대화 지문 초기화
            foreach (char letter in text_.ToCharArray())                    //대화 지문 한글자씩 뽑아내기
            {
                DialogT.text += letter;                                     //한글자씩 출력
                yield return new WaitForSeconds(delay);                     //출력 딜레이
            }
        }

        StopCoroutine(skip_seq);                                        //지문 출력이 끝나면 터치 대기 코루틴 해제
        IEnumerator next = next_touch(index, number);                   //버튼 이외에 부분을 터치해도 넘어가는 코루틴 시작
        StartCoroutine(next);

    }

    public IEnumerator touch_wait(IEnumerator seq, int index, int number)//터치 대기 코루틴
    {
        yield return new WaitForSeconds(0.3f);
        yield return new WaitUntil(() => Input.GetMouseButton(0));
        StopCoroutine(seq);                                              //대화 지문 코루틴 해제
        DialogT.text = text_;                                            //스킵시 모든 지문 한번에 출력

        IEnumerator next = next_touch(index, number);                    //대화 지문 코루틴 해제 됬기 때문에 다음 지문으로 가는 코루틴 시작
        StartCoroutine(next);
    }

    public IEnumerator next_touch(int index, int number)    //터치로 다음 지문 넘어가는 코루틴
    {
        StopCoroutine(seq_);
        StopCoroutine(skip_seq);
        yield return new WaitForSeconds(0.3f);
        yield return new WaitUntil(() => Input.GetMouseButton(0));
        DisplayNext(index, number);
    }

    public bool dialog_read(int check_index)          //index의 부분을 읽었는지 확인하는 함수
    {
        if (!dialog_cycles[check_index].check_cycle_read)
        {
            return true;
        }

        return false;
    }

    public int current_dialog()
    {
        for (int i = 0; i < dialog_cycles.Count; i++)
        {
            if (dialog_read(i) && !dialog_read(i - 1))
            {
                return i;
            }
            else
            {
                continue;
            }
        }
        return 0;
    }

    public void load_dialog(int check_index)
    {
        for (int i = 0; i < check_index; i++)
        {
            dialog_cycles[i].check_cycle_read = true;
        }
    }

    public void reset_data()
    {
        for (int i = 0; i < 2; i++)
        {
            dialog_cycles[i].check_cycle_read = false;
            //print(i);
        }
    }

}
