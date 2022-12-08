using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisoner_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int Total_Health;
    public Component[] Clothes_Array;
    private bool Has_Hit = false;
    //ublic Text Current_Health;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Has_Hit is " + Has_Hit);
        Total_Health = 100;
        //DontDestroyOnLoad(gameObject);
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

            gameObject.GetComponent<NPC_Escape>().enabled = false;
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
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Light_Weapon" && Has_Hit == false)
        {
            Total_Health -= 15;
            Has_Hit = true;
            Debug.Log("Has_Hit is " + Has_Hit);

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
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Medium_Weapon" && Has_Hit == false)
        {
            Total_Health -= 20;
            Has_Hit = true;
            Debug.Log("Has_Hit is " + Has_Hit);
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
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Heavy_Weapon" && Has_Hit == false)
        {

            Total_Health -= 25;
            Has_Hit = true;
            Debug.Log("Has_Hit is " + Has_Hit);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (Has_Hit == true)
        {
            Has_Hit = false;
            Debug.Log("Has_Hit is " + Has_Hit);
        }
    }
}
