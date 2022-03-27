using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform start;
    public Transform end;

    public float speed = 1f;
    public float length = 4f;
    private float startTime;

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        transform.position = Vector3.Lerp(start.position, end.position.normalized, distCovered / length);
    }
}
