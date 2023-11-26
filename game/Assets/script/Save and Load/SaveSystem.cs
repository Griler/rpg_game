using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class SaveSystem
{
    private const string PATH_DATA_PLAYER = "/Resources/Data/playerData.json";
    private const string PATH_DATA_ENEMY = "/Resources/Data/EnemyData.json";
    private static string PATH_STAGE_NAME = SceneManager.GetActiveScene().name;

    /*
    private static string PATH_DATA_ENEMY_NEW_STAGE =
        "/Resources/Data/EnemyData" + SceneManager.GetActiveScene().name + ".json";*/

    private static List<EnemyManager> EnemyDatas = new List<EnemyManager>();
    private static List<EnemyPatrolling> EnemyPatrollingArr = new List<EnemyPatrolling>();

    public static void SaveData(PlayerManager playerManager)
    {
        PlayerData data = new PlayerData(playerManager);
        data.test();
        string json = JsonUtility.ToJson(data, true);
        string path = Application.dataPath + PATH_DATA_PLAYER;
        Debug.Log(path);
        if (Directory.Exists(path))
            File.WriteAllText(path, json);
        else
        {
            var folder = Directory.CreateDirectory(Application.dataPath + "/Resources/Data");
            File.WriteAllText(path, json);
            // returns a DirectoryInfo object
        }
    }

    public static void SaveDataEnemy()
    {
        string path = Application.dataPath + PATH_DATA_ENEMY;
        Debug.Log("save continue game data enemy: " + path);
        List<EnemyData> datas = new List<EnemyData>();
        findEnemy();
        Debug.Log("list quái : " + EnemyDatas.Count);
        for (int i = 0; i < EnemyDatas.Count; i++)
        {
            EnemyData data = new EnemyData(EnemyDatas[i], EnemyPatrollingArr[i]);
            datas.Add(data);
            Debug.Log(datas.Count);
        }
        string json = JsonHelper.ToJson(datas, true);
        File.WriteAllText(path, json);
        EnemyDatas.Clear();
        EnemyPatrollingArr.Clear();
    }

    static void findEnemy()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            EnemyDatas.Add(o.GetComponent<EnemyManager>());
            EnemyPatrollingArr.Add(o.GetComponent<EnemyPatrolling>());
        }
    }
}