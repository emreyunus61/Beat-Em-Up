using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    //public Transform target;
    //public float smootSpeed = 0.125f;
    //public Vector3 offset;


    //private void FixedUpdate()
    //{

    //    //Vector3 desiredPosition = target.position + offset;

    //    //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smootSpeed);
    //    //transform.position = smoothedPosition;

    //    // transform.LookAt(target);

    //    // transform.position = target.position + offset;


    //}


    public Transform PlayerTransform;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmootFactor = 0.5f;

     void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

     void LateUpdate()
    {
        Vector3 newPos = PlayerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmootFactor);
    }




}
