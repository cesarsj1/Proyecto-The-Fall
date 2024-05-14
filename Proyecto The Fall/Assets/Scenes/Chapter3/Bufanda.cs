using UnityEngine;

public class Bufanda : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    public static int itemCount = 0; // Contador de objetos recogidos como variable estática
    public string escenaDeCambio; // Variable para almacenar el nombre de la escena de cambio

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
        if (transform.position.x >= -1.1 && transform.position.x <= 1.1 &&
            transform.position.y >= -6 && transform.position.y <= -1.4)
        {
            itemCount++; // Incrementa el contador de objetos recogidos
            Destroy(gameObject); // Destruye el objeto

            if (itemCount == 1) // Verifica si todos los objetos han sido recogidos
            {
                ChangeScene();
            }
        }
    }

    void ChangeScene()
    {
        // Carga la escena definida en el inspector
        UnityEngine.SceneManagement.SceneManager.LoadScene(escenaDeCambio);
    }
    void Start()
    {
        itemCount = 0;
    }
}
