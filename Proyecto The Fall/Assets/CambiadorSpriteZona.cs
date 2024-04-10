using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiadorSpriteZona : MonoBehaviour
{
    public Sprite[] sprites;
    private int spriteIndex = 0;
    private bool isMoving = false;
    private bool changingSprite = false;
    private bool forwardDirection = true; // Dirección del bucle de sprites
    public Transform limiteSuperior;
    public Transform limiteInferior;
    public float fadeDuration = 0.5f; // Duración del fade

    private void Update()
    {
        if (isMoving && !changingSprite)
        {
            if (forwardDirection)
            {
                if (spriteIndex == 3 && transform.position.y >= limiteSuperior.position.y)
                {
                    CambiarSprite();
                }
            }
            else
            {
                if (spriteIndex == 4 && transform.position.y <= limiteInferior.position.y)
                {
                    CambiarSprite();
                }
            }
        }
    }

    private void OnMouseDown()
    {
        isMoving = true;
    }

    private void OnMouseUp()
    {
        isMoving = false;
    }

    private void CambiarSprite()
    {
        isMoving = false; // Detiene el movimiento mientras se cambia el sprite
        changingSprite = true;

        // Cambio de sprite
        if (forwardDirection)
        {
            spriteIndex = 4; // Cambiar al índice de la imagen 4
        }
        else
        {
            spriteIndex = 3; // Cambiar al índice de la imagen 3
        }

        StartCoroutine(ChangeSpriteWithFade(sprites[spriteIndex]));
    }

    IEnumerator ChangeSpriteWithFade(Sprite nuevoSprite)
    {
        // Fade Out
        yield return StartCoroutine(FadeSprite(1, 0, fadeDuration / 2)); // Fade out en la mitad del tiempo total

        // Cambia el sprite
        GetComponent<SpriteRenderer>().sprite = nuevoSprite;

        // Fade In
        yield return StartCoroutine(FadeSprite(0, 1, fadeDuration / 2)); // Fade in en la mitad del tiempo total

        // Cambiar la dirección del bucle de sprites cuando se complete el movimiento
        if (forwardDirection)
        {
            forwardDirection = false;
        }
        else
        {
            forwardDirection = true;
        }

        changingSprite = false;
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

