using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, -4, -10);
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(0, player.position.y + offset.y, player.position.z + offset.z);
    }
}
