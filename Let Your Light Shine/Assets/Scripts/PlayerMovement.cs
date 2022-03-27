using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 velocity;

    [SerializeField] float sidewaysForce;
    [SerializeField] float jumpForce;

    private bool left = false;
    private bool right = false;
    private bool jumping = false;
    private bool onWall = false;
    private int whichWall = -1;
    private Vector2 speedLimit = new Vector2(0f, -10f);
    private bool off = false;

    private void Start()
    {
        sidewaysForce = 20f;
        jumpForce = 300f;
        //rb.AddTorque(1f, ForceMode2D.Force);
    }

    // Update is called once per frame
    private void Update()
    {
        velocity = rb.velocity;

        if (!off)
        {
            if (Input.GetKeyDown(KeyCode.A) && whichWall != 0)
            {
                left = true;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                left = false;
            }

            if (Input.GetKeyDown(KeyCode.D) && whichWall != 1)
            {
                right = true;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                right = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumping = true;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumping = false;
            }
        }
        else
        {
            left = false;
            right = false;
        }
    }

    private void FixedUpdate()
    {
        if (velocity.y < speedLimit.y)
        {
            rb.AddForce(new Vector2(0, -rb.velocity.y), ForceMode2D.Force);
        }

        if (left)
        {
            rb.AddForce(new Vector2(-sidewaysForce * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        if (right)
        {
            rb.AddForce(new Vector2(sidewaysForce * Time.deltaTime, 0), ForceMode2D.Impulse);
        }

        if (jumping && onWall)
        {
            rb.velocity = new Vector2(0, 0);
            //rb.AddForce(new Vector2(0, jumpForce * Time.deltaTime), ForceMode2D.Impulse);
            rb.AddForce(new Vector2(SidewaysJumpingForce(whichWall) * Time.deltaTime, jumpForce * Time.deltaTime), ForceMode2D.Impulse);
            /*Invoke("PauseMovement", 1f);
            off = false;*/
        }
    }

    private float SidewaysJumpingForce(int ww)
    {
        // 0 means that there is a collision with the left wall.
        if (ww == 1)
        {
            return -500;
        }
        else
        {
            return 500;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("LeftWall") || collision.collider.CompareTag("RightWall"))
        {
            onWall = true;
            if (collision.collider.CompareTag("LeftWall"))
            {
                whichWall = 0;
            }
            else
            {
                whichWall = 1;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("LeftWall") || collision.collider.CompareTag("RightWall"))
        {
            onWall = false;
            whichWall = -1;
        }
    }

    void PauseMovement()
    {
        off = true;
    }
}
