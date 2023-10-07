using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LvSelectSceneBtnController : MonoBehaviour
{
    #region For UI Animation Variables

    public GameObject stage1Img;
    public GameObject stage2Img;
    public Button rightBtn;
    public Button leftBtn;

    // 이동 애니메이션의 진행 시간
    public float animationDuration = 1.0f;
    Coroutine cr1;
    Coroutine cr2;

    private Vector3 stage1StartPos;
    private Vector3 stage1EndPos;

    private Vector3 stage2StartPos;
    private Vector3 stage2EndPos;

    private bool isAnimating = false;

    #endregion


    [SerializeField] private GameObject cantBtn;

    void Awake()
    {
        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        leftBtn.interactable = false;

        // initialize default value
        stage1StartPos = stage1Img.transform.localPosition;
        stage1EndPos = new Vector3(-760f, stage1StartPos.y, stage1StartPos.z);

        stage2StartPos = stage2Img.transform.localPosition;
        stage2EndPos = new Vector3(0f, stage2StartPos.y, stage2StartPos.z);
    }

    public void OnClickRightButton()
    {
        if (!isAnimating)
        {
            cr1 = StartCoroutine(MoveImages(stage1StartPos, stage1EndPos, stage2StartPos, stage2EndPos));

            leftBtn.interactable = true;
            rightBtn.interactable = false;
        }
    }

    public void OnClickLeftButton()
    {
        if (!isAnimating)
        {
            cr2 = StartCoroutine(MoveImages(stage1EndPos, stage1StartPos, stage2EndPos, stage2StartPos));

            leftBtn.interactable = false;
            rightBtn.interactable = true;
        }
    }

    #region Do Animation UI
    private IEnumerator MoveImages(Vector3 stage1Start, Vector3 stage1Target, Vector3 stage2Start, Vector3 stage2Target)
    {
        isAnimating = true;

        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            // stage1Img를 이동
            stage1Img.transform.localPosition = Vector3.Lerp(stage1Start, stage1Target, elapsedTime / animationDuration);

            // stage2Img를 이동
            stage2Img.transform.localPosition = Vector3.Lerp(stage2Start, stage2Target, elapsedTime / animationDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 애니메이션이 끝나면 위치를 보정
        stage1Img.transform.localPosition = stage1Target;
        stage2Img.transform.localPosition = stage2Target;

        isAnimating = false;
    }
    #endregion

    public void OnClickEarthBtn()
    {
        SceneManager.LoadScene("EarthScene");
        SoundManager.Instance.audioSource.clip = SoundManager.Instance.stage1;
        SoundManager.Instance.audioSource.Play();
    }
    public void OnClickMarsBtn()
    {
        cantBtn.SetActive(true);
    }

    public void OnClickCloseCantBtn()
    {
        cantBtn.SetActive(false);
    }
}
