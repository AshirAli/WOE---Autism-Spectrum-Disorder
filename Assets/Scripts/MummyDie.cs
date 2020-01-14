using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyDie : MonoBehaviour
{
    public GameObject coinfx;
   public Rigidbody rb;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Time.timeScale = 0;
           rb.AddForce(0,200, 0);
            // Destroy(transform.parent.gameObject);
            transform.GetChild(0).gameObject.SetActive(false);

            Instantiate(coinfx);

            Debug.Log("collidinggg");
             

        }
    }

}
