using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float dif=2;
    public float timeFactor = 0;
    public float minY;
    public float maxY;

    private void Start()
    {
        // init camera position to be minY - the lowe
        Vector3 cur = transform.position;
        //if (target.position.y > minY)
        //    cur.y = target.position.y;
        //else cur.y = minY;
        cur.y = minY;
        transform.position = cur;
    }
    private void FixedUpdate()
    {
        Vector3 cameraCurPos = transform.position;
        Vector3 targetPos = target.position + offset;
        float differenceTargetCamera = targetPos.y - cameraCurPos.y;
        bool isUpdate = false;
        if (differenceTargetCamera >= dif) // target is higher than camera 
        {
            if (targetPos.y > maxY)
                targetPos.y = maxY;
            isUpdate = true;
        }
        else if(cameraCurPos.y != minY && differenceTargetCamera <= dif*-1)
        {
            if (targetPos.y < minY)
                targetPos.y = minY;
            isUpdate = true;
        }
        if (isUpdate)
        {
            targetPos.x = cameraCurPos.x;
            Vector3 smooth = Vector3.Lerp(cameraCurPos, targetPos, timeFactor * Time.deltaTime);
            transform.position = smooth;
        }

    }
}
