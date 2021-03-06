﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    GameObject Arrow, SkillManager;
    public float Arrow_angle;
    float max, min;
    public float angleSpeed;
    bool isLeft;

    SkillManager skillMgr;

    void Awake()
    {
        if (Arrow == null)
            Arrow = GameObject.Find("Arrow");
        if (SkillManager == null)
            SkillManager = GameObject.Find("SkillManager");
        if (skillMgr == null)
            skillMgr = SkillManager.GetComponent<SkillManager>();

        Arrow_angle = 0;
        max = 70f;
        min = -70f;
        angleSpeed = 100f;
        isLeft = true;
    }

    void Update()
    {
        // 방향 설정
        if (isLeft)
        {
            if (Arrow_angle <= min)
                isLeft = false;
        }
        else
        {
            if (Arrow_angle >= max)
                isLeft = true;
        }
        // 좌우 움직임
        if (skillMgr.arrowMoveable)
            Arrow_angle += (isLeft ? -1 : 1) * angleSpeed * Time.deltaTime;
        
        Arrow.gameObject.transform.eulerAngles = new Vector3(0, 0, Arrow_angle);
    }
}
