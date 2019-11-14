using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class CSVreader
{
    // 라인변경 확인
    // 콤마 확인
    // 맨윗줄 삭제
    static string SPLIT_LINE = "\n"; // 줄바꿈 패턴의 문자열을 분리 하는데 쓰임
    static string SPLIT_COMMA = ","; // 특정 패턴의 문자열로 분리 하는데 쓰임
    static char[] TRIM_CHAR = { }; // 단어의 양끝에 공백또는 지정 문자를 제거하는데 쓰임

    public static List<Dictionary<string, string>> ReadFile(string rawData)
    {
        var dict = new List<Dictionary<string, string>>();
        var spliedLine = Regex.Split(rawData, SPLIT_LINE); // 줄바꿈으로 나눠놓고 저장
        
        if (spliedLine.Length <= 1)
        {
            Debug.Log("라인별로 구분한게 해더밖에 안나오거나 더 작음");
            return dict;
        }

        var header = Regex.Split(spliedLine[0], SPLIT_COMMA); // 첫줄 카테고리 분류

        for (int i = 1; i < spliedLine.Length; i++) // 라인나눔 수만큼 돌리기
        {
            var splitedVoca = Regex.Split(spliedLine[i], SPLIT_COMMA); //줄마다 콤마로 나눠놓고 저장
            var reGathering = new Dictionary<string, string>(); // 중간 저장할 딕셔너리

            for (int j = 0; j < splitedVoca.Length; j++)
            {
                reGathering[header[j]] = splitedVoca[j];
                dict.Add(reGathering);
            }
        }
        return dict;
    }
    //[1112]딕셔너리 형태에 대해서 다시 생각해보기
}
