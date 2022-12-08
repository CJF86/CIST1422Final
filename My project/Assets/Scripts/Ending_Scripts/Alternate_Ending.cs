using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Alternate_Ending : MonoBehaviour
{
    // This script handles the event trigger for the alternate ending

    private bool Is_Touching;
    private GameObject Jace;
    private GameObject Aemond;
    private GameObject Luke;

    private void Start()
    {
        Jace = GameObject.Find("Jace");
        Luke = GameObject.Find("Aemond");
        Aemond = GameObject.Find("Luke");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Is_Touching = true;
        }

        if (Input.GetKeyUp(KeyCode.E) == true)
        {
            Is_Touching = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && Is_Touching == true)
        {
            Jace.GetComponent<NPC_Escape>().enabled = false;
            Luke.GetComponent<NPC_Escape>().enabled = false;
            Aemond.GetComponent<NPC_Escape>().enabled = false;
            Jace.GetComponent<NPC_Health>().enabled = false;
            Luke.GetComponent<NPC_Health>().enabled = false;
            Aemond.GetComponent<NPC_Health>().enabled = false;
            /*
            Destroy(Jace);
            Destroy(Luke);
            Destroy(Aemond);
            */
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("Bad_Ending");
        }
    }
}
