using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{ 
    public void cap1() {

        SceneManager.LoadScene("Escena1");
    }
    public void cap2() {

        SceneManager.LoadScene("Escena2.1");
    }
    public void cap3()
    {

        SceneManager.LoadScene("OrdenarEstanteria");
    }
    public void cap4()
    {

        SceneManager.LoadScene("Escena4.1");
    }
}
