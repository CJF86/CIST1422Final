using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Pickup : MonoBehaviour
{
    // This script handles the player picking up and dropping weapons/items

    private GameObject Player_Hand;

    public GameObject Current_Character;

    public Hand_Position Hand_Position;

    void Start()
    {
        //Player_Hand = transform.Find("Hand");

        Current_Character = GameObject.FindGameObjectWithTag("Player");

        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Player_Hand = GameObject.Find("Hand");
        //Player_Hand = //Current_Character.transform.GetChild(0);

        Debug.Log(Player_Hand.name);



    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision trigger");

            transform.position = Player_Hand.transform.position;

            gameObject.transform.parent = Player_Hand.transform;

            transform.Rotate(new Vector3(-77f,0,0));
            transform.Translate(0f, 0.025f, 0f);
            
            

        }
        
    }
    
}
