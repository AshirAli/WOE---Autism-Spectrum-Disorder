using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int speed;
    Animator animator;
    public Rigidbody rb;
    public GameObject win_panel;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate ()
    {

    if (Input.GetKey(KeyCode.Space)&& Input.GetKey(KeyCode.RightArrow))
        {
          // animator.SetBool("walk", true);
            animator.SetBool("jump", true);
            //  GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0) *10* Time.deltaTime);
            //GetComponent<Rigidbody>().AddForce(new Vector3(0, 30, 0) * 50 * Time.deltaTime);
            transform.Translate(Vector3.up * 7 * Time.deltaTime, Space.World);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("walk", true);
            animator.SetBool("jump", false);
            transform.Translate(Vector3.right  * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.back * Time.deltaTime);
            animator.SetBool("walk", false);

        }
        else if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("jump", true);
          animator.SetBool("walk", false);
            transform.Translate(Vector3.up * 7 * Time.deltaTime, Space.World);
        }

        else
        {
            animator.SetBool("walk", false);
            animator.SetBool("jump", false);
        }
    }



    }
