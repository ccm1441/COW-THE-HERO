using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlcok : MonoBehaviour {
    Rigidbody2D rb;

    //public GameObject FallingDown;
	// Use this for initialization
	void Start () {
        rb = GetComponent <Rigidbody2D>();
	}
	void OnTriggerEnter2D(Collider2D hit)
    {
       
            if(hit.CompareTag("Player"))
            {
                rb.isKinematic = false;
            }
        
      
          
        }

    }

