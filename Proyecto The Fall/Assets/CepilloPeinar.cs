using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CepilloPeinar : MonoBehaviour
{
    private Vector3 startPosition;
    private float timeMoved = 0f;
    private bool isMoving = false;
    public GameObject animationTarget; // Asigna el objeto con la animaci�n aqu�

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            timeMoved += Time.deltaTime;
            if (timeMoved > 5f)
            {
                // Detener la animaci�n si es necesario
                // Destruir todos los assets con un fade (requiere implementaci�n adicional)
                SceneManager.LoadScene("Escena2");
                Debug.Log("Assets destruidos despu�s de 5 segundos de movimiento.");

            }
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;
            transform.position = mousePosition;
            isMoving = true;
            // Iniciar la animaci�n
            animationTarget.GetComponent<Animator>().Play("NombreDeTuAnimacion"); // Aseg�rate de cambiar "NombreDeTuAnimacion"
        }
        else if (Input.GetMouseButtonUp(0))
        {
            transform.position = startPosition;
            isMoving = false;
            // Opcional: Detener la animaci�n si es necesario
        }
    }
}
