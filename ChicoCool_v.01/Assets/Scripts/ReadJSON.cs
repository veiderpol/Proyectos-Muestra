using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;
using LitJson;

public class ReadJSON : MonoBehaviour
{
    string temspScoreAndroid;
    private string jsonString;
    private JsonData itemData;
    // Start is called before the first frame update
    void Start(){
        string filePath = Path.Combine(Application.persistentDataPath, "PlayerStats.json");
        if(Application.platform == RuntimePlatform.Android){
            if(!File.Exists("jar:file://" + Application.dataPath + "!/assets/" + "PlayerStats.json")){
                WWW www = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "PlayerStats.json");
                File.WriteAllBytes(filePath, www.bytes);
            }
        }
    }

}
