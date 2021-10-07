using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Play : MonoBehaviour
{
    public float time;
    public Text time_text;
    public GameObject prologue_obj;
    public static Play instance = null;
    private bool Corunning;
    public Coroutine coPlay;
    public int checkNum;

    void Start()
    {
        //StartCo();
        Time.timeScale = 1.0f;
        //IEnumerator StartProlog = playPrologue();
        //StartCoroutine(StartProlog);
        StartCo();
    }

    void Awake()    //싱글톤 패턴
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        time_text = GameObject.Find("time").GetComponent<Text>();
        checkNum = SLManager.loadData;
        //print(GameObject.Find("JSONManager").GetComponent<SLManager>().loadData);
        print("Check");
        print(checkNum);

    }

   
    public void StartCo()
    {
        //Corunning = false;
        StopAllCoroutines();
        
        coPlay = StartCoroutine(playPrologue());
        //dialog.instance.dialog_system_start(0);
    }
   

    public void StopCo()
    {
        //Corunning = true;
        StopCoroutine(coPlay);
    }
    /*
    public IEnumerator playPrologue()
    {
        while (!Corunning)
        {
            yield return new WaitUntil(() =>
            {
                if (!dialog.instance.dialog_read(3))
                {
                    return true;
                }
                else
                {
                    print(checkNum);
                    time -= Time.deltaTime;
                    time_text.text = time.ToString(); // 코루틴 실행 진입 포인트 확인용

                    for (int j = 0; j < 3; j++)
                    {
                        if (!dialog.instance.dialog_read(j))
                        {
                            print("Dialog read = ");
                            print(j);//LOAD가 제대로 되었는지 확인용
                        }
                    }

                    for (int i = checkNum; i < 3; i++)
                    {
                        if (dialog.instance.dialog_read(i) && !dialog.instance.running)
                        {
                            IEnumerator dialog_co = dialog.instance.dialog_system_start(i);
                            StartCoroutine(dialog_co);

                            if (dialog.instance.dialog_read(i))
                            {
                                return false;
                            }
                        }
                    }
                    /**
                    if (dialog.instance.dialog_read(0) && !dialog.instance.running)
                    {
                        IEnumerator dialog_co = dialog.instance.dialog_system_start(0);
                        StartCoroutine(dialog_co);

                        if (dialog.instance.dialog_read(0))
                        {
                            return false;
                        }
                    }

                    else if (dialog.instance.dialog_read(1) && !dialog.instance.running)
                    {
                        IEnumerator dialog_co = dialog.instance.dialog_system_start(1);
                        StartCoroutine(dialog_co);

                        if (dialog.instance.dialog_read(1))
                        {
                            return false;
                        }
                    }

                    else if (dialog.instance.dialog_read(2) && !dialog.instance.running)
                    {
                        IEnumerator dialog_co = dialog.instance.dialog_system_start(2);
                        StartCoroutine(dialog_co);

                        if (dialog.instance.dialog_read(2))
                        {
                            return false;
                        }
                    }

                    else if (dialog.instance.dialog_read(3) && !dialog.instance.running)
                    {
                        IEnumerator dialog_co = dialog.instance.dialog_system_start(3);
                        StartCoroutine(dialog_co);

                        if (dialog.instance.dialog_read(3))
                        {
                            return false;
                        }
                    }
                    
                    return false;
                    
                }

            });
        }
    }
    */

    public IEnumerator playPrologue()
    {
        while (!Corunning)
        {
          
                    
            time = 100f;

            
            yield return new WaitUntil(() =>
            {
               
                
                time -= Time.deltaTime;
                if(time_text)
                    time_text.text = time.ToString();

                for (int i = checkNum; i < 3; i++)
                {
                        if (dialog.instance.dialog_read(i) && !dialog.instance.running)
                        {
                            IEnumerator dialog_co = dialog.instance.dialog_system_start(i);
                            StartCoroutine(dialog_co);
                        }
                    
                }
                return false;
            });
                    

               

           
        }
    }

}
