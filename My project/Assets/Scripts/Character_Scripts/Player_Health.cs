using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Health : MonoBehaviour
{
    public int Total_Health;
    public Component[] Clothes_Array;
    
    //ublic Text Current_Health;
    // Start is called before the first frame update
    void Start()
    {
        
        Total_Health = 100;
        //Current_Health.text = "Health: " + Total_Health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Current_Health.text = "Health: " + Total_Health.ToString();

        if (Total_Health <= 0)
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

        if (collision.gameObject.tag == "Light_Weapon")
        {
            //Debug.Log("first trigger");
            if (collision.transform.parent is null)
            {
                Total_Health += 15;
                //Debug.Log("not held");
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Light_Weapon")
        {
            Total_Health -= 15;
            
            Debug.Log("Damage trigger " + Total_Health);
        }

        if (collision.gameObject.tag == "Medium_Weapon")
        {
            //Debug.Log("first trigger");
            if (collision.transform.parent is null)
            {
                //Debug.Log("not held");
                Total_Health += 20;
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Medium_Weapon")
        {
            Total_Health -= 20;

            Debug.Log("Green trigger " + Total_Health);
        }

        if (collision.gameObject.tag == "Heavy_Weapon")
        {
            //Debug.Log("first trigger");
            if (collision.transform.parent is null)
            {
                //Debug.Log("not held");
                Total_Health += 25;
            }

          

            
        }
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Heavy_Weapon")
        {
            Total_Health -= 25;

            //Debug.Log("Red trigger " + Total_Health);
        }
    }
}
