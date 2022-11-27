using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class Level_Trigger : MonoBehaviour
{
    
    public Component[] Clothes_Array;
    public GameObject Player_Eyes;
    private bool Player_Exit;

    private void Start()
    {
        Player_Eyes = GameObject.Find("Camera_Pos");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Player_Exit = true;
        }
        if (Input.GetKeyDown(KeyCode.E) == false)
        {
            Player_Exit = false;
        }
        
    }

    public void OnCollisionStay(Collision collision)
    {
        
        if(collision.gameObject.tag == "Aemond" || collision.gameObject.tag == "Jace" || collision.gameObject.tag == "Luke")
        {

            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            collision.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            Clothes_Array = collision.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
            
            foreach(SkinnedMeshRenderer Cloth in Clothes_Array)
            {
                Cloth.enabled = false;
            }
            collision.gameObject.GetComponent<NPC_Escape>().enabled = false;
            //SceneManager.MoveGameObjectToScene(collision.gameObject, SceneManager.GetSceneByName("Prison_Stairwell"));
           

            Debug.Log(collision.gameObject.name + "escaped");
        }
        

        if(collision.gameObject.tag == "Player" && Player_Exit == true)
        {
            SceneManager.LoadScene("Prison_Stairwell");
        }
    }
}
