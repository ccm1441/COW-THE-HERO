using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private PlayerInventoryDisplay playerInventoryDisplay;
    [SerializeField] private InventoryManager inventoryManager;

    public GameObject Pet;
    public Text useCtrl;
    // #########################################
    // #                                       #
    // #        플레이어 체력 부분             # 
    // #                                       #
    // #########################################

    // #       플레이어 체력 변수 선언         #
    public Image playerHP;
    public Text playerLIfe;
    public static int playerLife_count = 3;

    //인스펙터에 나오니깐 정적으로 선언하던가 해야할듯
    public bool god = false;


    // #       Update 부분에 추가한 문장       #
    // playerLIfe.text = playerLifeCount.ToString();


    // #       플레이어 체력 함수 선언부       #
    public void playerhealth(float damage)
    {
        if (god == false)
            playerHP.fillAmount -= damage;
    }
    // 위 함수는 데미지를 입을때 호출해주면 됨

    // #       플레이어 체력 무적 선언부       #
    IEnumerator godmod()
    {
        Debug.Log("무적 시작");
        yield return new WaitForSeconds(2f);
        Debug.Log("무적 끝");
        god = false;
    }

    // #       플레이어 체력 무적 사용법       #
    // 아래 코드를 데미지 입는 부분에 넣어주면됨 현 Player에 들어가있음
    //    if (!playerControl.god)
    //{
    //    playerControl.god = true;
    //   playerControl.StartCoroutine("godmod");
    //}


    // #########################################
    // #                                       #
    // #        플레이어 체력 부분  끝         # 
    // #                                       #
    // #########################################


    // #########################################
    // #                                       #
    // #        플레이어 산소통 부분           # 
    // #                                       #
    // #########################################

    // #      플레이어 산소통 변수 선언        #
    public Image player_O2_background;
    public Image player_O2;
    static float add = 1f; // 산소통 가중치
    bool check = true;

    // #      void start 함수에 추가 함        #
    //player_O2.enabled = false;
    //    player_O2_background.enabled = false;

    // #########################################
    // #                                       #
    // #      플레이어 산소통 부분  끝         # 
    // #                                       #
    // #########################################



    // #########################################
    // #                                       #
    // #        바다맵에서 플레이어컨트롤      # 
    // #                                       #
    // #########################################

    // #           바다맵 범위 선언            #
    [HideInInspector]
    public bool inTheWater = false;
    private float water_x_min;
    private float water_x_max;
    private float water_y_min;
    private float water_y_max;
    public Transform water_corner_max;
    public Transform water_corner_min;
    public static int bulletCount = 0;

    // #       바다맵 관련 함수 선언부         #
    private void InTheWater()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        if ((x >= water_x_min && x <= water_x_max) && (y >= water_y_min && y <= water_y_max))
        {

            inTheWater = true;
            player_O2.enabled = true;
            player_O2_background.enabled = true;
            player_O2.fillAmount -= 0.00011f * add;
            add += 0.5f;
            if (player_O2.fillAmount <= 0)
            {
                if (check)
                {
                    add = 1f;
                    check = false;
                }
                playerHP.fillAmount -= 0.0001f * add;
            }
        }
        else
        {
            inTheWater = false;
            check = true;
            if (player_O2.fillAmount != 1f)
            {
                add += 0.5f;
                player_O2.fillAmount += 0.0001f * add;
            }
            else
            {
                player_O2.enabled = false;
                player_O2_background.enabled = false;
                add = 1f;
            }
        }
    }

    /* 파도맵 관련 변수 선언부!! */
    public bool inTheWave = false;
    private float wave1_x_min;
    private float wave1_x_max;
    private float wave1_y_min;
    private float wave1_y_max;
    public Transform wave1_corner_max;
    public Transform wave1_corner_min;
    bool wave_check = true;

    private float wave2_x_min;
    private float wave2_x_max;
    private float wave2_y_min;
    private float wave2_y_max;
    public Transform wave2_corner_max;
    public Transform wave2_corner_min;

    //#              파도맵 관련 메서드 선언부
    private void InTheWave()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        if (((x >= wave1_x_min && x <= wave1_x_max) && (y >= wave1_y_min && y <= wave1_y_max)) || ((x >= wave2_x_min && x <= wave2_x_max) && (y >= wave2_y_min && y <= wave2_y_max)))
        {

            inTheWave = true;
            player_O2.enabled = true;
            player_O2_background.enabled = true;
            player_O2.fillAmount -= 0.0005f * add;

            add += 0.5f;

            if (player_O2.fillAmount <= 0)
            {
                if (wave_check)
                {
                    add = 1f;
                    wave_check = false;
                }
                playerHP.fillAmount -= 0.002f * add;
            }
        }
        else
        {
            inTheWave = false;
            wave_check = true;
            if (player_O2.fillAmount != 1f)
            {
                add += 0.5f;
                player_O2.fillAmount += 0.0001f * add;
            }
            else
            {
                player_O2.enabled = false;
                player_O2_background.enabled = false;
                add = 1f;
            }
        }
    }
    // #########################################
    // #                                       #
    // #        바다맵에서 플레이어컨트롤      # 
    // #                                       #
    // #########################################

    // #########################################
    // #                                       #
    // #        얼음맵에서 플레이어컨트롤      # 
    // #                                       #
    // #########################################
    public Transform ice_corner_max;
    public Transform ice_corner_min;
    private float ice_x_min;
    private float ice_x_max;
    private float ice_y_min;
    private float ice_y_max;
    [HideInInspector]
    public bool locker_ice = false; //얼음맵에서 감옥 오픈

    // #########################################
    // #                                       #
    // #        흙맵  에서 플레이어컨트롤      # 
    // #                                       #
    // #########################################
    public Transform dirt_corner_max;
    public Transform dirt_corner_min;
    private float dirt_x_min;
    private float dirt_x_max;
    private float dirt_y_min;
    private float dirt_y_max;
    [HideInInspector]
    public bool locker_dirt = false; //얼음맵에서 감옥 오픈


    public AudioSource Jump;  // 점프 사운드
    [SerializeField] private SetActive setActive;
    public bool playerAlive = true;
    private int jumpCount = 0;
    private Player player;

    public Image bulletImg;
    private Rigidbody2D rigidBody2D;

    public float speed = 10;



    // 코너체크
    public Transform corner_max;
    public Transform corner_min;
    private float x_min;
    private float y_min;
    private float x_max;
    private float y_max;
    //##################################
    //#                                #
    //#       코너체크 끝              #
    //##################################

    public Text counttext;  // 죽은 횟수 체크
    public int countnum = 0;

    [HideInInspector]
    public bool facingRight = true;         // For determining which way the player is currently facing.
    [HideInInspector]
    public bool jump = false;				// Condition for whether the player should jump.
    public bool num = true;
    public bool run = false;
    public float moveForce = 365f;          // Amount of force added to move the player left and right.
    public float maxSpeed = 5f;             // The fastest the player can travel in the x axis.
    public AudioClip[] jumpClips;           // Array of clips for when the player jumps.
    public float jumpForce = 1000f;			// Amount of force added when the player jumps.
    public bool shoot = false;

    public GameObject bulletToRight, bulletToLeft;
    Vector2 bulletPos;
    Vector3 respawn;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    private Transform groundCheck;          // A position marking where to check if the player is grounded.
    private bool grounded = false;          // Whether or not the player is grounded.
    private Animator anim;
    public Animator anim2;


    public float h;
    public float v;


    private float followTime = 0.0f;
    public bool follow = false;

    public Transform target;
    // 게임 오브젝트 좌표를 받아와서 그 안에서만 움직이도록
    private void KeepWithinMinMaxRectangle()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;


        float clampedX = Mathf.Clamp(x, x_min, x_max);
        float clampedY = Mathf.Clamp(y, y_min, y_max);

        transform.position = new Vector3(clampedX, clampedY, z);


        if (y < y_min)
        {
            countnum++;
            counttext.text = countnum.ToString();
            transform.position = respawn;//new Vector3(0, 0, z);
        }

        if ((x >= ice_x_min && x <= ice_x_max) && (y >= ice_y_min && y <= ice_y_max))
        {//얼음맵 감옥
            locker_ice = true;
        }

        if ((x >= dirt_x_min && x <= dirt_x_max) && (y >= dirt_y_min && y <= dirt_y_max))
        {//1스테이지 감옥
            locker_dirt = true;
        }


    }
    //##########################################
    //#      플레이어 움직임 좌표 제한 끝     ##
    //##########################################

    void Start()
    {
        player = GetComponent<Player>();
        player_O2.enabled = false;
        player_O2_background.enabled = false;

    }

    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        // Setting up references.
        groundCheck = transform.Find("groundCheck");
        anim = GetComponent<Animator>();


        x_max = corner_max.position.x;
        x_min = corner_min.position.x;
        y_max = corner_max.position.y;
        y_min = corner_min.position.y;

        water_x_max = water_corner_max.position.x;
        water_x_min = water_corner_min.position.x;
        water_y_max = water_corner_max.position.y;
        water_y_min = water_corner_min.position.y;

        wave1_x_max = wave1_corner_max.position.x;
        wave1_x_min = wave1_corner_min.position.x;
        wave1_y_max = wave1_corner_max.position.y;
        wave1_y_min = wave1_corner_min.position.y;

        wave2_x_max = wave2_corner_max.position.x;
        wave2_x_min = wave2_corner_min.position.x;
        wave2_y_max = wave2_corner_max.position.y;
        wave2_y_min = wave2_corner_min.position.y;

       ice_x_max = ice_corner_max.position.x;
        ice_x_min = ice_corner_min.position.x;
        ice_y_max = ice_corner_max.position.y;
        ice_y_min = ice_corner_min.position.y;

        dirt_x_max = dirt_corner_max.position.x;
        dirt_x_min = dirt_corner_min.position.x;
        dirt_y_max = dirt_corner_max.position.y;
        dirt_y_min = dirt_corner_min.position.y;
    }

    public void DeathCheck()
    {
        if (playerAlive == true && playerHP.fillAmount <= 0)
        {
            transform.position = respawn;
            playerLife_count--;
            playerHP.fillAmount = 1f; //체력 초기화
            player_O2.fillAmount = 1f;//산소 초기화
            add = 1f; // 가중치 초기화
            playerAlive = false;
            follow = false;
            check = true;
            Pet.gameObject.SetActive(false);
            GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        }
        else
            playerAlive = true;
    }

    void Update()
    {
        if(playerLife_count<=0)
        {
         
       Application.LoadLevel("Game Over");
            playerLife_count = 3;
        }
        // 체력
        playerLIfe.text = playerLife_count.ToString();

        DeathCheck();
        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (grounded)
        {
            anim.SetBool("Jump", false);
            jumpCount = 0;
        }


        // If the jump button is pressed and the player is grounded then the player should jump.
        if (Input.GetButtonDown("Jump"))
        {

            PlayJump();
            jump = true;
            jumpCount++;
        }

        if (jumpCount >= 1)
        {
            anim.SetBool("Jump", true);
        }
        if (Player.haveGun && (bulletCount > 0 && bulletCount <= 5))
        {
            if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
            {
                bulletCount--;
                bulletImg.fillAmount -= 0.2f;
                nextFire = Time.time + fireRate;

                fire();
            }
        }



    }

    void fire()
    {
        bulletPos = transform.position;
        if (facingRight)
        {
            bulletPos += new Vector2(+1f, -0.43f);
            Instantiate(bulletToRight, bulletPos, Quaternion.identity);
        }
        else
        {
            bulletPos += new Vector2(-1f, -0.43f);
            Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
        }

    }

    void FixedUpdate()
    {
        DeathCheck();

        if (playerInventoryDisplay.pet)
        {
            if (inTheWave)
            {
                useCtrl.text = "Use Left CTRL!!!";
            }
            if (Input.GetButtonDown("Fire1") && inTheWave)
            {
                if ((inventoryManager.item_box_2 && playerInventoryDisplay.pet && playerInventoryDisplay.item2_object == "pet") || (inventoryManager.item_box_3 && playerInventoryDisplay.pet && playerInventoryDisplay.item3_object == "pet") || (inventoryManager.item_box_4 && playerInventoryDisplay.pet && playerInventoryDisplay.item4_object == "pet"))
                {
                    playerInventoryDisplay.petadd++;
                    Pet.gameObject.SetActive(true);
                    Pet.gameObject.transform.localScale += new Vector3(4, 4, 0);
                    Pet.gameObject.transform.position += new Vector3(3, 3, 0);
                    follow = true;
                }
            }
        }

        if (follow)
        {
            followTime += Time.deltaTime;

            if (followTime <= 10.0f)
            //if (cowObject.transform.position != target.position)
            {
                GetComponent<Rigidbody2D>().gravityScale = 0.0f;
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            if (followTime >= 10.0f)
            {
                Pet.gameObject.SetActive(false);
            }

        }

        anim2.SetFloat("Speed", Mathf.Abs(h));

        if (inTheWater == false)
        {
            if (jump == true && jumpCount <= 1)
            {            
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
                jump = false;
            }
        }
        else if (inTheWater == true)
        {
            if (jump == true)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
                jump = false;
            }
        }


        h = Input.GetAxis("Horizontal");

        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        KeepWithinMinMaxRectangle();
        InTheWater();
        InTheWave();

    }

    public void PlayJump()
    {
        Jump.Play();
    }





    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Checkpoint"))
        {
            respawn = hit.transform.position;
        }
    }
}
