using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    public Animator Player_Movement;

    //public int Turn_Control = 1;

    public Rigidbody Player_Body;

    public bool He_Zoom = false;

    public float Character_Walk_Speed = 1f;

    public float Character_Turn_Speed = 5f;

    public float Character_Run_Speed = 5f;

    public Vector3 X_Movement_Update;

    public Vector3 Z_Movement_Update;

    public float Mouse_Value;

    

    public float Mouse_X;

    

    // Start is called before the first frame update
    void Start()
    {
        Player_Movement = GetComponent<Animator>();

        Player_Body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        

        

        Character_Control();
        Character_Rotation();

        

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
            Player_Body.AddRelativeForce(Vector3.forward.normalized * -Character_Walk_Speed, ForceMode.VelocityChange);
            Player_Movement.SetBool("Is_Walking", true);

        }
        if(Z_Movement >= 0.1 && He_Zoom == true)
        {
            
            Player_Movement.SetBool("Is_Walking", false);
            Player_Movement.SetBool("Is_Running", true);
            Player_Body.AddForce(Vector3.forward.normalized * -Character_Run_Speed, ForceMode.VelocityChange);
            Debug.Log("Run trigger");

        }

        if(Z_Movement < 0)
        {
            Player_Body.AddRelativeForce(Vector3.forward.normalized * Character_Walk_Speed, ForceMode.VelocityChange);
            Player_Movement.SetBool("Is_Walking", false);
            Player_Movement.SetBool("Is_Walking_Back", true);

        }
        if(Z_Movement < 0 && Input.GetKey("left shift") == true)
        {
            Player_Movement.SetBool("Is_Walking_Back", false);
            Player_Movement.SetBool("Is_Running_Back", true);
            Player_Body.AddForce(Vector3.forward.normalized * Character_Run_Speed, ForceMode.VelocityChange);
            Debug.Log("Run trigger");
        }

        if(X_Movement >= 0.1)
        {
            Player_Body.AddRelativeForce(Vector3.right.normalized * Character_Walk_Speed, ForceMode.VelocityChange);
            Player_Movement.SetBool("Strafe_Right", true);
            Player_Movement.SetBool("Strafe_Left", false);
        }

        if(X_Movement < 0)
        {
            Player_Body.AddRelativeForce(Vector3.right.normalized * -Character_Walk_Speed, ForceMode.VelocityChange);
            Player_Movement.SetBool("Strafe_Left", true);
            Player_Movement.SetBool("Strafe_Right", false);
        }
        
        //.AddRelativeForce fixed the sideways movement issue. Think it had something to do with local/world vector differences

    }

    public void Character_Rotation()
    {
        //Works well enough for now

        Mouse_Value = Input.GetAxis("Mouse X");

        Debug.Log(Mouse_Value);

        float Turn_Degree = Mouse_Value * Character_Turn_Speed * Time.fixedDeltaTime;

        Vector3 Turn_Vector = new Vector3();

        Turn_Vector.y += -Mouse_Value * Character_Turn_Speed * Time.fixedDeltaTime;

        Debug.Log("This is" + Turn_Vector.y);

        Quaternion Turn = Quaternion.Euler(Turn_Vector);

        Player_Body.MoveRotation(Player_Body.rotation * Turn);

       

        



    }

    
    
}
