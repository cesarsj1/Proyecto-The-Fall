using UnityEngine;
using UnityEngine.SceneManagement;

public class TapMover : MonoBehaviour
{
    [SerializeField] private float speed = 1f; // Velocidad a la que el objeto se moverá hacia la posición deseada
    private bool isMoving = false; // Controla si el objeto debe moverse
    [SerializeField] private Vector3 targetPosition = new Vector3(0, 0); // La posición objetivo a la que se moverá el objeto
    [SerializeField] private string sceneName = "Gaming"; // Nombre de la escena a cargar

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
                ChangeScene(); // Cambia de escena directamente
            }
        }
    }

    void OnMouseDown()
    {
        isMoving = true; // Comienza a mover el objeto cuando se hace clic en él
    }

    void ChangeScene()
    {
        // Código para cambiar de escena
        SceneManager.LoadScene(sceneName);
    }
}
