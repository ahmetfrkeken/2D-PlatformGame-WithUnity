using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 cameraOffset;
    private Vector3 targetedPosition;
    private Vector3 velocity = Vector3.zero;

    public float smoothTime = 0.3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        targetedPosition = targetObject.transform.position + cameraOffset;

        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime);//SmoothDamp yavaş yavaş kamerayı playera eşitler Keskinliği azaltır.
    }
}
