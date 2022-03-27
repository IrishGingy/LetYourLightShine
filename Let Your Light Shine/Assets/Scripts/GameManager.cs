using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;
    ScrollingText text;
    bool faded = false;

    public float restartDelay = 1f;
    public float fadeSpeed = 1f;
    public GameObject player;

    public void ShowMessage()
    {
        Debug.Log("Showing message...");
        text = gameObject.GetComponent<ScrollingText>();
        text.ShowTextBox();
    }

    public void EndLevel()
    {
        if (gameOver == false)
        {
            gameOver = true;
            Invoke("Restart", restartDelay);
        }
    }

    public void FadeToWhite()
    {
        // fade to white.
        Invoke("WinLevel", 2f);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinLevel()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
    }

    public bool CheckScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            return true;
        }
        return false;
    }
}
