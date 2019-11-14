using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVexecute : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Resource/MorriesSpine_Char_text.txt");
        string source = sr.ReadToEnd();

        //print("원본 스트링 \n" + source);

        List<Dictionary<string, string>> dictList = CSVreader.ReadFile(source);

        foreach (var eachDict in dictList)
        {
            List<string> getKey = new List<string>(eachDict.Keys);
            List<string> getValue = new List<string>(eachDict.Values);

            foreach (string eachKey in getKey)
            {
                Debug.Log("키 : " + eachKey);
            }
            foreach (var eachValue in getValue)
            {
                Debug.Log("값 : " + eachValue);
            }
        }
    }
    
}
