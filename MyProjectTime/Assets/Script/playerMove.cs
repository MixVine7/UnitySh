using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    public float speed_Move;
    public float speed_Run;
    public float speed_Current;
    public float jump;
    public float gravity;
    float x_Move;
    float z_Move;
    CharacterController player;
    Vector3 move_Direction;

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        x_Move = Input.GetAxis("Horizontal");
        z_Move = Input.GetAxis("Vertical");
        if (player.isGrounded)
        {
            move_Direction = new Vector3(x_Move, 0f, z_Move);
            move_Direction = transform.TransformDirection(move_Direction);
            if (Input.GetKey(KeyCode.Space))
            {
                move_Direction.y += jump;
            }
            if (Input.GetKey(KeyCode.C))
            {
                player.height = 1.2f;
            }
            else player.height = 2.7f;
        }
        move_Direction.y -= gravity;

        //run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed_Current = speed_Run;
        }
        else
        {
            speed_Current = speed_Move;
        }
        player.Move(move_Direction * speed_Current * Time.deltaTime);
    }

}
