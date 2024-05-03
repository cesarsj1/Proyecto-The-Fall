using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MoveToPositionAndChangeScene : MonoBehaviour
{
    private Vector3 targetPosition = new Vector3(0, 0, -20); // Nueva posición objetivo que incluye Z
    private Vector3 originalScale; // Escala original del objeto
    private Vector3 targetScale; // Escala objetivo del objeto
    private float totalTime = 3f; // Tiempo total para moverse a la posición objetivo
    private float elapsedTime = 0; // Tiempo transcurrido desde que comenzó el movimiento
    private bool isMoving = false; // Controla si el objeto debe moverse
    public GameObject fadeEffectObject; // El GameObject que tiene el script Desvanecer
    private Desvanecer fadeEffectScript; // Referencia al script Desvanecer

    void Start()
    {
        originalScale = transform.localScale; // Guardar la escala original
        targetScale = originalScale * 1.5f; // Calcular la escala objetivo (50% más grande)
        if (fadeEffectObject != null)
            fadeEffectScript = fadeEffectObject.GetComponent<Desvanecer>(); // Obtener el componente Desvanecer
    }

    void Update()
    {
        if (isMoving)
        {
            elapsedTime += Time.deltaTime; // Actualizar el tiempo transcurrido
            float fraction = elapsedTime / totalTime; // Calcular la fracción del tiempo total transcurrido

            // Mover el objeto hacia la posición objetivo y escalarlo de manera suave
            transform.position = Vector3.Lerp(transform.position, targetPosition, fraction);
            transform.localScale = Vector3.Lerp(originalScale, targetScale, fraction);

            // Verifica si el objeto ha llegado a la posición objetivo
            if (fraction >= 1.0f)
            {
                isMoving = false; // Detiene el movimiento
                elapsedTime = 0; // Resetea el tiempo transcurrido para futuras reutilizaciones
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
        SceneManager.LoadScene("Escena3.2");
    }
}
