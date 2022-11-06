using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Pickup : MonoBehaviour
{
    // This script handles the player picking up and dropping weapons/items

    private GameObject Player_Hand;

    public GameObject Current_Character;

    public Hand_Position Hand_Position;

    //public Player_Health Player_Health;



    public bool Pick_Up = false;
    void Start()
    {
        //Player_Hand = transform.Find("Hand");

        Current_Character = GameObject.FindGameObjectWithTag("Player");

        
        
    }
    public void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.E) == true)
        {

            Pick_Up = true;
            //Debug.Log(Pick_Up);
        }
        if(Input.GetKeyUp(KeyCode.E)==true)
        {
            Pick_Up = false;
            //Debug.Log(Pick_Up);
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Player_Hand = GameObject.Find("Hand");
        //Player_Hand = //Current_Character.transform.GetChild(0);

        //Debug.Log(Player_Hand.name);
        
        

    }

    
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && Pick_Up==true)
        {
            //Debug.Log("Collision trigger");

            transform.position = Player_Hand.transform.position;

            gameObject.transform.parent = Player_Hand.transform;

            transform.rotation = Player_Hand.transform.rotation;

            Player_Hand.transform.Rotate(70, 0, 0);

            Player_Hand.transform.Translate(0f,-0.123f,0.049f);

            //Player_Health.Instance.Total_Health += 10;
            
            
            
            //Debug.Log(Player_Health.Instance.Total_Health);
        }
        
    }

    

}
