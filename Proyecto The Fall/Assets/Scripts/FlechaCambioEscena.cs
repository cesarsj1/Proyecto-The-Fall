using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlechaCambioEscena : MonoBehaviour
{
    // M�todo que se ejecuta cuando se hace clic en el objeto
    public void Button1()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene("Escena1.2.1");
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
