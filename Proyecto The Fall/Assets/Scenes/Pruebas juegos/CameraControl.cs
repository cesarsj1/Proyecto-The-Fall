using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera mainCamera;

    public void MoveCameraLeft()
    {
        if (mainCamera.transform.position.x > -3)
        {
            mainCamera.transform.position += new Vector3(-3, 0, 0);
        }
    }

    public void MoveCameraRight()
    {
        if (mainCamera.transform.position.x < 3)
        {
            mainCamera.transform.position += new Vector3(3, 0, 0);
        }
    }
}
