using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public int i;

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitButtonPressed()
    {
        Debug.Log("Закрыто до завтра");
        Application.Quit();
    }

    public void BackButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    public void GameLevelsPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + i);
    }

    public void YouLosePressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}

