using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void OnClickReBtn()
    {
        print("asd");
        SceneManager.LoadScene(GameManager.Instance.sceneIndex);
    }

    public void OnClickMenuBtn()
    {
        SceneManager.LoadScene("LevelSelectScene");
        SoundManager.Instance.audioSource.Stop();
        SoundManager.Instance.audioSource.clip = SoundManager.Instance.selectBgm;
        SoundManager.Instance.audioSource.Play();
    }

    public void OnClickFinish()
    {
        SceneManager.LoadScene("LevelSelectScene");
        SoundManager.Instance.audioSource.Stop();
        SoundManager.Instance.audioSource.clip = SoundManager.Instance.selectBgm;
        SoundManager.Instance.audioSource.Play();
    }
}
