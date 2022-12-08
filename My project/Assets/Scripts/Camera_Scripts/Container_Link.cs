using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Container_Link : MonoBehaviour
{
    public Transform Player_Eyes;
    private float Character_Turn_Speed = 20f;
    public float Y_Input;
    public float Mouse_Value;
    public GameObject Player_Character;
    public bool Script_Active = true;
    
    void Update()
    {
        Player_Eyes = GameObject.Find("Man_Eyes_Mesh").transform;

        Player_Character = GameObject.FindGameObjectWithTag("Player");

        transform.rotation = Player_Eyes.transform.rotation;

        if(Player_Character.GetComponent<Character_Movement>().enabled == false)
        {
            Script_Active = false;
        }
        else
        {
            Script_Active = true;
        }

        Y_Rotation();
        
    }

    public void Y_Rotation()
    {
        Mouse_Value = Input.GetAxis("Mouse Y");

        Vector3 Turn_Vector = new Vector3();

        Turn_Vector.x += Mouse_Value * Character_Turn_Speed * Time.fixedDeltaTime;

        Quaternion Turn = Quaternion.Euler(Turn_Vector);

        Player_Eyes.transform.Rotate(Turn_Vector, Space.Self);

    }

    
}
