using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Camera_Movement : MonoBehaviour
{
    public float Mouse_Sensitivity = 100f;

    public float Mouse_X_Pos;
    public float Mouse_Y_Pos;

    public float X_Rotation;
    public float Y_Rotation;

    public Transform Player_Body;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //obtains the current x and y values of the mouse and multiplies it to maintain consistency with framerates
        Mouse_X_Pos = Input.GetAxisRaw("Mouse X") * Mouse_Sensitivity * Time.deltaTime;

        Mouse_Y_Pos = Input.GetAxisRaw("Mouse Y") * Mouse_Sensitivity * Time.deltaTime;

        //My explanation is copied witchcraft
        Y_Rotation += Mouse_X_Pos;

        X_Rotation -= Mouse_Y_Pos;

        X_Rotation = Mathf.Clamp(X_Rotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(X_Rotation, Y_Rotation, 0);

        Player_Body.rotation = Quaternion.Euler(0, Y_Rotation, 0);
        
    }
}
