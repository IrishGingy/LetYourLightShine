using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoal : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] GameManager manager;
    [SerializeField] GameObject[] followers;

    private CameraFollow follow;
    private PlayerMovement movement;
    private Rigidbody2D rb;
    private bool end;
    bool embraced = false;

    private void Start()
    {
        follow = mainCam.GetComponent<CameraFollow>();
        movement = gameObject.GetComponent<PlayerMovement>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        end = FindObjectOfType<GameManager>().CheckScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && end)
        {
            embraced = true;
            foreach(GameObject follower in followers)
            {
                follower.GetComponent<PointEffector2D>().forceMagnitude = -50;
            }
            Debug.Log("Flipped followers");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            follow.enabled = false;
            manager.ShowMessage();
        }
        if (collision.CompareTag("Salvation") && embraced)
        {
            Debug.Log("Saved");
            movement.enabled = false;
            FindObjectOfType<GameManager>().FadeToWhite();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            movement.enabled = false;
            rb.gravityScale = 0;
        }
    }
}
