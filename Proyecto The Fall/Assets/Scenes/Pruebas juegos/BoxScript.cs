using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private int itemCount = 0; // Contador de objetos recogidos

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DraggableObject")
        {
            itemCount++; // Incrementa el contador de objetos
            Destroy(other.gameObject); // Destruye el objeto

            if (itemCount == 6) // Verifica si todos los objetos han sido recogidos
            {
                ChangeScene();
            }
        }
    }

    void ChangeScene()
    {
        // Código para cambiar de escena
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuPrincipal");
    }
    private void Start()
    {
        itemCount = 0;
    }
}
