using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public Transform HPBar; // hp바 통을 일컷
    public Transform Monster1; // 몬스터
    public Transform Bar; // 실질적 hp 닳는 바
    public Transform player; // 캐릭터 방향에 따른 몬스터 넉백
    public GameObject monsterdie; // 죽으면 없애기 위하여 정의
    public float max_X; //최대 좌표 
    public float min_X; // 최소좌표 
    private float monsterX;
    private float monsterY;
    private float monsterZ;
    private float playerX;
    private float playerY;
    private float playerZ;

    float health = 1f; // 100


    private bool turn = false;

    public float monster_scale;
    public float hp_scale;


    int movementFlag = 0;
    bool inTracing = false;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("changemove");
    }


    void monstermove()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if (monsterX >= max_X)
            movementFlag = 1;
        else if (monsterX <= min_X)
            movementFlag = 2;

        if (inTracing)
        {
            Vector3 playerPos = player.transform.position;

            if (playerPos.x < transform.position.x)
                dist = "Left";
            else if (playerPos.x > transform.position.x)
                dist = "Right";
        }
        else
        {
            if (movementFlag == 1)
                dist = "Left";
            else if (movementFlag == 2)
                dist = "Right";
        }

        if (dist == "Left")
        {
            moveVelocity = Vector3.left;
                Monster1.localScale = new Vector3(-monster_scale, monster_scale, monster_scale);
            HPBar.localScale = new Vector3(-hp_scale, hp_scale, hp_scale);

        }
        else if (dist == "Right")
        {
            moveVelocity = Vector3.right;
                            Monster1.localScale = new Vector3(monster_scale, monster_scale, monster_scale);
            HPBar.localScale = new Vector3(hp_scale, hp_scale, hp_scale);
        }

        Monster1.position += moveVelocity * 3f * Time.deltaTime;

    }
    IEnumerator changemove()
    {
        movementFlag = Random.Range(1, 3);
        yield return new WaitForSeconds(3f); //3초마다 랜덤 뽑음.
        StartCoroutine("changemove");
    }

    void OnTriggerEnter2D(Collider2D other)
    { //플레이어 진입
        if (other.gameObject.tag == "Player")
            StopCoroutine("changmove");
    }

    void OnTriggerStay2D(Collider2D other)
    { //플레이어 진입 후 원 안에 머물때
        if (other.gameObject.tag == "Player")
            inTracing = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    { // 플레이어 아웃
        if (other.gameObject.tag == "Player")
            inTracing = false;
    }


    private void Update()
    { // 좌표는 지속 업데이트 필요
        playerX = player.position.x;
        playerY = player.position.y;
        playerZ = player.position.z;

        monsterX = Monster1.position.x;
        monsterY = Monster1.position.y;
        monsterZ = Monster1.position.z;

    }

    void FixedUpdate()
    {
        monstermove();

    }

    public void monster_F(float damage)
    {
        health -= damage;

        if (health <= 0)
            Destroy(monsterdie);

        Bar.localScale = new Vector3(health, 1f);

        monsterX -= 0.3f;
        if (monsterX <= min_X)
            monsterX = min_X + 0.2f;

        Monster1.position = new Vector3(monsterX, monsterY);
    }
}
