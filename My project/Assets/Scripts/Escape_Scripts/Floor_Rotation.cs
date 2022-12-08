using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Floor_Rotation : MonoBehaviour
{
    private Camera Mini_Camera;
    private Quaternion Initial_Rotation;
    private Quaternion Final_Rotation;
    private int Rotate_Speed = 5;
    private Bird_Collection Total_Evidence;
    private Escape_Spawn Surviving_Prisoners;
    [SerializeField]
    private bool Rotate_Trigger = false;
    void Start()
    {
        Initial_Rotation = transform.rotation;
        Final_Rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z - 50f, transform.rotation.w);
        Mini_Camera = GameObject.Find("Camera_Holder").GetComponentInChildren<Camera>();
        Total_Evidence = GameObject.Find("Collected_Evidence").GetComponent<Bird_Collection>();
        Surviving_Prisoners = GameObject.Find("EscapeSpawn").GetComponent<Escape_Spawn>();
    }

    
    void Update()
    {
        if (Mini_Camera.enabled == true)
        {
            Rotate_Trigger = true;
            
            StartCoroutine(Game_End());
        }

        Floor_Rotate();

    }

    public void Floor_Rotate()
    {
        if(Rotate_Trigger == true)
        {
            transform.Rotate(new Vector3(0, 0, -Rotate_Speed) * Time.deltaTime);
        }
        

        if(transform.rotation.z <= -50)
        {
            Rotate_Trigger = false;
        }
    }

    public void Good_Ending()
    {
        SceneManager.LoadScene("Good_Ending");
    }

    public void Medium_Ending()
    {
        SceneManager.LoadScene("Medium_Ending");
    }

    public void Bad_Ending()
    {
        SceneManager.LoadScene("Bad_Ending");
    }

    public IEnumerator Game_End()
    {
        yield return new WaitForSeconds(15f);

        if(Surviving_Prisoners.Prisoner_Array.Count == 3 && Total_Evidence.Evidence_Collected >= 5)
        {
            Good_Ending();
        }

        if (Surviving_Prisoners.Prisoner_Array.Count == 3 && Total_Evidence.Evidence_Collected < 5)
        {
            Medium_Ending();
        }

        if (Surviving_Prisoners.Prisoner_Array.Count == 1 || Surviving_Prisoners.Prisoner_Array.Count == 2 && Total_Evidence.Evidence_Collected >= 0)
        {
            Medium_Ending();
        }

        if (Surviving_Prisoners.Prisoner_Array.Count == 0 && Total_Evidence.Evidence_Collected < 5 || Total_Evidence.Evidence_Collected >= 5)
        {
            Bad_Ending();
        }

    }
}
