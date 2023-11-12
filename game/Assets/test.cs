using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tPlayer;
    public Transform tFollowTarget;
    private CinemachineVirtualCamera vcam;

    void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        tPlayer = GameManager.playerInstance;
    }

    void Update()
    {
        if (tPlayer != null)
        {
            tFollowTarget = tPlayer.transform;
            //vcam.LookAt = tFollowTarget;
            vcam.Follow = tFollowTarget;
        }
        else
        {
            tPlayer = GameManager.playerInstance;
        }
    }
}
