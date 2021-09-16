using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void TitleSceneTransition()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void GameSceneTransition()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ResultTransition()
    {
        SceneManager.LoadScene("ResultScene");
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
