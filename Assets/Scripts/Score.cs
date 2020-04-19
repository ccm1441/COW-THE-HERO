using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class Score : MonoBehaviour {

    public Text Scoreboard;
 
	// Use this for initialization
	void Start () {
        //ScoreTest.score3 = Player.playerScore2 + (int)Player.playerScore;
        Scoreboard.text = "SCORE : " + ScoreTest.score3.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        //ScoreTest.score3 = Player.playerScore2 + (int)Player.playerScore;
        //Scoreboard.text = ScoreTest.score3.ToString();
    }

}
