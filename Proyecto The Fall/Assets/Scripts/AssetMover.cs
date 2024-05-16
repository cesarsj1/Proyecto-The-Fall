using UnityEngine;

public class AssetMover : MonoBehaviour
{
    public Vector3 newPosition; // Posición nueva a la que se moverá el objeto
    private bool isMoving = false;
    private float speed = 5f; // Velocidad de movimiento, ajustable desde el Inspector

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
            if (transform.position == newPosition)
            {
                isMoving = false;
            }
        }

        // Manejo de entrada táctil
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        Disappear();
                    }
                }
            }
        }
    }
    private void Start()
    {
        Move();
    }

    public void Move()
    {
        isMoving = true;
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().CheckAllObjectsDisabled();
    }
}