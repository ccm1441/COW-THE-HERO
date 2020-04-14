using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {
    public GameObject BoldManParent;
    public GameObject CrabParent;
    public GameObject GolemParent;
    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {

    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("knockback_bold_man"))
        {
            CharacterClubBrandish.boldHealth -= 0.5f;
            
            Destroy(gameObject);
        }
        if (hit.CompareTag("knockback_crab"))
        {
            CharacterClubBrandish.crabHealth -= 0.5f;
           
            Destroy(gameObject);
        }
        if (hit.CompareTag("knockback_golem"))
        {
            CharacterClubBrandish.golemHealth -= 0.5f;
           
            Destroy(gameObject);
        }
        if (hit.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

                
        
}
