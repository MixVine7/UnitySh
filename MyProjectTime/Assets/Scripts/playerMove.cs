using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    [SerializeField] Slider staminaSlider;
    [SerializeField] float staminaValue;
    [SerializeField] float minValueStamina;
    [SerializeField] float maxValueStamina;
    [SerializeField] float staminaReturn;
    private Text textStamina;


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
        textStamina = staminaSlider.transform.GetChild(3).GetComponent<Text>();
    }

    void Update()
    {
        Move();
        Stamina();
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
            staminaValue -= staminaReturn * Time.deltaTime * 7;
        }
        else
        {
            speed_Current = speed_Move;
            staminaValue += staminaReturn * Time.deltaTime * 2;
        }
        player.Move(move_Direction * speed_Current * Time.deltaTime);
    }

    private void Stamina()
    {
        if (staminaValue > 100f) staminaValue = 100f;
        if (staminaValue < 0f) staminaValue = 0f;
        textStamina.text = staminaSlider.value.ToString();
        staminaSlider.value = staminaValue;
    }

}
