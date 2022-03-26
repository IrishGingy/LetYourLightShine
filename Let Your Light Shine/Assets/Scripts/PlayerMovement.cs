using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 velocity;

    [SerializeField] float sidewaysForce;

    private bool left = false;
    private bool right = false;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
        }
    }

    private void FixedUpdate()
    {
        velocity = rb.transform.position;

        if (left)
        {
            rb.AddForce(new Vector2(-sidewaysForce * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        if (right)
        {
            rb.AddForce(new Vector2(sidewaysForce * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
    }
}
