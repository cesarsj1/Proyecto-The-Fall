using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{ 
    public void cap1() {

        SceneManager.LoadScene("EscenaInicio1");
    }
    public void cap2() {

        SceneManager.LoadScene("EscenaInicio2");
    }
    public void cap3()
    {

        SceneManager.LoadScene("EscenaInicio3");
    }
    public void cap4()
    {

        SceneManager.LoadScene("EscenaInicio4");
    }
}
