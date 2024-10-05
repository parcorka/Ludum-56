using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    public float moveSmoothTime = 0.1f;
    public float gravity;
    public float jumpForce;
    public float speed;

    private Vector3 playerInput;
    private Vector3 move;
    private Vector3 currentMoveVelocity;
    private Vector3 moveDampVelocity;

    private Vector3 currentForceVelocity; // mainly for gravity
    public float hight = 1.1f; // checking distance to ground

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        playerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        };
        if (playerInput.magnitude > 1f) // player speed is constant no mater the direction
        {
            playerInput.Normalize();
        }

        move = transform.TransformDirection(playerInput);
        //float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? Runspeed : WalkSpeed; // for sprinting
        currentMoveVelocity = Vector3.SmoothDamp(currentMoveVelocity, move * speed, ref moveDampVelocity, moveSmoothTime);
        characterController.Move(currentMoveVelocity * Time.deltaTime);

        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(groundCheckRay, hight))
        {
            currentForceVelocity.y = -2f;

            if(Input.GetKey(KeyCode.Space))
            {
                currentForceVelocity.y = jumpForce;
            }
        }
        else
        {
            currentForceVelocity.y -= gravity * Time.deltaTime;
        }
        characterController.Move(currentForceVelocity * Time.deltaTime);
    }

}
