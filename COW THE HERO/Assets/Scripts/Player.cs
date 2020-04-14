using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Player : MonoBehaviour
{

    public float knockbackTime;
    float x;
    float y;
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private PlayerInventoryDisplay playerInventoryDisplay;

    public PlayerControl playerControl;  //플레이어 컨트롤 불러오기 위해서
    public static bool haveGun = false;  // 총을 찾았는지 체크
    public Image gunImage;    // 총알 이미지
    public Sprite iconGun;    // 총이 있을때
    public Sprite iconNoGun;    // 총이 없을때
    bool check_Collision = false;    // 아이템 중복 획득 방지
    Vector3 temp2;
    float speed = 0.05f;

    private Transform target;
    private Collider2D locker_box;// 감옥박스

    public Animator locker_open;
    public Animator locker_open_sea;
    public Animator locker_open_ice;

    public Transform ice_monster_golem;
    public Text playerScoreText;
    public Text playerScoreText2;
    public static float playerScore = 0.0f;
    public static int playerScore2 = 0;
    float spikeTime = 0;

    [HideInInspector]
    public bool item = false; //아이템 갯수 내리기

    void Start()
    {
        playerControl = GetComponent<PlayerControl>();
        playerScore = 0.0f;
        playerScore2 = 0;
        locker_box = GameObject.Find("stage2_Locker").GetComponent<Collider2D>();
      
    }



    void OnTriggerEnter2D(Collider2D hit)
    {
        /*
            if (hit.CompareTag("knockback_bold_man") || hit.CompareTag("knockback_crab") || hit.CompareTag("knockback_crab"))
            {
                knockbackTime += Time.deltaTime;
                if (knockbackTime >= 0.15f)
                {
                    if (this.transform.position.x < hit.transform.position.x)
                        x = this.transform.position.x - 1f;
                    else
                        x = this.transform.position.x + 1f;
                    y = this.transform.position.y;
                    this.transform.position = new Vector3(x, y, 0);
                    if (knockbackTime >= 0.2f)
                        knockbackTime = 0.0f;
                }
            }
         */
        if (hit.CompareTag("pickup"))
        {
            if (check_Collision == false)
            {
                check_Collision = true;
                PickUp item = hit.GetComponent<PickUp>();
                inventoryManager.Add(item);
                Destroy(hit.gameObject);
            }
            else check_Collision = false;
        }

        if (hit.CompareTag("locker"))
        {
            if (playerInventoryDisplay.key_locker_count > 0)
            {
                if ((inventoryManager.item_box_2 && playerInventoryDisplay.key && playerInventoryDisplay.item2_object == "key") || (inventoryManager.item_box_3 && playerInventoryDisplay.key && playerInventoryDisplay.item3_object == "key") || (inventoryManager.item_box_4 && playerInventoryDisplay.key && playerInventoryDisplay.item4_object == "key"))
                {
                    if (playerControl.locker_dirt)
                        locker_open.SetBool("open", true);
                    if (playerControl.inTheWater)
                        locker_open_sea.SetBool("open", true);
                    if (playerControl.locker_ice)
                    {
                        locker_open_ice.SetBool("open", true);
                        ice_monster_golem.gameObject.SetActive(true);
                    }
                    playerInventoryDisplay.keyadd++;
                    locker_box.enabled = false;
                }
            }
        }
        //감옥 열쇠체크
        if (hit.CompareTag("locker_check_key"))
        {
            if ((inventoryManager.item_box_2 && playerInventoryDisplay.key && playerInventoryDisplay.item2_object == "key") || (inventoryManager.item_box_3 && playerInventoryDisplay.key && playerInventoryDisplay.item3_object == "key") || (inventoryManager.item_box_4 && playerInventoryDisplay.key && playerInventoryDisplay.item4_object == "key"))
            {
                if (playerControl.inTheWater)
                    locker_box = GameObject.Find("stage3_Locker").GetComponent<Collider2D>();
                else if (playerControl.locker_ice)
                    locker_box = GameObject.Find("stage4_Locker").GetComponent<Collider2D>();
                else if (playerControl.locker_dirt)
                    locker_box = GameObject.Find("stage2_Locker").GetComponent<Collider2D>();

                if (!playerInventoryDisplay.key)
                    locker_box.isTrigger = false;
                else locker_box.isTrigger = true;
            }
        }

        //당근 먹었을때
        if (hit.CompareTag("Carrot"))
        {
            if (check_Collision == false)
            {
                playerScore2 += 500;

                Destroy(hit.gameObject);
                check_Collision = true;
            }
            else
                check_Collision = false;
        }

        //나무 가시 밟았을때
        if (hit.CompareTag("Woodspike"))
        {
            spikeTime += Time.deltaTime;
            if (spikeTime >= 0.05f)
            {
                transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.3f, 0);
                playerControl.playerhealth(0.1f);
            }
        }

        //철 가시 밟았을때
        if (hit.CompareTag("Ironspike"))
        {
            spikeTime += Time.deltaTime;
            if (spikeTime >= 0.05f)
            {
                transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.3f, 0);
                playerControl.playerhealth(0.3f);
            }

            if (!playerControl.god)
            {
                playerControl.god = true;
                playerControl.StartCoroutine("godmod");
            }
        }


        if (hit.CompareTag("IceSpike"))
        {
            spikeTime += Time.deltaTime;
            if (spikeTime >= 0.05f)
            {
                transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.3f, 0);
                playerControl.playerhealth(0.6f);
            }


        }
        if (hit.CompareTag("Heart"))
        {
            if (check_Collision == false)
            {
                PlayerControl.playerLife_count++;
                Destroy(hit.gameObject);
                check_Collision = true;
            }
            else
                check_Collision = false;
        }
        if (hit.CompareTag("Chicken"))
        {
            if (check_Collision == false)
            {
                Player.playerScore2 += 3000;
                Destroy(hit.gameObject);
                check_Collision = true;
            }
            else
                check_Collision = false;
        }
    }

    //총 이미지 업데이트 함수
    public void UpdateGunImage()
    {
        if (haveGun)
            gunImage.sprite = iconGun;
        else
            gunImage.sprite = iconNoGun;
    }

    void Update()
    {
        //플레이어 스코어
        playerScore -= Time.deltaTime * 10;
        ScoreTest.score3 = playerScore2 + (int)playerScore;
        playerScoreText2.text = "SCORE: " + playerScore2.ToString();

    }



}

