using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Health : MonoBehaviour
{

    [Range(0, 100)] public int Total_Health;
    public Component[] Clothes_Array;
    private bool Has_Hit = false;
    private float Regen_Health_Range = 15f;
    [SerializeField]
    private bool In_Regen_Range;
    private LayerMask Enemy;
    void Start()
    {
        Debug.Log("Has_Hit is " + Has_Hit);
        Total_Health = 100;
        StartCoroutine(Regen_Timer());
    }

    
    void Update()
    {
        
        In_Regen_Range = Physics.CheckSphere(transform.position, Regen_Health_Range, Enemy);

        if (Total_Health <= 0)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;

            Clothes_Array = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (SkinnedMeshRenderer Cloth in Clothes_Array)
            {
                Cloth.enabled = false;
            }
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        
       

        if (collision.gameObject.tag == "Light_Weapon")
        {
            
            if (collision.transform.parent is null)
            {
                Total_Health += 15;
                
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Light_Weapon" && Has_Hit == false)
        {
            Total_Health -= 15;
            Has_Hit = true;
            

        }

        if (collision.gameObject.tag == "Medium_Weapon")
        {
            
            if (collision.transform.parent is null)
            {
                
                Total_Health += 20;
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Medium_Weapon" && Has_Hit == false)
        {
            Total_Health -= 20;
            Has_Hit = true;
            
        }

        if (collision.gameObject.tag == "Heavy_Weapon")
        {
            
            if (collision.transform.parent is null)
            {
                
                Total_Health += 25;
            }

          

            
        }
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Heavy_Weapon" && Has_Hit == false)
        {
            
            Total_Health -= 25;
            Has_Hit = true;
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(Has_Hit == true)
        {
            Has_Hit = false;
            
        }
    }

    public IEnumerator Regen_Timer()
    {
        while (true)
        {
            if (!In_Regen_Range && Total_Health < 100)
            {
                Debug.Log("In While loop");
                Total_Health += 1;
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return null;
            }
        }
        
    }
}
