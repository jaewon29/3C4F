using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;

class data
{
    public int dialogNum;

    public data(int dialogNum)
    {
        this.dialogNum = dialogNum;
    }
}

public class SLManager : MonoBehaviour
{
    List<data> datas = new List<data>();
    public static SLManager instance = null;
    public static int loadData;
    //Dictionary<string, data> datas = new Dictionary<string, data>();
    //data p1 = new data(3);
    //public Text tx;

    private void Start()
    {
        //datas.Add(new data(3));
        //string jdata = JsonConvert.SerializeObject(datas);
        //string jdata = JsonConvert.SerializeObject(p1);
        //datas["p1"] = new data(3);
        //print(jdata);
    }

    public void _save()
    {
        datas.Add(new data(dialog.instance.current_dialog()));
        print(datas[0].dialogNum);
        string jdata = JsonConvert.SerializeObject(datas);
        //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
        //string format = System.Convert.ToBase64String(bytes);

        File.WriteAllText(Application.dataPath + "/3C4FStudio.json", jdata);
        
    }

    public void _load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/3C4FStudio.json");
        //byte[] bytes = System.Convert.FromBase64String(jdata);
        //string reformat = System.Text.Encoding.UTF8.GetString(bytes);
        //tx.text = jdata;
        datas = JsonConvert.DeserializeObject<List<data>>(jdata);
        loadData = datas[0].dialogNum;
        print(loadData);
        //print(datas[0].dialogNum);
    }
}
