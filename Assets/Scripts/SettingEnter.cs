using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingEnter : MonoBehaviour
{
    [SerializeField]
    SoundManager soundManager;
    [SerializeField]
    AudioClip clip;
    [SerializeField]
    AudioClip clip2;

    void Start()
    {
        soundManager = GameObject.FindWithTag("SoundManager")?.GetComponent<SoundManager>(); //SoundManager‚ğQÆ
    }

    public void SelectSetting()
    {
        soundManager.PlaySe(clip);
    }

    public void DecideSetting()
    {
        soundManager.PlaySe(clip2);
    }

    public void ToSetting()
    {
        SceneManager.LoadScene("Setting");
    }
}
