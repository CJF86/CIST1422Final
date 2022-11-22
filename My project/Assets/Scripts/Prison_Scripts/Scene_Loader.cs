using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Loader : MonoBehaviour
{
    private bool loaded = false;
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Camera_Pos").GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && loaded==false)
        {
            SceneManager.LoadSceneAsync("Prison_Stairwell", LoadSceneMode.Additive);
            loaded = true;
            Debug.Log("Next Scene loading");
            camera.enabled = true;
        }
        
    }
}
