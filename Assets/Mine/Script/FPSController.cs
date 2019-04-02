using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attributes;
using Leap.Unity;
using UnityStandardAssets.CrossPlatformInput;


// src code:https://www.mvcode.com/lessons/first-person-camera-and-controller-jamie

public class FPSController : MonoBehaviour {

    public float turnSpeed = 50f;
    public float walkSpeed = 0.01f;

    public GameObject backwardCommand;
    public GameObject forwardCommand;
    public GameObject leftCommand;
    public GameObject rightCommand;

    Rigidbody rb;
    Vector3 moveDirection;
    public GameObject gestureManager;

    public float Gravity = 1f;
    public float Sensitivity = 1f;

    float horizontalAxis;
    float verticalAxis;

    private void Awake() {
        //rb = GetComponent<Rigidbody>();
    }

    void MouseAiming() {
        var rot = new Vector3(0f, 0f, 0f);
        // rotates Camera Left
        if (Input.GetAxis("Mouse X") < 0) {
            rot.x -= 1;
        }
        // rotates Camera Left
        if (Input.GetAxis("Mouse X") > 0) {
            rot.x += 1;
        }

        // rotates Camera Up
        if (Input.GetAxis("Mouse Y") < 0) {
            rot.z -= 1;
        }
        // rotates Camera Down
        if (Input.GetAxis("Mouse Y") > 0) {
            rot.z += 1;
        }

        transform.Rotate(rot, turnSpeed * Time.deltaTime);
    }

    void KeyboardMovement() {
        float sensitivity = 0.01f;
        Vector3 movementVector = new Vector3(0f, 0f, 0f);
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        // left arrow
        if (hMove < -sensitivity) movementVector.x = -walkSpeed;
        // right arrow
        if (hMove > sensitivity) movementVector.x = walkSpeed;
        // up arrow
        if (vMove < -sensitivity) movementVector.z = -walkSpeed;
        // down arrow
        if (vMove > sensitivity) movementVector.z = walkSpeed;
        // Using Translate allows you to move while taking the current rotation into consideration
        transform.Translate(movementVector);
    }

    float GetAxisRaw(string axisName) {
        //float axisValue = 0f;
        if (axisName == "Vertical")
        {
            //Mathf.MoveTowards(currentAxis.GetValue, button.axisValue, button.responseSpeed * Time.deltaTime)
            if (forwardCommand.name == "activate" && forwardCommand != null)
                // up arrow
                return -1f;
            else if (backwardCommand.name == "activate" && backwardCommand)
                return 1f;
            else return 0f;
        }
        else if (axisName == "Horizontal") {
            return 0f;
        }

        return 0f;

    }

    private void Update() {
        //Non-physics steps
        horizontalAxis = GetAxisRaw("Horizontal");
        verticalAxis = GetAxisRaw("Vertical");
        Debug.Log("Update: " + verticalAxis);
        //moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward);

    }

    private void Move(float input) {
        //Vector3 yVelFix = new Vector3(0, rb.velocity.y, 0);
        //rb.velocity = moveDirection * walkSpeed * Time.deltaTime;
        //rb.velocity += yVelFix;
        Debug.Log("Input: " + input);
        Debug.Log(Vector3.forward * -input * walkSpeed);
        transform.Translate(transform.forward * input * walkSpeed); //* Time.deltaTime);
    }

    void FixedUpdate() { 
        Move(verticalAxis);
        //Debug.Log(rb.velocity);
        //KeyboardMovement();

    }

}

    
    //void Update() {
    //    MouseAiming();
    //    KeyboardMovement();
    //}
//}
