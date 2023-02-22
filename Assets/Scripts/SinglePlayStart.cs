using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinglePlayStart : MonoBehaviour
{
    [SerializeField]
    SoundManager soundManager;
    [SerializeField]
    AudioClip clip;
    [SerializeField]
    AudioClip clip2;

    void Start()
    {
        soundManager = GameObject.FindWithTag("SoundManager")?.GetComponent<SoundManager>(); //SoundManagerÇéQè∆
    }

    public void SelectSingle()
    {
        soundManager.PlaySe(clip);
    }

    public void DecideSingle()
    {
        soundManager.PlaySe(clip2);
    }

    public void StartSinglePlay()
    {
        SceneManager.LoadScene("Game");
    }
}
