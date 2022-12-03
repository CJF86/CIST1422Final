using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pod_Door_Movement : MonoBehaviour
{
    private Vector3 Closed_Position;
    private Vector3 Open_Position;
    [SerializeField]
    private bool Door_Pos;
    
    void Start()
    {
        Closed_Position = transform.position;
        Open_Position = new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        Door_Closed();
    }
    
    public void Door_Open()
    {
        
        transform.Translate(-Vector3.up * Time.deltaTime);

        if (Vector3.Distance(transform.position, Open_Position) < 0.75f)
        {
            Door_Pos = true;
            Debug.Log("Door is opening" + Door_Pos);
            
        }
        
    }

    public void Door_Closed()
    {
        if (Door_Pos == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
        }
        

        if (Vector3.Distance(transform.position, Closed_Position) < 0.01f)
        {
            Door_Pos = false;
            Debug.Log("Door is opening" + Door_Pos);
            
        }
        

    }
    
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Player colliding");
        if(collision.gameObject.CompareTag("Player"))
        {
            Door_Open();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Door_Closed();
    }




}
