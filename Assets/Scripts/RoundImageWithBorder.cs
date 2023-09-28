using UnityEngine;
using UnityEngine.UI;

public class RoundImageWithBorder : MonoBehaviour
{
    public Image image; // Reference to the Image component displaying the image.
    public Vector4 cornerRadii = new Vector4(20f, 20f, 20f, 20f); // The radii for each corner separately.
    public bool showBorder = false; // Whether to display the border.
    public float borderWidth = 2f; // The width of the border.

    private void Start()
    {
        // Initialize the image properties.
        if (image == null)
        {
            image = GetComponent<Image>();
        }

        // Apply rounded corners to the image.
        RoundCorners();

        // Optionally, apply a border to the image.
        if (showBorder)
        {
            ApplyBorder();
        }
    }

    private void RoundCorners()
    {
        if (image == null) return;

        // Create a mask to round the corners.
        RectTransform rectTransform = image.rectTransform;
        Vector2 size = rectTransform.sizeDelta;

        if (image.material == null)
        {
            Debug.LogError("Image material is not set. Make sure the image has a material using the correct shader.");
            return;
        }

        image.material.SetVector("_RoundCorners", cornerRadii);
        image.material.SetFloat("_RoundCornerRadius", 0f);
        image.material.SetInt("_RoundCornersClip", 1);

        Debug.Log("Rounded corners applied.");
    }

    private void ApplyBorder()
    {
        if (image == null) return;

        // Add an outline effect to create a border.
        Outline outline = image.gameObject.GetComponent<Outline>();
        if (outline == null)
        {
            outline = image.gameObject.AddComponent<Outline>();
        }

        outline.effectColor = Color.black; // Change the border color as needed.
        outline.effectDistance = new Vector2(borderWidth, borderWidth);

        Debug.Log("Border applied.");
    }
}
