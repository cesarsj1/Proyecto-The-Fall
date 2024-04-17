using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento

    void Update()
    {
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime; // Obtener la entrada del teclado y calcular el desplazamiento

        transform.Translate(0, moveY, 0); // Mover el GameObject
    }
}
