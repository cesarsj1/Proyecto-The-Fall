using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] objectsToMove; // Lista de todos los objetos que pueden moverse y desaparecer
    public string nextSceneName = "NextScene"; // Nombre de la escena siguiente

    // M�todo para iniciar el movimiento de todos los objetos
    public void MoveAllObjects()
    {
        foreach (var obj in objectsToMove)
        {
            obj.GetComponent<AssetMover>().Move();
        }
    }

    // Verifica si todos los objetos est�n desactivados
    public void CheckAllObjectsDisabled()
    {
        foreach (var obj in objectsToMove)
        {
            if (obj.activeInHierarchy)
                return;
        }
        // Cambia de escena si todos los objetos est�n desactivados
        SceneManager.LoadScene(nextSceneName);
    }
}