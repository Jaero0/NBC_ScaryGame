using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFadeOut : MonoBehaviour
{
    [SerializeField] private GameObject blackImg;
    [SerializeField] private GameObject startBtn;

    private Image img;
    [SerializeField][Range(0, 1)] private float fadeOutTime;
    [SerializeField] private float btnTicTocTime;
    Coroutine cr;

    

    

    void Awake()
    {
        img = blackImg.GetComponent<Image>();
        cr = StartCoroutine(FadeOut());
        cr = StartCoroutine(TicTocStartBtn());
    }

    IEnumerator FadeOut()
    {
        float targetAlpha = 0f; // 목표 알파값을 0으로 설정 (완전히 투명한 상태)

        while (img.color.a > targetAlpha)
        {
            Color currentColor = img.color;
            float newAlpha = Mathf.MoveTowards(currentColor.a, targetAlpha, fadeOutTime);
            img.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
            yield return null;
        }

        // 알파값이 0보다 작거나 같으면 반복문을 빠져나오고 이미지를 비활성화합니다.
        blackImg.SetActive(false);
    }

    IEnumerator TicTocStartBtn()
    {
        while (true)
        {
            startBtn.SetActive(true);
            yield return new WaitForSeconds(btnTicTocTime);
            startBtn.SetActive(false);
            yield return new WaitForSeconds(btnTicTocTime);
        }
    }
}
