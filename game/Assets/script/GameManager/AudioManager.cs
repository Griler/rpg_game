using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    // Use this for initialization
    void Awake ()
    {
        instance = this;
        volume(PlayerPrefs.GetFloat("volMaster"));
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public void  volume(float volume )
    {
        this.GetComponent<AudioSource>().volume = volume;
        PlayerPrefs.SetFloat("volMaster", this.GetComponent<AudioSource>().volume);
        PlayerPrefs.Save();
    }
    
}
