using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SliderComplete : MonoBehaviour
{
    public Slider slider;  // Referencia al slider
    public string sceneName;  // Cambia esto al nombre de tu escena deseada

    void Update()
    {
        if (slider.value >= 1)  // Checa si el valor del slider es 1 o 100%
        {
            SceneManager.LoadScene(sceneName);  // Carga la escena
        }
    }
}
