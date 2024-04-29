using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;

    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(targetToFollow.position.y,-40f,95f),
            transform.position.z);
    }
}

