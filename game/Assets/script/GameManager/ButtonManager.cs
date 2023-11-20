using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static void btnNewGame()
    {
        GameManager.instance.isNewGame = true;
        Debug.Log("load vào");
        SceneManager.LoadScene("stage 1-1");
    }

    public static void btnContinueGame()
    {
        PlayerData data = LoadSystem.LoadPlayer();
        if (data == null) return;
        SceneManager.LoadScene(data.stage_level);
        GameManager.instance.isNewGame = false;
    }

    public static void btnSetting(GameObject oj)
    {
        oj.SetActive(true);
    }

    public static void btnExitUi()
    {
        GameObject.FindGameObjectWithTag("UI").SetActive(false);
        Time.timeScale = 1;
    }

    public static void btnQuit()
    {
        Application.Quit();
        Debug.Log("hello2");
    }

    public static void btnSaveGame()
    {
        SaveSystem.SaveData(PlayerManager.instance);
        SaveSystem.SaveDataEnemy();
    }

    public static void btnResetGame()
    {
        btnContinueGame();
        Time.timeScale = 1;
    }

    public static void btnNextStage()
    {
        string stageName = SceneManager.GetActiveScene().name;
        int stringLen = stageName.Length;
        string stageString = "" + stageName[stringLen - 3];
        string stageLevelString = "" + stageName[stringLen - 1];
        int stage = int.Parse(stageString);
        int stageLevel = int.Parse(stageLevelString);
        stageLevel += 1;
        if (stageLevel >= 4)
        {
            stage += 1;
            stageLevel = 1;
        }
        Debug.Log(String.Format("stage {0}-{1}", stage, stageLevel));
    }
}