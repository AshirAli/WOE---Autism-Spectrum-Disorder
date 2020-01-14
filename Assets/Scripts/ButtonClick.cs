using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonClick : MonoBehaviour {
    public GameObject popup;
    public GameObject popup_wrong;
    public GameObject login;
    private GameObject Username;
    private GameObject Password;

    private string username;
    private string password;

    private string m_Scene;

    public Text errortext;


    // Use this for initialization
    void Start () {
        m_Scene = SceneManager.GetActiveScene().name;


    }

    // Update is called once per frame
    void Update () {
		
	}



    public void Buttonclick()
    {
        string a = EventSystem.current.currentSelectedGameObject.name;
        if (a == "Red")
        {
            Debug.Log("run");
            popup.SetActive(true);
        }
        else
        {
            popup_wrong.SetActive(true);

        }
    }



    public void Room()
    {
        SceneManager.LoadScene("Room");
    }


        public void Restart()
    {
       
        // m_Scene = SceneManager.GetActiveScene.name;
        // SceneManager.LoadScene("ColorCheck");
        SceneManager.LoadScene(m_Scene);

    }

    public void MenuPlay()
    {

        //login.SetActive(true);
        SceneManager.LoadScene("Room");
    }

    public void Login()
    {

        Username = GameObject.Find("Text Panel_Account");
        username= Username.GetComponent<InputField>().text;       //

        Password = GameObject.Find("Text Panel_Password");
        password = Password.GetComponent<InputField>().text;

        if(username=="admin"&&password=="admin")
        {

            Debug.Log("logedin");
            SceneManager.LoadScene("Room");

        }
        else
        {
            errortext.text = "* Incorrect Username and Passwordd";

        }





    }

    public void close()
    {
        login.SetActive(false);


    }

    public void NextLevel()
    {
        if(m_Scene == "Game1")
        {
            Debug.Log("game1");
            SceneManager.LoadScene("Game2");

        }
        if (m_Scene == "Game2")
        {
            SceneManager.LoadScene("Main game 1");

        }
        if (m_Scene == "Main game 1")
        {
            SceneManager.LoadScene("MainGame2");

        }
        if (m_Scene == "MainGame2")
        {
            SceneManager.LoadScene("MainGame3");

        }
        if (m_Scene == "MainGame3")
        {
            SceneManager.LoadScene("MemoryCardGame2x2");

        }
        if (m_Scene == "MemoryCardGame2x2")
        {
            SceneManager.LoadScene("NewLevel1");

        }
        if (m_Scene == "NewLevel1")
        {
            SceneManager.LoadScene("NewLevel2");

        }
        if (m_Scene == "NewLevel2")
        {
            SceneManager.LoadScene("Menu");

        }
        if (m_Scene == "Menu")
        {
            SceneManager.LoadScene("MenuScreen");

        }
    }



    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }


}
