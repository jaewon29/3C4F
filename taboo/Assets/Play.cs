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
    public Item[] ItemArr;

    

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
                if (!dialog.instance.dialog_read(2))
                {
                    IEnumerator selection_co = selection.instance.selection_system_start(0);
                    StartCoroutine(selection_co);

                    if (selection.way == 1)
                    {
                        selection.way = 0;
                        MentalGauge.Instance.MentalGaugeChange(-10f);
                        Inventory.Instance.AddItem(ItemArr[0]);
                        StopCoroutine(selection_co);
                        IEnumerator dialog_co = dialog.instance.dialog_system_start(3);
                        StartCoroutine(dialog_co);
                        if (dialog.instance.dialog_read(3))
                        {
                            return false;
                        }
                        
                    }

                    else if(selection.way == 2)
                    {
                        selection.way = 0;
                        MoodPointManage.MoodPointChange(0, 1);
                        print(MoodPointManage.MoodPointArr[0]);
                        place.Instance.changePlace("BackGround2");
                        StopCoroutine(selection_co);
                        IEnumerator dialog_co = dialog.instance.dialog_system_start(4);
                        StartCoroutine(dialog_co);
                        if (dialog.instance.dialog_read(4))
                        {
                            return false;
                        }
                    }
                }

                return false;
            });
                    

               

           
        }
    }

}
