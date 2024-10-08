using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PullOutPutAway : MonoBehaviour
{

    private Animator mAnimator;
    public Camera playerPOV;
    private bool zoomState;
    private bool dialogueTime;
    private float normalZoom;
    private float zoomedZoom;
    private float currentZoom;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        zoomState = false;
        dialogueTime = false;
        normalZoom = 60f;
        zoomedZoom = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !dialogueTime)
        {
            if (!zoomState)
            {
                mAnimator.SetTrigger("PullOut");
                zoomState = true;
            }
            else
            {
                mAnimator.SetTrigger("PutAway");
                zoomState = false;
            }
        }
        Zoom();
    }
    public void DialogueTime()
    {
        dialogueTime = true;
    }
    public void FreeZoom()
    {
        dialogueTime = false;
    }
    public bool ZoomState()
    {
        return zoomState;
    }
    private void Zoom()
    {
        //crouchState = !crouchState;
        //UpdateCameraZoom();
        float targetZoom = zoomState ? zoomedZoom : normalZoom;
        currentZoom = Mathf.Lerp(currentZoom, targetZoom, Time.deltaTime * 5f);
        //Vector3 cameraMoveTo = cameraPosition.transform.localPosition;
        //cameraMoveTo.y = currentHight;
        playerPOV.fieldOfView = currentZoom;

        //characterController.height = crouchState ? 0.5f : 2f;
    }
    //public void UpdateCameraZoom()
    //{
    //    if (!locked)
    //    {
    //        if (!crouchState)
    //        {
    //            speed = walkSpeed;
    //        }
    //        else
    //        {
    //            speed = crouchedSpeed;
    //        }
    //    }
    //}
}
