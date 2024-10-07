using UnityEngine;
using UnityEngine.UI;

public class CreditsRoll : MonoBehaviour
{
    public RectTransform creditsText;  // The RectTransform of the credits text
    public float scrollSpeed = 50f;    // Speed at which the credits scroll

    private Vector2 startPosition;

    void Start()
    {
        // Store the initial position of the credits text
        startPosition = creditsText.anchoredPosition;
    }

    void Update()
    {
        // Move the text upwards over time
        creditsText.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);

        // Optionally, reset the credits once they reach the top or stop them
        if (creditsText.anchoredPosition.y > startPosition.y + 1000f) // Adjust the value based on your setup
        {
            // Stop the credits, reset, or fade out
        }
    }
}