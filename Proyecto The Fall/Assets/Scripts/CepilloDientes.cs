using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brush : MonoBehaviour
{
    private Vector3 startPosition;
    private float timeMoved = 0f;
    private bool isMoving = false;

    [SerializeField] private float timeRequire = 3f; // Tiempo necesario para mover el objeto antes de cambiar la escena
    [SerializeField] private string sceneName = "EscenaPelos"; // Nombre de la escena a cargar

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            timeMoved += Time.deltaTime;
            if (timeMoved > timeRequire)
            {
                SceneManager.LoadScene(sceneName);
                Debug.Log("Assets destruidos después de " + timeRequire + " segundos de movimiento.");
            }
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;
            transform.position = mousePosition;
            isMoving = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            transform.position = startPosition;
            isMoving = false;
            timeMoved = 0f; // Restablecer el contador de tiempo cuando se suelta el botón
        }
    }
}
