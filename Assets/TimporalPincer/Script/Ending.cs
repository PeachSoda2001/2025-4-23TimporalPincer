using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ending : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public float delay = 0.05f;

    private string fullText;

    private void Start()
    {
        fullText = textComponent.text;  // Grab text already in TMP at start
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textComponent.text = "";
        foreach (char c in fullText)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(delay);
        }
    }
}