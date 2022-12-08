using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player_Health : MonoBehaviour
{

    [Range(0, 100)] public int Total_Health;
    public Component[] Clothes_Array;
    private bool Has_Hit = false;
    private float Regen_Health_Range = 15f;
    [SerializeField]
    private bool In_Regen_Range;
    private LayerMask Enemy;
    public Bird_Collection Bird_Evidence;
    private bool Evidence_Trigger;
    private Animator Player_Movement;
    void Start()
    {
        Player_Movement = GetComponent<Animator>();
        
        Total_Health = 100;
        StartCoroutine(Regen_Timer());
        Bird_Evidence = GameObject.Find("Collected_Evidence").GetComponent<Bird_Collection>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Evidence_Trigger = true;
        }

        if (Input.GetKeyUp(KeyCode.E) == true)
        {
            Evidence_Trigger = false;
        }

        In_Regen_Range = Physics.CheckSphere(transform.position, Regen_Health_Range, Enemy);

        if (Total_Health <= 0)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;

            Clothes_Array = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (SkinnedMeshRenderer Cloth in Clothes_Array)
            {
                Cloth.enabled = false;
            }
            Player_Movement.SetBool("Is_Walking", false);
            Player_Movement.SetBool("Is_Walking_Back", false);
            Player_Movement.SetBool("Is_Running", false);
            Player_Movement.SetBool("Is_Running_Back", false);
            Player_Movement.SetBool("Strafe_Left", false);
            Player_Movement.SetBool("Strafe_Right", false);
            Player_Movement.SetBool("Is_Dead", true);
            StartCoroutine(Player_Death());
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Light_Weapon")
        {
            
            if (collision.transform.parent is null)
            {
                Total_Health += 5;
                
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Light_Weapon" && Has_Hit == false)
        {
            Total_Health -= 5;
            Has_Hit = true;
            

        }

        if (collision.gameObject.tag == "Medium_Weapon")
        {
            
            if (collision.transform.parent is null)
            {
                
                Total_Health += 10;
            }

        }
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Medium_Weapon" && Has_Hit == false)
        {
            Total_Health -= 10;
            Has_Hit = true;
            
        }

        if (collision.gameObject.tag == "Heavy_Weapon")
        {
            
            if (collision.transform.parent is null)
            {
                
                Total_Health += 15;
            }

          

            
        }
        if (collision.contacts[0].otherCollider.transform.gameObject.tag == "Heavy_Weapon" && Has_Hit == false)
        {
            
            Total_Health -= 15;
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
                
                Total_Health += 1;
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return null;
            }
        }
        
    }

    public void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bird_Evidence") && Evidence_Trigger == true)
        {
            Bird_Evidence.Evidence_Collected++;
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator Player_Death()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Player_Death", LoadSceneMode.Single);
    }
}
