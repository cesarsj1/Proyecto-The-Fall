using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteChangerWithFade : MonoBehaviour
{
    public Sprite[] sprites;
    private int spriteIndex = 0;
    private bool isClickable = true; // Para controlar si el objeto es clickable
    public float fadeDuration = 0.5f; // Duración del fade

    private void OnMouseDown()
    {
        if (isClickable)
        {
            StartCoroutine(ChangeSpriteAfterDelay(fadeDuration));
        }
    }

    IEnumerator ChangeSpriteAfterDelay(float delay)
    {
        isClickable = false; // Deshabilita clics durante el cambio

        // Fade Out
        yield return StartCoroutine(FadeSprite(1, 0, delay / 2)); // Fade out en la mitad del tiempo total

        // Cambio de sprite después del fade out y espera
        spriteIndex++;
        if (spriteIndex < sprites.Length)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
        }
        else
        {
            gameObject.SetActive(false); // Desactiva el objeto si no hay más sprites
        }

        // Fade In
        yield return StartCoroutine(FadeSprite(0, 1, delay / 2)); // Fade in en la mitad del tiempo total

        yield return new WaitForSeconds(0.5f); // Espera adicional antes de permitir otro clic

        isClickable = true; // Re-habilita clics después del cambio y espera
    }

    IEnumerator FadeSprite(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color currentColor = spriteRenderer.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            spriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }
    }
}

