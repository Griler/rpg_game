using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    private float volume;

    public GameObject slider;
    // Start is called before the first frame update
    void Start()
    {
        volume = PlayerPrefs.GetFloat("volMaster");
        slider.GetComponent<Slider>().value = volume;
    }
    void Update()
    {
        volume = slider.GetComponent<Slider>().value;
        AudioManager.instance.volume(volume);
    }
}
