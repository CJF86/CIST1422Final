using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Position : MonoBehaviour
{
    //public Transform Player_Hand_Reference;

    public GameObject Hand;
    
    void Start()
    {
        

        Debug.Log(Hand);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Everything in update so that it happens consistently

        Hand = GameObject.Find("Hand");
        

        Hand.transform.position = transform.position;

        
    }
}
