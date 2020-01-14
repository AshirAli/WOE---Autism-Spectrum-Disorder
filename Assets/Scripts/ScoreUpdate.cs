using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {
    private PhysicsMovement player;
    int count;
    public Text score;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PhysicsMovement>();
    }

private void OnEnable()
{
        player.scoreupdate += scoreval;
}


    // Use this for initialization
void Start()
{
        
}


    private void scoreval()
{
        count++;
        score.text = "score-" + count;

}

private void OnDisable()
{
        player.scoreupdate -= scoreval;
}

}
