using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PoliceNav : MonoBehaviour
{
    public NavMeshAgent police;
    public Transform [] Targets;
    public int index;
    [SerializeField] private GameObject gameover;

    // Use this for initialization
    void Start()
    {
        police = GetComponent<NavMeshAgent>();
        SetTarget(0);
        gameover.SetActive(false);


    }
    void SetTarget(int index)
    {
        police.SetDestination(Targets[index].position);
    }
    // Update is called once per frame
    void Update()
    {

        CheckDistanceToTarget();
        if(index >= 4)
        {
            index = 0;
        }

    }


    void CheckDistanceToTarget()
    {
        if (police.remainingDistance < 1)
        {
            if (index < Targets.Length)
            {
                index++;
                SetTarget(index);
            }
            else
            {
                police.SetDestination(Targets[0].position);

            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("1");
        if (collision.gameObject)
        {
            gameover.SetActive(true);
            Debug.Log("2");
            Time.timeScale = 0;
            // Destroy(collision.collider);

        }
    }

}