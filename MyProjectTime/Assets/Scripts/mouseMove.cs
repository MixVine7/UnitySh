using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMove : MonoBehaviour
{
    float x_Rot;
    float y_Rot;
    float x_RotCurrent;
    float y_RotCurrent;
    public Camera player;
    public GameObject playerGameObject;
    public float sensivity = 5f;
    public float smoothTime = 0.1f;
    float currentVelosytyX;
    float currentVelosytyY;

    void Update()
    {
        MouseMove();
    }

    void MouseMove()
    {
        Cursor.lockState = CursorLockMode.Locked;
        x_Rot += Input.GetAxis("Mouse X") * sensivity;
        y_Rot += Input.GetAxis("Mouse Y") * sensivity;
        y_Rot = Mathf.Clamp(y_Rot, -90, 90);

        x_RotCurrent = Mathf.SmoothDamp(x_RotCurrent, x_Rot, ref currentVelosytyX, smoothTime);
        y_RotCurrent = Mathf.SmoothDamp(y_RotCurrent, y_Rot, ref currentVelosytyY, smoothTime);
        player.transform.rotation = Quaternion.Euler(-y_RotCurrent, x_RotCurrent, 0f);
        playerGameObject.transform.rotation = Quaternion.Euler(0f, x_RotCurrent, 0f );
    }
}
