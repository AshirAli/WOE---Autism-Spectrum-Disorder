using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyNav : MonoBehaviour {

    public NavMeshAgent Enemy;
    public Transform [] Targets;

    [SerializeField] private int targetCount;
    public int index;
   // [SerializeField] private GameObject gameover;



	void Start () 
    {
targetCount=Targets.Length;
Debug.Log(targetCount);

        Enemy = GetComponent<NavMeshAgent>();
        SetTarget(0);
     //   gameover.SetActive(false);

	}
	   void SetTarget(int index)
    {
       
            Enemy.SetDestination(Targets[index].position);

    }


	void Update () 
    {

      CheckDistanceToTarget();
        if(index >= 2)
        {
            index = 0;
        }

	}


    void CheckDistanceToTarget()
    {
        if (Enemy.remainingDistance < 1)
        {
            if (index < Targets.Length)
            {
                index++;
                SetTarget(index);
            }
            else
            {
                Enemy.SetDestination(Targets[0].position);

            }
        }


    }




}
