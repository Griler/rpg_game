using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class SaveSytem
{
    private const string PATH_DATA_PLAYER = "/Data/playerData.json";
    private const string PATH_DATA_ENEMY = "/Data/EnemyData.json";
    public static string PATH_STAGE_NAME = SceneManager.GetActiveScene().name;
    private static string PATH_DATA_ENEMY_NEW_STAGE = "/Data/EnemyData" + SceneManager.GetActiveScene().name + ".json";
    public static List<EnemyManager> EnemyDatas = new List<EnemyManager>();
    public static List<EnemyPatrolling> EnemyPatrollingArr = new List<EnemyPatrolling>();
    public static void SaveData(PlayerManager playerManager)
    {
        PlayerData data = new PlayerData(playerManager);
        data.test();
        string json = JsonUtility.ToJson(data, true);
        string path = Application.dataPath + PATH_DATA_PLAYER;
        Debug.Log(path);
        File.WriteAllText(path, json);
    }
    public static void SaveDataEnemy()
    {
        string path;
        if (GameManager.instance.isNewGame)
        {
            path = Application.dataPath + PATH_DATA_ENEMY_NEW_STAGE;
            Debug.Log("save new game data enemy: " + path);
        }
        else
        {
            path = Application.dataPath + PATH_DATA_ENEMY;
            Debug.Log("save continue game data enemy: " + path);
        }
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