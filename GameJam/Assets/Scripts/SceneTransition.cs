using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static void TitleSceneTransition()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public static void GameSceneTransition()
    {
        SceneManager.LoadScene("GameScene");
    }
    public static void ResultTransition()
    {
        SceneManager.LoadScene("ResultScene");
    }
    public static void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
