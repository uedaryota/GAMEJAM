using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private GameScore gameScore;
    private GameObject GetGameScore;
    public Text Rank1,Rank2,Rank3;
    private int score = 0;
    public int first, second, third;
    void Start()
    {
        GetGameScore = GameObject.Find("ScoreSave");
        gameScore = GetGameScore.GetComponent<GameScore>();
        ScoreChange();
        SaveData();
        DrawScore();
    }
    public void Update()
    {

    }
    private void SaveData()
    {
        PlayerPrefs.SetInt("1位", first);
        PlayerPrefs.SetInt("2位", second);
        PlayerPrefs.SetInt("3位", third);
        PlayerPrefs.Save();
    }
    private void ScoreChange()
    {
        score = gameScore.Score;
        first = PlayerPrefs.GetInt("1位", first);
        second = PlayerPrefs.GetInt("2位", second);
        third = PlayerPrefs.GetInt("3位", third);
        if(first<score)
        {
            third = second;
            second = first;
            first = score;
            SaveData();
        }
        if(first>score&&score>second)
        {
            third = second;
            second = score;
            SaveData();
        }
        if (second > score&&score>third)
        {
            third = score;
            SaveData();
        }
    }
    private void DrawScore()
    {
        Rank1.text = PlayerPrefs.GetString(first.ToString(),first.ToString());
        Rank2.text = PlayerPrefs.GetString(second.ToString(), second.ToString());
        Rank3.text = PlayerPrefs.GetString(third.ToString(), third.ToString());
    }
}
