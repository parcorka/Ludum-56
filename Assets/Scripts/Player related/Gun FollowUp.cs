using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollowUp : MonoBehaviour
{
    //public float tilt;
    //public float offset;

    //void Start()
    //{
        
    //}

    //void Update()
    //{
        
    //}

    public void GunFollow(float tilt, float offset)
    {
        transform.DOLocalRotate(new Vector3(0, 0, tilt), 1f);
        transform.DOLocalMoveX(offset, 1f);
    }
    public void ResetGunFollow()
    {
        transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
        transform.DOLocalMoveX(0.2f, 0.5f);
    }
}
