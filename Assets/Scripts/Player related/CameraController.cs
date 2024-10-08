using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Animations;

public class CameraController : MonoBehaviour
{
    public Transform player; // rotate player_y
    public Transform cameraHolder; // rotate camera_x
    public float mouse_sens;
    private float target_rotation_x;
    private float target_rotation_y;

    //public GameObject pewpew; // Object spawning/throwing
    //public float throwForce = 5;
    //public GameObject impactEffect; // Particle shooting

    public float tilt_z = 4f;
    public KeyCode leftKey = KeyCode.A; //A is default
    public KeyCode rightKey = KeyCode.D; //D is default
    //public GunFollowUp gun; // unused

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //StartCoroutine(CameraTilt());
    }

    /*private void OnLevelWasLoaded(int level) // lockin when out of menu scene
    {
        if (level == 1)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }*/

    void Update()
    {
        //Debug.Log(this.transform.rotation);
        float mouse_x = Input.GetAxis("Mouse X") * mouse_sens;
        float mouse_y = Input.GetAxis("Mouse Y") * mouse_sens;
        target_rotation_y += mouse_x;
        target_rotation_x -= mouse_y;
        target_rotation_x = Mathf.Clamp(target_rotation_x, -90f, 90f);

        cameraHolder.rotation = Quaternion.Euler(target_rotation_x, target_rotation_y, 0f);
        player.Rotate(Vector3.up * mouse_x);
        if (Input.GetKey(leftKey) && !Input.GetKey(rightKey))
        {
            DoTilt(tilt_z);
            //gun.GunFollow(tilt_z, 0.2f); // unused
        }
        else
        {
            if (Input.GetKey(rightKey) && !Input.GetKey(leftKey))
            {
                DoTilt(-tilt_z);
                //gun.GunFollow(-tilt_z, -0.2f);// unused
            }
            else
            {
                transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
                //gun.ResetGunFollow();// unused
            }
        }
        /*if (Input.GetKey(KeyCode.Mouse0)) // throw/spawn balls
        {
            PewPew();
        }*/
        /*if (Input.GetKey(KeyCode.E)) // raycast particle
        {
            shoot();
        }*/
    }
    //public void Look(Transform target)
    //{
    //    cameraHolder.DOLocalRotate(target.position, 2f);
    //}
    private void DoTilt(float tilt_z)
    {
        transform.DOLocalRotate(new Vector3(0, 0, tilt_z), 1f);
    }
    //IEnumerator CameraTilt()
    //{
    //    Quaternion target_left = Quaternion.Euler(0f, 0f, -5f);
    //    Quaternion target_right = Quaternion.Euler(0f, 0f, 5f);
    //    Quaternion target_center = Quaternion.Euler(0f, 0f, 0f);
    //    Quaternion target;
    //    Quaternion move = this.transform.rotation;
    //    while (transform.rotation.z != -tiltAmount)
    //    {
    //        if (Input.GetKey(leftKey) && !Input.GetKey(rightKey))
    //        {
    //            target = target_left;
    //        }
    //        else
    //        {
    //            if (Input.GetKey(rightKey) && !Input.GetKey(leftKey))
    //            {
    //                target = target_right;
    //            }
    //            else
    //            {
    //                target = target_center;
    //            }
    //        }
    //        //move.x = transform.rotation.x;
    //        //move.y = transform.rotation.y;
    //        move.z += (target.z - transform.rotation.z) / 10;
    //        if (Mathf.Abs(move.z) > 0.1)
    //        {
    //            //transform.localRotation = Quaternion.Lerp(transform.rotation, move, 2f);
    //            transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, move.z);   
    //        }
    //        //else 
    //        //{
    //        //    transform.localRotation = target_center;
    //        //}
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}

    /*private void shoot() // Particle shooting
    {
        RaycastHit pow;
        Physics.Raycast(this.transform.position, this.transform.forward, out pow);
        //cam.Recoil();
        //enemyGUN en = pow.transform.GetComponent<enemyGUN>();
        //if (en != null) en.GetHit();
        //boom.Play();
        GameObject obj = Instantiate(impactEffect, pow.point, Quaternion.LookRotation(pow.normal));
        Destroy(obj, 1f);
    }*/

    /*private void PewPew() // Object throwing
    {
        GameObject projectile = (GameObject)Instantiate(pewpew, transform.position, this.transform.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(throwForce * Vector3.forward, ForceMode.Impulse);
    }*/
}
