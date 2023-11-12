using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public string stage_level;
    public int heath;
    public float[] position;

    public PlayerData(PlayerManager playerManager)
    {
        stage_level = SceneManager.GetActiveScene().name;
        this.heath = playerManager.currentHeath;
        position = new float[3];
        this.position[0] = playerManager.transform.position.x;
        this.position[1] = playerManager.transform.position.y;
        this.position[2] = playerManager.transform.position.z;
    }
    

    public void test()
    {
        Debug.Log(string.Format("stage level {0} + heath {1} + position {2},{3},{4}",
            stage_level, heath,
            position[0],
            position[1], position[2]));
    }
}