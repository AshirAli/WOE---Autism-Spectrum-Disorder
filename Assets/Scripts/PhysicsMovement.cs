using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhysicsMovement : MonoBehaviour {
    public int speed;
    Animator animator;
    int count;

    public event Action<GameObject> OnGemCollect;
    public event Action scoreupdate;

    [SerializeField] private GameObject winner;
    [SerializeField] private Transform origin;
    [SerializeField] private LayerMask layer;
    // Use this for initialization
	void Start () {
     animator = GetComponent<Animator>();
        count = 0;

	}
	
	// Update is called once per frame
	void Update ()
    {

        Rigidbody rigidbody;

        winner.SetActive(false);

   
        if(count==5)
        {


            winner.SetActive(true);

            Time.timeScale = 0;

        }

        if (Physics.Raycast(origin.position,origin.forward,10,layer))
        {

            Debug.Log("Hit police");
        }
	}


    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("hit");

        if(collision.gameObject.CompareTag("gem"))
        {
            Debug.Log("hit gem");

            if (OnGemCollect != null)
                OnGemCollect(collision.gameObject);
            scoreupdate();
            count++;
            Debug.Log("hit gem1");

           // Destroy(collision.collider);

        }
    }



}
