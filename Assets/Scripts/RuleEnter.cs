using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleEnter : MonoBehaviour
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

    public void SelectRule()
    {
        soundManager.PlaySe(clip);
    }

    public void DecideRule()
    {
        soundManager.PlaySe(clip2);
    }

    public void ToRule()
    {
        SceneManager.LoadScene("Rule");
    }
}
