using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float player_score;
    public static float stage_time;
    public bool isNewGame;
    public int enemyCount = 0;
    public GameObject enemy;
    public GameObject player;
    public static GameManager instance;
    public static GameObject playerInstance;
    public GameObject PauseGameObject;
    public Transform startPoint;

    // Start is called before the first frame update
    void Awake()
    {
        // Ensure there is only one instance of this class
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 100;
        stage_time = 0; 
    }

    private void Update()
    {
        player_score = PlayerManager.player_score;
        countTimeStage();
        //Debug.Log(SaveSystem.EnemyDatas.Count);
    }

    public void InstantiateOject()
    {
        InstantiatePlayer();
        InstantiateEnemy();
    }

    public void InstantiatePlayer()
    {
        if (isNewGame == true)
        {
            startPoint = GameObject.Find("StartPoint").transform;
            playerInstance = Instantiate(player, startPoint.position, transform.rotation);
            return;
        }

        PlayerData data = LoadSystem.LoadPlayer();
        if (data == null) return;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        playerInstance = Instantiate(player, position, transform.rotation);
        playerInstance.GetComponent<PlayerManager>().currentHeath = data.heath;
    }

    void countTimeStage()
    {
        stage_time += Time.deltaTime;
    }

    public void InstantiateEnemy()
    {
        if (isNewGame == false)
        {
            EnemyData[] datas = LoadSystem.LoadEnemyFromDataSave();
            Debug.Log("so quai" + datas.Length);
            for (int i = 0; i < datas.Length; i++)
            {
                Vector3 position;
                position.x = datas[i].position[0];
                position.y = datas[i].position[1];
                position.z = datas[i].position[2];
                GameObject gameObject = Instantiate(enemy, position, transform.rotation);
                gameObject.GetComponent<EnemyManager>().transform.localScale = new Vector3(datas[i].scaleX, 1, 1);
                Vector3 patrolPointOne;
                patrolPointOne.x = datas[i].patrolPointOne[0];
                patrolPointOne.y = datas[i].patrolPointOne[1];
                patrolPointOne.z = datas[i].patrolPointOne[2];
                gameObject.GetComponent<EnemyPatrolling>().patrolPoints[0] = patrolPointOne;
                Vector3 patrolPointTwo;
                patrolPointTwo.x = datas[i].patrolPointTwo[0];
                patrolPointTwo.y = datas[i].patrolPointTwo[1];
                patrolPointTwo.z = datas[i].patrolPointTwo[2];
                gameObject.GetComponent<EnemyPatrolling>().patrolPoints[1] = patrolPointTwo;
            }
        }

    }
    
    public void setActiveEnemy()
    {
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            e.SetActive(false);
        }
    }
}
