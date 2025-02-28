using System.Collections;
using TMPro;
using UnityEngine;

public class TextTyper : MonoBehaviour
{
    public TMP_Text textMeshPro; // Reference to the TextMeshPro component
    public float typingSpeed = 0.05f; // Speed of typing

    public void StartTyping(string text)
    {
        StopAllCoroutines();
        StartCoroutine(TypeText(text));

    }

    private IEnumerator TypeText(string text)
    {
        textMeshPro.text = ""; // Clear the text initially

        foreach (char letter in text.ToCharArray())
        {
            textMeshPro.text += letter; // Add one letter at a time
            yield return new WaitForSeconds(typingSpeed); // Wait for the specified typing speed
        }
    }
}
