using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    public Animator Player_Movement;

    //public int Turn_Control = 1;

    public Rigidbody Player_Body;

    public float Character_Walk_Speed = 10f;

    public float Character_Run_Speed = 20f;

    public Vector3 X_Movement_Update;

    public Vector3 Z_Movement_Update;

    public Vector3 Mouse_Value;

    public Vector3 Total_Change;

    public float Mouse_X;

    public Quaternion X_Rotation;

    public Quaternion Initial_Rotation;

    //public Transform Player_Transform; Transform probably can be accessed through game object

    // Start is called before the first frame update
    void Start()
    {
        Player_Movement = GetComponent<Animator>();

        Player_Body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Mouse_Value = Input.mousePosition;

        Mouse_X = Mouse_Value.x * Time.fixedDeltaTime;

        //Debug.Log(Mouse_X);

        Initial_Rotation = Player_Body.rotation;

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        if (Input.GetKey("d") == true)
        {
            X_Movement_Update = Vector3.right * -Character_Walk_Speed * Time.fixedDeltaTime;

            //Player_Body.MovePosition(transform.position + X_Movement_Update);

            Debug.Log("Turn trigger");

        }
        


        if (Input.GetKey("w")==true)
        {
            //rotation does not work currently

            
           
            Player_Movement.SetBool("Is_Walking", true);

            Z_Movement_Update = Vector3.forward * -Character_Walk_Speed * Time.fixedDeltaTime;
            //X_Movement_Update = Vector3.right * -Character_Walk_Speed * Time.deltaTime;

            
            Player_Body.MovePosition(transform.position + Z_Movement_Update);
            

            

            if (Input.GetKey("left shift"))
            {
                Player_Movement.SetBool("Is_Walking", false);
                Player_Movement.SetBool("Is_Running", true);

                Z_Movement_Update = Vector3.forward * -Character_Run_Speed * Time.fixedDeltaTime;

                Player_Body.MovePosition(transform.position + Z_Movement_Update);



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

            Z_Movement_Update = Vector3.forward * Character_Walk_Speed * Time.fixedDeltaTime;

            Player_Body.MovePosition(transform.position + Z_Movement_Update);



            if (Input.GetKey("left shift"))
            {
                Player_Movement.SetBool("Is_Walking_Back", false);
                Player_Movement.SetBool("Is_Running_Back", true);

                Z_Movement_Update = Vector3.forward * Character_Run_Speed * Time.fixedDeltaTime;

                Player_Body.MovePosition(transform.position + Z_Movement_Update);



            }


        }
        else
        {
            Player_Movement.SetBool("Is_Walking_Back", false);
            Player_Movement.SetBool("Is_Running_Back", false);
        }
        

    }
}
