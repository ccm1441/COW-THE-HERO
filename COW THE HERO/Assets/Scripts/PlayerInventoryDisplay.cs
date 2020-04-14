using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryDisplay : MonoBehaviour
{
    // 코드 안더럽게 재사용
    [SerializeField] private InventoryManager inventoryManager;

    //아이템을 순서없이 먹었을때 차례대로 나열하기위함.
    bool item2 = false;
    bool item3 = false;
    bool item4 = false;

    // 어떤 템을 먹었나를 체크
    [HideInInspector]
    public bool gun = false;
    [HideInInspector]
    public bool key = false;
    [HideInInspector]
    public bool pet = false;

    [HideInInspector]
    public string item2_object;
    [HideInInspector]
    public string item3_object;
    [HideInInspector]
    public string item4_object;

    public Text key_count;
    [HideInInspector]
    public int key_locker_count;

    public Text pet_count;
    [HideInInspector]
    public int pet_item_count;


    public int keyadd = 0;
    public int petadd = 0;

    [SerializeField] private Player player; // 플레이어 값을 불러오기 위함

    void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        key_count.text = (key_locker_count - keyadd).ToString();
        pet_count.text = (pet_item_count - petadd).ToString();
    }
    public void OnChangeInventory(Dictionary<PickUp.PickUpType, int> inventory)
    {

        int numItems = inventory.Count;

        foreach (var item in inventory)
        {
            int itemTotal = item.Value;
            string description = item.Key.ToString();

            if (description == "key")
            {
                key_locker_count = itemTotal;
            }
            if (description == "pet")
            {
                pet_item_count = itemTotal;

            }
            if (!item2 && !item3 && !item4)
            { //2번칸
                if (description == "gun")
                {
                    PlayerControl.bulletCount = 5;

                    Player.haveGun = true;
                    player.UpdateGunImage();
                    inventoryManager.item_gun.gameObject.SetActive(true);
                    item2 = true;
                    gun = true;
                    item2_object = "gun";
                }
                else if (description == "key")
                {
                    inventoryManager.item_key.gameObject.SetActive(true);
                    inventoryManager.item_key.transform.position = new Vector3(749, 46, 0);
                    item2 = true;
                    key = true;
                    item2_object = "key";
                }
                else if (description == "pet")
                {
                    inventoryManager.item_pet.gameObject.SetActive(true);
                    inventoryManager.item_pet.transform.position = new Vector3(753, 46, 0);
                    item2 = true;
                    pet = true;
                    item2_object = "pet";
                }
            }
            else if (item2 && !item3 && !item4)
            { //3번칸
                if (description == "gun" && !gun)
                {
                    inventoryManager.item_gun.gameObject.SetActive(true);
                    inventoryManager.item_gun.transform.position = new Vector3(849.5f, 45, 0);
                    item3 = true;
                    gun = true;
                    item3_object = "gun";
                }
                else if (description == "key" && !key)
                {
                    inventoryManager.item_key.gameObject.SetActive(true);
                    item3 = true;
                    key = true;
                    item3_object = "key";
                }
                else if (description == "pet" && !pet)
                {
                    inventoryManager.item_pet.gameObject.SetActive(true);
                    inventoryManager.item_pet.transform.position = new Vector3(849, 45f, 0);
                    item3 = true;
                    pet = true;
                    item3_object = "pet";
                }
            }
            else if (item2 && item3 && !item4)
            { //4번칸
                if (description == "gun" && !gun)
                {
                    inventoryManager.item_gun.gameObject.SetActive(true);
                    inventoryManager.item_gun.transform.position = new Vector3(943, 45, 0);
                    item4 = true;
                    gun = true;
                    item4_object = "gun";
                }
                else if (description == "key" && !key)
                {
                    inventoryManager.item_key.gameObject.SetActive(true);
                    inventoryManager.item_key.transform.position = new Vector3(939, 45f, 0);
                    item4 = true;
                    key = true;
                    item4_object = "key";
                }
                else if (description == "pet" && !pet)
                {
                    inventoryManager.item_pet.gameObject.SetActive(true);
                    item4 = true;
                    pet = true;
                    item4_object = "pet";
                }
            }
        }
    }
}
