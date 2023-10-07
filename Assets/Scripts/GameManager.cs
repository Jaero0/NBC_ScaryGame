using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBase<GameManager>
{
    public int sceneIndex = 2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IfFifthStage()
    {
        if (sceneIndex == 5)
        {
            SoundManager.Instance.audioSource.Stop();
            SoundManager.Instance.audioSource.clip = SoundManager.Instance.EndBgm;
            SoundManager.Instance.audioSource.Play();
        }
    }
}
