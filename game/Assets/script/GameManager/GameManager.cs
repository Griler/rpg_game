using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        	QualitySettings.vSyncCount = 1;
        	Application.targetFrameRate = 75;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}