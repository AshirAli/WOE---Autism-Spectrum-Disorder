using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem: MonoBehaviour {

    private PhysicsMovement player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PhysicsMovement>();
    }

    private void OnEnable()
    {
        player.OnGemCollect += Destroy;
    }

    // Use this for initialization
    void Start () {
		
	}
    void Update()
    {
        transform.Rotate(0, 1, 0);
    }


    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        player.OnGemCollect -= Destroy;
    }
}
