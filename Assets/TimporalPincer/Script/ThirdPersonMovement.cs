using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] public CharacterController controller;
    [SerializeField] public Transform cam;

    [SerializeField] public float Speed = 5f;
    [SerializeField] public float currentSpeed;

    [SerializeField] public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    [SerializeField] public float gravity = 9.81f;

    void FixedUpdate()
    {
        if (PlayerControl.Instance.IsInteractingWithUI) return;

        // Get both horizontal (strafe) and vertical (forward) input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create a direction vector using both inputs
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Calculate current speed based on input magnitude
        currentSpeed = direction.magnitude * Speed;

        if (direction.magnitude >= 0.1f)
        {
            // Calculate the target angle based on input direction and camera
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // Smooth the rotation
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            // Apply the rotation to the player
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Calculate move direction relative to the camera angle
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Move the character
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
        }

        // Apply gravity
        controller.Move(new Vector3(0, -gravity * Time.deltaTime, 0));
    }

    private void Start()
    {
        currentSpeed = 0;
        Cursor.visible = false;
    }
}