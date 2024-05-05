using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonEscena : MonoBehaviour
{
    public string escenaDeCambio; // Variable para almacenar el nombre de la escena de cambio

    // Método que se ejecuta cuando se hace clic en el objeto
    public void Button1()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene(escenaDeCambio);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
