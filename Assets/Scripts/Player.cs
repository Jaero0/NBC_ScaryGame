using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] private float moveSpeed = 5.0f; // 오브젝트 이동 속도

    public GameObject failCanvas;

    void Awake()
    {
        Time.timeScale = 1;
        print(GameManager.Instance.sceneIndex);
        mainCam = Camera.main;
    }
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        transform.position = Vector3.Lerp(transform.position, mousePosition, Time.deltaTime * moveSpeed);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            
            GameManager.Instance.sceneIndex++;
            GameManager.Instance.IfFifthStage();
            SceneManager.LoadScene(GameManager.Instance.sceneIndex);
        }
        if (collision.gameObject.tag == "Border")
        {
            //TODO setactive
            failCanvas.SetActive(true);
            Time.timeScale = 0f;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 1);
        }
    }
}
