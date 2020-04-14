using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClubBrandish : MonoBehaviour {
    public GameObject BoldManParent;
    public GameObject CrabParent;
    public GameObject GolemParent;
    public static float boldHealth=1f;
    public static float crabHealth=1f;
    public static float golemHealth=1f;
    public Monster monster;
    public Animator anim3;
    public BulletDamage bulletDamage;
    bool brandish = false;
    public GameObject boldMan;
    public GameObject crab;
    public GameObject golem;
    float x;
    float y;
    public bool once = false;
    public static int boldmanLife = 1;
    public static int crabLife = 1;
    public static int golemLife = 1;

    private PlayerControl playerControl;
	// Use this for initialization
	void Start () {
        monster = GetComponent<Monster>();
        anim3 = gameObject.GetComponent<Animator>();
        playerControl = GetComponent<PlayerControl>();
        bulletDamage = GetComponent<BulletDamage>();
	}
	
    void Update()
    {
       
            if (boldmanLife==0)
            {
                Player.playerScore2 += 3000;
            boldmanLife--;
            }
            if (crabLife == 0)
            {
                Player.playerScore2 += 3000;
            crabLife--;
            }
            if (golemLife == 0)
            {
                Player.playerScore2 += 10000;
            golemLife--;
            Application.LoadLevel("Ending Scene");
            golemLife = 1;
            }
        
    }
	// Update is called once per frame
	void FixedUpdate () {
       
    
            if (boldHealth <= 0)
            {
                BoldManParent.gameObject.SetActive(false);
            boldmanLife--;

        }
            if (crabHealth <= 0)
            {
                CrabParent.gameObject.SetActive(false);
            crabLife--;

        }
            if (golemHealth <= 0)
            {
               
                GolemParent.gameObject.SetActive(false);
            golemLife--;
        }
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim3.SetBool("Brandish", true);
        }
        else
            anim3.SetBool("Brandish", false);
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (anim3.GetBool("Brandish"))
        {
            if (hit.CompareTag("knockback_bold_man"))
            {
                boldHealth -= 0.1f;
                if (this.transform.position.x > hit.transform.position.x)
                    x = boldMan.gameObject.transform.position.x - 1f;
                else
                    x = boldMan.gameObject.transform.position.x + 1f;
                y = boldMan.gameObject.transform.position.y;
                boldMan.gameObject.transform.position = new Vector3(x, y, 0);
               
            }
            if (hit.CompareTag("knockback_crab"))
            {
                crabHealth -= 0.1f;
                if (this.transform.position.x > hit.transform.position.x)
                    x = crab.gameObject.transform.position.x - 1f;
                else
                    x = crab.gameObject.transform.position.x + 1f;
                y = crab.gameObject.transform.position.y;
                crab.gameObject.transform.position = new Vector3(x, y, 0);
               
            }
            if (hit.CompareTag("knockback_golem"))
            {
                golemHealth -= 0.1f;
                if (this.transform.position.x > hit.transform.position.x)
                    x = golem.gameObject.transform.position.x - 1f;
                else
                    x = golem.gameObject.transform.position.x + 1f;
                y = golem.gameObject.transform.position.y;
                golem.gameObject.transform.position = new Vector3(x, y, 0);
               
            }
        }

        }
        
    }
    



