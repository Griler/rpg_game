using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMg : MonoBehaviour
{
    public GameObject settings;
    public GameObject PauseGameObject;

    private void Awake()
    {
        if(!GameManager.instance.isNewGame)GameManager.instance.setActiveEnemy();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    public void pauseGame()
    {
        PauseGameObject.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void btnSaveGame()
    {
        ButtonManager.btnSaveGame();
    }

    public void btnNewGame()
    {
        ButtonManager.btnNewGame();
    }    public void btnResetGame()
    {
        ButtonManager.btnResetGame();
    }

    public void btnContinueGame()
    {
        ButtonManager.btnContinueGame();
    }    public void btnSetting()
    {
        ButtonManager.btnSetting(settings);
    } 
    public void btnExitUi()
    {
        ButtonManager.btnExitUi();
    }  
    public void btnQuitApp()
    {
        ButtonManager.btnQuit();
        Debug.Log("hello");
    }

    public void btnNextStage()
    {
        ButtonManager.btnNextStage();
    }
}