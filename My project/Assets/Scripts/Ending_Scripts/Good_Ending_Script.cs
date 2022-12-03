using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Good_Ending_Script : MonoBehaviour
{
    private float Text_Speed = 0.5f;
    private bool Start_Return;
    [SerializeField]
    private TMP_Text Text;
    void Update()
    {
        transform.Translate(Vector3.up*Text_Speed*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Start_Return = true;
        }

        if (Input.GetKeyUp(KeyCode.Space) == true)
        {
            Start_Return = false;
        }

        if(transform.position.y >= 12)
        {
            Text.enabled = true;
        }

        if(transform.position.y >=12 && Start_Return)
        {
            SceneManager.LoadScene("Start_Menu");
        }
    }
}
