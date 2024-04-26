using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public Sprite[] sprites; // Array para almacenar los sprites
    private SpriteRenderer spriteRenderer; // Componente SpriteRenderer
    public float changeInterval = 1.0f; // Intervalo de cambio en segundos

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtener el componente SpriteRenderer
        if (sprites.Length > 0)
        {
            StartCoroutine(ChangeSprite()); // Iniciar la coroutine
        }
    }

    IEnumerator ChangeSprite()
    {
        int index = 0;
        while (true)
        {
            spriteRenderer.sprite = sprites[index]; // Cambiar el sprite actual
            index = (index + 1) % sprites.Length; // Actualizar el índice, rotar de vuelta a 0 si excede la cantidad de sprites
            yield return new WaitForSeconds(changeInterval); // Esperar el intervalo de tiempo antes de cambiar de nuevo
        }
    }

}
