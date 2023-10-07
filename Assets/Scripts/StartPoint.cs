using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Start()
    {
        if (player != null)
        {
            player.transform.position = transform.position;
        }
    }
}
