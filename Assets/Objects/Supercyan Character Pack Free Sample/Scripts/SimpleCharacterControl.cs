﻿using UnityEngine;
using System.Collections.Generic;

public class SimpleCharacterControl : MonoBehaviour
{

    private enum ControlMode
    {
        Tank,
        Direct,
        Custom,
    }

    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_turnSpeed = 200;
    [SerializeField] private float m_jumpForce = 4;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;
    public Rigidbody rb;
    [SerializeField] private ControlMode m_controlMode = ControlMode.Direct;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.33f;
    private readonly float m_backwardsWalkScale = 0.16f;
    private readonly float m_backwardRunScale = 0.66f;

    public bool m_wasGrounded;
    private Vector3 m_currentDirection = Vector3.zero;

    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;

    private bool m_isGrounded;
    private List<Collider> m_collisions = new List<Collider>();




    public GameObject loose_panel;

    public void Start()
    {
        Time.timeScale = 1;
        loose_panel.SetActive(false);

    }
    private void OnCollisionEnter(Collision collision)
    {
        /*  if (collision.collider.gameObject.CompareTag("win"))
          {
              Debug.Log("win");
              win_panel.SetActive(true);
              Time.timeScale = 0;



          }*/
        if (collision.collider.gameObject.CompareTag("spike"))
        {
            Debug.Log("win");
            loose_panel.SetActive(true);
            Time.timeScale = 0;



        }



        if (collision.collider.gameObject.CompareTag("Trampoline"))
        {
            Debug.Log("Trampoline");


            rb.AddForce(0, 700, 0);
            Debug.Log("Trampoline_ground");

        }

    


    ContactPoint[] contactPoints = collision.contacts;
        for(int i = 0; i<contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider)) {
                    m_collisions.Add(collision.collider);
                }
m_isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
{
    ContactPoint[] contactPoints = collision.contacts;
    bool validSurfaceNormal = false;
    for (int i = 0; i < contactPoints.Length; i++)
    {
        if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
        {
            validSurfaceNormal = true; break;
        }
    }

    if (validSurfaceNormal)
    {
        m_isGrounded = true;
        if (!m_collisions.Contains(collision.collider))
        {
            m_collisions.Add(collision.collider);
        }
    }
    else
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }
}

private void OnCollisionExit(Collision collision)
{
    if (m_collisions.Contains(collision.collider))
    {
        m_collisions.Remove(collision.collider);
    }
    if (m_collisions.Count == 0) { m_isGrounded = false; }
}

void Update()
{
    m_animator.SetBool("Grounded", m_isGrounded);

    switch (m_controlMode)
    {

        case ControlMode.Tank:
            TankUpdate();
            break;

        case ControlMode.Custom:
            TankCustom();
            break;
        default:
            Debug.LogError("Unsupported state");
            break;
    }

    m_wasGrounded = m_isGrounded;
}

private void TankUpdate()
{
    float v = Input.GetAxis("Vertical");
    float h = Input.GetAxis("Horizontal");

    bool walk = Input.GetKey(KeyCode.LeftShift);

    if (v < 0)
    {
        if (walk) { v *= m_backwardsWalkScale; }
        else { v *= m_backwardRunScale; }
    }
    else if (walk)
    {
        v *= m_walkScale;
    }

    m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
    m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

    transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;
    transform.Rotate(0, m_currentH * m_turnSpeed * Time.deltaTime, 0);

    m_animator.SetFloat("MoveSpeed", m_currentV);

    JumpingAndLanding();
}


private void TankCustom()
{

    float v = Input.GetAxis("Vertical");
    float h = Input.GetAxis("Horizontal");

    bool walk = Input.GetKey(KeyCode.LeftShift);

    if (v < 0)
    {
        if (walk) { v *= m_backwardsWalkScale; }
        else { v *= m_backwardRunScale; }
    }
    else if (walk)
    {
        v *= m_walkScale;
    }

    m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
    m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

    transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;
    //  transform.Rotate(0, m_currentH * m_turnSpeed * Time.deltaTime, 0);

    m_animator.SetFloat("MoveSpeed", m_currentV);

    JumpingAndLanding();


}






private void JumpingAndLanding()
{
    bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

    if (jumpCooldownOver && m_isGrounded && Input.GetKey(KeyCode.Space))
    {
        m_jumpTimeStamp = Time.time;
        m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
    }

    if (!m_wasGrounded && m_isGrounded)
    {
        m_animator.SetTrigger("Land");
    }

    if (!m_isGrounded && m_wasGrounded)
    {
        m_animator.SetTrigger("Jump");
    }
}
}
