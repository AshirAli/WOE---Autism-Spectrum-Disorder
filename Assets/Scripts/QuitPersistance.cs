using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPersistance : MonoBehaviour
{
    public GameObject options;
    bool status;

    private void Start()
    {
        if (options.activeInHierarchy)
        {
            options.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            options.SetActive(status);
            status = !status;
        }
        //Debug.Log("Time: " + Time.timeScale);
    }
}
