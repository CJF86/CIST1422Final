using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Pickup : MonoBehaviour
{
    // This script handles the player picking up and dropping weapons/items

    private GameObject Player_Hand;

    public GameObject Current_Character;

    public Hand_Position Hand_Position;

    public Character_Movement Character_Movement;

    public Transform Parent_Weapon;

    public bool Pick_Up = false;
    void Start()
    {
        Parent_Weapon = gameObject.transform;

        

        
        
    }
    public void Update()
    {
        Current_Character = GameObject.FindWithTag("Player");

        Debug.Log(Parent_Weapon.name);

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
        
        Weapon_Drop();
        //Debug.Log(gameObject.name);
        
        

    }

    
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && Pick_Up==true)
        {
            //Debug.Log("Collision trigger");

            transform.position = Player_Hand.transform.position;

            gameObject.transform.parent = Player_Hand.transform;

            Debug.Log(gameObject.name);

            transform.rotation = Player_Hand.transform.rotation;

            Player_Hand.transform.Rotate(70, 0, 0);

            Player_Hand.transform.Translate(0f,-0.123f,0.049f);

           
        }
        
    }

    public void Weapon_Drop()
    {
        if (Input.GetKeyDown(KeyCode.X)==true && gameObject.transform.parent is not null)
        {
            //Debug.Log("Dropping weapon");
            Player_Hand.transform.DetachChildren();
            Player_Hand.transform.Rotate(-70, 0, 0);

            Parent_Weapon.transform.position = Current_Character.transform.position;
            Parent_Weapon.transform.rotation = Quaternion.identity;
            Debug.Log(Parent_Weapon.name);
        }
    }

    

}
