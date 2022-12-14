using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple_Alien_Health : MonoBehaviour
{
    public GameObject Green_Weapon;
    public GameObject Dropped_Weapon;
    public float Purple_Health;
    public Animator Animator;
    public Aemond_Target aemond;
    public Target_Decision Targeting;
    public Jace_Target Jace;
    public Luke_Target Luke;
    public AI_Events Player;
    private bool Death_Event = false;
    private bool Weapon_Drop = false;
    public Rigidbody Attached_RB;
    private bool Has_Hit = false;
    void Start()
    {
        aemond = GetComponent<Aemond_Target>();
        Targeting = GetComponent<Target_Decision>();
        Jace = GetComponent<Jace_Target>();
        Player = GetComponent<AI_Events>();
        Luke = GetComponent<Luke_Target>();
        Purple_Health = 75;

        Animator = GetComponent<Animator>();
        Attached_RB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Purple_Health <= 0)
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
            if(Death_Event == false)
            {
                StartCoroutine("Enemy_Cleanup");
                Death_Event = true;
            }
            
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
                Purple_Health += 15;
                return;
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Light_Weapon" && collision.contacts[0].otherCollider.transform.parent.root.tag != "Enemy" && Has_Hit == false)
        {
            Attached_RB.isKinematic = false;
            Purple_Health -= 15;
            Has_Hit = true;
            //Debug.Log("Damage trigger " + Purple_Health);
        }

        if (collision.gameObject.tag == "Medium_Weapon")
        {

            if (collision.transform.parent is null)
            {

                Purple_Health += 20;
                return;
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Medium_Weapon" && collision.contacts[0].otherCollider.transform.parent.root.tag != "Enemy" && Has_Hit == false)
        {
            Attached_RB.isKinematic = false;
            Purple_Health -= 20;
            Has_Hit = true;
            //Debug.Log("Green trigger " + Purple_Health);
        }

        if (collision.gameObject.tag == "Heavy_Weapon")
        {
            //Debug.Log("first trigger");
            if (collision.transform.parent is null)
            {
                //Debug.Log("not held");
                Purple_Health += 25;
                return;
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Heavy_Weapon" && collision.contacts[0].otherCollider.transform.parent.root.tag != "Enemy" && Has_Hit == false)
        {
            Attached_RB.isKinematic = false;
            Purple_Health -= 25;
            Has_Hit = true;
            //Debug.Log("Red trigger " + Purple_Health);
        }
    }

    public IEnumerator Enemy_Cleanup()
    {
        

        if (Weapon_Drop == false)
        {
            Dropped_Weapon = Instantiate(Green_Weapon, transform.position, Quaternion.identity) as GameObject;
            Weapon_Drop = true;
        }
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        Attached_RB.isKinematic = true;

        if(Has_Hit == true)
        {
            Has_Hit = false;
        }
    }
}
