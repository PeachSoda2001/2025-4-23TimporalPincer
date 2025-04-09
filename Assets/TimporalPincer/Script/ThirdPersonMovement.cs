using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float Speed;
    public float currentSpeed;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Update is called once per frame

    
    void FixedUpdate()
    {
        if (PlayerControl.Instance.IsInteractingWithUI) return;
        //Debug.Log(BasicSpeedCalculator.Instance.GetSpeedDelta());
        float Vertical = Input.GetAxis("Vertical");
        currentSpeed = Mathf.Abs( Vertical * Speed);
        Vector3 direction = new Vector3(0f, 0f, Vertical).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
        controller.Move(new Vector3(0, -10 * Time.deltaTime, 0));
    }

    private void Start()
    {
        currentSpeed = 0;
        Cursor.visible = false;
    }
}
