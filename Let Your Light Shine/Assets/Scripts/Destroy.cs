using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public Sprite sprite;
    public float fadeSpeed = 1f;

    PlayerMovement movement;
    Color spriteColor;
    bool faded = false;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        spriteColor = GetComponent<SpriteRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Spikes"))
        {
            Debug.Log("Play Destroyed Animation for: " + gameObject.name);
            movement.enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            //FindObjectOfType<GameManager>().FadeOut(GetComponent<SpriteRenderer>().material.color);
            Restart();
        }
    }

    void Restart()
    {
        FindObjectOfType<GameManager>().EndLevel();
    }
}
