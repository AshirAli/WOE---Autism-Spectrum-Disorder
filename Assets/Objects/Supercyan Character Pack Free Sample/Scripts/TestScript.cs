using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {
    public Rigidbody rb;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.CompareTag("Trampoline"))
        {

       //   rb.AddForce(Vector3.up * 500);
          
            rb.AddForce(0, 500, 0);
            Debug.Log("Trampoline");

        }
    }

}
