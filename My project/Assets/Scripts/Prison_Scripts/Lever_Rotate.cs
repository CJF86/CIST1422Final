using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Rotate : MonoBehaviour
{
    public bool Lever_Switch;
    public bool Escape_Activated = false;
    public MeshRenderer Turn_Material;
    public Transform Child_Object;
    void Start()
    {
        //Turn_Material = GetComponentInChildren<Material>();
        Child_Object = transform.Find("Sphere");

        Turn_Material = Child_Object.GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Lever_Switch = true;
        }

        if (Input.GetKeyDown(KeyCode.E) == false)
        {
            Lever_Switch = false;
        }

        if(Escape_Activated == true)
        {
            Turn_Material.material.color = Color.green;
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && Lever_Switch == true)
        {
            
            Escape_Activated = true;
        }
    }
}
