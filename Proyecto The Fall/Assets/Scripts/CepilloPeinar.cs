using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CepilloPeinar : MonoBehaviour
{
    private Vector3 startPosition;
    private float timeMoved = 0f;
    private bool isMoving = false;

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
                SceneManager.LoadScene("EscenaBajar");
                Debug.Log("Assets destruidos después de 5 segundos de movimiento.");
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
        }
    }
}
