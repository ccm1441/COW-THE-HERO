using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDisable : MonoBehaviour {
    public GameObject Parent;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Ground"))
        {
            //Destroy(gameObject);
            Parent.gameObject.SetActive(false);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
