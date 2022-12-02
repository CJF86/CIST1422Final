using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Flicker : MonoBehaviour
{
    private float duration = 1.0f;
    private Light Engine_Light;
    public Engine_Flicker engine_Flicker;
    
    private void Start()
    {
        engine_Flicker = gameObject.GetComponentInParent<Engine_Flicker>();
        Engine_Light = gameObject.GetComponent<Light>();
    }

    private void Update()
    {
        if(engine_Flicker.Light_Trigger >= 4)
        {
            Light_Change();
        }
        else
        {
            return;
        }
        
    }
    public void Light_Change()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        Engine_Light.color = Color.Lerp(Color.white, Color.black, t);
    }


}
