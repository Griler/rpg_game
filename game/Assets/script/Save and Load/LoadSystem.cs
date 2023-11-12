using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class LoadSystem : MonoBehaviour
{

    private const string PATH_DATA_PLAYER = "/Data/playerData.json";
    private const string PATH_DATA_ENEMY = "/Data/EnemyData.json";
    public static string PATH_STAGE_NAME = SceneManager.GetActiveScene().name;
    private static string PATH_DATA_ENEMY_NEW_STAGE = "/Data/EnemyData" + SceneManager.GetActiveScene().name + ".json";
        
    public static PlayerData LoadPlayer()
    {
        string path = Application.dataPath + PATH_DATA_PLAYER;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            return data;
        }
        else
        {
            Debug.Log("loi");
            return null;
        }
    }

    public static EnemyData[] LoadFromJson()
    {
        string path;
        if (GameManager.instance.isNewGame)
        {
            path = Application.dataPath + PATH_DATA_ENEMY_NEW_STAGE;
            Debug.Log("load new game: " + path);
        }
        else
        {
            path = Application.dataPath + PATH_DATA_ENEMY;
            Debug.Log("load continue game: " + path);
        }

        string json = File.ReadAllText(path);
        if (File.Exists(path))
        {
            EnemyData[] datas = JsonHelper.FromJson<EnemyData>(json);
            return datas;
        }
        else
        {
            Debug.Log("loi");
            return null;
        }
    }
}
