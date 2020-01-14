using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyScript : MonoBehaviour {
    // public GameObject coinfx;
    public GameObject loose_panel;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("hit");

        if (collision.gameObject.CompareTag("Player"))
        {
          Time.timeScale = 0;
            loose_panel.SetActive(true);
          //  Instantiate(coinfx);


        }
    }



}
