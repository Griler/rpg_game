using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static void btnNewGame()
    {
        Debug.Log("load vào");
        SceneManager.LoadScene("stage 1-1");
        GameManager.instance.isNewGame = true;
    }

    public static void btnContinueGame()
    {
        PlayerData data = LoadSystem.LoadPlayer();
        if(data == null) return;
        SceneManager.LoadScene(data.stage_level);
        GameManager.instance.isNewGame = false;
    }
}
