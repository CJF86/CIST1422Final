using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public float Total_Health;
    public Component[] Clothes_Array;
    //public static Player_Health Instance;
    // Start is called before the first frame update
    void Start()
    {
        //Instance = this;
        Total_Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(Total_Health <= 0)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;

            Clothes_Array = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (SkinnedMeshRenderer Cloth in Clothes_Array)
            {
                Cloth.enabled = false;
            }
        }

        //Debug.Log(Total_Health);

        
    }

    public void OnCollisionEnter(Collision collision)
    {
        
        //Debug.Log("Event being triggered");
        //Debug.Log(collision.gameObject.name);
        
        //public GameObject Go = collision.transform.parent.gameObject;

        if (collision.gameObject.name == "SwordBlue")
        {
            //Debug.Log("first trigger");
            if (collision.transform.parent is null)
            {
                Total_Health += 15;
                //Debug.Log("not held");
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.name == "SwordBlue")
        {
            Total_Health -= 15;

            Debug.Log("Damage trigger " + Total_Health);
        }

        if (collision.gameObject.name == "SwordGreen")
        {
            //Debug.Log("first trigger");
            if (collision.transform.parent is null)
            {
                //Debug.Log("not held");
                Total_Health += 20;
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.name == "SwordGreen")
        {
            Total_Health -= 20;

            Debug.Log("Green trigger " + Total_Health);
        }

        if (collision.gameObject.name == "SwordRed")
        {
            //Debug.Log("first trigger");
            if (collision.transform.parent is null)
            {
                //Debug.Log("not held");
                Total_Health += 25;
            }

          

            
        }
        if (collision.contacts[0].otherCollider.transform.gameObject.name == "SwordRed")
        {
            Total_Health -= 25;

            Debug.Log("Red trigger " + Total_Health);
        }
    }
}
