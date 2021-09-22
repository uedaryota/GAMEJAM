﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScore : MonoBehaviour
{
    public GameScene GetGameScene;
    public GameObject GameScene;
    public int Score = 0;
    private int ArrowScore = 0;

    private static GameScore instance;
    public static GameScore Instance
    {
		get
		{
			if (null == instance)
			{
				instance = (GameScore) FindObjectOfType(typeof(GameScore));
				if (null == instance) Debug.Log(" PlayerData Instance Error ");
			}
			return instance;
		}
	}
    private void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Score"); //タグで判別
        if (1 < obj.Length) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        try
        {
            GameScene = GameObject.Find("GameScene");
            GetGameScene = GameScene.GetComponent<GameScene>();
        }
        catch(System.IndexOutOfRangeException e)
        {

        }
    }
    private void Update()
    {
        if (GameScene != null)
        {
            ArrowScore = GetGameScene.arrowNum * 500;
            Score = GetGameScene.scoreNum + ArrowScore;
        }
        //else
        //Debug.Log(Score);
        if(SceneManager.GetActiveScene().name=="GameScene"&&GameScene==null)
        {
            GameScene = GameObject.Find("GameScene");
            GetGameScene = GameScene.GetComponent<GameScene>();
        }
    }
}
