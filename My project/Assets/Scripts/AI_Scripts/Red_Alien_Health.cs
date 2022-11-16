using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Alien_Health : MonoBehaviour
{
    public GameObject Red_Weapon;
    public GameObject Dropped_Weapon;
    public float Red_Health;
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        Red_Health = 150;

        Animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Red_Health <= 0)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            
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

        if (collision.gameObject.name == "SwordBlue")
        {
            //Debug.Log("first trigger");
            if (collision.transform.parent is null)
            {
                Red_Health += 15;
                //Debug.Log("not held");
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.name == "SwordBlue")
        {
            Red_Health -= 15;

            Debug.Log("Damage trigger " + Red_Health);
        }

        if (collision.gameObject.name == "SwordGreen")
        {
            //Debug.Log("first trigger");
            if (collision.transform.parent is null)
            {
                //Debug.Log("not held");
                Red_Health += 20;
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.name == "SwordGreen")
        {
            Red_Health -= 20;

            Debug.Log("Green trigger " + Red_Health);
        }

        if (collision.gameObject.name == "SwordRed")
        {
            //Debug.Log("first trigger");
            if (collision.transform.parent is null)
            {
                //Debug.Log("not held");
                Red_Health += 25;
            }




        }
        if (collision.contacts[0].otherCollider.transform.gameObject.name == "SwordRed")
        {
            Red_Health -= 25;

            Debug.Log("Red trigger " + Red_Health);
        }
    }

    public IEnumerator Enemy_Cleanup()
    {
        yield return new WaitForSeconds(10f);
        Dropped_Weapon = Instantiate(Red_Weapon, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
    }


}
