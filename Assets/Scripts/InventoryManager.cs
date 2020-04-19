using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    private PlayerInventoryDisplay playerInventoryDisplay;
    private Dictionary<PickUp.PickUpType, int> items = new Dictionary<PickUp.PickUpType, int>();

    public Transform inventory_c;
    public Image item_gun;
    public Image item_key;
    public Image item_pet;

    public Transform club;
    public Transform gun;
   
    [HideInInspector]
    public bool item_box_1 = false;
    [HideInInspector]
    public bool item_box_2 = false;
    [HideInInspector]
    public bool item_box_3 = false;
    [HideInInspector]
    public bool item_box_4 = false;

    // Use this for initialization
    void Start()
    {
        playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
        playerInventoryDisplay.OnChangeInventory(items);

        //인벤토리 초기값 설정
        inventory_c.position = new Vector3(658.45f, 46.25f, 0);

        //아이템 이미지 체크x
        item_gun.gameObject.SetActive(false);
        item_key.gameObject.SetActive(false);
        item_pet.gameObject.SetActive(false);

    }

    public void Add(PickUp pickup)
    {
        PickUp.PickUpType type = pickup.type;
        int oldTotal = 0;
        if (items.TryGetValue(type, out oldTotal))
            items[type] = oldTotal + 1;
        else
            items.Add(type, 1);

        playerInventoryDisplay.OnChangeInventory(items);
    }

    void FixedUpdate()
    {
        // 인벤토리 선택 하는 부분
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            item_box_1 = true;
            item_box_2 = false;
            item_box_3 = false;
            item_box_4 = false;
            club.gameObject.SetActive(true);
            gun.gameObject.SetActive(false);
            inventory_c.position = new Vector3(658.45f, 46.25f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            item_box_1 = false;
            item_box_2 = true;
            item_box_3 = false;
            item_box_4 = false;

           if((item_box_2 && playerInventoryDisplay.gun && playerInventoryDisplay.item2_object == "gun") || (item_box_3 && playerInventoryDisplay.gun && playerInventoryDisplay.item3_object == "gun") || (item_box_4 && playerInventoryDisplay.gun && playerInventoryDisplay.item4_object == "gun"))
                {
                club.gameObject.SetActive(false);
                gun.gameObject.SetActive(true);
            }
                inventory_c.position = new Vector3(755.2f, 46.25f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            item_box_1 = false;
            item_box_2 = false;
            item_box_3 = true;
            item_box_4 = false;

            if ((item_box_2 && playerInventoryDisplay.gun && playerInventoryDisplay.item2_object == "gun") || (item_box_3 && playerInventoryDisplay.gun && playerInventoryDisplay.item3_object == "gun") || (item_box_4 && playerInventoryDisplay.gun && playerInventoryDisplay.item4_object == "gun"))
            {
                club.gameObject.SetActive(false);
                gun.gameObject.SetActive(true);
            }
            inventory_c.position = new Vector3(851.2f, 46.25f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            item_box_1 = false;
            item_box_2 = false;
            item_box_3 = false;
            item_box_4 = true;

            if ((item_box_2 && playerInventoryDisplay.gun && playerInventoryDisplay.item2_object == "gun") || (item_box_3 && playerInventoryDisplay.gun && playerInventoryDisplay.item3_object == "gun") || (item_box_4 && playerInventoryDisplay.gun && playerInventoryDisplay.item4_object == "gun"))
            {
                club.gameObject.SetActive(false);
                gun.gameObject.SetActive(true);
            }
            inventory_c.position = new Vector3(945f, 46.25f, 0);
        }

    }
}


//좌표정보
// 인본토리 1번칸 선택 658.45/46.25
// 인본토리 2번칸 선택 755.2/46.25 
// 인본토리 3번칸 선택 851.2/46.25
// 인본토리 4번칸 선택 945/46.25

// 인벤토리 2번칸 총 752/45
// 인벤토리 3번칸 총 849.5/45
// 인벤토리 4번칸 총 943/45

// 인벤토리 2번칸 열쇠 749/45
// 인벤토리 3번칸 열쇠 844/45
// 인벤토리 4번칸 열쇠 939/45

// 인벤토리 2번칸 펫 753/45
// 인벤토리 3번칸 펫 849/45
// 인벤토리 4번칸 펫 943.6/45