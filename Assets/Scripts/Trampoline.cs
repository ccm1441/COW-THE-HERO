using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {
    Animator anim2;
 
	// Use this for initialization
	void Start () {
        anim2 = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
void OnTriggerEnter2D(Collider2D hit)
    {
      
            if (hit.CompareTag("Player"))
            {
                anim2.SetBool("isStepped",true);
            }
        
     

        }
        
        /*
        void OnCollisionStay2D(Collision2D other)
    {
        if (onTop)
        {
            anim.SetBool("isStepped", true);
        }
    }
    */

    void OnTriggerExit2D()
    {
    
        anim2.SetBool("isStepped",false);
    }

  
}

