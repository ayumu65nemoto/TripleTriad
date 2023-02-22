using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBGM : MonoBehaviour
{
    [SerializeField]
    SoundManager soundManager;
    [SerializeField]
    AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindWithTag("SoundManager")?.GetComponent<SoundManager>(); //SoundManager���Q��
        soundManager.PlayBgm(clip);
    }
}
