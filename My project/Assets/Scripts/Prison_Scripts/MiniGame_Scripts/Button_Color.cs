using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Button_Color : MonoBehaviour
{
    public Button button;
    public Color Red_Color;
    public Color Green_Color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Color_Change()
    {
        if(button.image.color == Color.red)
        {
            button.image.color = Color.green;
        }

        if(button.image.color == Color.green)
        {
            button.image.color = Color.red;
        }
    }
}
