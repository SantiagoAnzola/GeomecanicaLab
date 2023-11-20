using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RandomImage : MonoBehaviour
{
    public Image Mascota;

    public Sprite[] Sprites;

    private int x;
    // Start is called before the first frame update

    public void ChangeImageOnClick()
    {
        x = Random.Range(0, Sprites.Length); // Use Sprites.Length to determine the range
        Mascota.sprite = Sprites[x];
    }
}