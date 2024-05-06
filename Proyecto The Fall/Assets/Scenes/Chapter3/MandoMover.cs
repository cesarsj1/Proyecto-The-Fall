using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MandoMover : MonoBehaviour
{
    public float speed = 1f; // Velocidad a la que el objeto se moverá hacia la posición deseada
    private bool isMoving = false; // Controla si el objeto debe moverse
    private Vector3 targetPosition = new Vector3(0, 0, 0); // La posición objetivo a la que se moverá el objeto
    public GameObject fadeEffectObject; // El GameObject que tiene el script Desvanecer
    private Desvanecer fadeEffectScript; // Referencia al script Desvanecer

    void Start()
    {
        if (fadeEffectObject != null)
            fadeEffectScript = fadeEffectObject.GetComponent<Desvanecer>(); // Obtener el componente Desvanecer
    }

    void Update()
    {
        if (isMoving)
        {
            // Mover el objeto hacia la posición objetivo
            float step = speed * Time.deltaTime; // Calcula la distancia a mover en cada frame
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Verifica si el objeto ha llegado a la posición objetivo
            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                isMoving = false; // Detiene el movimiento
                if (fadeEffectScript != null)
                {
                    fadeEffectScript.StartEffect(); // Inicia el efecto de desvanecimiento
                    StartCoroutine(WaitForFadeEffect()); // Espera a que el efecto de desvanecimiento termine
                }
                else
                {
                    ChangeScene(); // Cambia de escena si no hay efecto de desvanecimiento
                }
            }
        }
    }

    void OnMouseDown()
    {
        isMoving = true; // Comienza a mover el objeto cuando se hace clic en él
    }

    IEnumerator WaitForFadeEffect()
    {
        yield return new WaitUntil(() => fadeEffectScript.HasFinished()); // Espera hasta que el efecto de desvanecimiento termine
        ChangeScene(); // Cambia la escena después de que el efecto de desvanecimiento haya terminado
    }

    void ChangeScene()
    {
        // Código para cambiar de escena
        SceneManager.LoadScene("Gaming");
    }
}
