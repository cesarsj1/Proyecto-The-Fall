using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiar4 : MonoBehaviour
{
    public Sprite[] sprites;
    private int spriteIndex = 0;
    private bool isClickable = true; // Para controlar si el objeto es clickable
    public float fadeDuration = 0.5f; // Duración del fade

    public GameObject fadeEffectObject; // Referencia al GameObject con el script Desvanecer
    private Desvanecer fadeEffectScript; // Referencia al script Desvanecer

    private void Start()
    {
        // Inicializar la referencia al script Desvanecer si el objeto está asignado
        if (fadeEffectObject != null)
            fadeEffectScript = fadeEffectObject.GetComponent<Desvanecer>();
    }

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
            // Si estamos en el último sprite, activamos la animación de desvanecimiento antes de cargar la escena
            if (fadeEffectScript != null)
            {
                fadeEffectScript.StartEffect(); // Inicia el efecto de desvanecimiento
                yield return new WaitUntil(() => fadeEffectScript.HasFinished()); // Espera a que el efecto de desvanecimiento termine
                SceneManager.LoadScene("Escena2.2"); // Cambia la escena después de que el efecto de desvanecimiento haya terminado
            }
            else
            {
                SceneManager.LoadScene("Escena2.2"); // Cambia la escena directamente si no hay efecto de desvanecimiento
            }
            yield break; // Salimos de la corrutina para evitar que se realice el fade in
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
