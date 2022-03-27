using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongPlatform : MonoBehaviour
{
    public Transform start;
    public Transform end;

    public float speed = 1f;
    public float length = 1f;
    private float startTime;

    // Update is called once per frame
    void Update()
    {
        float distCovered = Mathf.PingPong(Time.time - startTime, length / speed);
        transform.position = Vector3.Lerp(start.position, end.position, distCovered / length);
    }
}
