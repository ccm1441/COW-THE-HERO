using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerControl.playerLife_count = 3;
        CharacterClubBrandish.golemLife = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
