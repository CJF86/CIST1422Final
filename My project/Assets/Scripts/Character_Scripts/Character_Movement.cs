using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Movement : MonoBehaviour
{
    public Animator Player_Movement;

    public AudioSource Player_Audio;

    public AudioClip Walking_Sound;

    public AudioClip Attacking_Sound;

    public AudioClip FiveG_Clip;

    public AudioClip Bird_Drone;

    public Rigidbody Player_Body;

    public bool He_Zoom = false;

    private float Character_Walk_Speed = 1f;

    private float Character_Turn_Speed = 20f;

    private float Character_Run_Speed = 5f;

    public Vector3 X_Movement_Update;

    public Vector3 Z_Movement_Update;

    public float Mouse_Value;

    public static Character_Movement Instance;

    public float Mouse_X;

    private bool Is_Talking;

    
    void Start()
    {
        Player_Movement = GetComponent<Animator>();

        Player_Body = GetComponent<Rigidbody>();
        
        Instance = this;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Is_Talking = true;
        }

        if (Input.GetKeyUp(KeyCode.E) == true)
        {
            Is_Talking = false;
        }
    }

    private void FixedUpdate()
    {


        if (SceneManager.GetActiveScene().name != "Character_Selection")
        {
            Character_Control();
            Character_Rotation();
            Character_Attacks();
            Character_Jump();
            Is_Holding();
        }
        
    }

    public void Character_Control()
    {
        if(Input.GetKey("left shift") == true)
        {
            He_Zoom = true;
            
        }
        else
        {
            He_Zoom = false;
            
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
            Player_Body.AddRelativeForce(Vector3.forward * Character_Walk_Speed, ForceMode.VelocityChange);
            Player_Movement.SetBool("Is_Walking", true);
            if (Player_Audio.isPlaying == false)
            {
                Player_Audio.PlayOneShot(Walking_Sound);
            }



        }
        
        if(Z_Movement >= 0.1 && He_Zoom == true)
        {
            
            Player_Movement.SetBool("Is_Walking", false);
            Player_Movement.SetBool("Is_Running", true);
            Player_Body.AddRelativeForce(Vector3.forward * Character_Run_Speed, ForceMode.VelocityChange);
            

        }
        
        if(Z_Movement < 0)
        {
            Player_Body.AddRelativeForce(Vector3.forward * -Character_Walk_Speed, ForceMode.VelocityChange);
            Player_Movement.SetBool("Is_Walking", false);
            Player_Movement.SetBool("Is_Walking_Back", true);
            if (Player_Audio.isPlaying == false)
            {
                Player_Audio.PlayOneShot(Walking_Sound);
            }

        }
       
        if (X_Movement >= 0.1)
        {
            Player_Body.AddRelativeForce(Vector3.right * Character_Walk_Speed, ForceMode.VelocityChange);
            Player_Movement.SetBool("Strafe_Right", true);
            Player_Movement.SetBool("Strafe_Left", false);
            if (Player_Audio.isPlaying == false)
            {
                Player_Audio.PlayOneShot(Walking_Sound);
            }
        }

        if(X_Movement < 0)
        {
            Player_Body.AddRelativeForce(Vector3.right * -Character_Walk_Speed, ForceMode.VelocityChange);
            Player_Movement.SetBool("Strafe_Left", true);
            Player_Movement.SetBool("Strafe_Right", false);
            if (Player_Audio.isPlaying == false)
            {
                Player_Audio.PlayOneShot(Walking_Sound);
            }
        }
        
        //.AddRelativeForce fixed the sideways movement issue. Think it had something to do with local/world vector differences
        //Fix quit working for some reason. Multiplying strafe value gives it enough to ovverride what im guessing is a drag issue
    }

    public void Character_Rotation()
    {
        
        Mouse_Value = Input.GetAxis("Mouse X");

        float Turn_Degree = Mouse_Value * Character_Turn_Speed * Time.fixedDeltaTime;

        Vector3 Turn_Vector = new Vector3();

        Turn_Vector.y += Mouse_Value * Character_Turn_Speed * Time.fixedDeltaTime;

        Quaternion Turn = Quaternion.Euler(Turn_Vector);

        Player_Body.MoveRotation(Player_Body.rotation * Turn);

    }

    public void Character_Jump()
    {
        if (Input.GetKey(KeyCode.Space) == true)
        {
            Player_Movement.SetBool("Is_Jumping", true);
            Player_Body.AddRelativeForce(Vector3.up * Character_Walk_Speed, ForceMode.Impulse);
        }
        else
        {
            Player_Movement.SetBool("Is_Jumping", false);
        }
    }

    public void Character_Attacks()
    {
        bool Attack_Trigger = Input.GetMouseButton(0);

        if (Attack_Trigger == true)
        {
            Player_Movement.SetBool("Is_Attacking", true);
            if (Player_Audio.isPlaying == false)
            {
                Player_Audio.PlayOneShot(Attacking_Sound);
            }
        }
        else
        {
            Player_Movement.SetBool("Is_Attacking", false);
        }

        
    }

    public void Character_Block()
    {
        bool Block_Trigger = Input.GetMouseButton((int)KeyCode.Mouse1);
        if (Block_Trigger == true)
        {
            Player_Movement.SetBool("Is_Blocking", true);
            Debug.Log("Is blocking");
        }
        else
        {
            Player_Movement.SetBool("Is_Blocking", false);
            
        }
    }

    public bool Is_Holding()
    {
        GameObject Weapon = GameObject.Find("Hand");

        if (Weapon.transform.childCount == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Aemond" && Is_Talking == true)
        {
            if (Player_Audio.isPlaying == false)
            {
                Player_Audio.PlayOneShot(FiveG_Clip);
            }
        }

        if(collision.gameObject.tag == "Jace" && Is_Talking == true)
        {
            if (Player_Audio.isPlaying == false)
            {
                Player_Audio.PlayOneShot(Bird_Drone);
            }
        }
    }

}
