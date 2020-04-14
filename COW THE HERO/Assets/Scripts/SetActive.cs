using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    //private PlayerControl playerControl;
    //private bool compare = false;
    //public GameObject gameObject;
    // Use this for initialization
    void Start()
    {
        //playerControl = GetComponent<PlayerControl>();
       transform.GetChild(0).gameObject.SetActive(false);
    }
 
    

    public void SetMeActive()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        //transform.GetChild(0).gameObject.SetActive(false);
    }

}
