using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform camera_pos;

    void Update()
    {
        transform.position = camera_pos.position;
    }
}
