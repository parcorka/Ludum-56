using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float tiltAmount = 5f;
    //private float tilt_z = 0f;
    public KeyCode leftKey = KeyCode.A; //A is default
    public KeyCode rightKey = KeyCode.D; //D is default

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        float mouse_x = Input.GetAxis("Mouse X") * mouse_sens;
        float mouse_y = Input.GetAxis("Mouse Y") * mouse_sens;
        target_rotation_y += mouse_x;
        target_rotation_x -= mouse_y;
        target_rotation_x = Mathf.Clamp(target_rotation_x, -90f, 90f);

        cameraHolder.rotation = Quaternion.Euler(target_rotation_x, target_rotation_y, 0f);
        player.Rotate(Vector3.up * mouse_x);

        /*if (Input.GetKey(KeyCode.Mouse0)) // throw/spawn balls
        {
            PewPew();
        }*/
        /*if (Input.GetKey(KeyCode.E)) // raycast particle
        {
            shoot();
        }*/
    }

    //private bool Movement()
    //{
    //    return (Input.GetKey(leftKey) || Input.GetKey(rightKey));
    //}
    //IEnumerator WaitUntilMove()
    //{
    //    while (true)
    //    {
    //        transform.rotation = Quaternion.Lerp(transform.rotation.x,)
    //        yeald return new WaitUntil(() => Movement());
    //    }
    //}
    //IEnumerator WaitWhileMove()
    //{
    //    while (true) 
    //    {
    //        yeald return new WaitWhile(() => Movement());
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
