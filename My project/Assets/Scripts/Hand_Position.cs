using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Position : MonoBehaviour
{
    //public Transform Player_Hand_Reference;

    public GameObject Hand;
    
    void Start()
    {
        Hand = GameObject.Find("Hand");

        Debug.Log(Hand);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("This is the player hand "+ Player_Hand_Reference);

        Hand.transform.position = transform.position;

        
    }
}
