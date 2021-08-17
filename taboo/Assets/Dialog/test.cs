using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public float time;
    public float target;
    public float target_2;
    public Text time_text;
    public bool test_1;
    void Start()
    {
        if (test_1)
        {
            StartCoroutine("timer");
        }
        else
        {
            StartCoroutine("timer_action");
        }
        
    }
    /*
    selection selection_co = GetComponent<Selection>();
    StartCoroutine(selection_co);
    */

    IEnumerator timer()
    {
        yield return new WaitUntil(() => {
            if (time <= 0)
            {
                return true;
            }
            else
            {

                if (time <= target)
                {
                    if (dialog.instance.dialog_read(0) && !dialog.instance.running)
                    {
                        IEnumerator dialog_co = dialog.instance.dialog_system_start(0);
                        StartCoroutine(dialog_co);

                        if (dialog.instance.dialog_read(0))
                        {
                            return false;
                        }

                    }
                    else if (!dialog.instance.dialog_read(0) && !dialog.instance.running && dialog.instance.dialog_read(1) && dialog.instance.dialog_read(2))
                    {
                        IEnumerator selection_co = selection.instance.selection_system_start(0);
                        IEnumerator selection2_co = selection2.instance.selection_system_start(0);
                        StartCoroutine(selection_co);
                        StartCoroutine(selection2_co);


                        if (selection.way == 1)
                        {
                            place.Instance.changePlace("background3");
                            MentalGauge.Instance.MentalGaugeChange(-10f);
                            StopCoroutine(selection_co);
                            StopCoroutine(selection2_co);
                            IEnumerator dialog_co = dialog.instance.dialog_system_start(1);
                            StartCoroutine(dialog_co);
                            if (dialog.instance.dialog_read(1))
                            {
                                return false;
                            }
                            /*
                            else if (!dialog.instance.dialog_read(1))
                            {
                                StopCoroutine(dialog_co);
                            }
                            */
                            selection.way = 0;
                        }
                        else if (selection.way == 2)
                        {
                            StopCoroutine(selection_co);
                            StopCoroutine(selection2_co);
                            IEnumerator dialog_co = dialog.instance.dialog_system_start(2);
                            StartCoroutine(dialog_co);
                            if (dialog.instance.dialog_read(2))
                            {
                                return false;
                            }

                            selection.way = 0;
                        }

                    }
                    else if (!dialog.instance.dialog_read(1) || !dialog.instance.dialog_read(2))
                    {
                        if (dialog.instance.dialog_read(3) && !dialog.instance.running)
                        {
                            IEnumerator dialog_co = dialog.instance.dialog_system_start(3);
                            StartCoroutine(dialog_co);

                            if (dialog.instance.dialog_read(3))
                            {
                                return false;
                            }
                        }
                    }
                    

                }

                else
                {
                    time -= Time.deltaTime;
                    time_text.text = time.ToString();
                }
                
                return false;
            }
        });
    }

    IEnumerator timer_action()
    {
        yield return new WaitUntil(() => {
            if (time <= 0)
            {
                return true;
            }
            else
            {
                if (time <= target && time>=target_2)
                {
                    if (dialog.instance.dialog_read(0) && !dialog.instance.running)
                    {
                        IEnumerator dialog_co = dialog.instance.dialog_system_start(0);
                        StartCoroutine(dialog_co);

                        if (dialog.instance.dialog_read(0))
                        {
                            return false;
                        }

                    }
                    else if (!dialog.instance.dialog_read(0) && !dialog.instance.running)
                    {
                        time -= Time.deltaTime;
                        time_text.text = time.ToString();
                    }

                }else if(time <= target_2)
                {
                    if (dialog.instance.dialog_read(1) && !dialog.instance.running)
                    {
                        IEnumerator dialog_co = dialog.instance.dialog_system_start(1);
                        StartCoroutine(dialog_co);

                        if (dialog.instance.dialog_read(1))
                        {
                            return false;
                        }

                    }
                    else if (!dialog.instance.dialog_read(1) && !dialog.instance.running)
                    {
                        time -= Time.deltaTime;
                        time_text.text = time.ToString();
                    }
                }
                else
                {
                    time -= Time.deltaTime;
                    time_text.text = time.ToString();
                }

                return false;
            }
        });
    }

}
