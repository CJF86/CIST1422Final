using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    public Animator Player_Movement;

    //public CharacterController Player_Character;

    //public Rigidbody Player_Body;

    public float Character_Walk_Speed = 1f;

    public float Character_Run_Speed = 5f;

    public Vector3 Z_Movement_Update;

    //public Transform Player_Transform; Transform probably can be accessed through game object

    // Start is called before the first frame update
    void Start()
    {
        Player_Movement = GetComponent<Animator>();

        //Player_Character = GetComponent<CharacterController>();
        //finds the game object named "MainCharacter"
    }



    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey("w")==true)
        {

            Player_Movement.SetBool("Is_Walking", true);

            

            if (Input.GetKey("left shift"))
            {
                Player_Movement.SetBool("Is_Walking", false);
                Player_Movement.SetBool("Is_Running", true);

                

            }

        }
        
        else
        {
            Player_Movement.SetBool("Is_Walking", false);
            Player_Movement.SetBool("Is_Running", false);

        }

        //handles backwards animations
        if (Input.GetKey("s"))
        {
            Player_Movement.SetBool("Is_Walking_Back", true);

           

            if (Input.GetKey("left shift"))
            {
                Player_Movement.SetBool("Is_Walking_Back", false);
                Player_Movement.SetBool("Is_Running_Back", true);

                

            }


        }
        else
        {
            Player_Movement.SetBool("Is_Walking_Back", false);
            Player_Movement.SetBool("Is_Running_Back", false);
        }
        

    }
}
