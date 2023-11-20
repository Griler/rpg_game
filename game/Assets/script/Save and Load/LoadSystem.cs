using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class LoadSystem
{
    private const string PATH_DATA_PLAYER = "/Resources/Data/playerData.json";
    public static string PATH_STAGE_NAME = SceneManager.GetActiveScene().name;
    private const string PATH_DATA_ENEMY = "/Resources/Data/EnemyData.json";

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

    /*
    public static EnemyData[] LoadFromJson()
    {
        string path;
        path = Application.dataPath + PATH_DATA_ENEMY;
        string json;
        if (!File.Exists(path))
        {
            Debug.Log("load continue game: " + path);
            Debug.Log("loi");
            return null;
        }

        if (GameManager.instance.isNewGame)
        {
             json = PlayerPrefs.GetString(PATH_STAGE_NAME);
            EnemyData[] datas = JsonHelper.FromJson<EnemyData>(json);
            return datas;
        }
        else
        {
            Debug.Log("load continue game: " + path);
            json = File.ReadAllText(path);
            EnemyData[] datas = JsonHelper.FromJson<EnemyData>(json);
            return datas;
        }
    }
*/
    public static EnemyData[] LoadEnemyFromDataSave()
    {
        if (GameManager.instance.isNewGame) return new EnemyData[0];
        else
        {  // GameManager.instance.setActiveEnemy();
            string path = Application.dataPath + PATH_DATA_ENEMY;
            path = Application.dataPath + PATH_DATA_ENEMY;
            Debug.Log("load continue game: " + path);
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
}