using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StageWin : MonoBehaviour {
    string m_scene;
    public GameObject win_panel;

    // Use this for initialization
    void Start () {
        m_scene = SceneManager.GetActiveScene().name;
        win_panel.SetActive(false);
        Time.timeScale = 1;

    }



    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("hit");

        if (collision.collider.gameObject.CompareTag("Player"))
        {



                Debug.Log("win");
                win_panel.SetActive(true);
                Time.timeScale = 0;

                // win_panel.SetActive(true);

            
        }
    }




}
