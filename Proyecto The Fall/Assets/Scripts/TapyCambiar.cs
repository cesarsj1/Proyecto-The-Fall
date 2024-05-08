using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapyCambiar : MonoBehaviour
{
    public Sprite[] sprites;
    private int spriteIndex = 0;
    private bool isClickable = true; // Para controlar si el objeto es clickable
    public float fadeDuration = 0.5f; // Duración del fade

    public string nextSceneName; // Nombre de la escena a cargar
    public bool useWhiteFade; // Activar o desactivar el fade blanco desde el inspector
    public Sprite whiteSprite; // Sprite de color blanco para el fade

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
            if (useWhiteFade)
            {
                GetComponent<SpriteRenderer>().sprite = whiteSprite; // Aplica el sprite blanco
                yield return StartCoroutine(FadeSprite(0, 1, fadeDuration)); // Realiza un fade in al blanco
                yield return new WaitForSeconds(fadeDuration); // Mantiene el sprite blanco durante el tiempo del fade
                SceneManager.LoadScene(nextSceneName); // Carga la próxima escena
            }
            else
            {
                SceneManager.LoadScene(nextSceneName);
            }

            yield break; // Salimos de la corrutina
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