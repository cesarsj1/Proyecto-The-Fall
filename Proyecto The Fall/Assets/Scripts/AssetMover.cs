using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AssetMover : MonoBehaviour
{
    public GameObject[] assets; // Array de todos los objetos
    public Vector3[] startPositions; // Posiciones iniciales fuera de la cámara
    public Vector3[] insidePositions; // Posiciones dentro de la cámara
    private bool[] touched; // Para controlar si el objeto ya fue tocado
    public string nextSceneName; // Nombre de la próxima escena a cargar

    void Start()
    {
        if (assets.Length != startPositions.Length || assets.Length != insidePositions.Length)
        {
            Debug.LogError("Configuration error: Arrays must be of the same length.");
            return;
        }

        touched = new bool[assets.Length];
        for (int i = 0; i < assets.Length; i++)
        {
            assets[i].transform.position = startPositions[i];
            StartCoroutine(MoveInside(i));
        }
    }

    IEnumerator MoveInside(int index)
    {
        yield return new WaitForSeconds(1f); // Pequeña demora antes de mover cada objeto
        assets[index].transform.position = insidePositions[index];
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                int index = System.Array.IndexOf(assets, hit.transform.gameObject);
                if (index != -1)
                {
                    assets[index].transform.position = startPositions[index];
                    touched[index] = true;
                    CheckAllTouched();
                }
            }
        }
    }

    void CheckAllTouched()
    {
        foreach (bool wasTouched in touched)
        {
            if (!wasTouched) return;
        }
        SceneManager.LoadScene(nextSceneName);
    }
}
