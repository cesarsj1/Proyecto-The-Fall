using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    public Sprite[] sprites; // Array para almacenar los sprites
    private Image imageComponent; // Componente Image
    public float changeInterval = 1.0f; // Intervalo de cambio en segundos

    void Start()
    {
        imageComponent = GetComponent<Image>(); // Obtener el componente Image
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
            imageComponent.sprite = sprites[index]; // Cambiar el sprite actual
            index = (index + 1) % sprites.Length; // Actualizar el índice, rotar de vuelta a 0 si excede la cantidad de sprites
            yield return new WaitForSeconds(changeInterval); // Esperar el intervalo de tiempo antes de cambiar de nuevo
        }
    }

}
