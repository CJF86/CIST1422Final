using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Engine_Level : MonoBehaviour
{
    public Component[] Clothes_Array;
    public GameObject Player_Eyes;
    private bool Player_Exit;
    private GameObject Jace;
    private GameObject Luke;
    private GameObject Aemond;
    private GameObject Escape_Text;
    public TMP_Text Text;
    private void Start()
    {
        Escape_Text = GameObject.Find("EscapeText");
        Jace = GameObject.Find("Jace");
        Luke = GameObject.Find("Luke");
        Aemond = GameObject.Find("Aemond");
        Player_Eyes = GameObject.Find("Camera_Pos");
        //Text = Escape_Text.GetComponent<TMP_Text>();
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

        if (collision.gameObject.tag == "Aemond" || collision.gameObject.tag == "Jace" || collision.gameObject.tag == "Luke")
        {

            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            collision.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            Clothes_Array = collision.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (SkinnedMeshRenderer Cloth in Clothes_Array)
            {
                Cloth.enabled = false;
            }
            collision.gameObject.GetComponent<NPC_Escape>().enabled = false;
            //SceneManager.MoveGameObjectToScene(collision.gameObject, SceneManager.GetSceneByName("Prison_Stairwell"));


            Debug.Log(collision.gameObject.name + "escaped");
        }

        if (collision.gameObject.tag == "Player")
        {

            Text.enabled = true;
        }


        if (collision.gameObject.tag == "Player" && Player_Exit == true)
        {
            Jace.GetComponent<NPC_Escape>().enabled = false;
            Luke.GetComponent<NPC_Escape>().enabled = false;
            Aemond.GetComponent<NPC_Escape>().enabled = false;
            SceneManager.LoadScene("Prison_Engines");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Text.enabled = false;
    }
}
