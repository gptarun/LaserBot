using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public JoyButton joyButton;
    protected bool jump = false;
    int jumpCount = 0;

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joyButton = FindObjectOfType<JoyButton>();
    }

    private void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * 4f,
                                         rigidbody.velocity.y,
                                         joystick.Vertical * 4f);

        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);
        if (moveVector != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveVector, Vector3.left);
            rigidbody.MoveRotation(newRotation);            
        }

        if (!jump && joyButton.Pressed && rigidbody.position.y >= -0.5 && rigidbody.position.y <= 0.4 && jumpCount < 2)
        {
            rigidbody.velocity += Vector3.up * 4.0f;
            jump = true;
            jumpCount++;
        }
        if (jump && !joyButton.Pressed)
        {
            jump = false;        
            jumpCount = 0;
        }
    }
}
