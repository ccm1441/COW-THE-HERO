using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtPlayer : MonoBehaviour {
    private PlayerControl playerControl;
	// Use this for initialization
	void Start () {
        playerControl = GetComponent<PlayerControl>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //playerControl.knockBackCount = playerControl.knockBackLength;

            //if (other.transform.position.x < transform.position.x)
            //playerControl.knockBackRight = true;
            //else
            // playerControl.knockBackRight = false;
            Destroy(gameObject);
                
        }
    }
    
}
