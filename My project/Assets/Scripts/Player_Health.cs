using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public float Total_Health;
    public static Player_Health Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Total_Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(Total_Health <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log(Total_Health);
    }
}
