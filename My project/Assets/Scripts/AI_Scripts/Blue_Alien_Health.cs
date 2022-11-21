using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Alien_Health : MonoBehaviour
{
    public GameObject Blue_Weapon;
    public GameObject Dropped_Weapon;
    public float Blue_Health;
    public Animator Animator;
    public Aemond_Target aemond;
    public Target_Decision Targeting;
    public Jace_Target Jace;
    public Luke_Target Luke;
    public AI_Events Player;
    private bool Weapon_Drop = false;
    private Rigidbody Attached_RB;
    void Start()
    {
        aemond = GetComponent<Aemond_Target>();
        Targeting = GetComponent<Target_Decision>();
        Jace = GetComponent<Jace_Target>();
        Player = GetComponent<AI_Events>();
        Luke = GetComponent<Luke_Target>();
        Attached_RB = GetComponent<Rigidbody>();
        Blue_Health = 50;

        Animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Blue_Health <= 0)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            aemond.enabled = false;
            Targeting.enabled = false;
            Jace.enabled = false;
            Player.enabled = false;
            Luke.enabled = false;
            Animator.SetBool("AI_Dead", true);
            Animator.SetBool("AI_Attacking", false);
            Animator.SetBool("AI_Running", false);
            Animator.SetBool("AI_Walking", false);
            StartCoroutine("Enemy_Cleanup");
        }

        
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
                Blue_Health += 15;
                //Debug.Log("not held");
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Light_Weapon")
        {
            Attached_RB.isKinematic = false;
            Blue_Health -= 15;

            //Debug.Log("Damage trigger " + Blue_Health);
        }

        if (collision.gameObject.tag == "Medium_Weapon")
        {
            
            if (collision.transform.parent is null)
            {
                
                Blue_Health += 20;
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Medium_Weapon")
        {
            Attached_RB.isKinematic = false;
            Blue_Health -= 20;

            //Debug.Log("Green trigger " + Blue_Health);
        }

        if (collision.gameObject.tag == "Heavy_Weapon")
        {
            //Debug.Log("first trigger");
            if (collision.transform.parent is null)
            {
                //Debug.Log("not held");
                Blue_Health += 25;
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Heavy_Weapon")
        {
            Attached_RB.isKinematic = false;
            Blue_Health -= 25;

            //Debug.Log("Red trigger " + Blue_Health);
        }
    }

    public IEnumerator Enemy_Cleanup()
    {
        
        
        if(Weapon_Drop == false)
        {
            Dropped_Weapon = Instantiate(Blue_Weapon, transform.position, Quaternion.identity) as GameObject;
            Weapon_Drop = true;
        }
        
        
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        Attached_RB.isKinematic = true;
    }
}
