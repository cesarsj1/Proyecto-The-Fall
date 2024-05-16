using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    [Tooltip("Time in seconds for the fade to complete")]
    public float fadeDuration = 6.0f;  // Time in seconds for the fade to complete
    private SpriteRenderer spriteRenderer;
    private Color startColor;
    private Color endColor = Color.black;
    private float startTime;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component missing from this GameObject");
            return;
        }

        startColor = spriteRenderer.color;
        startTime = Time.time;
    }

    void Update()
    {
        if (spriteRenderer == null) return;

        float timeSinceStarted = Time.time - startTime;
        float percentageComplete = timeSinceStarted / fadeDuration;

        spriteRenderer.color = Color.Lerp(startColor, endColor, percentageComplete);

        if (percentageComplete >= 1.0f)
        {
            enabled = false; // Stop the update loop when fade is complete
        }
    }
}
