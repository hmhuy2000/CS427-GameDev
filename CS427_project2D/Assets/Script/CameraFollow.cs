using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public int dif=2;
    private float initCamY = 0f;

    private void Start()
    {
        this.initCamY = transform.position.y;
    }
    private void FixedUpdate()
    {
        Vector3 curPos = transform.position;
        float targetY = target.position.y;
        float transformY = transform.position.y;
        //if(targetY - transformY >dif || transformY - targetY > dif/2)
        if(Math.Abs(targetY-transformY)>dif)
        {
            if (targetY < this.initCamY)
                curPos.y = this.initCamY;
            else curPos.y = targetY;
            curPos.z = target.position.z + offset.z;
            transform.position = curPos;
        }

        
    }
}
