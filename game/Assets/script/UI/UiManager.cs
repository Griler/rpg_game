using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI time_text;

    public TextMeshProUGUI score_text;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        display();
    }

    void display()
    {
        time_text.text = Mathf.Round(GameManager.stage_time).ToString();
        score_text.text = Mathf.Round(GameManager.player_score).ToString();
    }
}