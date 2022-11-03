using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container_Link : MonoBehaviour
{
    public Transform Player_Eyes;
    public float Character_Turn_Speed = 5f;
    public float Y_Input;
    public float Mouse_Value;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Player_Eyes = GameObject.Find("Man_Eyes_Mesh").transform;

        transform.position = Player_Eyes.transform.position;

        transform.rotation = Player_Eyes.transform.rotation;

        Y_Rotation();
        
    }

    public void Y_Rotation()
    {
        Mouse_Value = Input.GetAxis("Mouse Y");


        Vector3 Turn_Vector = new Vector3();

        Turn_Vector.x += -Mouse_Value * Character_Turn_Speed * Time.fixedDeltaTime;

        Quaternion Turn = Quaternion.Euler(Turn_Vector);

        Player_Eyes.transform.Rotate(Turn_Vector, Space.Self);

    }
}
