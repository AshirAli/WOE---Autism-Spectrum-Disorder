using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour {



    public void Tutorial()
    {

        SceneManager.LoadScene("Game1");
    }
    public void PlayGame()
    {

        SceneManager.LoadScene("Main game 1");
    }
    public void Task1()
    {
        SceneManager.LoadScene("MemoryCardGame2x2");

    }
    public void Task2()
    {
        SceneManager.LoadScene("Colorcheck");

    }

    public void Task3()
    {
        SceneManager.LoadScene("MainGame2");

    }

    public void Task4()
    {
        SceneManager.LoadScene("Main");

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
