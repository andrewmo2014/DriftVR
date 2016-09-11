using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    void Awake()
    {
        string levelName = LevelManager.SharedInstance.GetCurrentLevelName();
        SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
    }
}