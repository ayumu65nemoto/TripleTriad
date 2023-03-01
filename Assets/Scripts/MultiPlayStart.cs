using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiPlayStart : MonoBehaviour
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

    public void SelectMulti()
    {
        soundManager.PlaySe(clip);
    }

    public void DecideMulti()
    {
        soundManager.PlaySe(clip2);
    }

    public void StartMultiPlay()
    {
        SceneManager.LoadScene("Online");
    }
}
