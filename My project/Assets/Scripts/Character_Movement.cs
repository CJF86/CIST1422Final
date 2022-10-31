using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    public Animator Player_Movement;

    //public int Turn_Control = 1;

    public Rigidbody Player_Body;

    public bool He_Zoom = false;

    public float Character_Walk_Speed = 10f;

    public float Character_Run_Speed = 15f;

    public Vector3 X_Movement_Update;

    public Vector3 Z_Movement_Update;

    public Vector3 Mouse_Value;

    

    public float Mouse_X;

    //public Quaternion X_Rotation;

    //public Quaternion Initial_Rotation;

    //public Transform Player_Transform; Transform probably can be accessed through game object

    // Start is called before the first frame update
    void Start()
    {
        Player_Movement = GetComponent<Animator>();

        Player_Body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        

        //Debug.Log(Mouse_X);

        //Initial_Rotation = Player_Body.rotation;

        Character_Control();
        //Character_Rotation();

        //Animation_Triggers();

    }

    public void Character_Control()
    {
        if(Input.GetKey("left shift") == true)
        {
            He_Zoom = true;
            Debug.Log("True");
        }
        else
        {
            He_Zoom = false;
            Debug.Log("false");
        }
        //quicker way to access WASD controls as opposed to nested if statements
        float X_Movement = Input.GetAxis("Horizontal");
        
        float Z_Movement = Input.GetAxis("Vertical");
        

        if(X_Movement == 0 && Z_Movement == 0)
        {
            Player_Movement.SetBool("Is_Walking", false);
            Player_Movement.SetBool("Is_Walking_Back", false);
            Player_Movement.SetBool("Is_Running", false);
            Player_Movement.SetBool("Is_Running_Back", false);
            Player_Movement.SetBool("Strafe_Left", false);
            Player_Movement.SetBool("Strafe_Right", false);

        }
        
        if(Z_Movement >= 0.1)
        {
            Player_Body.AddForce(Vector3.forward * -Character_Walk_Speed, ForceMode.VelocityChange);
            Player_Movement.SetBool("Is_Walking", true);

        }
        if(Z_Movement >= 0.1 && He_Zoom == true)
        {
            
            Player_Movement.SetBool("Is_Walking", false);
            Player_Movement.SetBool("Is_Running", true);
            Player_Body.AddForce(Vector3.forward * -Character_Run_Speed, ForceMode.VelocityChange);
            Debug.Log("Run trigger");

        }

        if(Z_Movement < 0)
        {
            Player_Body.AddForce(Vector3.forward * Character_Walk_Speed, ForceMode.VelocityChange);
            Player_Movement.SetBool("Is_Walking", false);
            Player_Movement.SetBool("Is_Walking_Back", true);

        }
        if(Z_Movement < 0 && Input.GetKey("left shift") == true)
        {
            Player_Movement.SetBool("Is_Walking_Back", false);
            Player_Movement.SetBool("Is_Running_Back", true);
            Player_Body.AddForce(Vector3.forward * Character_Run_Speed, ForceMode.VelocityChange);
            Debug.Log("Run trigger");
        }

        if(X_Movement >= 0.1)
        {
            Player_Body.AddForce(Vector3.right * -Character_Walk_Speed, ForceMode.VelocityChange);
            Player_Movement.SetBool("Strafe_Right", true);
            Player_Movement.SetBool("Strafe_Left", false);
        }

        if(X_Movement < 0)
        {
            Player_Body.AddForce(Vector3.right * Character_Walk_Speed, ForceMode.VelocityChange);
            Player_Movement.SetBool("Strafe_Left", true);
            Player_Movement.SetBool("Strafe_Right", false);
        }
        
        

    }

    public void Character_Rotation()
    {
        Mouse_Value = Input.mousePosition;

        Mouse_X = Mouse_Value.x * Time.fixedDeltaTime;

        Player_Body.AddTorque(Vector3.up * Mouse_X);

    }

    
    
}
