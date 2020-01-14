using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public int adjustmentXaxis;
    public int adjustmentYaxis;

    public int adjustmentZaxis;

    public GameObject Player;
 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {





        transform.position = new Vector3(Player.transform.position.x+ adjustmentXaxis, transform.position.y + adjustmentYaxis, transform.position.z+ adjustmentZaxis);

    }
}
