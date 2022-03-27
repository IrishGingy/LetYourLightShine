using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScrollingText : MonoBehaviour
{
    [Header("Text Settings")]
    [SerializeField] [TextArea] string[] itemInfo;
    [SerializeField] float textSpeed = 0.01f;

    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI itemInfoText;
    int currentDisplayingText = 0;

    private Image textArea;

    private void Start()
    {
        textArea = itemInfoText.GetComponentInParent<Image>();
        textArea.enabled = false;
    }
    
    public void ShowTextBox()
    {
        textArea.enabled = true;
        Invoke("ActivateText", 1f);
    }

    public void ActivateText()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        for (int i = 0; i < itemInfo[currentDisplayingText].Length + 1; i++)
        {
            itemInfoText.text = itemInfo[currentDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
