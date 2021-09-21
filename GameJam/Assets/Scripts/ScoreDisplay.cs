using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private GameScore gameScore;
    private Text text;
    private int rank1, rank2, rank3;
    private int first =1000, second =500, third = 100;
    void Start()
    {
        
        Dictionary<string, int> dictionary = new Dictionary<string, int>()
        {
            { "1位", first },
            { "2位", second },
            { "3位", third },
        };
        foreach(KeyValuePair<string,int>pair in dictionary)
        {
            string rank = pair.Key;
            int rankNumber = pair.Value;
            Debug.Log(rank + ":" + rankNumber);
        }
    }
    public void Update()
    {
        
    }
    private void SaveData()
    {
        PlayerPrefs.SetInt("1位", first);
        PlayerPrefs.SetInt("2位", second);
        PlayerPrefs.SetInt("3位", third);
    }
}
