using UnityEngine;

public class CajaSalon : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    public static int itemCount = 0; // Contador de objetos recogidos como variable estática

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
        if (transform.position.x >= -1.5 && transform.position.x <= 1.5 &&
            transform.position.y >= -6 && transform.position.y <= -3.5)
        {
            itemCount++; // Incrementa el contador de objetos recogidos
            Destroy(gameObject); // Destruye el objeto

            if (itemCount == 7) // Verifica si todos los objetos han sido recogidos
            {
                ChangeScene();
            }
        }
    }

    void ChangeScene()
    {
        // Código para cambiar de escena
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gaming");
    }
}
