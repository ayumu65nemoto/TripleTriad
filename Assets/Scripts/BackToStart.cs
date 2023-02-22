using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStart : MonoBehaviour
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

    public void SelectBack()
    {
        soundManager.PlaySe(clip);
    }

    public void DecideBack()
    {
        soundManager.PlaySe(clip2);
    }

    public void BackStart()
    {
        SceneManager.LoadScene("Start");
    }
}
