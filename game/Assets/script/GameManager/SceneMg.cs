using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMg : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.isNewGame = false;
    }

    public void btnSaveGame()
    {
        SaveSytem.SaveData(PlayerManager.instance);
    }

    public void btnNewGame()
    {
        ButtonManager.btnNewGame();
    }

    public void btnContinueGame()
    {
        ButtonManager.btnContinueGame();
    }
}