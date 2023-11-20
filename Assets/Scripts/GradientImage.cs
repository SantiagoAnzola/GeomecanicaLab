using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradientImage : MonoBehaviour
{
    public Color color1 = Color.white;
    public Color color2 = Color.black;
    public float angle = 45f;

    private Material material;

    private void Start()
    {
        Image image = GetComponent<Image>();
        material = new Material(image.material);
        image.material = material;
    }

    private void Update()
    {
        // Update the material's properties based on the script variables
        material.SetColor("_Color1", color1);
        material.SetColor("_Color2", color2);
        material.SetFloat("_Angle", angle);
    }
}
