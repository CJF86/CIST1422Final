using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Scene_Transition : MonoBehaviour
{
    //This script handles the transition from the start menu screen

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void Start_Game()
    {
        SceneManager.LoadScene("Character_Selection", LoadSceneMode.Single);
    }

    public void Control_Scene()
    {
        SceneManager.LoadScene("Controls_Scene", LoadSceneMode.Single);
    }

    public void Main_Menu()
    {
        SceneManager.LoadScene("Start_Menu", LoadSceneMode.Single);
    }
}
