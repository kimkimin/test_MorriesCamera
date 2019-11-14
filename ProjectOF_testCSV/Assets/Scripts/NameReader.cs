using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 스파인 파일이름으로 애니메이션 유형에따라 분류
/// 나중에는 CSVreader에서 이름 가져와서 할수있게 바꾸기
/// </summary>
public class NameReader : MonoBehaviour
{
    List<string[]> animTypeList = new List<string[]>();
    string Loop = "L";
    string End = "E";

    public List<Sprite> imageObjs;
    public List<string[]> animType_Loop = new List<string[]>(); //TouchLoop
    public List<string[]> animType_End = new List<string[]>(); //TouchEnd
    public List<string[]> animType_Default = new List<string[]>(); //Loop

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < imageObjs.Count; i++)
        {
            string[] tempNameSet;
            tempNameSet = imageObjs[i].name.Split('_');//이름 분할
            animTypeList.Add(tempNameSet);//배열 추가

            if(animTypeList[i].Length == 2)//Default
            {
                animType_Default.Add(animTypeList[i]);
            }
            else
            {
                if (animTypeList[i][2] == Loop)//Loop
                    animType_Loop.Add(animTypeList[i]);
                if (animTypeList[i][2] == End)//End
                    animType_End.Add(animTypeList[i]);
            }
        }

        Debug.LogFormat("Default : {0}, Loop : {1}, End : {2}", animType_Default.Count, animType_Loop.Count, animType_End.Count);
    }
}
