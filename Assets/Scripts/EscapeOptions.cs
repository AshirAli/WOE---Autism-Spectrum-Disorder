using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeOptions : MonoBehaviour
{
    public void ApplicationQuit()
    {
        SceneManager.LoadScene("MenuScreen");
        Debug.Log("Exit to main menu");
    }
}
