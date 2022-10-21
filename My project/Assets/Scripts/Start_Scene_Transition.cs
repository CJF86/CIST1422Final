using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Scene_Transition : MonoBehaviour
{
    //This script handles the transition from the start menu screen

    public void Start_Game()
    {
        SceneManager.LoadScene("Character_Selection", LoadSceneMode.Single);
    }
}
