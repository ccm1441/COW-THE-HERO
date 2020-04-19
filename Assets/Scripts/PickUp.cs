using UnityEngine;

public class PickUp : MonoBehaviour {

    public string description;
    
    public enum PickUpType
    {
        club,gun,key,pet
    }

    public PickUpType type;

}
