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
    public static string PATH_STAGE_NAME = SceneManager.GetActiveScene().name;

    /*
    private static string PATH_DATA_ENEMY_NEW_STAGE =
        "/Resources/Data/EnemyData" + SceneManager.GetActiveScene().name + ".json";*/

    public static List<EnemyManager> EnemyDatas = new List<EnemyManager>();
    public static List<EnemyPatrolling> EnemyPatrollingArr = new List<EnemyPatrolling>();

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

        for (int i = 0; i < EnemyDatas.Count; i++)
        {
            EnemyData data = new EnemyData(EnemyDatas[i], EnemyPatrollingArr[i]);
            datas.Add(data);
        }

        string json = JsonHelper.ToJson(datas, true);
        File.WriteAllText(path, json);
    }
}