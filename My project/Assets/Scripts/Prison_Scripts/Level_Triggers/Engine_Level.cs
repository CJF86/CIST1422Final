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
    [SerializeField]
    private GameObject Jace;
    [SerializeField]
    private GameObject Luke;
    [SerializeField]
    private GameObject Aemond;
    private GameObject Escape_Text;
    public TMP_Text Text;
    public Engine_Flicker engine_Flicker;
    [SerializeField]
    private GameObject[] Luke_Array;
    [SerializeField]
    private GameObject[] Jace_Array;
    [SerializeField]
    private GameObject[] Aemond_Array;

    private Prisoner_Spawn prisoner_Spawn;
    private void Start()
    {
        prisoner_Spawn = GameObject.Find("PrisonerSpawn").GetComponent<Prisoner_Spawn>();
        Escape_Text = GameObject.Find("EscapeText");
        Jace_Array = GameObject.FindGameObjectsWithTag("Jace");
        Luke_Array = GameObject.FindGameObjectsWithTag("Luke");
        Aemond_Array = GameObject.FindGameObjectsWithTag("Aemond");
        foreach(GameObject go in Jace_Array)
        {
            if (go.GetComponent<NPC_Escape>().enabled)
            {
                Jace = go;
                break;
            }
        }

        foreach (GameObject go in Luke_Array)
        {
            if (go.GetComponent<NPC_Escape>().enabled)
            {
                Luke = go;
                break;
            }
        }

        foreach (GameObject go in Aemond_Array)
        {
            if (go.GetComponent<NPC_Escape>().enabled)
            {
                Aemond = go;
                break;
            }
        }
        Player_Eyes = GameObject.Find("Camera_Pos");
        //Text = Escape_Text.GetComponent<TMP_Text>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Player_Exit = true;
        }
        if (Input.GetKeyUp(KeyCode.E) == true)
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
            foreach(GameObject go in prisoner_Spawn.Prisoner_Array)
            {
                go.GetComponent<NPC_Escape>().enabled = false;
            }
            
            SceneManager.LoadScene("Prison_Engines");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Text.enabled = false;
    }
}
