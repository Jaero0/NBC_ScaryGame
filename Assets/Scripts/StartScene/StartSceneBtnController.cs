using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneBtnController : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance.audioSource.clip = SoundManager.Instance.startBgm;
        SoundManager.Instance.audioSource.Play();
    }

    public void OnClickGameStartBtn()
    {
        SceneManager.LoadScene("LevelSelectScene");
        SoundManager.Instance.audioSource.clip = SoundManager.Instance.selectBgm;
        SoundManager.Instance.audioSource.Play();
    }
}
