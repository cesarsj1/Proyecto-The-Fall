using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset; // Offset cuando se agarra el objeto
    private float zCoord; // Profundidad del objeto en coordenadas de pantalla

    [SerializeField] private static int itemCount = 0; // Contador de objetos recogidos como variable estática
    [SerializeField] private int totalItemsNeeded = 7; // Total de objetos necesarios para recoger

    [SerializeField] private float minX = -5.5f; // Límite mínimo en X para soltar objetos
    [SerializeField] private float maxX = 5.5f;  // Límite máximo en X para soltar objetos
    [SerializeField] private float minY = -4f;   // Límite mínimo en Y para soltar objetos
    [SerializeField] private float maxY = -2f;   // Límite máximo en Y para soltar objetos
    [SerializeField] private string nextSceneName = "Escena2.2"; // Nombre de la próxima escena

    void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }

    void OnMouseUp()
    {
        if (transform.position.x >= minX && transform.position.x <= maxX &&
            transform.position.y >= minY && transform.position.y <= maxY)
        {
            itemCount++; // Incrementa el contador de objetos recogidos
            Destroy(gameObject); // Destruye el objeto

            if (itemCount == totalItemsNeeded) // Verifica si todos los objetos han sido recogidos
            {
                ChangeScene();
            }
        }
    }

    void ChangeScene()
    {
        // Código para cambiar de escena
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }

    void Start()
    {
        itemCount = 0; // Reiniciar el contador de objetos al iniciar
    }
}
