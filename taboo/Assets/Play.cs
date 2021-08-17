using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("playPrologue");
    }
    IEnumerator playPrologue()
    {
        yield return new WaitUntil(() => {
            if (!dialog.instance.dialog_read(1))
            {
                return true;
            }
            else
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

                else if (dialog.instance.dialog_read(1) && !dialog.instance.running)
                {
                    IEnumerator dialog_co = dialog.instance.dialog_system_start(1);
                    StartCoroutine(dialog_co);

                    if (dialog.instance.dialog_read(1))
                    {
                        return false;
                    }
                }
                return false;
            }
        });
    }
        
}
