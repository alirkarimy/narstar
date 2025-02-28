using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class FadeImage : MonoBehaviour
{
    public Image image; // Reference to the UI Image component
    public float fadeDuration = 1f; // Duration of the fade effect
    public UnityEvent OnFadeIn;
    private void OnEnable()
    {
        // Start the fade-in effect
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        Color color = image.color;
        color.a = 0; // Start fully transparent
        image.color = color;

        while (color.a < 1)
        {
            color.a += Time.deltaTime / fadeDuration; // Increase alpha
            image.color = color;
            yield return null; // Wait for the next frame
        }
        OnFadeIn?.Invoke();
        yield return new WaitForSeconds(1); // Wait for the next frame

        // Start fade-out after fade-in is complete
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        Color color = image.color;

        while (color.a > 0)
        {
            color.a -= Time.deltaTime / fadeDuration; // Decrease alpha
            image.color = color;
            yield return null; // Wait for the next frame
        }
        gameObject.SetActive(false);
    }
}
