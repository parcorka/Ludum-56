using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    public float moveSmoothTime = 0.1f;
    public float gravity;
    public float jumpForce;

    public float walkSpeed;
    public float crouchedSpeed;
    private float speed;
    private bool locked;
    private bool crouchState; // if true then the player will be crouching
    public GameObject cameraPosition;
    public float standingHight = 0.5f;
    public float crouchingHight = 0.2f;
    private float currentHight;

    private Vector3 playerInput;
    private Vector3 move;
    private Vector3 currentMoveVelocity;
    private Vector3 moveDampVelocity;

    private Vector3 currentForceVelocity; // mainly for gravity
    public float GroundDistance = 1.1f; // checking distance to ground // unaffected by hight

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        locked = false;
        crouchState = false;
        UpdateMovement();
        currentHight = standingHight;
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
        //if (!locked)
        //{
        //    speed = crouchState ? crouchedSpeed : walkSpeed; // for sprinting
        //}
        currentMoveVelocity = Vector3.SmoothDamp(currentMoveVelocity, move * speed, ref moveDampVelocity, moveSmoothTime);
        characterController.Move(currentMoveVelocity * Time.deltaTime);

        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(groundCheckRay, GroundDistance))
        {
            currentForceVelocity.y = -2f;

            if (Input.GetKey(KeyCode.Space))
            {
                currentForceVelocity.y = jumpForce;
            }
        }
        else
        {
            currentForceVelocity.y -= gravity * Time.deltaTime;
        }
        characterController.Move(currentForceVelocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouchState = !crouchState;
        }

        Crouch();
    }
    private void Crouch() 
    {
        //crouchState = !crouchState;
        UpdateMovement();
        float targetHight = crouchState ? crouchingHight : standingHight;
        currentHight = Mathf.Lerp(currentHight, targetHight, Time.deltaTime * 3f);
        Vector3 cameraMoveTo = cameraPosition.transform.localPosition;
        cameraMoveTo.y = currentHight;
        cameraPosition.transform.localPosition = cameraMoveTo;
        
        characterController.height = crouchState ? 0.5f : 2f;
    }
    public void LockMovement()
    {
        speed = 0;
        crouchState = false;
        locked = true;
    }
    public void UnlockMovement()
    {
        locked = false;
        UpdateMovement();
    }
    public void UpdateMovement()
    {
        if (!locked)
        {
            if (!crouchState)
            {
                speed = walkSpeed;
            }
            else
            {
                speed = crouchedSpeed;
            }
        }
    }
}
