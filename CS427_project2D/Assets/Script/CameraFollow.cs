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
        //    Vector3 curPos = transform.position;
        //    float targetY = target.position.y;
        //    float transformY = transform.position.y;
        //    //if(targetY - transformY >dif || transformY - targetY > dif/2)
        //    if(Math.Abs(targetY-transformY)>dif)
        //    {
        //        if (targetY < this.initCamY)
        //            curPos.y = this.initCamY;
        //        else curPos.y = targetY;
        //        curPos.z = target.position.z + offset.z;
        //        transform.position = curPos;
        //    }

        //Vector3 curPos = transform.position;
        //Vector3 destPos = target.position + offset;
        //if(Math.Abs(destPos.y - curPos.y) > dif || curPos.y - destPos.y > dif/2)
        //{
        //    if(destPos.y < minY)
        //    {
        //        destPos.y = minY;
        //    }
        //    if (destPos.y > maxY)
        //        destPos.y = maxY;
        //    destPos.x = curPos.x;
        //    Vector3 smooth = Vector3.Lerp(curPos, destPos, timeFactor * Time.deltaTime);
        //    transform.position = smooth;
        //}

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
