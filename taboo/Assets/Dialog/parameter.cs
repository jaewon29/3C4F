using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class parameter : MonoBehaviour
{
    public GameObject d_obj;
    public Text name_text;
    public Text content;

    private void Start()
    {
        d_obj = GameObject.Find("Dialog");
        name_text = GameObject.Find("Text_Name").GetComponent<Text>();
        content = GameObject.Find("Text_Content").GetComponent<Text>();
    }
}
