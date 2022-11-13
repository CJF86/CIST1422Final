using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrical_Mini : MonoBehaviour
{
    public MeshRenderer Switch_Color;
    public bool Is_Active;
    public RaycastHit Hit;
    // Start is called before the first frame update
    void Start()
    {
        Switch_Color = gameObject.GetComponent<MeshRenderer>();
        Is_Active = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Camera.current.name);
        
        if(Is_Active == true)
        {
            Switch_Color.material.color = Color.green;
        }

        if(Is_Active == false)
        {
            Switch_Color.material.color = Color.red;
        }
    }

    public void Turn_On()
    {
        if(Switch_Color.material.color == Color.green)
        {
            Is_Active = false;
            Debug.Log(Is_Active);
            Debug.Log("Switch being pressed");
        }

        if (Switch_Color.material.color == Color.red)
        {
            Is_Active = true;
            Debug.Log(Is_Active);
            Debug.Log("Switch being pressed");
        }

    }

    
}
