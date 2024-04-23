using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 touchPosition;
    private Vector3 offset;
    private Camera mainCamera;
    private bool isDragging = false;
    public float minY = 250.0f; // Posici�n inicial en Y
    public float maxY = 0.0f; // Posici�n final en Y para cambiar de escena

    void Start()
    {
        mainCamera = Camera.main; // Asegura que hay una c�mara principal definida
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Inicia el arrastre
                    touchPosition = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                    offset = transform.position - touchPosition;
                    isDragging = true;
                    break;

                case TouchPhase.Moved:
                    // Mientras se mueve el dedo, actualizar la posici�n
                    if (isDragging)
                    {
                        touchPosition = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                        float clampedY = Mathf.Clamp(touchPosition.y + offset.y, minY, maxY);
                        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
                    }
                    break;

                case TouchPhase.Ended:
                    // Detiene el arrastre
                    isDragging = false;
                    // Verificar si ha alcanzado la posici�n para cambiar de escena
                    if (transform.position.y >= maxY)
                    {
                        ChangeScene();
                    }
                    break;
            }
        }
    }

    void ChangeScene()
    {
        // Cambia a la nueva escena
        UnityEngine.SceneManagement.SceneManager.LoadScene("Escena2");
    }
}


