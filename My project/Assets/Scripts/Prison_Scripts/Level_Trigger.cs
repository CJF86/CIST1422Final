using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level_Trigger : MonoBehaviour
{
    
    public Component[] Clothes_Array;

    private bool Player_Exit;
    // Update is called once per frame
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
            Clothes_Array = collision.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach(SkinnedMeshRenderer Cloth in Clothes_Array)
            {
                Cloth.enabled = false;
            }

            Debug.Log(collision.gameObject.name + "escaped");
        }

        if(collision.gameObject.tag == "Player" && Player_Exit == true)
        {
            SceneManager.LoadScene("Prison_Stairwell");
        }
    }
}
