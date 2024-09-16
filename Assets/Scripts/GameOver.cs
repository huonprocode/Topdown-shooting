using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }

    public void BackMainMenu(){
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1;
    }
}
